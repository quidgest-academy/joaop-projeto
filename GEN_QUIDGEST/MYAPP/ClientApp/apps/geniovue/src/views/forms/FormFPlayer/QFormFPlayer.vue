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
			data-key="F_PLAYER"
			:data-loading="!formInitialDataLoaded">
			<template v-if="formControl.initialized && showFormBody">
				<q-row-container v-show="controls.F_PLAYERPLAYRUNDCTC__.isVisible">
					<q-control-wrapper
						v-show="controls.F_PLAYERPLAYRUNDCTC__.isVisible"
						class="control-join-group">
						<base-input-structure
							class="i-text"
							v-bind="controls.F_PLAYERPLAYRUNDCTC__"
							v-on="controls.F_PLAYERPLAYRUNDCTC__.handlers"
							:loading="controls.F_PLAYERPLAYRUNDCTC__.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-toggle-input
								v-if="controls.F_PLAYERPLAYRUNDCTC__.isVisible"
								v-bind="controls.F_PLAYERPLAYRUNDCTC__.props"
								v-on="controls.F_PLAYERPLAYRUNDCTC__.handlers" />
						</base-input-structure>
					</q-control-wrapper>
				</q-row-container>
				<q-row-container
					v-show="controls.F_PLAYERPSEUDNEWGRP01.isVisible || controls.F_PLAYERPSEUDAGTINFO_.isVisible"
					is-large>
					<q-control-wrapper
						v-show="controls.F_PLAYERPSEUDNEWGRP01.isVisible"
						class="row-line-group">
						<q-group-box-container
							id="F_PLAYERPSEUDNEWGRP01"
							v-bind="controls.F_PLAYERPSEUDNEWGRP01"
							:is-visible="controls.F_PLAYERPSEUDNEWGRP01.isVisible">
							<!-- Start F_PLAYERPSEUDNEWGRP01 -->
							<q-row-container v-show="controls.F_PLAYERPLAYRGENDER__.isVisible">
								<q-control-wrapper
									v-show="controls.F_PLAYERPLAYRGENDER__.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.F_PLAYERPLAYRGENDER__"
										v-on="controls.F_PLAYERPLAYRGENDER__.handlers"
										:loading="controls.F_PLAYERPLAYRGENDER__.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.F_PLAYERPLAYRGENDER__.isVisible"
											v-bind="controls.F_PLAYERPLAYRGENDER__.props"
											@update:model-value="model.ValGender.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.F_PLAYERPLAYRNAME____.isVisible">
								<q-control-wrapper
									v-show="controls.F_PLAYERPLAYRNAME____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.F_PLAYERPLAYRNAME____"
										v-on="controls.F_PLAYERPLAYRNAME____.handlers"
										:loading="controls.F_PLAYERPLAYRNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.F_PLAYERPLAYRNAME____.props"
											@blur="onBlur(controls.F_PLAYERPLAYRNAME____, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.F_PLAYERPLAYRPOSIC___.isVisible">
								<q-control-wrapper
									v-show="controls.F_PLAYERPLAYRPOSIC___.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.F_PLAYERPLAYRPOSIC___"
										v-on="controls.F_PLAYERPLAYRPOSIC___.handlers"
										:loading="controls.F_PLAYERPLAYRPOSIC___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.F_PLAYERPLAYRPOSIC___.props"
											@blur="onBlur(controls.F_PLAYERPLAYRPOSIC___, model.ValPosic.value)"
											@change="model.ValPosic.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.F_PLAYERPLAYRBIRTHDAT.isVisible || controls.F_PLAYERPLAYRAGE_____.isVisible">
								<q-control-wrapper
									v-show="controls.F_PLAYERPLAYRBIRTHDAT.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.F_PLAYERPLAYRBIRTHDAT"
										v-on="controls.F_PLAYERPLAYRBIRTHDAT.handlers"
										:loading="controls.F_PLAYERPLAYRBIRTHDAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.F_PLAYERPLAYRBIRTHDAT.isVisible"
											v-bind="controls.F_PLAYERPLAYRBIRTHDAT.props"
											:model-value="model.ValBirthdat.value"
											@reset-icon-click="model.ValBirthdat.fnUpdateValue(model.ValBirthdat.originalValue ?? new Date())"
											@update:model-value="model.ValBirthdat.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-control-wrapper>
								<q-control-wrapper
									v-show="controls.F_PLAYERPLAYRAGE_____.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.F_PLAYERPLAYRAGE_____"
										v-on="controls.F_PLAYERPLAYRAGE_____.handlers"
										:loading="controls.F_PLAYERPLAYRAGE_____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.F_PLAYERPLAYRAGE_____.isVisible"
											v-bind="controls.F_PLAYERPLAYRAGE_____.props"
											@update:model-value="model.ValAge.fnUpdateValue" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<q-row-container v-show="controls.F_PLAYERPLAYRCOUNTRY_.isVisible">
								<q-control-wrapper
									v-show="controls.F_PLAYERPLAYRCOUNTRY_.isVisible"
									class="control-join-group">
									<base-input-structure
										class="i-text"
										v-bind="controls.F_PLAYERPLAYRCOUNTRY_"
										v-on="controls.F_PLAYERPLAYRCOUNTRY_.handlers"
										:loading="controls.F_PLAYERPLAYRCOUNTRY_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.F_PLAYERPLAYRCOUNTRY_.props"
											@blur="onBlur(controls.F_PLAYERPLAYRCOUNTRY_, model.ValCountry.value)"
											@change="model.ValCountry.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-control-wrapper>
							</q-row-container>
							<!-- End F_PLAYERPSEUDNEWGRP01 -->
						</q-group-box-container>
					</q-control-wrapper>
					<q-control-wrapper
						v-show="controls.F_PLAYERPSEUDAGTINFO_.isVisible"
						class="control-join-group">
						<q-table
							v-show="controls.F_PLAYERPSEUDAGTINFO_.isVisible"
							v-bind="controls.F_PLAYERPSEUDAGTINFO_"
							v-on="controls.F_PLAYERPSEUDAGTINFO_.handlers" />
						<q-table-extra-extension
							:list-ctrl="controls.F_PLAYERPSEUDAGTINFO_"
							v-on="controls.F_PLAYERPSEUDAGTINFO_.handlers" />
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

	import FormViewModel from './QFormFPlayerViewModel.js'

	const requiredTextResources = ['QFormFPlayer', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FORM_INCLUDEJS F_PLAYER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFPlayer',

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
					name: 'F_PLAYER',
					location: 'form-F_PLAYER',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFPlayer', false),

				interfaceMetadata: {
					id: 'QFormFPlayer', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'F_PLAYER',
					route: 'form-F_PLAYER',
					area: 'PLAYR',
					primaryKey: 'ValCodplayr',
					designation: computed(() => this.Resources.PLAYER57424),
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
					F_PLAYERPLAYRUNDCTC__: new fieldControlClass.ArrayBooleanControl({
						modelField: 'ValUndctc',
						valueChangeEvent: 'fieldChange:playr.undctc',
						id: 'F_PLAYERPLAYRUNDCTC__',
						name: 'UNDCTC',
						size: 'mini',
						label: computed(() => this.Resources.UNDER_CONTRACT_12632),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'UnderContract',
						trueLabel: computed(() => this.Resources.YES34196),
						falseLabel: computed(() => this.Resources.NO57340),
						controlLimits: [
						],
					}, this),
					F_PLAYERPSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'F_PLAYERPSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.PLAYER_DETAILS02042),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['F_PLAYERPLAYRGENDER__', 'F_PLAYERPLAYRNAME____', 'F_PLAYERPLAYRPOSIC___', 'F_PLAYERPLAYRBIRTHDAT', 'F_PLAYERPLAYRAGE_____', 'F_PLAYERPLAYRCOUNTRY_'],
						controlLimits: [
						],
					}, this),
					F_PLAYERPLAYRGENDER__: new fieldControlClass.ArrayStringControl({
						modelField: 'ValGender',
						valueChangeEvent: 'fieldChange:playr.gender',
						id: 'F_PLAYERPLAYRGENDER__',
						name: 'GENDER',
						size: 'mini',
						label: computed(() => this.Resources.GENDER44172),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PLAYERPSEUDNEWGRP01',
						maxLength: 1,
						labelId: 'label_F_PLAYERPLAYRGENDER__',
						arrayName: 'Gender',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					F_PLAYERPLAYRNAME____: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:playr.name',
						id: 'F_PLAYERPLAYRNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NAME_OF_THE_PLAYER61428),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PLAYERPSEUDNEWGRP01',
						maxLength: 85,
						labelId: 'label_F_PLAYERPLAYRNAME____',
						controlLimits: [
						],
					}, this),
					F_PLAYERPLAYRPOSIC___: new fieldControlClass.StringControl({
						modelField: 'ValPosic',
						valueChangeEvent: 'fieldChange:playr.posic',
						id: 'F_PLAYERPLAYRPOSIC___',
						name: 'POSIC',
						size: 'xxlarge',
						label: computed(() => this.Resources.POSITION54869),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PLAYERPSEUDNEWGRP01',
						maxLength: 50,
						labelId: 'label_F_PLAYERPLAYRPOSIC___',
						controlLimits: [
						],
					}, this),
					F_PLAYERPLAYRBIRTHDAT: new fieldControlClass.DateControl({
						modelField: 'ValBirthdat',
						valueChangeEvent: 'fieldChange:playr.birthdat',
						id: 'F_PLAYERPLAYRBIRTHDAT',
						name: 'BIRTHDAT',
						size: 'small',
						label: computed(() => this.Resources.BIRTHDATE22743),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PLAYERPSEUDNEWGRP01',
						format: 'date',
						controlLimits: [
						],
					}, this),
					F_PLAYERPLAYRAGE_____: new fieldControlClass.NumberControl({
						modelField: 'ValAge',
						valueChangeEvent: 'fieldChange:playr.age',
						id: 'F_PLAYERPLAYRAGE_____',
						name: 'AGE',
						size: 'medium',
						label: computed(() => this.Resources.PLAYER_S_AGE12664),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PLAYERPSEUDNEWGRP01',
						isFormulaBlocked: true,
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line no-unused-vars
							fnFormula(params)
							{
								// Formula: [PLAYR->BIRTHDAT]==1
								return this.ValBirthdat.value===1
							},
							dependencyEvents: ['fieldChange:playr.birthdat'],
							isServerRecalc: false,
						},
					}, this),
					F_PLAYERPLAYRCOUNTRY_: new fieldControlClass.StringControl({
						modelField: 'ValCountry',
						valueChangeEvent: 'fieldChange:playr.country',
						id: 'F_PLAYERPLAYRCOUNTRY_',
						name: 'COUNTRY',
						size: 'xxlarge',
						label: computed(() => this.Resources.COUNTRY64133),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PLAYERPSEUDNEWGRP01',
						maxLength: 50,
						labelId: 'label_F_PLAYERPLAYRCOUNTRY_',
						controlLimits: [
						],
					}, this),
					F_PLAYERPSEUDAGTINFO_: new fieldControlClass.TableListControl({
						id: 'F_PLAYERPSEUDAGTINFO_',
						name: 'AGTINFO',
						size: '',
						label: computed(() => this.Resources.AGENT_INFO01863),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PLAYR',
						action: 'F_player_ValAgtinfo',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'AGENT',
								field: 'NAME',
								label: computed(() => this.Resources.AGENT_S_NAME23140),
								dataLength: 85,
								scrollData: 85,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValPhone',
								area: 'AGENT',
								field: 'PHONE',
								label: computed(() => this.Resources.AGENT_S_PHONE23147),
								dataLength: 14,
								scrollData: 14,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValEmail',
								area: 'AGENT',
								field: 'EMAIL',
								label: computed(() => this.Resources.AGENT_S_EMAIL56414),
								dataLength: 50,
								scrollData: 50,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValPerc_com',
								area: 'AGENT',
								field: 'PERC_COM',
								label: computed(() => this.Resources.PERCENTAGE_OF_THE_CO01872),
								scrollData: 4,
								maxDigits: 1,
								decimalPlaces: 2,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValTotcomis',
								area: 'AGENT',
								field: 'TOTCOMIS',
								label: computed(() => this.Resources.TOTAL_EARN_THROUGH_C21845),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValAgtinfo',
							serverMode: true,
							pkColumn: 'ValCodagent',
							tableAlias: 'AGENT',
							tableNamePlural: computed(() => this.Resources.AGENTES60642),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.AGENT_INFO01863),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_AGENT',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_AGENT',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_AGENT',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_AGENT',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_AGENT',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__F_AGENT',
								name: '_F_AGENT',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'F_AGENT',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'F_AGENT': {
									fnKeySelector: (row) => row.Fields.ValCodagent,
									isPopup: false
								},
							},
							allowFileExport: true,
							defaultSearchColumnName: 'ValEmail',
							defaultSearchColumnNameOriginal: 'ValEmail',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-AGENT'],
						uuid: 'F_player_ValAgtinfo',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'playr'],
								dependencyEvents: ['fieldChange:playr.codplayr'],
								dependencyField: 'PLAYR.CODPLAYR',
								fnValueSelector: (model) => model.ValCodplayr.value
							},
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
					'F_PLAYERPSEUDNEWGRP01',
				]),

				tableFields: readonly([
					'F_PLAYERPSEUDAGTINFO_',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Playr: {
						get ValAge() { return vm.model.ValAge.value },
						set ValAge(value) { vm.model.ValAge.updateValue(value) },
						get ValBirthdat() { return vm.model.ValBirthdat.value },
						set ValBirthdat(value) { vm.model.ValBirthdat.updateValue(value) },
						get ValCodagent() { return vm.model.ValCodagent.value },
						set ValCodagent(value) { vm.model.ValCodagent.updateValue(value) },
						get ValCountry() { return vm.model.ValCountry.value },
						set ValCountry(value) { vm.model.ValCountry.updateValue(value) },
						get ValGender() { return vm.model.ValGender.value },
						set ValGender(value) { vm.model.ValGender.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPosic() { return vm.model.ValPosic.value },
						set ValPosic(value) { vm.model.ValPosic.updateValue(value) },
						get ValUndctc() { return vm.model.ValUndctc.value },
						set ValUndctc(value) { vm.model.ValUndctc.updateValue(value) },
					},
					keys: {
						/** The primary key of the PLAYR table */
						get playr() { return vm.model.ValCodplayr },
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
// USE /[MANUAL AJF FORM_CODEJS F_PLAYER]/
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
// USE /[MANUAL AJF BEFORE_LOAD_JS F_PLAYER]/
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
// USE /[MANUAL AJF FORM_LOADED_JS F_PLAYER]/
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
// USE /[MANUAL AJF BEFORE_APPLY_JS F_PLAYER]/
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
// USE /[MANUAL AJF AFTER_APPLY_JS F_PLAYER]/
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
// USE /[MANUAL AJF BEFORE_SAVE_JS F_PLAYER]/
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
// USE /[MANUAL AJF AFTER_SAVE_JS F_PLAYER]/
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
// USE /[MANUAL AJF BEFORE_DEL_JS F_PLAYER]/
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
// USE /[MANUAL AJF AFTER_DEL_JS F_PLAYER]/
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
// USE /[MANUAL AJF BEFORE_EXIT_JS F_PLAYER]/
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
// USE /[MANUAL AJF AFTER_EXIT_JS F_PLAYER]/
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
// USE /[MANUAL AJF DLGUPDT F_PLAYER]/
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
// USE /[MANUAL AJF CTRLBLR F_PLAYER]/
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
// USE /[MANUAL AJF CTRLUPD F_PLAYER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FUNCTIONS_JS F_PLAYER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
