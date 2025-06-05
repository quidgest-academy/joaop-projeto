import _assignIn from 'lodash-es/assignIn'
import cloneDeep from 'lodash-es/cloneDeep'
import _get from 'lodash-es/get'
import _keyBy from 'lodash-es/keyBy'
import _toString from 'lodash-es/toString'
import { computed, nextTick, ref, unref, watch } from 'vue'

import listFunctions from '@/mixins/listFunctions.js'
import { systemInfo } from '@/systemInfo'
import { validateFormula } from '@/utils/formula.js'
import { QEventEmitter } from '@quidgest/clientapp/plugins/eventBus'
import { useGenericDataStore } from '@quidgest/clientapp/stores'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'

export class BaseColumn
{
	#fnVisibility

	constructor(options, modelCtx, eventEmitter, init = true)
	{
		this.order = 0
		this.dataType = 'None'
		this.searchFieldType = null
		this.dataDisplay = null
		this.dataDisplayText = null
		this.component = null
		this.name = 'Undefined'
		this.area = 'Undefined'
		this.field = 'Undefined'
		this.label = ''
		this.supportForm = null
		this.supportFormIsPopup = false
		this.params = null
		this.cellAction = false
		this.sortable = true
		this.searchable = true
		this.export = true
		this.array = null
		this.useDistinctValues = false
		this.isOrderingColumn = false
		this.initialSort = false
		this.initialSortOrder = ''
		this.isDefaultSearch = false
		this.pkColumn = null
		this.isHtmlField = false
		this.multipleValues = false
		this.isSerialized = false
		this.showWhen = null
		this.visibilityListeners = []

		Object.defineProperties(this, {
			visible: {
				value: ref(true),
				configurable: true,
				writable: true,
				enumerable: false
			},
			visibilityEval: {
				value: ref(false),
				configurable: true,
				writable: true,
				enumerable: false
			},
			modelCtx: {
				value: null,
				configurable: true,
				writable: true,
				enumerable: false
			},
			eventEmitter: {
				value: null,
				configurable: true,
				writable: true,
				enumerable: false
			}
		})

		this.#fnVisibility = async () => {
			const isVisible = unref(this.isVisible)
			this.visibilityEval.value = await validateFormula(this.showWhen, this.modelCtx)

			// If the visibility changes, triggers the listeners.
			if (isVisible !== unref(this.isVisible))
				for (let listener of this.visibilityListeners)
					listener(unref(this.isVisible))
		}

		/**
		 * Whether the column is currently visible.
		 */
		this.isVisible = computed({
			get: () => this.visible.value && this.visibilityEval.value,
			set: (newValue) => (this.visible.value = newValue)
		})

		// Add all properties to itself
		_assignIn(this, options)

		if (init)
			this.init(modelCtx, eventEmitter)
	}

	/**
	 * Asynchronously initializes the necessary properties and listeners in the column.
	 * @param {ViewModel} modelCtx The model context
	 * @param {QEventEmitter} eventEmitter The event emitter instance
	 */
	async init(modelCtx, eventEmitter)
	{
		// Needs to wait so that the "modelCtx" and "eventEmitter" are already set.
		await nextTick()

		this.eventEmitter = unref(eventEmitter)

		if (this.showWhen && this.eventEmitter instanceof QEventEmitter)
		{
			this.modelCtx = unref(modelCtx)
			watch(() => modelCtx, (value) => this.modelCtx = unref(value), { deep: true })

			this.eventEmitter.offMany(this.showWhen.dependencyEvents, this.#fnVisibility)
			this.eventEmitter.onMany(this.showWhen.dependencyEvents, this.#fnVisibility)
			await this.#fnVisibility()
		}
		else
			this.visibilityEval.value = true
	}

	/**
	 * Adds the specified listener to be executed when the column's visibility changes.
	 * @param {function} listener The listener function to add
	 */
	addVisibilityListener(listener)
	{
		if (typeof listener !== 'function')
			throw new Error('The "listener" argument should be a function.')
		this.visibilityListeners.push(listener)
	}

	/**
	 * Creates a clone of this column.
	 * @returns The column clone.
	 */
	clone()
	{
		const clonedCol = new this.constructor(cloneDeep(this), this.modelCtx, this.eventEmitter, false)

		// This is needed since non-enumerable properties won't be set, as "cloneDeep" will ignore them.
		clonedCol.visible.value = unref(this.visible) ?? true
		clonedCol.visibilityEval.value = unref(this.visibilityEval) ?? false

		return clonedCol
	}

	/**
	 * Normalize a value based on the column type
	 * @param {string} value Field value
	 * @returns {string} A Date object representing the given date and time.
	 */
	getNormalizedValue(value)
	{
		return value
	}
}

export class TextColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataDisplayText: listFunctions.textDisplayCell
		}, options), modelCtx, eventEmitter, init)
	}
}

export class NumericColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		const genericDataStore = useGenericDataStore()

		super(_assignIn({
			dataType: 'Numeric',
			searchFieldType: 'num',
			dataDisplay: listFunctions.numericDisplayCell,
			dataDisplayText: listFunctions.numericDisplayCell,
			maxDigits: 0,
			decimalPlaces: 0,
			numberFormat: {
				decimalSeparator: genericDataStore.numberFormat.decimalSeparator,
				groupSeparator: genericDataStore.numberFormat.thousandsSeparator,
			},
			showTotal: true,
			columnClasses: 'c-table__cell-numeric row-numeric',
			columnHeaderClasses: 'c-table__head-numeric'
		}, options), modelCtx, eventEmitter, init)
	}

	/**
	 * @override
	 */
	async init(modelCtx, eventEmitter)
	{
		super.init(modelCtx, eventEmitter)

		// Add class for column with row re-order controls
		if (this.isOrderingColumn)
			this.columnHeaderClasses += ' thead-order'
	}
}

export class CurrencyColumn extends NumericColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			dataType: 'Currency',
			searchFieldType: 'num',
			dataDisplay: listFunctions.currencyDisplayCell,
			dataDisplayText: listFunctions.currencyDisplayCell,
			currency: systemInfo.system.baseCurrency.code,
			currencySymbol: systemInfo.system.baseCurrency.symbol
		}, options), modelCtx, eventEmitter, init)
	}
}

export class DateColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		const genericDataStore = useGenericDataStore()

		super(_assignIn({
			dataType: 'Date',
			searchFieldType: 'date',
			dateTimeType: 'dateTime',
			dateFormats: genericDataStore.dateFormat,
			dataDisplay: listFunctions.dateDisplayCell,
			dataDisplayText: listFunctions.dateDisplayCell
		}, options), modelCtx, eventEmitter, init)
	}

	/**
	 * Convert a date's format to ISO based on the column the date comes from
	 * @param {string} value A string formatted as a date in a configuration defined format
	 * @returns {string} A string in ISO date format
	 */
	getNormalizedValue(value)
	{
		const genericDataStore = useGenericDataStore()

		// Get date format based on the column
		const dateFormat = genericDataStore.dateFormat[this.dateTimeType]

		// Convert to date object
		let parsedDate = genericFunctions.stringToDate(value, dateFormat)

		// If invalid date
		if (parsedDate === null)
			return ''

		// Convert to ISO string
		return parsedDate.toISOString()
	}
}

export class BooleanColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			dataType: 'Boolean',
			searchFieldType: 'bool',
			component: 'q-render-boolean',
			dataDisplay: listFunctions.booleanDisplayCell,
			dataDisplayText: listFunctions.booleanDisplayCell
		}, options), modelCtx, eventEmitter, init)
	}
}

export class ImageColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			dataType: 'Image',
			component: 'q-render-image',
			cellAction: true,
			dataDisplay: listFunctions.imageDisplayCell,
			dataDisplayText: listFunctions.imageDisplayCell
		}, options), modelCtx, eventEmitter, init)
	}
}

export class DocumentColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			dataType: 'Document',
			searchFieldType: 'text',
			component: 'q-render-document',
			dataDisplay: listFunctions.documentDisplayCell,
			dataDisplayText: listFunctions.documentDisplayCell,
			isSerialized: true
		}, options), modelCtx, eventEmitter, init)
	}
}

export class ArrayColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			dataType: 'Array',
			component: 'q-render-array',
			searchFieldType: 'enum',
			dataDisplay: listFunctions.enumerationDisplayCell,
			dataDisplayText: listFunctions.enumerationDisplayCell
		}, options), modelCtx, eventEmitter, init)
	}

	get arrayAsObj()
	{
		return new Proxy(_keyBy(this.array, (aElem) => _toString(aElem.key)), {
			get(target, name)
			{
				return _get({
					__v_skip: true,
					__v_isReactive: true,
					__v_isRef: false,
					__v_isReadonly: true,
					__v_raw: true
				}, name, _get(target, name, {}))
			}
		})
	}
}

export class GeographicColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		const genericDataStore = useGenericDataStore()

		super(_assignIn({
			dataType: 'Geographic',
			dataDisplay: listFunctions.geographicDisplayCell,
			dataDisplayText: listFunctions.geographicDisplayCell,
			numberFormat: {
				decimalSeparator: genericDataStore.numberFormat.decimalSeparator,
				groupSeparator: genericDataStore.numberFormat.thousandsSeparator,
			}
		}, options), modelCtx, eventEmitter, init)
	}
}

export class GeographicShapeColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			dataType: 'GeographicShape',
			dataDisplay: listFunctions.geographicShapeDisplayCell,
			dataDisplayText: listFunctions.geographicShapeDisplayCell
		}, options), modelCtx, eventEmitter, init)
	}
}

export class GeometricShapeColumn extends GeographicShapeColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			dataType: 'GeometricShape'
		}, options), modelCtx, eventEmitter, init)
	}
}

export class HyperLinkColumn extends BaseColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.hyperLinkDisplayCell,
			dataDisplayText: listFunctions.hyperLinkDisplayCell,
			component: 'q-render-hyperlink'
		}, options), modelCtx, eventEmitter, init)
	}
}

export class HtmlColumn extends TextColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			component: 'q-render-html',
			isHtmlField: true
		}, options), modelCtx, eventEmitter, init)
	}
}

export class MarkdownColumn extends TextColumn
{
	constructor(options, modelCtx, eventEmitter, init)
	{
		super(_assignIn({
			component: 'q-render-markdown',
			isHtmlField: true
		}, options), modelCtx, eventEmitter, init)
	}
}

export default {
	BaseColumn,
	TextColumn,
	NumericColumn,
	CurrencyColumn,
	DateColumn,
	BooleanColumn,
	ImageColumn,
	DocumentColumn,
	ArrayColumn,
	GeographicColumn,
	GeographicShapeColumn,
	GeometricShapeColumn,
	HyperLinkColumn,
	HtmlColumn,
	MarkdownColumn
}
