﻿<template>
	<nav
		v-if="hasMultiplePages"
		aria-label="Page navigation">
		<q-button-group>
			<!-- BEGIN: Page navigation buttons -->
			<!-- BEGIN: First page button -->
			<q-button
				:aria-label="texts.first"
				:disabled="!beginButtonActive"
				@click="beginButtonAction">
				<q-icon icon="page-first" />
			</q-button>
			<!-- END: First page button -->
			<!-- BEGIN: Previous page button -->
			<q-button
				:aria-label="texts.previous"
				:disabled="!prevButtonActive"
				@click="prevButtonAction">
				<q-icon icon="page-previous" />
			</q-button>
			<!-- END: Previous page button -->
			<!-- BEGIN: Visible page number buttons -->
			<template v-if="hasMorePages || page > 1">
				<span
					class="e-pagination__info"
					style="white-space: nowrap">
					<span>{{ page }} / </span>
					<span v-if="hasMorePages">...</span>
					<span v-else>{{ page }}</span>
				</span>
			</template>
			<!-- END: Visible page number buttons -->
			<!-- BEGIN: Next page button -->
			<q-button
				:aria-label="texts.next"
				:disabled="!nextButtonActive"
				@click="nextButtonAction">
				<q-icon icon="page-next" />
			</q-button>
			<!-- END: Next page button -->
			<!-- END: Page navigation buttons -->
		</q-button-group>
	</nav>
	<!-- BEGIN: Number of rows per page -->
	<div
		v-if="showPerPageMenu && hasMultiplePages"
		class="rows-per-page-menu">
		<span class="i-text__label">{{ texts.rowsPerPage + ':' }}</span>
		<q-dropdown-menu
			:id="tableId + '-rowspp-menu'"
			:texts="{ title: perPageLabel, label: perPageLabel }"
			:options="perPageOptionsObj"
			class="pagination-dropdown"
			:button-classes="['dropdown-toggle']"
			:button-options="{ borderless: true }"
			:single-option-button="false"
			:disabled="disabled"
			@selected="perPageHandler($event)">
		</q-dropdown-menu>
	</div>
	<!-- END: Number of rows per page -->
</template>

<script>
	import { defineAsyncComponent } from 'vue'

	import listFunctions from '@/mixins/listFunctions.js'

	export default {
		name: 'QTablePaginationAlt',

		emits: ['update:page', 'update:perPage'],

		components: {
			QDropdownMenu: defineAsyncComponent(() => import('@/components/QDropdownMenu.vue'))
		},

		props: {
			/**
			 * The current page number for which items are displayed in the table.
			 */
			page: {
				type: [String, Number],
				required: true
			},

			/**
			 * The number of items to display on each page of the table.
			 */
			perPage: {
				type: [String, Number],
				required: true
			},

			/**
			 * The total number of items across all pages of the table.
			 */
			total: {
				type: [String, Number],
				required: true
			},

			/**
			 * Options for the number of items to display per page, presented as a drop-down menu to the user.
			 */
			perPageOptions: {
				type: Array,
				default: () => []
			},

			/**
			 * A flag indicating whether the drop-down menu for selecting the number of items per page should be visible.
			 */
			showPerPageMenu: {
				type: Boolean,
				default: false
			},

			/**
			 * Indicates whether there are more pages available beyond the current page number.
			 */
			hasMorePages: {
				type: Boolean,
				default: false
			},

			/**
			 * Text for the drop-down option currently selected for number of items per page.
			 */
			perPageLabel: {
				type: String,
				default: ''
			},

			/**
			 * An object containing localized strings for display within the pagination component.
			 */
			texts: {
				type: Object,
				required: true
			},

			/**
			 * Whether the pagination is disabled.
			 */
			disabled: {
				type: Boolean,
				default: false
			},

			/**
			 * The table ID.
			 */
			tableId: {
				type: String,
				default: ''
			}
		},

		expose: [],

		data() {
			return {
				start: this.page + 0,
				end: 0
			}
		},

		computed: {
			isEmpty() {
				return this.total === 0
			},

			hasMultiplePages() {
				return this.hasMorePages || this.page > 1
			},

			prevButtonActive() {
				return this.page > 1
			},

			nextButtonActive() {
				return this.hasMorePages
			},

			beginButtonActive() {
				return this.page > 1
			},

			perPageOptionsObj() {
				return listFunctions.getPerPageOptions(this.perPageOptions)
			}
		},

		methods: {
			/**
			 * Emit event to update page number (built-in method)
			 * @param index {Number}
			 */
			pageHandler(index) {
				if (!this.disabled && index >= 1 /* && index <= this.totalPages*/) {
					this.$emit('update:page', index)
				}
			},

			/**
			 * Emit event to update number of rows per page (built-in method)
			 * @param option {Object}
			 */
			perPageHandler(option) {
				if (!this.disabled)
					this.$emit('update:perPage', option)
			},

			/**
			 * Action for button to previous page
			 */
			prevButtonAction() {
				if(this.prevButtonActive)
					this.pageHandler(this.page - 1)
			},

			/**
			 * Action for button to next page
			 */
			nextButtonAction() {
				if(this.nextButtonActive)
					this.pageHandler(this.page + 1)
			},

			/**
			 * Action for button to first page
			 */
			beginButtonAction() {
				if(this.beginButtonActive)
					this.pageHandler(1)
			},

			/**
			 * Determine if string represents positive integer?
			 * @param str {String}
			 * @returns Boolean?
			 */
			isPositiveInteger(str) {
				return /^\+?(0|[1-9]\d*)$/.test(str)
			}
		}
	}
</script>
