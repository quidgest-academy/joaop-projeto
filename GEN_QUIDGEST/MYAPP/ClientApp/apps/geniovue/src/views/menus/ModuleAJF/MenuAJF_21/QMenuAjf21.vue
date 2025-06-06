<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-bind="controls.menu"
					v-on="controls.menu.handlers">
				</q-table>

				<q-table-extra-extension
					:list-ctrl="controls.menu"
					v-on="controls.menu.handlers" />
			</q-row-container>
		</form>
	</teleport>

	<teleport
		v-if="menuModalIsReady && hasButtons"
		:to="`#${uiContainersId.footer}`"
		:disabled="!menuInfo.isPopup">
		<q-row-container>
			<div id="footer-action-btns">
				<template
					v-for="btn in menuButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isVisible"
						:id="btn.id"
						:label="btn.text"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action">
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
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import netAPI from '@quidgest/clientapp/network'
	import openQSign from '@quidgest/clientapp/plugins/qSign'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import { computed, readonly } from 'vue'

	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import { loadResources } from '@/plugins/i18n.js'

	import hardcodedTexts from '@/hardcodedTexts'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable no-unused-vars */

	import MenuViewModel from './QMenuAJF_21ViewModel.js'

	const requiredTextResources = ['QMenuAJF_21', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FORM_INCLUDEJS AJF_MENU_21]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuAjf21',

		mixins: [
			MenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the menu is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'onBeforeRouteLeave',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuAJF_21', false),

				interfaceMetadata: {
					id: 'QMenuAJF_21', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '21',
					isMenuList: true,
					designation: computed(() => this.Resources.PLAYERS11892),
					acronym: 'AJF_21',
					name: 'PLAYR',
					route: 'menu-AJF_21',
					order: '21',
					controller: 'PLAYR',
					action: 'AJF_Menu_21',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'AJF_Menu_21',
						controller: 'PLAYR',
						action: 'AJF_Menu_21',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.NumericColumn({
								order: 1,
								name: 'ValAge',
								area: 'PLAYR',
								field: 'AGE',
								label: computed(() => this.Resources.PLAYER_S_AGE12664),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValPosic',
								area: 'PLAYR',
								field: 'POSIC',
								label: computed(() => this.Resources.POSITION54869),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValBirthdat',
								area: 'PLAYR',
								field: 'BIRTHDAT',
								label: computed(() => this.Resources.BIRTHDATE22743),
								scrollData: 8,
								dateTimeType: 'date',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 4,
								name: 'ValGender',
								area: 'PLAYR',
								field: 'GENDER',
								label: computed(() => this.Resources.GENDER44172),
								dataLength: 1,
								scrollData: 1,
								array: computed(() => qProjArrays.QArrayGender.setResources(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayGender.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValCountry',
								area: 'PLAYR',
								field: 'COUNTRY',
								label: computed(() => this.Resources.COUNTRY64133),
								dataLength: 50,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValName',
								area: 'PLAYR',
								field: 'NAME',
								label: computed(() => this.Resources.NAME_OF_THE_PLAYER61428),
								dataLength: 85,
								scrollData: 30,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Agent.ValEmail',
								area: 'AGENT',
								field: 'EMAIL',
								label: computed(() => this.Resources.AGENT_S_EMAIL56414),
								dataLength: 50,
								scrollData: 30,
								pkColumn: 'ValCodagent',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'AJF_Menu_21',
							serverMode: true,
							pkColumn: 'ValCodplayr',
							tableAlias: 'PLAYR',
							tableNamePlural: computed(() => this.Resources.PLAYERS11892),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PLAYERS11892),
							showRecordCount: true,
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
										formName: 'F_PLAYER',
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
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_PLAYER',
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
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_PLAYER',
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
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_PLAYER',
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
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_PLAYER',
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
								id: 'RCA_AJF_211',
								name: 'form-F_PLAYER',
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodplayr
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'F_PLAYER',
								}
							},
							formsDefinition: {
								'F_PLAYER': {
									fnKeySelector: (row) => row.Fields.ValCodplayr,
									isPopup: false
								},
							},
							allowFileExport: true,
							allowFileImport: true,
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: 'ValPosic',
								sortOrder: 'asc'
							}
						},
						groupFilters: [
							{
								id: 'filter_AJF_Menu_21_GENDER',
								isMultiple: false,
								filters: [
									{
										id: 'filter_AJF_Menu_21_GENDER_1',
										key: '1',
										value: computed(() => this.Resources.MALE32397),
										selected: false
									},
									{
										id: 'filter_AJF_Menu_21_GENDER_2',
										key: '2',
										value: computed(() => this.Resources.FEMININE01419),
										selected: false
									},
									{
										id: 'filter_AJF_Menu_21_GENDER_3',
										key: '3',
										value: computed(() => this.Resources.OTHER37293),
										selected: false
									},
								],
								value: '',
								defaultValue: ''
							},
						],
						globalEvents: ['changed-PLAYR', 'changed-CNTRY', 'changed-AGENT'],
						uuid: '2d3723f4-da2d-4f44-8217-12f42ba20e02',
						allSelectedRows: 'false',
						headerLevel: 1,
					}, this),
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		beforeRouteLeave(to, _, next)
		{
			this.onBeforeRouteLeave(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FORM_CODEJS AJF_MENU_21]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF FUNCTIONS_JS AJF_21]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL AJF LISTING_CODEJS AJF_MENU_21]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
