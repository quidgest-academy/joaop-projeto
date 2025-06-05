<template>
	<q-table-config
		:table-ctrl="listCtrl"
		modal-id="config"
		v-bind="listCtrl.config"
		v-on="tableConfigHandlers"
		:signal="listCtrl.subSignals.config"
		:texts="listCtrl.texts" />

	<q-table-column-config
		v-if="isListVisible"
		modal-id="column-config"
		v-bind="listCtrl.config"
		v-on="tableColumnConfigHandlers"
		:signal="listCtrl.subSignals.columnConfig"
		:columns="listCtrl.columns"
		:default-search-column-name="listCtrl.config.defaultSearchColumnName"
		:texts="listCtrl.texts" />

	<q-table-advanced-filters
		v-if="listCtrl.config.allowAdvancedFilters"
		modal-id="advanced-filters"
		v-bind="listCtrl.config"
		v-on="tableAdvancedFilters"
		:signal="listCtrl.subSignals.advancedFilters"
		:table-name="listCtrl.config.name"
		:columns="listCtrl.columns"
		:filters="listCtrl.advancedFilters"
		mode="editAll"
		:texts="listCtrl.texts"
		:locale="listCtrl.locale"
		:filter-operators="filterOperators" />

	<q-table-advanced-filters
		v-if="listCtrl.config.allowAdvancedFilters"
		modal-id="advanced-filters-new"
		v-bind="listCtrl.config"
		v-on="tableAdvancedFilters"
		:signal="listCtrl.subSignals.advancedFiltersNew"
		:table-name="listCtrl.config.name"
		:columns="listCtrl.columns"
		:filters="listCtrl.advancedFilters"
		mode="new"
		:texts="listCtrl.texts"
		:locale="listCtrl.locale"
		:filter-operators="filterOperators" />

	<q-table-view-save
		modal-id="view-save"
		v-bind="listCtrl.config"
		v-on="tableViewSaveHandlers"
		:signal="listCtrl.subSignals.viewSave"
		:config-names="listCtrl.config.userTableConfigNames"
		:texts="listCtrl.texts" />

	<q-table-views
		modal-id="views"
		v-bind="listCtrl.config"
		v-on="tableViewHandlers"
		:signal="listCtrl.subSignals.views"
		:config-names="listCtrl.config.userTableConfigNames"
		:config-name-default="listCtrl.config.userTableConfigNameDefault"
		:texts="listCtrl.texts" />
</template>

<script>
	import searchFilterDataModule from '@/api/genio/searchFilterData'

	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'

	import QTableConfig from './QTableConfig.vue'
	import QTableColumnConfig from './QTableColumnConfig.vue'
	import QTableAdvancedFilters from './QTableAdvancedFilters.vue'
	import QTableViewSave from './QTableViewSave.vue'
	import QTableViews from './QTableViews.vue'

	export default {
		name: 'QTableExtraExtension',

		emits: [
			'signal-component',
			'show-popup',
			'hide-popup',
			'set-property',
			'update-config',
			'set-info-message',
			'save-column-config',
			'apply-column-config',
			'reset-column-config',
			'reset-column-sizes',
			'reset-column-ordering',
			'toggle-text-wrap',
			'add-advanced-filter',
			'edit-advanced-filters',
			'set-advanced-filter-state',
			'remove-advanced-filter',
			'remove-column-filter',
			'save-view',
			'rename-view',
			'copy-view',
			'select-view',
			'view-action'
		],

		components: {
			QTableConfig,
			QTableColumnConfig,
			QTableAdvancedFilters,
			QTableViewSave,
			QTableViews
		},

		inheritAttrs: false,

		props: {
			/**
			 * Control object containing necessary state and configuration properties for a list-style view of the table component.
			 */
			listCtrl: {
				type: Object,
				required: true
			},

			/**
			 * A set of operator definitions used for creating and managing advanced filters in the table.
			 */
			filterOperators: {
				type: Object,
				default: () => searchFilterDataModule.operators.elements
			}
		},

		expose: [],

		data()
		{
			return {
				tableConfigHandlers: {
					showPopup: (eventData) => this.emitEvent('show-popup', eventData),
					hidePopup: (eventData) => this.emitEvent('hide-popup', eventData),
					signalComponent: (...args) => this.emitEventArgs('signal-component', ...args)
				},

				tableColumnConfigHandlers: {
					showPopup: (eventData) => this.emitEvent('show-popup', eventData),
					hidePopup: (eventData) =>
					{
						this.emitEvent('hide-popup', eventData)
						this.closeConfigPopup()
					},
					setProperty: (...args) => this.emitEventArgs('set-property', ...args),
					updateConfig: (...args) => this.$emit('update-config', ...args),
					applyColumnConfig: (eventData) =>
						this.emitEvent('apply-column-config', eventData),
					resetColumnConfig: (eventData) =>
						this.emitEvent('reset-column-config', eventData),
					resetColumnSizes: (eventData) =>
						this.emitEvent('reset-column-sizes', eventData),
					resetColumnOrdering: (eventData) =>
						this.emitEvent('reset-column-ordering', eventData),
					toggleTextWrap: (eventData) => this.emitEvent('toggle-text-wrap', eventData)
				},

				tableAdvancedFilters: {
					showPopup: (eventData) => this.emitEvent('show-popup', eventData),
					hidePopup: (eventData) =>
					{
						this.emitEvent('hide-popup', eventData)
						this.closeConfigPopup()
					},
					updateConfig: (...args) => this.$emit('update-config', ...args),
					addAdvancedFilter: (eventData) =>
						this.emitEvent('add-advanced-filter', eventData),
					editAdvancedFilters: (eventData) =>
						this.emitEvent('edit-advanced-filters', eventData),
					setAdvancedFilterState: (eventData) =>
						this.emitEvent('set-advanced-filter-state', eventData),
					removeAdvancedFilter: (eventData) =>
						this.emitEvent('remove-advanced-filter', eventData),
					removeAllAdvancedFilters: () =>
						this.emitEvent('remove-all-advanced-filters'),
					removeColumnFilter: (eventData) =>
						this.emitEvent('remove-column-filter', eventData),
				},

				tableViewSaveHandlers: {
					showPopup: (eventData) => this.emitEvent('show-popup', eventData),
					hidePopup: (eventData) =>
					{
						this.emitEvent('hide-popup', eventData)
						this.closeConfigPopup()
					},
					setProperty: (...args) => this.emitEventArgs('set-property', ...args),
					saveView: (eventData) => this.emitSaveViewEvent('save-view', eventData),
					renameView: (eventData) => this.$emit('rename-view', eventData),
					copyView: (eventData) => this.emitSaveViewEvent('copy-view', eventData)
				},

				tableViewHandlers: {
					showPopup: (eventData) => this.emitEvent('show-popup', eventData),
					hidePopup: (eventData) =>
					{
						this.emitEvent('hide-popup', eventData)
						this.closeConfigPopup()
					},
					selectView: (eventData) => this.emitEvent('select-view', eventData),
					viewAction: (eventData) => this.emitViewEvent('view-action', eventData)
				}
			}
		},

		computed: {
			isListVisible()
			{
				// FIXME: remove by implementing a view mode manager
				// QTable SHOULD ONLY IMPLEMENT TABLE LOGIC!!! => DOES NOT CARE ABOUT VIEWMODES
				return !this.listCtrl.viewModes?.length || this.listCtrl.activeViewModeId === 'LIST'
			}
		},

		methods: {
			emitEvent(eventName, eventData)
			{
				this.$emit(eventName, eventData)
			},

			emitEventArgs()
			{
				this.$emit(...arguments)
			},

			emitEventCallbackParams(callbackParams)
			{
				this.emitEvent(callbackParams.eventName, callbackParams.eventData)
			},

			saveViewOpenView(callbackParams)
			{
				this.$emit('save-view', {
					name: this.listCtrl.config.userTableConfigName,
					isSelected: false
				})
				this.emitEventCallbackParams(callbackParams)
			},

			emitViewEvent(eventName, eventData)
			{
				if (
					eventName === undefined || eventName === null || eventName === ''
					|| eventData?.name === undefined || eventData?.name === null || eventData?.name === ''
				)
					return

				switch(eventData?.name)
				{
					case 'SHOW':
						//Opening a view, confirm whether to save changes to current view
						if(this.listCtrl.confirmChanges && !this.listCtrl.readonly)
						{
							genericFunctions.displayMessage(
								`${this.listCtrl.texts.wantToSaveChangesToView}`,
								'warning',
								null,
								{
									confirm: {
										label: this.listCtrl.texts.saveText,
										action: this.saveViewOpenView
									},
									cancel: {
										label: this.listCtrl.texts.discard,
										action: this.emitEventCallbackParams
									}
								},
								{ callbackParams: { eventName: eventName, eventData: eventData } }
							)
						}
						else
							this.$emit(eventName, eventData)
						break
					case 'RENAME':
						this.$emit(
							'signal-component',
							'viewSave',
							{ mode: eventData?.name, renameFromName: eventData.rowValue },
							true
						)
						this.$emit('signal-component', 'config', { selectedTab: 'view-save' }, false)
						break
					case 'DUPLICATE':
						this.$emit(
							'signal-component',
							'viewSave',
							{ mode: eventData?.name, copyFromName: eventData.rowValue },
							true
						)
						this.$emit('signal-component', 'config', { selectedTab: 'view-save' }, false)
						break
					case 'DELETE':
						//Deleting a view, confirm
						genericFunctions.displayMessage(
							this.listCtrl.texts.wantToDelete,
							'warning',
							null,
							{
								confirm: {
									label: this.listCtrl.texts.deleteText,
									action: this.emitEventCallbackParams
								},
								cancel: {
									label: this.listCtrl.texts.cancelText,
									action: null
								}
							},
							{ callbackParams: { eventName: eventName, eventData: eventData } }
						)
						break
					default:
						this.$emit(eventName, eventData)
						break
				}
			},

			emitSaveViewEvent(eventName, eventData)
			{
				this.$emit(eventName, eventData)

				const alertProps = {
					type: 'success',
					message: this.listCtrl.texts.tableViewSaveSuccess,
					icon: 'ok',
					pinned: true
				}
				this.$emit('set-info-message', alertProps)
			},

			closeConfigPopup()
			{
				this.$emit('signal-component', 'config', { show: false })
			}
		}
	}
</script>
