﻿<template>
	<div
		:id="id"
		:class="['q-table-list', 'q-grid-table-list', { 'q-grid-table-list--readonly': $props.readonly }]"
		:data-loading="!loaded">
		<div class="page-header row no-gutters justify-content-between">
			<div class="col">
				<div class="c-action-bar">
					<div class="table-title c-table__title">
						<h1>{{ config.tableTitle }}</h1>
					</div>
				</div>
			</div>
		</div>

		<div class="table-responsive-wrapper text-nowrap">
			<div class="table-responsive">
				<table :class="tableClasses">
					<thead class="c-table__head">
						<tr>
							<th class="text-center thead-actions">
								<div class="column-header-content">
									<q-icon icon="tag" />
								</div>
							</th>

							<th class="text-center thead-actions">
								<div class="column-header-content">
									<q-icon icon="actions" />
								</div>
							</th>

							<template
								v-for="column in visibleColumns"
								:key="column.name">
								<th>
									<div class="column-header-content">
										{{ column.label }}
									</div>
								</th>
							</template>
						</tr>
					</thead>

					<tbody :class="['c-table__body', { 'c-table__body--loading': !loaded }]">
						<tr
							v-if="!loaded"
							class="c-table__row-loader">
							<td :colspan="numVisibleColumns">
								<span class="c-table__row--loading-text">
									{{ texts.loading }}
								</span>
								<q-line-loader />
							</td>
						</tr>

						<template
							v-for="model in viewModels"
							:key="model.uniqueIdentifier">
							<component
								:is="component"
								history-branch-id="main"
								is-nested
								:nested-model="model"
								:id="model.uniqueIdentifier"
								:mode="rowMode(model)"
								:initial-state="getRowInitialState(model)"
								:permissions="permissions"
								:columns="columns"
								:is-deleted-state="isRowDeletedState(model)"
								@update:nested-model="rowUpdated(model)"
								@mark-for-deletion="markForDeletion(model)"
								@toggle-errors="toggleErrors(model)"
								@undo-deletion="undoDeletion(model)" />

							<tr v-if="expandedErrors.includes(model.uniqueIdentifier) && hasMessages(model)">
								<td
									class="q-validation-summary-td"
									:colspan="numVisibleColumns">
									<template
										v-for="(type, index) in messageTypes"
										:key="index">
										<q-validation-summary
											v-if="getMessagesByType(type, model)"
											:messages="getMessagesByType(type, model)"
											:type="type" />
									</template>
								</td>
							</tr>
						</template>

						<tr
							v-if="readonly && loaded && viewModels.length === 0"
							class="c-table__row--empty">
							<td :colspan="numVisibleColumns">
								<slot name="empty-results">
									<img
										v-if="config.resourcesPath"
										:src="`${config.resourcesPath}empty_card_container.png`"
										:alt="texts.noRecordsText" />
									{{ texts.emptyText }}
								</slot>
							</td>
						</tr>
					</tbody>

					<tfoot v-if="hasColumnTotalizers">
						<tr
							class="q-grid-table-list__column-totalizers">
							<!-- Corresponding to checklist column -->
							<td>
								<span>
									{{ texts.total }}
								</span>
							</td>
							<!-- Corresponding to actions column -->
							<td />
							<td
								v-for="column in columnsWithTotalizers"
								:key="column.name">
								<q-input-group
									v-if="column.totalizer"
									size="block">
									<template
										v-if="column.dataType === 'Currency'"
										#prepend>
										<span>{{ column.currencySymbol }}</span>
									</template>
									<q-text-field
										class="q-grid-table-list__column-totalizers--field"
										:model-value="column.total"
										readonly>
									</q-text-field>
								</q-input-group>
							</td>
						</tr>
					</tfoot>
				</table>
			</div>
		</div>
	</div>
</template>

<script>
	import { getColumnTotalValueDisplay, isVisibleColumn } from '@/mixins/listFunctions'

	export default {
		name: 'QGridTableList',

		emits: ['row-updated', 'mark-for-deletion', 'undo-deletion'],

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * Component name used as a slot to render each row of data within the table.
			 */
			component: {
				type: String,
				required: true
			},

			/**
			 * Name of the control or feature being used.
			 */
			name: {
				type: String,
				default: ''
			},

			/**
			 * Data object containing elements related to the table rows, which includes existing elements, new elements, and removed ones.
			 */
			data: {
				type: Object,
				default: () => ({
					elements: [],
					newElements: [],
					removedElements: []
				})
			},

			/**
			 * Array containing column definitions.
			 */
			columns: {
				type: Array,
				required: true
			},

			/**
			 * Config object with settings such as table title and form name.
			 */
			config: {
				type: Object,
				default: () => ({
					tableTitle: undefined,
					formName: undefined
				})
			},

			/**
			 * Permissions object determining what actions a user can perform on rows within the table.
			 */
			permissions: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Flag indicating whether all content related to the control has been loaded.
			 */
			loaded: {
				type: Boolean,
				default: true
			},

			/**
			 * Localized texts used in the component for labels, alt texts, and other strings.
			 */
			texts: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Whether the table is readonly.
			 */
			readonly: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data()
		{
			return {
				expandedErrors: [],
				messageTypes: ['error', 'warning', 'info']
			}
		},

		computed: {
			/**
			 * Array of classes to be applied to the table element.
			 */
			tableClasses()
			{
				const classes = ['c-table', 'c-table--alternate']

				if (this.readonly)
					classes.push('c-table--view')

				return classes
			},

			/**
			 * Array containing all the viewable models for the rows in the table.
			 */
			viewModels()
			{
				const rows = []

				rows.push(...(this.data?.elements ?? []))
				rows.push(...(this.data?.newElements ?? []))

				return rows
			},

			/**
			 * Array containing only the columns that should be visible according to their visibility property.
			 */
			visibleColumns()
			{
				return this.columns.filter((column) => isVisibleColumn(column))
			},

			/**
			 * The total number of visible columns within the table, including extra columns for actions.
			 */
			numVisibleColumns()
			{
				return this.visibleColumns.length + 2
			},

			/**
			 * True if at least one column has totalizers enabled and rows in the table, false otherwise.
			 */
			hasColumnTotalizers()
			{
				return this.visibleColumns.some((column) => column.totalizer) && this.viewModels.length > 0
			},

			/**
			 * The object with the total values of the columns with totalizers enabled.
			 */
			columnsWithTotalizers()
			{
				return this.getTotalGridColumnValues()
			}
		},

		methods: {
			/**
			 * Emits an event to signal that a row has been updated.
			 * @param {Object} row - The row object that has been updated.
			 */
			rowUpdated(row)
			{
				this.$emit('row-updated', row)
			},

			/**
			 * Emits an event to signal that a row should be marked for deletion.
			 * @param {Object} row - The row object that should be marked for deletion.
			 */
			markForDeletion(row)
			{
				this.$emit('mark-for-deletion', row)
			},

			/**
			 * Emits an event to signal that the deletion of a row should be undone.
			 * @param {Object} row - The row object for which deletion should be undone.
			 */
			undoDeletion(row)
			{
				this.$emit('undo-deletion', row)
			},

			/**
			 * Retrieves the initial state of a given row.
			 * @param {Object} row - The row object for which the initial state is to be determined.
			 * @returns {String} The initial state of the row, or an empty string if it's not new.
			 */
			getRowInitialState(row)
			{
				return this.data.newElements.some((r) => r === row) ? 'NEW' : ''
			},

			/**
			 * Returns the display mode for a row based on whether it is blocked or contained in the RemovedElements.
			 * @param {Object} row - The row object.
			 * @returns {String} The mode of the row, either 'SHOW' or 'EDIT'.
			 */
			rowMode(row)
			{
				return this.readonly || this.data.removedElements.includes(row.QPrimaryKey)
					? 'SHOW'
					: 'EDIT'
			},

			/**
			 * Checks if the row is in delete mode.
			 * @param {Object} row - The row object
			 * @returns {Boolean} True if the row is in delete mode, false otherwise.
			 */
			isRowDeletedState(row)
			{
				return !this.readonly && this.data.removedElements.includes(row.QPrimaryKey)
			},

			/**
			 * Toggles the error messages of the specified model.
			 * @param {Object} model - The model
			 */
			toggleErrors(model)
			{
				const id = model.uniqueIdentifier

				if (this.expandedErrors.includes(id))
					this.expandedErrors = this.expandedErrors.filter((errors) => errors !== id)
				else
					this.expandedErrors.push(id)
			},

			/**
			 * Indicates if a model has any message to show.
			 * @param {Object} model - The model to check for messages
			 * @returns {Boolean} True if the model has any message to show, false otherwise.
			 */
			hasMessages(model)
			{
				return model.serverErrorMessages?.length > 0 ||
					model.serverWarningMessages?.length > 0 ||
					model.serverInfoMessages?.length > 0
			},

			/**
			 * Gets the list of messages to show based on a type provided.
			 * @param {String} type - The type of messages to show
			 * @param {Object} model - The model with the messages
			 * @returns {array} The list of messages to show based on the type provided.
			 */
			getMessagesByType(type, model)
			{
				if (type === 'warning')
					return model.serverWarningMessages
				if (type === 'info')
					return model.serverInfoMessages
				return model.serverErrorMessages
			},

			/**
			 * Returns the total values of every column that has totalizers enabled.
			 * @returns {Object} A hashmap of the total values for each column.
			 */
			getTotalGridColumnValues()
			{
				const columnsWithTotal = this.visibleColumns

				columnsWithTotal.forEach((column) => {
					if (!column.totalizer)
						return

					const columnTotal = this.viewModels.reduce((sum, viewModel) => {
						const viewModelField = Object.values(viewModel).find((field) => field.area === column.area && field.field === column.field)
						const numericValue = parseFloat(viewModelField.value) || 0
						return sum + numericValue
					}, 0)

					column.currency = undefined // Must be undefined, since the currency symbol is already presented in the input itself.
					column.total = getColumnTotalValueDisplay(column, columnTotal)
				})

				return columnsWithTotal
			}
		}
	}
</script>
