<template>
	<teleport
		v-if="formModalIsReady && showFormHeader"
		:to="`#${uiContainersId.header}`"
		:disabled="!isPopup || isNested">
		<div
			ref="formHeader"
			:class="{ 'c-sticky-header': isStickyHeader, 'sticky-top': isStickyTop }">
			<div
				v-if="showFormHeader"
				class="c-action-bar">
				<h1
					v-if="formControl.uiComponents.header && formInfo.designation"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-toggle-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-toggle-group-item
									v-if="showFormHeaderButton(btn)"
									:model-value="btn.isSelected"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									@click="btn.action">
									<q-icon
										v-if="btn.icon"
										v-bind="btn.icon" />
								</q-toggle-group-item>
							</template>
						</q-toggle-group>
					</template>
				</div>
			</div>

			<q-anchor-container-horizontal
				v-if="$app.layout.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
				:anchors="anchorGroups"
				:controls="visibleControls"
				@focus-control="(...args) => focusControl(...args)" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:messages="validationErrors"
			@error-clicked="focusField" />

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<div
			class="form-flow"
			data-key="F_AGENT"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.F_AGENT_PSEUDNEWGRP03.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.F_AGENT_PSEUDNEWGRP03.isVisible"
						class="row-line-group">
						<q-accordion
							v-if="controls.F_AGENT_PSEUDNEWGRP03.isVisible"
							id="F_AGENT_PSEUDNEWGRP03"
							v-bind="controls.F_AGENT_PSEUDNEWGRP03">
							<!-- Start F_AGENT_PSEUDNEWGRP03 -->
							<q-group-collapsible
								id="F_AGENT_PSEUDNEWGRP01"
								v-bind="controls.F_AGENT_PSEUDNEWGRP01"
								v-on="controls.F_AGENT_PSEUDNEWGRP01.handlers">
								<!-- Start F_AGENT_PSEUDNEWGRP01 -->
								<q-row-container v-show="controls.F_AGENT_AGENTPHOTO___.isVisible">
									<q-control-wrapper
										v-show="controls.F_AGENT_AGENTPHOTO___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="q-image"
											v-bind="controls.F_AGENT_AGENTPHOTO___"
											v-on="controls.F_AGENT_AGENTPHOTO___.handlers"
											:loading="controls.F_AGENT_AGENTPHOTO___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-image
												v-if="controls.F_AGENT_AGENTPHOTO___.isVisible"
												v-bind="controls.F_AGENT_AGENTPHOTO___.props"
												v-on="controls.F_AGENT_AGENTPHOTO___.handlers" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.F_AGENT_AGENTGENDER__.isVisible">
									<q-control-wrapper
										v-show="controls.F_AGENT_AGENTGENDER__.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_AGENT_AGENTGENDER__"
											v-on="controls.F_AGENT_AGENTGENDER__.handlers"
											:loading="controls.F_AGENT_AGENTGENDER__.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-select
												v-if="controls.F_AGENT_AGENTGENDER__.isVisible"
												v-bind="controls.F_AGENT_AGENTGENDER__.props"
												@update:model-value="model.ValGender.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.F_AGENT_AGENTNAME____.isVisible">
									<q-control-wrapper
										v-show="controls.F_AGENT_AGENTNAME____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_AGENT_AGENTNAME____"
											v-on="controls.F_AGENT_AGENTNAME____.handlers"
											:loading="controls.F_AGENT_AGENTNAME____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.F_AGENT_AGENTNAME____.props"
												@blur="onBlur(controls.F_AGENT_AGENTNAME____, model.ValName.value)"
												@change="model.ValName.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.F_AGENT_AGENTEMAIL___.isVisible">
									<q-control-wrapper
										v-show="controls.F_AGENT_AGENTEMAIL___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_AGENT_AGENTEMAIL___"
											v-on="controls.F_AGENT_AGENTEMAIL___.handlers"
											:loading="controls.F_AGENT_AGENTEMAIL___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-mask
												v-if="controls.F_AGENT_AGENTEMAIL___.isVisible"
												v-bind="controls.F_AGENT_AGENTEMAIL___"
												:model-value="model.ValEmail.value"
												@update:model-value="model.ValEmail.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.F_AGENT_AGENTPHONE___.isVisible">
									<q-control-wrapper
										v-show="controls.F_AGENT_AGENTPHONE___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_AGENT_AGENTPHONE___"
											v-on="controls.F_AGENT_AGENTPHONE___.handlers"
											:loading="controls.F_AGENT_AGENTPHONE___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-mask
												v-if="controls.F_AGENT_AGENTPHONE___.isVisible"
												v-bind="controls.F_AGENT_AGENTPHONE___"
												:model-value="model.ValPhone.value"
												@update:model-value="model.ValPhone.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End F_AGENT_PSEUDNEWGRP01 -->
							</q-group-collapsible>
							<q-group-collapsible
								id="F_AGENT_PSEUDNEWGRP02"
								v-bind="controls.F_AGENT_PSEUDNEWGRP02"
								v-on="controls.F_AGENT_PSEUDNEWGRP02.handlers">
								<!-- Start F_AGENT_PSEUDNEWGRP02 -->
								<q-row-container v-show="controls.F_AGENT_AGENTPERC_COM.isVisible || controls.F_AGENT_AGENTTOTCOMIS.isVisible">
									<q-control-wrapper
										v-show="controls.F_AGENT_AGENTPERC_COM.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_AGENT_AGENTPERC_COM"
											v-on="controls.F_AGENT_AGENTPERC_COM.handlers"
											:loading="controls.F_AGENT_AGENTPERC_COM.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.F_AGENT_AGENTPERC_COM.isVisible"
												v-bind="controls.F_AGENT_AGENTPERC_COM.props"
												@update:model-value="model.ValPerc_com.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.F_AGENT_AGENTTOTCOMIS.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_AGENT_AGENTTOTCOMIS"
											v-on="controls.F_AGENT_AGENTTOTCOMIS.handlers"
											:loading="controls.F_AGENT_AGENTTOTCOMIS.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.F_AGENT_AGENTTOTCOMIS.isVisible"
												v-bind="controls.F_AGENT_AGENTTOTCOMIS.props"
												@update:model-value="model.ValTotcomis.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End F_AGENT_PSEUDNEWGRP02 -->
							</q-group-collapsible>
							<!-- End F_AGENT_PSEUDNEWGRP03 -->
						</q-accordion>
					</q-control-wrapper>
				</q-row-container>
			</template>
		</div>
	</teleport>

	<hr v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row-container v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'
	import { useRoute } from 'vue-router'

	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@quidgest/clientapp/network'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable no-unused-vars */

	import FormViewModel from './QFormFAgentViewModel.js'

	const requiredTextResources = ['QFormFAgent', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FORM_INCLUDEJS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFAgent',

		components: {
		},

		mixins: [
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'F_AGENT',
					location: 'form-F_AGENT',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
			'cancel',
			'initFormProperties',
			'navigationId'
		],

		setup(props)
		{
			const route = useRoute()

			return {
				/*
				 * As properties are reactive, when using $route.params, then when we exit it updates cached components.
				 * Properties have no value and this creates an error in new versions of vue-router.
				 * That's why the value has to be copied to a local property to be used in the router-link tag.
				 */
				currentRouteParams: props.isNested ? {} : route.params
			}
		},

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFAgent', false),

				interfaceMetadata: {
					id: 'QFormFAgent', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'F_AGENT',
					route: 'form-F_AGENT',
					area: 'AGENT',
					primaryKey: 'ValCodagent',
					designation: computed(() => this.Resources.AGENTE44214),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: ''
				},

				formButtons: {
					changeToShow: {
						id: 'change-to-show-btn',
						icon: {
							icon: 'view',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.view]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.show === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToShowMode
					},
					changeToEdit: {
						id: 'change-to-edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.edit === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToEditMode
					},
					changeToDuplicate: {
						id: 'change-to-dup-btn',
						icon: {
							icon: 'duplicate',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.duplicate]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.duplicate === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.new !== vm.formInfo.mode),
						action: vm.changeToDupMode
					},
					changeToDelete: {
						id: 'change-to-delete-btn',
						icon: {
							icon: 'delete',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.delete === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToDeleteMode
					},
					changeToInsert: {
						id: 'change-to-insert-btn',
						icon: {
							icon: 'add',
							type: 'svg'
						},
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.new === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.duplicate !== vm.formInfo.mode),
						action: vm.changeToInsertMode
					},
					repeatInsertBtn: {
						id: 'repeat-insert-btn',
						icon: {
							icon: 'save-new',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.repeatInsert]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.GRAVAR45301),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.saveForm
					},
					confirmBtn: {
						id: 'confirm-btn',
						icon: {
							icon: 'check',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[vm.isNested ? hardcodedTexts.delete : hardcodedTexts.confirm]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && (vm.formInfo.mode === vm.formModes.delete || vm.isNested)),
						action: vm.deleteRecord
					},
					cancelBtn: {
						id: 'cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.CANCELAR49513),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.leaveForm
					},
					resetCancelBtn: {
						id: 'reset-cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.cancel]),
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: () => vm.model.resetValues(),
						emitAction: {
							name: 'deselect',
							params: {}
						}
					},
					editBtn: {
						id: 'edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && vm.parentFormMode !== vm.formModes.delete),
						action: () => {},
						emitAction: {
							name: 'edit',
							params: {}
						}
					},
					deleteQuickBtn: {
						id: 'delete-btn',
						icon: {
							icon: 'bin',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && (typeof vm.permissions.canDelete === 'boolean' ? vm.permissions.canDelete : true)),
						action: vm.deleteRecord
					},
					backBtn: {
						id: 'back-btn',
						icon: {
							icon: 'back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.isPopup ? vm.Resources[hardcodedTexts.close] : vm.Resources[hardcodedTexts.goBack]),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					F_AGENT_PSEUDNEWGRP03: new fieldControlClass.AccordionControl({
						id: 'F_AGENT_PSEUDNEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.NEW_ZONE54096),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['F_AGENT_PSEUDNEWGRP01', 'F_AGENT_PSEUDNEWGRP02'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_AGENT_PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'F_AGENT_PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.AGENT_S_INFO06079),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_AGENT_PSEUDNEWGRP03',
						isCollapsible: true,
						anchored: false,
						directChildren: ['F_AGENT_AGENTPHOTO___', 'F_AGENT_AGENTGENDER__', 'F_AGENT_AGENTNAME____', 'F_AGENT_AGENTEMAIL___', 'F_AGENT_AGENTPHONE___'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_AGENT_AGENTPHOTO___: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:agent.photo',
						id: 'F_AGENT_AGENTPHOTO___',
						name: 'PHOTO',
						size: 'mini',
						label: computed(() => this.Resources.PHOTO_S_AGENT28065),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_AGENT_PSEUDNEWGRP01',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO_S_AGENT28065)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					F_AGENT_AGENTGENDER__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValGender',
						valueChangeEvent: 'fieldChange:agent.gender',
						id: 'F_AGENT_AGENTGENDER__',
						name: 'GENDER',
						size: 'mini',
						label: computed(() => this.Resources.GENDER44172),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_AGENT_PSEUDNEWGRP01',
						maxLength: 1,
						labelId: 'label_F_AGENT_AGENTGENDER__',
						arrayName: 'Gender',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					F_AGENT_AGENTNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:agent.name',
						id: 'F_AGENT_AGENTNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.AGENT_S_NAME23140),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_AGENT_PSEUDNEWGRP01',
						maxLength: 85,
						labelId: 'label_F_AGENT_AGENTNAME____',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_AGENT_AGENTEMAIL___: new fieldControlClass.MaskControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:agent.email',
						id: 'F_AGENT_AGENTEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.AGENT_S_EMAIL56414),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_AGENT_PSEUDNEWGRP01',
						maxLength: 50,
						labelId: 'label_F_AGENT_AGENTEMAIL___',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_AGENT_AGENTPHONE___: new fieldControlClass.MaskControl({
						modelField: 'ValPhone',
						valueChangeEvent: 'fieldChange:agent.phone',
						id: 'F_AGENT_AGENTPHONE___',
						name: 'PHONE',
						size: 'xxlarge',
						label: computed(() => this.Resources.AGENT_S_PHONE23147),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_AGENT_PSEUDNEWGRP01',
						maxLength: 14,
						labelId: 'label_F_AGENT_AGENTPHONE___',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_AGENT_PSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'F_AGENT_PSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.COMISSION_DETAILS18026),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_AGENT_PSEUDNEWGRP03',
						isCollapsible: true,
						anchored: false,
						directChildren: ['F_AGENT_AGENTPERC_COM', 'F_AGENT_AGENTTOTCOMIS'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_AGENT_AGENTPERC_COM: new fieldControlClass.NumberControl({
						modelField: 'ValPerc_com',
						valueChangeEvent: 'fieldChange:agent.perc_com',
						id: 'F_AGENT_AGENTPERC_COM',
						name: 'PERC_COM',
						size: 'xlarge',
						label: computed(() => this.Resources.PERCENTAGE_OF_THE_CO01872),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_AGENT_PSEUDNEWGRP02',
						maxIntegers: 1,
						maxDecimals: 2,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_AGENT_AGENTTOTCOMIS: new fieldControlClass.CurrencyControl({
						modelField: 'ValTotcomis',
						valueChangeEvent: 'fieldChange:agent.totcomis',
						id: 'F_AGENT_AGENTTOTCOMIS',
						name: 'TOTCOMIS',
						size: 'xlarge',
						label: computed(() => this.Resources.TOTAL_EARN_THROUGH_C21845),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_AGENT_PSEUDNEWGRP02',
						isFormulaBlocked: true,
						maxIntegers: 7,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'F_AGENT_PSEUDNEWGRP03',
					'F_AGENT_PSEUDNEWGRP01',
					'F_AGENT_PSEUDNEWGRP02',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Agent: {
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValGender() { return vm.model.ValGender.value },
						set ValGender(value) { vm.model.ValGender.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPerc_com() { return vm.model.ValPerc_com.value },
						set ValPerc_com(value) { vm.model.ValPerc_com.updateValue(value) },
						get ValPhone() { return vm.model.ValPhone.value },
						set ValPhone(value) { vm.model.ValPhone.updateValue(value) },
						get ValPhoto() { return vm.model.ValPhoto.value },
						set ValPhoto(value) { vm.model.ValPhoto.updateValue(value) },
						get ValTotcomis() { return vm.model.ValTotcomis.value },
						set ValTotcomis(value) { vm.model.ValTotcomis.updateValue(value) },
					},
					keys: {
						/** The primary key of the AGENT table */
						get agent() { return vm.model.ValCodagent },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			next((vm) => {
				vm.initFormProperties(to)
			})
		},

		beforeRouteLeave(to, _, next)
		{
			if (to.params.isControlled === 'true')
			{
				genericFunctions.setNavigationState(false)
				next()
			}
			else
				this.cancel(next)
		},

		beforeRouteUpdate(to, _, next)
		{
			if (to.params.isControlled === 'true')
				next()
			else
				this.cancel(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FORM_CODEJS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				let loadForm = true

				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF BEFORE_LOAD_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return loadForm
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FORM_LOADED_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before an apply action is performed.
			 */
			async beforeApply()
			{
				let applyForm = true // Set to 'false' to cancel form apply.

				// Execute the "Before apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeApply)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const canSetDocums = await this.model.updateFilesTickets(true)

				if (canSetDocums)
				{
					applyForm = await this.model.setDocumentChanges()

					if (applyForm)
					{
						const results = await this.model.saveDocuments()
						applyForm = results.every((e) => e === true)
					}
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF BEFORE_APPLY_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return applyForm
			},

			/**
			 * Called after an apply action is performed.
			 */
			async afterApply()
			{
				// Execute the "After apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterApply)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF AFTER_APPLY_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before the record is saved.
			 */
			async beforeSave()
			{
				let saveForm = true // Set to 'false' to cancel form saving.

				// Execute the "Before save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const canSetDocums = await this.model.updateFilesTickets()

				if (canSetDocums)
				{
					saveForm = await this.model.setDocumentChanges()

					if (saveForm)
					{
						const results = await this.model.saveDocuments()
						saveForm = results.every((e) => e === true)
					}
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF BEFORE_SAVE_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return saveForm
			},

			/**
			 * Called after the record is saved.
			 */
			async afterSave()
			{
				let redirectPage = true // Set to 'false' to cancel page redirect.

				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF AFTER_SAVE_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return redirectPage
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				let deleteForm = true // Set to 'false' to cancel form delete.

				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF BEFORE_DEL_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return deleteForm
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				let redirectPage = true // Set to 'false' to cancel page redirect.

				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF AFTER_DEL_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return redirectPage
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				let leaveForm = true // Set to 'false' to cancel page redirect.

				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF BEFORE_EXIT_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return leaveForm
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (let trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF AFTER_EXIT_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called whenever a field's value is updated.
			 * @param {string} fieldName The name of the field in the format [table].[field] (ex: 'person.name')
			 * @param {object} fieldObject The object representing the field in the model
			 * @param {any} fieldValue The value of the field
			 * @param {any} oldFieldValue The previous value of the field
			 */
			// eslint-disable-next-line
			onUpdate(fieldName, fieldObject, fieldValue, oldFieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF DLGUPDT F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
			},

			/**
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF CTRLBLR F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUnfocus(fieldObject, fieldValue)
			},

			/**
			 * Called whenever a control's value is updated.
			 * @param {string} controlField The name of the field in the controls that will be updated
			 * @param {object} control The object representing the field in the controls
			 * @param {any} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onControlUpdate(controlField, control, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF CTRLUPD F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FUNCTIONS_JS F_AGENT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
