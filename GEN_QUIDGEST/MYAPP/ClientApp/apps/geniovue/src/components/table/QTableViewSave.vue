﻿<template>
	<teleport
		v-if="(showPopup || showInline) && showHeader"
		:to="`#q-modal-${modalId}-header`"
		:key="domKey">
		<h2
			class="c-modal__header-title"
			:id="`q-modal-${modalId}_title`">
			{{ texts.saveViewText }}
		</h2>
	</teleport>

	<teleport
		v-if="(showPopup || showInline) && showBody"
		:to="`#q-modal-${modalId}-body`"
		:key="domKey">
		<q-control-wrapper class="control-join-group view-save-form">
			<base-input-structure
				id="save-view-name"
				class="i-text"
				is-required
				:label="texts.viewNameText"
				:label-attrs="{ class: 'i-text__label' }">
				<q-text-field
					id="save-view-name"
					v-model="saveViewName"
					size="large"
					:max-length="50"
					:class="{ 'error': message }" />

				<div
					v-if="message"
					class="btn-popover error">
					<q-icon icon="exclamation-sign" />
					{{ message }}
				</div>
			</base-input-structure>

			<base-input-structure
				id="save-view-is-selected"
				class="i-checkbox"
				label-position="right"
				:label="texts.setDefaultViewText"
				:label-attrs="{ class: 'i-checkbox__label' }">
				<template #label>
					<q-checkbox-input
						id="save-view-is-selected"
						v-model="saveViewIsSelected" />
				</template>
				<div
					v-if="message"
					class="btn-popover invisible">
					<q-icon icon="exclamation-sign" />
					{{ message }}
				</div>
			</base-input-structure>
		</q-control-wrapper>
	</teleport>

	<teleport
		v-if="(showPopup || showInline) && showFooter"
		:to="`#q-modal-${modalId}-footer`"
		:key="domKey">
		<div class="actions float-right">
			<q-button
				variant="bold"
				:label="texts.saveText"
				:title="texts.saveText"
				@click="checkSaveOrCopyView">
				<q-icon icon="save" />
			</q-button>

			<q-button
				:label="texts.cancelText"
				:title="texts.cancelText"
				@click="fnHidePopup">
				<q-icon icon="cancel" />
			</q-button>
		</div>
	</teleport>
</template>

<script>
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'

	import QControlWrapper from '@/components/ControlWrapper.vue'
	import BaseInputStructure from '@/components/inputs/BaseInputStructure.vue'

	export default {
		name: 'QTableViewSave',

		emits: ['show-popup', 'hide-popup', 'set-property', 'save-view', 'rename-view', 'copy-view'],

		components: {
			QControlWrapper,
			BaseInputStructure
		},

		inheritAttrs: false,

		props: {
			/**
			 * An object containing signals to manage the internal state and actions of the popup component.
			 */
			signal: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Text labels and placeholders used within the component, aiding in localization.
			 */
			texts: {
				type: Object,
				required: true
			},

			/**
			 * Identifier for the associated modal that provides a namespace for related event handling.
			 */
			modalId: {
				type: String,
				required: true
			},

			/**
			 * Indicates if the operation should be handled through server-side logic.
			 */
			serverMode: {
				type: Boolean,
				default: false
			},

			/**
			 * A list of existing configuration or view names, used to check for duplicates when saving.
			 */
			configNames: {
				type: Array,
				default: () => []
			}
		},

		expose: [],

		data() {
			return {
				showPopup: false,
				showInline: false,
				showHeader: true,
				showBody: true,
				showFooter: true,
				domKey: 0,
				saveViewName: '',
				saveViewIsSelected: true,
				message: null,
			}
		},

		methods: {
			fnShowPopup() {
				this.$emit('show-popup', this.modalId)
				this.$nextTick().then(() => {
					this.showPopup = true
					this.domKey++
				})
			},

			fnHidePopup() {
				this.$emit('hide-popup', this.modalId)
			},

			/**
			 * Save current view or copy a view
			 * @returns Array
			 */
			saveOrCopyView() {
				if (this.signal.mode === 'DUPLICATE' && this.signal.copyFromName !== undefined && this.signal.copyFromName !== null) {
					this.$emit('copy-view', {
						name: this.saveViewName,
						isSelected: this.saveViewIsSelected,
						copyFromName: this.signal.copyFromName
					})
					this.fnHidePopup()
				}
				else if (this.signal.mode === 'RENAME' && this.signal.renameFromName !== undefined && this.signal.renameFromName !== null) {
					this.$emit('rename-view', {
						name: this.saveViewName,
						isSelected: this.saveViewIsSelected,
						renameFromName: this.signal.renameFromName
					})
					this.fnHidePopup()
				}
				else {
					this.$emit('save-view', {
						name: this.saveViewName,
						isSelected: this.saveViewIsSelected
					})
					this.fnHidePopup()
				}

				this.$emit('set-property', ['confirmChanges'], false)
			},

			/**
			 * Check before saving or copying a view
			 * @returns
			 */
			checkSaveOrCopyView() {
				const buttons = {
					confirm: {
						label: this.texts.saveText,
						action: this.saveOrCopyView
					},
					cancel: {
						label: this.texts.cancelText
					}
				}

				// If the name is empty prevent saving and show error message
				if (this.saveViewName === '')
				{
					this.message = `${this.texts.viewNameText} ${this.texts.isRequired}`
					return
				}

				// Check if view with this name already exists.
				let viewExists = false
				for (let idx in this.configNames) {
					let configName = this.configNames[idx]
					if (this.saveViewName === configName) {
						viewExists = true
						break
					}
				}

				// View with this name already exists.
				if (viewExists && !this.signal?.renameFromName) {
					genericFunctions.displayMessage(`${this.texts.viewExistsText} ${this.texts.wantToOverwriteText}`, 'warning', null, buttons)
				}
				// No view with this name already exists.
				else {
					this.saveOrCopyView()
				}
			}
		},

		watch: {
			signal: {
				handler(newValue) {
					for (let key in newValue) {
						switch (key) {
							case 'show':
								if (newValue.show) {
									this.fnShowPopup()
								}
								break
							default:
								if (['showInline', 'showHeader', 'showBody', 'showFooter'].includes(key)) {
									this[key] = newValue[key]
								}
								break
						}
					}
				},
				deep: true
			}
		}
	}
</script>
