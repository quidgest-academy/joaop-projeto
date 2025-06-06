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
			data-key="F_CNTRCT"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container
					v-show="controls.F_CNTRCTPSEUDNEWGRP03.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.F_CNTRCTPSEUDNEWGRP03.isVisible"
						class="row-line-group">
						<q-accordion
							v-if="controls.F_CNTRCTPSEUDNEWGRP03.isVisible"
							id="F_CNTRCTPSEUDNEWGRP03"
							v-bind="controls.F_CNTRCTPSEUDNEWGRP03">
							<!-- Start F_CNTRCTPSEUDNEWGRP03 -->
							<q-group-collapsible
								id="F_CNTRCTPSEUDNEWGRP01"
								v-bind="controls.F_CNTRCTPSEUDNEWGRP01"
								v-on="controls.F_CNTRCTPSEUDNEWGRP01.handlers">
								<!-- Start F_CNTRCTPSEUDNEWGRP01 -->
								<q-row-container v-show="controls.F_CNTRCTPLAYRNAME____.isVisible">
									<q-control-wrapper
										v-show="controls.F_CNTRCTPLAYRNAME____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTPLAYRNAME____"
											v-on="controls.F_CNTRCTPLAYRNAME____.handlers"
											:loading="controls.F_CNTRCTPLAYRNAME____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-lookup
												v-if="controls.F_CNTRCTPLAYRNAME____.isVisible"
												v-bind="controls.F_CNTRCTPLAYRNAME____.props"
												v-on="controls.F_CNTRCTPLAYRNAME____.handlers" />
											<q-see-more-f-cntrctplayrname
												v-if="controls.F_CNTRCTPLAYRNAME____.seeMoreIsVisible"
												v-bind="controls.F_CNTRCTPLAYRNAME____.seeMoreParams"
												v-on="controls.F_CNTRCTPLAYRNAME____.handlers" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.F_CNTRCTCLUB_NAME____.isVisible">
									<q-control-wrapper
										v-show="controls.F_CNTRCTCLUB_NAME____.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTCLUB_NAME____"
											v-on="controls.F_CNTRCTCLUB_NAME____.handlers"
											:loading="controls.F_CNTRCTCLUB_NAME____.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-lookup
												v-if="controls.F_CNTRCTCLUB_NAME____.isVisible"
												v-bind="controls.F_CNTRCTCLUB_NAME____.props"
												v-on="controls.F_CNTRCTCLUB_NAME____.handlers" />
											<q-see-more-f-cntrctclub-name
												v-if="controls.F_CNTRCTCLUB_NAME____.seeMoreIsVisible"
												v-bind="controls.F_CNTRCTCLUB_NAME____.seeMoreParams"
												v-on="controls.F_CNTRCTCLUB_NAME____.handlers" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.F_CNTRCTAGENTEMAIL___.isVisible">
									<q-control-wrapper
										v-show="controls.F_CNTRCTAGENTEMAIL___.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTAGENTEMAIL___"
											v-on="controls.F_CNTRCTAGENTEMAIL___.handlers"
											:loading="controls.F_CNTRCTAGENTEMAIL___.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-mask
												v-if="controls.F_CNTRCTAGENTEMAIL___.isVisible"
												v-bind="controls.F_CNTRCTAGENTEMAIL___"
												:model-value="model.AgentValEmail.value"
												@update:model-value="model.AgentValEmail.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End F_CNTRCTPSEUDNEWGRP01 -->
							</q-group-collapsible>
							<q-group-collapsible
								id="F_CNTRCTPSEUDNEWGRP02"
								v-bind="controls.F_CNTRCTPSEUDNEWGRP02"
								v-on="controls.F_CNTRCTPSEUDNEWGRP02.handlers">
								<!-- Start F_CNTRCTPSEUDNEWGRP02 -->
								<q-row-container v-show="controls.F_CNTRCTCONTRSTARTDAT.isVisible || controls.F_CNTRCTCONTRFINDATE_.isVisible || controls.F_CNTRCTCONTRCTRDURAT.isVisible">
									<q-control-wrapper
										v-show="controls.F_CNTRCTCONTRSTARTDAT.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTCONTRSTARTDAT"
											v-on="controls.F_CNTRCTCONTRSTARTDAT.handlers"
											:loading="controls.F_CNTRCTCONTRSTARTDAT.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-date-time-picker
												v-if="controls.F_CNTRCTCONTRSTARTDAT.isVisible"
												v-bind="controls.F_CNTRCTCONTRSTARTDAT.props"
												:model-value="model.ValStartdat.value"
												@reset-icon-click="model.ValStartdat.fnUpdateValue(model.ValStartdat.originalValue ?? new Date())"
												@update:model-value="model.ValStartdat.fnUpdateValue($event ?? '')" />
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.F_CNTRCTCONTRFINDATE_.isVisible || controls.F_CNTRCTCONTRCTRDURAT.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTCONTRFINDATE_"
											v-on="controls.F_CNTRCTCONTRFINDATE_.handlers"
											:loading="controls.F_CNTRCTCONTRFINDATE_.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-date-time-picker
												v-if="controls.F_CNTRCTCONTRFINDATE_.isVisible"
												v-bind="controls.F_CNTRCTCONTRFINDATE_.props"
												:model-value="model.ValFindate.value"
												@reset-icon-click="model.ValFindate.fnUpdateValue(model.ValFindate.originalValue ?? new Date())"
												@update:model-value="model.ValFindate.fnUpdateValue($event ?? '')" />
										</base-input-structure>
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTCONTRCTRDURAT"
											v-on="controls.F_CNTRCTCONTRCTRDURAT.handlers"
											:loading="controls.F_CNTRCTCONTRCTRDURAT.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.F_CNTRCTCONTRCTRDURAT.isVisible"
												v-bind="controls.F_CNTRCTCONTRCTRDURAT.props"
												@update:model-value="model.ValCtrdurat.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.F_CNTRCTCONTRSALARY__.isVisible || controls.F_CNTRCTCONTRSLRYYR__.isVisible">
									<q-control-wrapper
										v-show="controls.F_CNTRCTCONTRSALARY__.isVisible || controls.F_CNTRCTCONTRSLRYYR__.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTCONTRSALARY__"
											v-on="controls.F_CNTRCTCONTRSALARY__.handlers"
											:loading="controls.F_CNTRCTCONTRSALARY__.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.F_CNTRCTCONTRSALARY__.isVisible"
												v-bind="controls.F_CNTRCTCONTRSALARY__.props"
												@update:model-value="model.ValSalary.fnUpdateValue" />
										</base-input-structure>
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTCONTRSLRYYR__"
											v-on="controls.F_CNTRCTCONTRSLRYYR__.handlers"
											:loading="controls.F_CNTRCTCONTRSLRYYR__.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.F_CNTRCTCONTRSLRYYR__.isVisible"
												v-bind="controls.F_CNTRCTCONTRSLRYYR__.props"
												@update:model-value="model.ValSlryyr.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<q-row-container v-show="controls.F_CNTRCTCONTRTRANSVAL.isVisible || controls.F_CNTRCTCONTRCOMISEUR.isVisible">
									<q-control-wrapper
										v-show="controls.F_CNTRCTCONTRTRANSVAL.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTCONTRTRANSVAL"
											v-on="controls.F_CNTRCTCONTRTRANSVAL.handlers"
											:loading="controls.F_CNTRCTCONTRTRANSVAL.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.F_CNTRCTCONTRTRANSVAL.isVisible"
												v-bind="controls.F_CNTRCTCONTRTRANSVAL.props"
												@update:model-value="model.ValTransval.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
									<q-control-wrapper
										v-show="controls.F_CNTRCTCONTRCOMISEUR.isVisible"
										class="control-join-group">
										<base-input-structure
											class="i-text"
											v-bind="controls.F_CNTRCTCONTRCOMISEUR"
											v-on="controls.F_CNTRCTCONTRCOMISEUR.handlers"
											:loading="controls.F_CNTRCTCONTRCOMISEUR.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.F_CNTRCTCONTRCOMISEUR.isVisible"
												v-bind="controls.F_CNTRCTCONTRCOMISEUR.props"
												@update:model-value="model.ValComiseur.fnUpdateValue" />
										</base-input-structure>
									</q-control-wrapper>
								</q-row-container>
								<!-- End F_CNTRCTPSEUDNEWGRP02 -->
							</q-group-collapsible>
							<!-- End F_CNTRCTPSEUDNEWGRP03 -->
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

	import FormViewModel from './QFormFCntrctViewModel.js'

	const requiredTextResources = ['QFormFCntrct', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FORM_INCLUDEJS F_CNTRCT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFCntrct',

		components: {
			QSeeMoreFCntrctplayrname: defineAsyncComponent(() => import('@/views/forms/FormFCntrct/dbedits/FCntrctplayrnameSeeMore.vue')),
			QSeeMoreFCntrctclubName: defineAsyncComponent(() => import('@/views/forms/FormFCntrct/dbedits/FCntrctclubNameSeeMore.vue')),
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
					name: 'F_CNTRCT',
					location: 'form-F_CNTRCT',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFCntrct', false),

				interfaceMetadata: {
					id: 'QFormFCntrct', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'F_CNTRCT',
					route: 'form-F_CNTRCT',
					area: 'CONTR',
					primaryKey: 'ValCodcontr',
					designation: computed(() => this.Resources.CONTRACT36364),
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
					F_CNTRCTPSEUDNEWGRP03: new fieldControlClass.AccordionControl({
						id: 'F_CNTRCTPSEUDNEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.NEW_ZONE54096),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['F_CNTRCTPSEUDNEWGRP01', 'F_CNTRCTPSEUDNEWGRP02'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_CNTRCTPSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'F_CNTRCTPSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.IDENTIFICATION_DETAI53665),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP03',
						isCollapsible: true,
						anchored: false,
						directChildren: ['F_CNTRCTPLAYRNAME____', 'F_CNTRCTCLUB_NAME____', 'F_CNTRCTAGENTEMAIL___'],
						controlLimits: [
						],
					}, this),
					F_CNTRCTPLAYRNAME____: new fieldControlClass.LookupControl({
						modelField: 'TablePlayrName',
						valueChangeEvent: 'fieldChange:playr.name',
						id: 'F_CNTRCTPLAYRNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME_OF_THE_PLAYER61428),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodplayr',
							dependencyEvent: 'fieldChange:contr.codplayr'
						},
						dependentFields: () => ({
							set 'playr.codplayr'(value) { vm.model.ValCodplayr.updateValue(value) },
							set 'playr.name'(value) { vm.model.TablePlayrName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					F_CNTRCTCLUB_NAME____: new fieldControlClass.LookupControl({
						modelField: 'TableClubName',
						valueChangeEvent: 'fieldChange:club.name',
						id: 'F_CNTRCTCLUB_NAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.CLUB_S_NAME65517),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodclub',
							dependencyEvent: 'fieldChange:contr.codclub'
						},
						dependentFields: () => ({
							set 'club.codclub'(value) { vm.model.ValCodclub.updateValue(value) },
							set 'club.name'(value) { vm.model.TableClubName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					F_CNTRCTAGENTEMAIL___: new fieldControlClass.StringControl({
						modelField: 'AgentValEmail',
						valueChangeEvent: 'fieldChange:agent.email',
						dependentModelField: 'ValCodagent',
						dependentChangeEvent: 'fieldChange:contr.codagent',
						id: 'F_CNTRCTAGENTEMAIL___',
						name: 'EMAIL',
						size: 'xxlarge',
						label: computed(() => this.Resources.AGENT_S_EMAIL56414),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP01',
						maxLength: 50,
						labelId: 'label_F_CNTRCTAGENTEMAIL___',
						controlLimits: [
						],
					}, this),
					F_CNTRCTPSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'F_CNTRCTPSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.CONTRACT_DETAILS55576),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP03',
						isCollapsible: true,
						anchored: false,
						directChildren: ['F_CNTRCTCONTRSTARTDAT', 'F_CNTRCTCONTRFINDATE_', 'F_CNTRCTCONTRCTRDURAT', 'F_CNTRCTCONTRSALARY__', 'F_CNTRCTCONTRSLRYYR__', 'F_CNTRCTCONTRTRANSVAL', 'F_CNTRCTCONTRCOMISEUR'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_CNTRCTCONTRSTARTDAT: new fieldControlClass.DateControl({
						modelField: 'ValStartdat',
						valueChangeEvent: 'fieldChange:contr.startdat',
						id: 'F_CNTRCTCONTRSTARTDAT',
						name: 'STARTDAT',
						size: 'medium',
						label: computed(() => this.Resources.STARTING_DATE47975),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP02',
						format: 'date',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_CNTRCTCONTRFINDATE_: new fieldControlClass.DateControl({
						modelField: 'ValFindate',
						valueChangeEvent: 'fieldChange:contr.findate',
						id: 'F_CNTRCTCONTRFINDATE_',
						name: 'FINDATE',
						size: 'small',
						label: computed(() => this.Resources.FINISH_DATE41863),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP02',
						format: 'date',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_CNTRCTCONTRCTRDURAT: new fieldControlClass.NumberControl({
						modelField: 'ValCtrdurat',
						valueChangeEvent: 'fieldChange:contr.ctrdurat',
						id: 'F_CNTRCTCONTRCTRDURAT',
						name: 'CTRDURAT',
						size: 'medium',
						label: computed(() => this.Resources.CONTRACT_DURATION31225),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP02',
						isFormulaBlocked: true,
						maxIntegers: 2,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					F_CNTRCTCONTRSALARY__: new fieldControlClass.CurrencyControl({
						modelField: 'ValSalary',
						valueChangeEvent: 'fieldChange:contr.salary',
						id: 'F_CNTRCTCONTRSALARY__',
						name: 'SALARY',
						size: 'large',
						label: computed(() => this.Resources.SALARY_OF_THE_PLAYER18170),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP02',
						maxIntegers: 5,
						maxDecimals: 2,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_CNTRCTCONTRSLRYYR__: new fieldControlClass.CurrencyControl({
						modelField: 'ValSlryyr',
						valueChangeEvent: 'fieldChange:contr.slryyr',
						id: 'F_CNTRCTCONTRSLRYYR__',
						name: 'SLRYYR',
						size: 'medium',
						label: computed(() => this.Resources.YEARLY_SALARY01615),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP02',
						isFormulaBlocked: true,
						maxIntegers: 9,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					F_CNTRCTCONTRTRANSVAL: new fieldControlClass.CurrencyControl({
						modelField: 'ValTransval',
						valueChangeEvent: 'fieldChange:contr.transval',
						id: 'F_CNTRCTCONTRTRANSVAL',
						name: 'TRANSVAL',
						size: 'medium',
						label: computed(() => this.Resources.TRANSFER_VALUE12168),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP02',
						maxIntegers: 7,
						maxDecimals: 2,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_CNTRCTCONTRCOMISEUR: new fieldControlClass.CurrencyControl({
						modelField: 'ValComiseur',
						valueChangeEvent: 'fieldChange:contr.comiseur',
						id: 'F_CNTRCTCONTRCOMISEUR',
						name: 'COMISEUR',
						size: 'xxlarge',
						label: computed(() => this.Resources.MONETARY_VALUE_COMIS27197),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_CNTRCTPSEUDNEWGRP02',
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
					'F_CNTRCTPSEUDNEWGRP03',
					'F_CNTRCTPSEUDNEWGRP01',
					'F_CNTRCTPSEUDNEWGRP02',
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
						get ValEmail() { return vm.model.AgentValEmail.value },
						set ValEmail(value) { vm.model.AgentValEmail.updateValue(value) },
						get ValPerc_com() { return vm.model.AgentValPerc_com.value },
						set ValPerc_com(value) { vm.model.AgentValPerc_com.updateValue(value) },
					},
					Club: {
						get ValName() { return vm.model.TableClubName.value },
						set ValName(value) { vm.model.TableClubName.updateValue(value) },
					},
					Contr: {
						get ValCodagent() { return vm.model.ValCodagent.value },
						set ValCodagent(value) { vm.model.ValCodagent.updateValue(value) },
						get ValCodclub() { return vm.model.ValCodclub.value },
						set ValCodclub(value) { vm.model.ValCodclub.updateValue(value) },
						get ValCodplayr() { return vm.model.ValCodplayr.value },
						set ValCodplayr(value) { vm.model.ValCodplayr.updateValue(value) },
						get ValComiseur() { return vm.model.ValComiseur.value },
						set ValComiseur(value) { vm.model.ValComiseur.updateValue(value) },
						get ValCtrdurat() { return vm.model.ValCtrdurat.value },
						set ValCtrdurat(value) { vm.model.ValCtrdurat.updateValue(value) },
						get ValFindate() { return vm.model.ValFindate.value },
						set ValFindate(value) { vm.model.ValFindate.updateValue(value) },
						get ValSalary() { return vm.model.ValSalary.value },
						set ValSalary(value) { vm.model.ValSalary.updateValue(value) },
						get ValSlryyr() { return vm.model.ValSlryyr.value },
						set ValSlryyr(value) { vm.model.ValSlryyr.updateValue(value) },
						get ValStartdat() { return vm.model.ValStartdat.value },
						set ValStartdat(value) { vm.model.ValStartdat.updateValue(value) },
						get ValTransval() { return vm.model.ValTransval.value },
						set ValTransval(value) { vm.model.ValTransval.updateValue(value) },
					},
					Playr: {
						get ValName() { return vm.model.TablePlayrName.value },
						set ValName(value) { vm.model.TablePlayrName.updateValue(value) },
					},
					keys: {
						/** The primary key of the CONTR table */
						get contr() { return vm.model.ValCodcontr },
						/** The foreign key to the PLAYR table */
						get playr() { return vm.model.ValCodplayr },
						/** The foreign key to the CLUB table */
						get club() { return vm.model.ValCodclub },
						/** The foreign key to the AGENT table */
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
// USE /[MANUAL AJF FORM_CODEJS F_CNTRCT]/
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
// USE /[MANUAL AJF BEFORE_LOAD_JS F_CNTRCT]/
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
// USE /[MANUAL AJF FORM_LOADED_JS F_CNTRCT]/
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
// USE /[MANUAL AJF BEFORE_APPLY_JS F_CNTRCT]/
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
// USE /[MANUAL AJF AFTER_APPLY_JS F_CNTRCT]/
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
// USE /[MANUAL AJF BEFORE_SAVE_JS F_CNTRCT]/
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
// USE /[MANUAL AJF AFTER_SAVE_JS F_CNTRCT]/
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
// USE /[MANUAL AJF BEFORE_DEL_JS F_CNTRCT]/
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
// USE /[MANUAL AJF AFTER_DEL_JS F_CNTRCT]/
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
// USE /[MANUAL AJF BEFORE_EXIT_JS F_CNTRCT]/
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
// USE /[MANUAL AJF AFTER_EXIT_JS F_CNTRCT]/
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
// USE /[MANUAL AJF DLGUPDT F_CNTRCT]/
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
// USE /[MANUAL AJF CTRLBLR F_CNTRCT]/
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
// USE /[MANUAL AJF CTRLUPD F_CNTRCT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FUNCTIONS_JS F_CNTRCT]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
