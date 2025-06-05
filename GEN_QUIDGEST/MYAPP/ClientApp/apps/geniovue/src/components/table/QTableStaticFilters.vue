<template>
	<!-- BEGIN: Static Filters -->
	<div
		:id="`${menuName}_filters`"
		class="filters-container">
		<!-- BEGIN: Active Filters -->
		<div
			v-if="hasActiveFilters"
			class="active-filter-box"
			:data-testid="`${menuName}_active_filters`">
			<!-- BEGIN: Checkbox options -->
			<label class="i-text__label">{{ texts.state }}:</label>

			<base-input-structure
				v-for="(filter, filterId) in activeFilters.options"
				:key="filterId"
				:id="filter.id"
				class="i-checkbox"
				:label="filter.value"
				label-position="right"
				:label-attrs="{ class: 'i-checkbox i-checkbox__label' }">
				<template #label>
					<q-checkbox-input
						:id="filter.id"
						:model-value="filter.selected"
						@update:model-value="updateActiveFilterSelected(filterId, $event)" />
				</template>
			</base-input-structure>
			<!-- END: Checkbox options -->

			<!-- BEGIN: Date -->
			<base-input-structure
				:id="dateValueFilter.id"
				:class="['i-text', 'i-flex', { 'i-text--disabled': false }]"
				:label="texts.onDate"
				label-position="left"
				:label-attrs="{ class: 'i-text__label' }">
				<q-date-time-picker
					:id="dateValueFilter.id"
					:model-value="dateValueFilter.value"
					:size="dateValueFilter.type === 'date' ? 'small' : 'medium'"
					:format="dateValueFilter.type"
					:locale="locale"
					@update:model-value="updateActiveFilterDateValue" />
			</base-input-structure>
			<!-- END: Date -->
		</div>
		<!-- END: Active Filters -->

		<!-- BEGIN: Group Filters -->
		<div
			v-for="(entry, groupIndex) in groupFilters"
			:key="groupIndex"
			class="static-filter-box"
			:data-testid="`${menuName}_group_filters`">
			<!-- BEGIN: Checkbox options -->
			<template v-if="groupFilterIsMultiple(entry)">
				<div
					class="form-check-inline"
					v-for="(filter, filterIndex) in entry.filters"
					:key="filterIndex">
					<base-input-structure
						:id="filter.id"
						class="i-checkbox"
						:label="filter.value"
						label-position="right"
						:label-attrs="{ class: 'i-checkbox i-checkbox__label' }"
						:user-help="filter.userHelp">
						<template #label>
							<q-checkbox-input
								:id="filter.id"
								:model-value="filter.selected"
								@update:model-value="updateGroupFilterSelected(groupIndex, filterIndex, $event)" />
						</template>
					</base-input-structure>
				</div>
			</template>
			<!-- END: Checkbox options -->
			<!-- BEGIN: Radio button options -->
			<q-radio-group
				v-else
				:model-value="entry.value"
				:options-list="entry.filters"
				:number-of-columns="entry.filters.length"
				@update:model-value="updateGroupFilterValue(groupIndex, $event)" />
			<!-- END: Radio button options -->
		</div>
		<!-- END: Group Filters -->
	</div>
	<!-- END: Static Filters -->
</template>

<script>
	export default {
		name: 'QTableStaticFilters',

		emits: {
			'update:activeFilters': (payload) => typeof payload === 'object',
			'update:groupFilters': (payload) => Array.isArray(payload)
		},

		inheritAttrs: false,

		props: {
			/**
			 * The unique name identifying this specific set of filters, typically associated with a table or view.
			 */
			menuName: {
				type: String,
				default: ''
			},

			/**
			 * An object representing active filters, which can be a mixture of various filter types including boolean or date.
			 */
			activeFilters: {
				type: Object,
				default: () => ({})
			},

			/**
			 * An array representing groups of filters that apply globally to the data set, affecting all columns.
			 */
			groupFilters: {
				type: Array,
				default: () => []
			},

			/**
			 * Localization or custom text strings that are used within the static filters interface, aiding in text consistency and localization.
			 */
			texts: {
				type: Object,
				default: () => ({})
			},

			/**
			 * Current system locale
			 */
			locale: {
				type: String,
				default: 'en-US'
			}
		},

		expose: [],

		computed: {
			/**
			 * The date filter.
			 */
			dateValueFilter()
			{
				return !this.hasActiveFilters ? { value: '' } : this.activeFilters.dateValue
			},

			/**
			 * True if there's an active filter, false otherwise.
			 */
			hasActiveFilters()
			{
				return Object.keys(this.activeFilters).length > 0
			}
		},

		methods: {
			/**
			 * Determine if multiple filters can be selected in group of filters.
			 * @param entry {Object}
			 * @returns Boolean
			 */
			groupFilterIsMultiple(entry)
			{
				return entry.isMultiple === true
			},

			/**
			 * Emit new active filters value.
			 * @param value {Object}
			 */
			emitActiveFilter(value)
			{
				this.$emit('update:activeFilters', value)
			},

			/**
			 * Emit new group filters value.
			 * @param value {Object}
			 */
			emitGroupFilter(value)
			{
				this.calcGroupFilterValues(value)
				this.$emit('update:groupFilters', value)
			},

			/**
			 * Update active filters.
			 * @param filterId {String}
			 * @param value {Boolean}
			 */
			updateActiveFilterSelected(filterId, value)
			{
				const options = { ...this.activeFilters.options }
				options[filterId].selected = value

				const activeFilters = {
					...this.activeFilters,
					options
				}

				this.emitActiveFilter(activeFilters)
			},

			/**
			 * Update active filters.
			 * @param value {Object}
			 */
			updateActiveFilterDateValue(value)
			{
				const dateValue = { ...this.activeFilters.dateValue }
				dateValue.value = value

				const activeFilters = {
					...this.activeFilters,
					dateValue
				}

				this.emitActiveFilter(activeFilters)
			},

			/**
			 * Update group filters.
			 * @param groupIndex {Int}
			 * @param filterIndex {Int}
			 * @param value {Object}
			 */
			updateGroupFilterSelected(groupIndex, filterIndex, value)
			{
				const filters = [...this.groupFilters[groupIndex].filters]
				filters[filterIndex] = {
					...filters[filterIndex],
					selected: value
				}

				const groupFilters = [...this.groupFilters]
				groupFilters[groupIndex] = {
					...groupFilters[groupIndex],
					filters
				}

				this.emitGroupFilter(groupFilters)
			},

			/**
			 * Update group filters.
			 * @param groupIndex {Int}
			 * @param value {Object}
			 */
			updateGroupFilterValue(groupIndex, value)
			{
				const groupFilters = [...this.groupFilters]
				groupFilters[groupIndex] = {
					...groupFilters[groupIndex],
					value
				}

				this.emitGroupFilter(groupFilters)
			},

			/**
			 * Get value for all radio button groups based on filter model.
			 * @param groupFilters {Object}
			 */
			calcGroupFilterValues(groupFilters)
			{
				for (let entry of groupFilters)
				{
					if (entry.isMultiple === true && typeof entry.value === 'string')
						entry.value = this.checkboxValue(entry)
				}
			},

			/**
			 * Get value for radio button group based on filter model.
			 * @param entry {Object}
			 * @returns String
			 */
			checkboxValue(entry)
			{
				if (!entry.isMultiple)
					return ''

				let multipleFilterValue = ''

				for (let filter of entry.filters)
				{
					if (filter.selected !== false)
						multipleFilterValue += filter.key
				}

				return multipleFilterValue
			}
		}
	}
</script>
