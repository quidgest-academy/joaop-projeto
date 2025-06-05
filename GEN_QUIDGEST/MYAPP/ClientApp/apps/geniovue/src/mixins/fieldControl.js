import _assignIn from 'lodash-es/assignIn'
import _assignInWith from 'lodash-es/assignInWith'
import _capitalize from 'lodash-es/capitalize'
import cloneDeep from 'lodash-es/cloneDeep'
import _debounce from 'lodash-es/debounce'
import _forEach from 'lodash-es/forEach'
import _get from 'lodash-es/get'
import _has from 'lodash-es/has'
import _isEmpty from 'lodash-es/isEmpty'
import _isEqual from 'lodash-es/isEqual'
import _isUndefined from 'lodash-es/isUndefined'
import _merge from 'lodash-es/merge'
import _mergeWith from 'lodash-es/mergeWith'
import _some from 'lodash-es/some'
import _toLower from 'lodash-es/toLower'
import _unionWith from 'lodash-es/unionWith'
import { v4 as uuidv4 } from 'uuid'
import { computed, isRef, nextTick, ref, watch, watchEffect } from 'vue'

import searchFilterData from '@/api/genio/searchFilterData.js'
import { validateFormula } from '@/utils/formula.js'
import asyncProcM from '@quidgest/clientapp/composables/async'
import {
	BlockConditionStack,
	HideConditionStack,
	RequiredConditionStack
} from '@quidgest/clientapp/models/conditionStack'
import netAPI from '@quidgest/clientapp/network'
import eventBus from '@quidgest/clientapp/plugins/eventBus'
import { useGenericDataStore, useSystemDataStore } from '@quidgest/clientapp/stores'

import { removeModal } from '@/utils/layout.js'
import qEnums from '@quidgest/clientapp/constants/enums'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import controlsResources from './controlsResources.js'
import getSpecialRenderingControls from './customControl.js'
import formFunctions from './formFunctions.js'
import listFunctions from './listFunctions.js'
import { systemInfo } from '@/systemInfo'

/**
 * Base form control
 */
export class BaseControl
{
	/**
	 * Base constructor
	 * @param {object} options
	 * @param {Proxy} vueContext
	 */
	constructor(options, vueContext)
	{
		this.vueContext = vueContext
		Object.defineProperty(this, 'vueContext', { enumerable: false })

		// Init default values of control properties
		/** The id of the control */
		this.id = ''
		/** The type of the control class */
		this.type = 'Base'
		/** The model field Id */
		this.modelField = ''
		/** «Reference» to Proxy object of model field */
		this.modelFieldRef = null
		/** The field table - copied from modelFieldRef */
		this.dbArea = ''
		/** The field name - copied from modelFieldRef */
		this.dbField = ''
		/** String or function that return Label text for this control */
		this.label = ''
		/** The <label> div Id. Used for accessibility */
		this.labelId = ''
		/** Indicates if the field has a label */
		this.hasLabel = true
		/** Indicates the parent zone id */
		this.container = ''
		/** Indicates the parent tab id */
		this.tab = ''
		/** Indicates the parent sub-form id */
		this.subForm = ''
		/** The id of the parent control */
		this.parent = computed(() => this.container || this.tab || this.subForm || '')
		/** List of sources that hide the control */
		this.showWhenConditions = new HideConditionStack()
		/** List of sources that block the control */
		this.blockWhenConditions = new BlockConditionStack()
		/** List of sources that make the control required */
		this.fieldRequiredConditions = new RequiredConditionStack()
		/** Whether or not the field is marked as mandatory */
		this.mustBeFilled = false
		/** Computed field that returns the result of the evaluation of the showWhenConditions to indicate if the control is visible */
		this.isVisible = false
		/** Indicates if the field is blocked (cannot be modified) */
		this.isBlocked = true
		/** Indicates if the field is readonly (cannot be modified) */
		this.readonly = true
		/** Indicates if the field is disabled (cannot be modified nor receive focus) */
		this.disabled = false
		/** Whether the field is blocked because it's calculated by a formula */
		this.isFormulaBlocked = false
		/** Computed field that returns the result of the evaluation of the fieldRequiredConditions to indicate if the control is required */
		this.isRequired = false
		/** Hidden when it is not editable form */
		this.hiddenInNonEditableMode = false
		/** List of limits that condition the presented value */
		this.tableLimits = []
		/** Whether or not some popup triggered by this control is visible */
		this.popupIsVisible = false
		/** Event handlers */
		this.handlers = {}
		/** The control label attributes */
		this.labelAttrs = { class: 'i-text__label' }
		this.dFlexInline = false
		/** The field allows adding suggestion */
		this.hasSuggestions = true
		/** The model field info (for Base input structure) */
		this.modelInfo = null
		/** The control size class */
		this.size = undefined
		/** Init async monitor for loading animation */
		this.componentOnLoadProc = asyncProcM.getProcListMonitor(`${options.id || uuidv4()}`, true)
		/** Whether the control is already loaded */
		this.loaded = computed(() => this.componentOnLoadProc.loaded)
		/** Translated texts */
		this.texts = new controlsResources.BaseResources(vueContext.$getResource)
		/** Indicates whether the field should display an alternative visualization (simpler than the standard ViewModes) */
		this.showAlternativeView = false

		_merge(this, options || {})
	}

	get props()
	{
		return {
			id: this.id,
			readonly: this.readonly,
			loading: !this.loaded,
			required: this.isRequired,
			texts: this.texts,
			ariaLabel: this.label,
			size: this.size
		}
	}

	get wrapperProps()
	{
		return {
			...this.props,
			// MTC - there was a problem with the error messages not appearing
			// in the GridTableList, because it didn't had the modelFieldRef
			// this is to show the error message of the field
			modelFieldRef: this.modelFieldRef
		}
	}

	/**
	 * Adds a value to the stack of the specified field's hiding sources.
	 * @param {string} sourceId The id of the hiding source
	 * @param {function} condition The condition to determine whether the source is active (optional)
	 * @param {string|array} eventIds An event to listen for, or a list of events (optional)
	 */
	async addHideSource(sourceId, condition, eventIds)
	{
		await this.showWhenConditions.add(sourceId, condition, eventIds)
	}

	/**
	 * Removes a value from the stack of the specified field's hiding sources.
	 * @param {string} sourceId The id of the hiding source
	 */
	removeHideSource(sourceId)
	{
		this.showWhenConditions.remove(sourceId)
	}

	/**
	 * Adds a value to the stack of the specified field's blocking sources.
	 * @param {string} sourceId The id of the blocking source
	 * @param {function} condition The condition to determine whether the source is active (optional)
	 * @param {string|array} eventIds An event to listen for, or a list of events (optional)
	 */
	async addBlockSource(sourceId, condition, eventIds)
	{
		await this.blockWhenConditions.add(sourceId, condition, eventIds)
	}

	/**
	 * Removes a value from the stack of the specified field's blocking sources.
	 * @param {string} sourceId The id of the blocking source
	 */
	removeBlockSource(sourceId)
	{
		this.blockWhenConditions.remove(sourceId)
	}

	/**
	 * Adds a value to the stack of the specified field's required sources.
	 * @param {string} sourceId The id of the required source
	 * @param {function} condition The condition to determine whether the source is active (optional)
	 * @param {string|array} eventIds An event to listen for, or a list of events (optional)
	 */
	async addRequiredSource(sourceId, condition, eventIds)
	{
		await this.fieldRequiredConditions.add(sourceId, condition, eventIds)
	}

	/**
	 * Removes a value from the stack of the specified field's required sources.
	 * @param {string} sourceId The id of the required source
	 */
	removeRequiredSource(sourceId)
	{
		this.fieldRequiredConditions.remove(sourceId)
	}

	/**
	 * Initialization of formulas that belong only to the control (interface part).
	 */
	async initControlFormulas()
	{
		await this.initFormulas(this.modelFieldRef)
	}

	/**
	 * Internal implementation of the initialization of formulas
	 * that belong only to the control (interface part).
	 * @param {object} modelFieldRef «Reference» to Proxy object of model field
	 */
	async initFormulas(modelFieldRef)
	{
		const promises = [],
			ctx = this.vueContext.model

		// Show when formula of the form
		if (!_isEmpty(this.showWhen))
		{
			const events = _unionWith(this.showWhen.dependencyEvents, ['CALC_SHOW_WHEN_FORMULAS'])
			const res = this.addHideSource('FORMULA_SHOW_WHEN', async () => await validateFormula(this.showWhen, ctx), events)
			promises.push(res)
		}

		// Block when formula of the form
		if (!_isEmpty(this.blockWhen))
		{
			const events = _unionWith(this.blockWhen.dependencyEvents, ['CALC_BLOCK_WHEN_FORMULAS'])
			const res = this.addBlockSource('FORMULA_BLOCK_WHEN', async () => await validateFormula(this.blockWhen, ctx), events)
			promises.push(res)
		}

		// Required conditions
		if (!_isEmpty(this.requiredConditions))
		{
			const events = _unionWith(this.requiredConditions.dependencyEvents, ['CALC_REQUIRED_FORMULAS'])
			const res = this.addRequiredSource('FORMULA_REQUIRED', async () => await validateFormula(this.requiredConditions, ctx), events)
			promises.push(res)
		}

		if (!_isEmpty(modelFieldRef) && !_isEmpty(this.modelFieldRef))
		{
			// Fill when formula to block the control
			if (!_isEmpty(modelFieldRef.fillWhen))
			{
				const events = _unionWith(modelFieldRef.fillWhen.dependencyEvents, ['CALC_FILL_WHEN_FORMULAS'])
				const res = this.modelFieldRef.fillWhenConditions.add('FORMULA_FILL_WHEN', async () => await validateFormula(modelFieldRef.fillWhen, ctx), events)
				promises.push(res)

				if (typeof modelFieldRef.fillWhen.clearValue !== 'function')
				{
					// If the field becomes blocked by the "Fill when" formula, it should also be cleared.
					modelFieldRef.fillWhen.clearValue = () => modelFieldRef.clearValue()
					this.modelFieldRef.fillWhenConditions.addOnClearListener(modelFieldRef.fillWhen.clearValue)
				}
			}

			// Show when formula of the table
			if (!_isEmpty(modelFieldRef.showWhen))
			{
				const events = _unionWith(modelFieldRef.showWhen.dependencyEvents, ['CALC_SHOW_WHEN_FORMULAS'])
				const res = this.modelFieldRef.showWhenConditions.add('FORMULA_SHOW_WHEN', async () => await validateFormula(modelFieldRef.showWhen, ctx), events)
				promises.push(res)
			}

			// Block when formula of the table
			if (!_isEmpty(modelFieldRef.blockWhen))
			{
				const events = _unionWith(modelFieldRef.blockWhen.dependencyEvents, ['CALC_BLOCK_WHEN_FORMULAS'])
				const res = this.modelFieldRef.blockWhenConditions.add('FORMULA_BLOCK_WHEN', async () => await validateFormula(modelFieldRef.blockWhen, ctx), events)
				promises.push(res)
			}
		}

		await Promise.all(promises)
	}

	/**
	 * Defines if the form is in editable mode.
	 * In addition to being locked/unlocked, some controls may be invisible in non-editable modes.
	 * @param {Boolean} isEditableForm
	 */
	async setFormModeBlockAndVisibility(isEditableForm)
	{
		if (isEditableForm === false)
		{
			await this.addBlockSource('NOT_EDITABLE_FORM')
			if (this.hiddenInNonEditableMode === true)
				await this.addHideSource('NOT_EDITABLE_FORM')
		}
		else
		{
			this.removeBlockSource('NOT_EDITABLE_FORM')
			this.removeHideSource('NOT_EDITABLE_FORM')
		}
	}

	/**
	 * Sets additional properties for the condition stacks.
	 */
	async initConditionStacks()
	{
		if (this.modelFieldRef?.isFixed)
			await this.modelFieldRef.blockWhenConditions.add('FIXED_FIELD')
		if (this.isFormulaBlocked)
			await this.addBlockSource('FORMULA_FIELD')

		if (this.mustBeFilled)
			await this.addRequiredSource('REQUIRED_FIELD')

		if (this.modelFieldRef)
		{
			this.showWhenConditions.associateStack(this.modelFieldRef.showWhenConditions)
			this.blockWhenConditions.associateStack(this.modelFieldRef.blockWhenConditions)
			this.blockWhenConditions.associateStack(this.modelFieldRef.fillWhenConditions)
		}

		// This condition is needed since some controls might be defined inside components (e.g. QCustomSelection),
		// making the context different.
		if (this.vueContext.internalEvents)
		{
			// The event emitter needs to be set here, because in the constructor it's not defined yet.
			this.showWhenConditions.setEventEmitter(this.vueContext.internalEvents)
			this.blockWhenConditions.setEventEmitter(this.vueContext.internalEvents)
			this.fieldRequiredConditions.setEventEmitter(this.vueContext.internalEvents)

			this.modelFieldRef?.showWhenConditions.setEventEmitter(this.vueContext.internalEvents)
			this.modelFieldRef?.blockWhenConditions.setEventEmitter(this.vueContext.internalEvents)
			this.modelFieldRef?.fillWhenConditions.setEventEmitter(this.vueContext.internalEvents)
		}
	}

	/**
	 * Initializes the event handlers.
	 */
	initHandlers()
	{
		const handlers = {
			showSuggestionPopup: (...args) => eventBus.emit('show-suggestion-popup', ...args)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) =>
			_isUndefined(objValue) ? srcValue : objValue
		)
	}

	/**
	 * Initializes the necessary properties.
	 * @param {boolean} isEditableForm Whether or not the control is editable
	 */
	async init(isEditableForm)
	{
		// Set reference to the model field
		if (!_isEmpty(this.modelField) && this.vueContext.model)
		{
			if (_has(this.vueContext.model, this.modelField))
			{
				this.modelFieldRef = _get(this.vueContext.model, this.modelField)

				this.dbArea = _toLower(this.modelFieldRef.area)
				this.dbField = _toLower(this.modelFieldRef.field)
				this.modelInfo = {
					tableId: this.modelFieldRef.area,
					fieldId: this.modelFieldRef.field
				}
			}
		}

		await this.setFormModeBlockAndVisibility(isEditableForm)
		await this.initConditionStacks()
		await this.initControlFormulas()
		this.initHandlers()

		// Computed variables should only be initialized after the component's data initialization (when the object becomes reactive)
		this.isVisible = computed(() => !this.showWhenConditions.anyMet)
		this.isBlocked = computed(() => this.blockWhenConditions.anyMet)
		this.isRequired = computed(() => this.fieldRequiredConditions.anyMet)

		// Initial step towards separating these concepts
		this.readonly = computed(() => this.isBlocked)
	}

	/**
	 * Gets the values of the control limits (with identifiers that are used in lists and lookups).
	 * @returns Returns the values of the control limits (if any)
	 */
	getLimitsValues()
	{
		const limitsValues = {},
			model = this.vueContext.model

		// Dynamic limits (value getter + identifier). Used in requests for the new rows list
		if (model && !_isEmpty(this.controlLimits))
		{
			_forEach(this.controlLimits, (limitInfo) => {
				const limitValue = limitInfo.fnValueSelector(model)
				if (Array.isArray(limitInfo.identifier))
				{
					_forEach(limitInfo.identifier, (limitIdentifier) => {
						Reflect.set(limitsValues, limitIdentifier, limitValue)
					})
				}
				else
					Reflect.set(limitsValues, limitInfo.identifier, limitValue)
			})
		}

		/**
		 * Limits with fixed value (value + identifier).
		 * Used, for example, in See More lists, to apply dynamic values received from the form (for example, 'Field' type limit).
		 */
		if (!_isEmpty(this.fixedControlLimits))
		{
			_forEach(this.fixedControlLimits, (limitValue, limitIdentifier) => {
				Reflect.set(limitsValues, limitIdentifier, limitValue)
			})
		}

		return limitsValues
	}

	/**
	 * Sets a modal with the specified data.
	 * @param {string|object} modalData The data of the modal (structure: { id: String, props: Object })
	 */
	setModal(modalData)
	{
		if (_isEmpty(modalData))
			return

		let properties = {}

		if (typeof modalData === 'object')
		{
			if (_isEmpty(modalData.id))
				return
			if (!_isEmpty(modalData.props))
				properties = modalData.props

			properties.id = modalData.id
		}
		else if (typeof modalData === 'string')
			properties.id = modalData
		else
			return

		const modalProps = {
			isActive: true,
			closeButtonEnable: true,
			...properties,
			dismissAction: () => {
				if (typeof properties.dismissAction === 'function')
					properties.dismissAction()
				this.popupIsVisible = false
			}
		}

		this.vueContext.setModal(modalProps)
		nextTick().then(() => this.popupIsVisible = true)
	}

	/**
	 * Removes from the DOM the modal with the specified id.
	 * @param {string} modalId The id of the modal
	 */
	removeFieldModal(modalId)
	{
		removeModal(modalId)
		this.popupIsVisible = false
	}

	/**
	 * Reloads the data of the control
	 */
	async reload()
	{
		return this.vueContext.fetchFormField(this.modelField)
	}

	/**
	 * Adds the async process to the watch list of that control's parent context.
	 * Controls in the certain conditions will cause the «Loading ...» effect to appear
	 * @param {Promise} cbPromise The «Promise» object of the proces
	 * @param {String} busyStateMessage The page busy state message
	 * @returns Promise or nothing
	 */
	addLoadingProcToParent(cbPromise, busyStateMessage)
	{
		return this.vueContext.componentOnLoadProc?.addBusy(cbPromise, busyStateMessage)
	}

	/**
	 * Adds a new handler for the specified event.
	 * @param {string} id The id of the event
	 * @param {function} behavior The behavior of the handler
	 * @param {boolean} rewrite Whether or not the previous behavior should be rewritten (defaults to false)
	 */
	addHandler(id, behavior, rewrite = false)
	{
		if (typeof id !== 'string' || typeof behavior !== 'function')
			return
		if (typeof this.handlers !== 'object')
			this.handlers = {}

		const prevHandler = this.handlers[id]
		var behaviorFunc = behavior

		if (!rewrite && typeof prevHandler === 'function')
		{
			behaviorFunc = (...args) => {
				prevHandler(...args)
				behavior(...args)
			}
		}

		this.handlers[id] = behaviorFunc
	}

	/**
	 * The control destroy to be invoked on the unmount.
	 */
	destroy()
	{
		this.componentOnLoadProc.destroy()
	}
}

/**
 * Represents a control type whose value comes from the database.
 */
class DatabaseControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			modelValue: this.modelFieldRef?.value
		}
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			'update:model-value': (eventData) => this.modelFieldRef?.fnUpdateValue(eventData)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}
}

/**
 * Represents a control type that shouldn't be blocked just because the form is in "SHOW" mode.
 */
class NonBlockableControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * Defines if the form is in editable mode
	 */
	async setFormModeBlockAndVisibility()
	{
		await super.setFormModeBlockAndVisibility(true)
	}
}

/**
 * Form string control
 */
export class StringControl extends DatabaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'String'
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			placeholder: this.placeholder,
			maxLength: this.maxLength
		}
	}
}

/**
 * Form multiline string control
 */
export class MultilineStringControl extends StringControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'MultilineString',
			rows: 3,
			cols: 20,
			resize: 'vertical',
			autosize: false,
			wrap: 'soft'
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			rows: this.rows,
			cols: this.cols,
			resize: this.resize,
			autosize: this.autosize,
			wrap: this.wrap
		}
	}
}

/**
 * Form text editor control
 */
export class TextEditorControl extends StringControl
{
	constructor(options, _vueContext)
	{
		const systemDataStore = useSystemDataStore()

		super({
			type: 'TextEditor',
			locale: computed(() => systemDataStore.system.currentLang)
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			locale: this.locale
		}
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			ctrlInitialized: () => this.onCtrlInitializedEvent()
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * @override
	 */
	destroy()
	{
		super.destroy()

		/**
		 * For some reason before unmount is not executed on the component.
		 * It will be the control's JS that will destroy the initialized plugin.
		 */
		if (window.tinymce)
		{
			let editorCtrl = window.tinymce.get(this.id)
			if (editorCtrl)
			{
				editorCtrl.remove()
				editorCtrl.destroy(true)
				window.tinymce.remove(this.id)
			}
		}
	}

	onCtrlInitializedEvent() { if (this.vueContext.internalEvents) this.vueContext.internalEvents.emit('ctrl-initialized', { id: this.id }) }
}

/**
 * Form code editor control
 */
export class CodeEditorControl extends StringControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'CodeEditor',
			language: '',
			rows: 15,
			texts: new controlsResources.CodeEditorResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			language: this.language,
			rows: this.rows
		}
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		if (this.languageData && typeof this.languageData.getLanguage !== 'function')
		{
			this.languageData.getLanguage = async () => {
				this.language = await validateFormula(this.languageData, this.vueContext.model)
			}
			this.languageData.getLanguage()

			const events = this.languageData.dependencyEvents
			this.vueContext.internalEvents.offMany(events, this.languageData.getLanguage)
			this.vueContext.internalEvents.onMany(events, this.languageData.getLanguage)
		}
	}
}

/**
 * Password control
 */
export class PasswordControl extends StringControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Password'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form boolean control
 */
export class BooleanControl extends DatabaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Boolean',
			labelAttrs: { class: 'i-checkbox i-checkbox__label' }
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		const boolProps = super.props
		// Checkboxes have no size property.
		delete boolProps.size
		return boolProps
	}
}

/**
 * Form numeric control
 */
export class NumberControl extends DatabaseControl
{
	constructor(options, _vueContext)
	{
		const genericDataStore = useGenericDataStore()

		super({
			type: 'Number',
			thousandsSeparator: genericDataStore.numberFormat.thousandsSeparator,
			decimalPoint: genericDataStore.numberFormat.decimalSeparator,
			maxDigits: 0,
			decimalDigits: 0,
			isDecimal: true, /* <= decimalDigits > 0 */
			isSequencial: false,
			showEmptyMessage: false,
			currencySymbol: ''
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			name: this.name,
			labelId: this.labelId,
			disabled: this.disabled,
			isRequired: this.isRequired,
			currencySymbol: this.currencySymbol,
			thousandsSeparator: this.thousandsSeparator,
			decimalPoint: this.decimalPoint,
			maxIntegers: this.maxIntegers,
			maxDecimals: this.maxDecimals,
			classes: this.classes,
			showEmptyMessage: this.showEmptyMessage
		}
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		if (this.modelFieldRef)
		{
			this.maxDigits = computed(() => this.modelFieldRef.maxDigits)
			this.decimalDigits = computed(() => this.modelFieldRef.decimalDigits)
			this.showEmptyMessage = computed(() => this.isSequencial && (_isEmpty(this.modelFieldRef) || this.modelFieldRef.value < 0))
		}
	}
}

/**
 * Form currency control
 */
export class CurrencyControl extends NumberControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Number',
			dFlexInline: true,
			currencySymbol: computed(() => systemInfo.system.baseCurrency.symbol ?? '€')
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form date control
 */
export class DateControl extends DatabaseControl
{
	constructor(options, _vueContext)
	{
		const systemDataStore = useSystemDataStore()

		super({
			type: 'Date',
			dFlexInline: true,
			locale: computed(() => systemDataStore.system.currentLang),
			texts: new controlsResources.DateTimeResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			type: this.type,
			locale: this.locale,
			format: this.format
		}
	}
}

/**
 * Form time control
 */
export class TimeControl extends DateControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Time'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * The base class for the Array controls
 */
class BaseArrayControl extends DatabaseControl
{
	constructor(options, _vueContext)
	{
		super({
			items: [],
			groups: [],
			arrayOptions: [],
			arrayElShowWhen: null
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			items: this.items,
			groups: this.groups,
			clearable: this.clearable,
			emptyValue: this.emptyValue,
			ariaLabel: this.label
		}
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		this.arrayOptions = computed(() => this.unwrapArrayOptions(this.modelFieldRef?.arrayOptions))
		// TODO: This is a workaround to hide groups without elements. This code is needed until the component has this part working for itself.
		this.arrayGroups = this.modelFieldRef?.arrayGroups
		this.groups = this.modelFieldRef?.arrayGroups
		watchEffect(() => {
			this.filterArray = this.filterArrayElements(this.arrayOptions, this.arrayGroups) || []
			this.items = this.setShowDescription(this.filterArray)
		})

		this.emptyValue = this.modelFieldRef?.constructor.EMPTY_VALUE
		// The array is clearable if its not required, and if the empty value is not an option of the array.
		this.clearable = computed(() => !this.isRequired && !this.items.some(item => item.key === this.emptyValue))

		this.filterArrayElements()
	}

	/**
	 * Defined if show array item description or not
	 */
	setShowDescription(array)
	{
		array.forEach((item) => {
			if (this.helpShortItem === 'None' || this.helpShortItem === '')
				item.helpResourceId = ''
			else if (this.helpDetailedItem === 'None' || this.helpShortItem === '')
				item.helpResourceVerboseId = ''
		})

		return array
	}

	/**
	 * Initialization of formulas that belong only to the control (interface part).
	 * @override
	 */
	async initControlFormulas()
	{
		// Array element show when formula
		if (this.arrayElShowWhen)
			this.vueContext.internalEvents.onMany(this.arrayElShowWhen.dependencyEvents, () => this.reloadArray())

		await super.initControlFormulas()
	}

	/**
	 * Reloads the array's data.
	 */
	reloadArray()
	{
		this.filterArrayElements(this.arrayOptions, this.arrayGroups)
	}

	/**
	 * Filters the array elements according to the specified condition.
	 * @param {Array} allOptions
	 * @param {Array} allGroups
	 */
	filterArrayElements(allOptions, allGroups)
	{
		if (!this.arrayElShowWhen || !allOptions || allOptions.length === 0)
			return allOptions

		// Filter array
		Promise.all(this.validateArrayElShowWhen(allOptions)).then(
			(options) => {
				const filteredOptions = options
					.filter((o) => o.show)
					.map((o) => o.el)

				// Update visible options
				if (allGroups !== undefined)
				{
					// Update visible options for groups
					watchEffect(() => {
						this.groups = allGroups.filter((item) => filteredOptions.some((option) => option.group === item.id))
					})
				}
				watchEffect(() => (this.items = filteredOptions))

				// Clean display value
				if (filteredOptions.filter((o) => o.key === this.modelFieldRef.value).length === 0)
					this.modelFieldRef.updateValue(null)
			}
		)
	}

	/**
	 * Runs the array element show when formula.
	 * @param {Array} allOptions
	 */
	validateArrayElShowWhen(allOptions)
	{
		const res = []

		_forEach(allOptions, (arrayEl) => {
			res.push(
				new Promise((resolve) => {
					validateFormula(this.arrayElShowWhen, this.vueContext.model, { arrayEl })
						.then((result) => resolve({ el: arrayEl, show: result }))
				})
			)
		})

		return res
	}

	/**
	 * Unwraps the options of the array,
	 * taking into consideration whether or not the array is dynamic.
	 * @param {Array} arrayOptions
	 */
	unwrapArrayOptions(arrayOptions)
	{
		return (isRef(arrayOptions) ? arrayOptions.value : arrayOptions) || []
	}
}

/**
 * Form array (String) control
 */
export class ArrayStringControl extends BaseArrayControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'String',
			texts: new controlsResources.LookupResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form array (Number) control
 */
export class ArrayNumberControl extends BaseArrayControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Number',
			texts: new controlsResources.LookupResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form array (Boolean) control
 */
export class ArrayBooleanControl extends BaseArrayControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Boolean',
			trueLabel: '',
			falseLabel: ''
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			trueLabel: this.trueLabel,
			falseLabel: this.falseLabel
		}
	}
}

/**
 * Form Coordinates control
 */
export class CoordinatesControl extends DatabaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Coordinates'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Form mask control
 */
export class MaskControl extends StringControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Mask',
			maskType: '',
			maskFormat: null
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		if (this.modelFieldRef)
		{
			this.maskType = this.modelFieldRef.maskType || ''
			this.maskFormat = this.modelFieldRef.maskFormat || null
		}
	}
}

/**
 * Form List control (DB)
 */
export class LookupControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			/** The type of the control class */
			type: 'Lookup',
			/** List of limits (value getter + identifier). Used in requests for the new options list */
			controlLimits: [],
			/** It's used to indicate if there are more records in addition to the ones it contains in items list */
			hasMore: true,
			selected: null,
			/** Used for reduce unnecessary requests when limit values have not changed */
			prevLimitValues: {},
			/** The identifier of the search field that the server is waiting to receive */
			searchId: 'UNKNOWN',
			seeMoreIsVisible: false,
			seeMoreParams: {},
			/** Information about the Key field on the model */
			lookupKeyModelField: {
				/** The Key model field name */
				name: null,
				/** The Key field change event name */
				dependencyEvent: null
			},
			/** «Reference» for the Key model field (Proxy) */
			lookupKeyModelFieldRef: null,
			// Number of last request
			// The list can make more than one 'simultaneous' request to the server and only the response of the last request is of interest
			requestNumberReload: 0,
			requestNumberGetDependants: 0,
			/** The interface texts */
			texts: new controlsResources.LookupResources(_vueContext.$getResource),
			insertEnabled: false,
			supportForm: undefined,
			externalCallbacks: {},
			externalProperties: {},
			isDebounce: false
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			modelValue: this.lookupKeyModelFieldRef?.value,
			items: this.modelFieldRef?.options ?? [],
			itemValue: 'key',
			itemLabel: 'value',
			totalRows: this.modelFieldRef?.totalRows,
			emptyValue: this.lookupKeyModelFieldRef?.constructor.EMPTY_VALUE,
			filterMode: 'manual',
			showSeeMore: this.hasMore,
			showViewDetails: !_isEmpty(this.supportForm),
			clearable: true,
			ariaLabel: this.label,
			debouncing: computed(() => this.isDebounce)
		}
	}

	get wrapperProps()
	{
		return {
			...super.wrapperProps,
			// The real field in the case of Lookup is the foreign key.
			// Used in the Grid control to show errors.
			modelFieldRef: this.lookupKeyModelFieldRef
		}
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		// Set reference to the model key field
		if (!_isEmpty(this.lookupKeyModelField.name) && typeof this.externalCallbacks.getModelField === 'function')
			this.lookupKeyModelFieldRef = this.externalCallbacks.getModelField(this.lookupKeyModelField.name)

		await super.init(isEditableForm)

		this.applyHistoryLimit()
		this.initEvents()

		// The search input Id that is sent to the server
		this.searchId = `qTable${_capitalize(this.dbArea)}${_capitalize(this.dbField)}`
		this.hasMore = computed(() => !this.readonly && this.modelFieldRef?.hasMore !== false)
	}

	/**
	 * Initialization of formulas that belong only to the control (interface part).
	 * @override
	 */
	async initControlFormulas()
	{
		await this.initFormulas(this.lookupKeyModelFieldRef)
	}

	/**
	 * Apply history to block the field
	 */
	applyHistoryLimit()
	{
		if (this.modelFieldRef && !_isEmpty(this.modelFieldRef.area))
		{
			const formArea = this.vueContext.formInfo.area.toLowerCase()
			const lookupArea = this.modelFieldRef.area.toLowerCase()
			const navigation = this.vueContext.navigation

			// We don't want to add a limit by history if the previous level is for
			// the same record, of the same area, as the current one, and the lookup
			// isn't blocked in that level.
			if (navigation.currentLevel.hasEntry(lookupArea, false, true, formArea))
				this.addBlockSource('HISTORY')
		}
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		this.debouncedSearch = _debounce(this.handleSearch, 500)

		const handlers = {
			'update:model-value': (eventData) => this.lookupKeyModelFieldRef?.fnUpdateValue(eventData),
			beforeShow: (eventData) => this.handleBeforeShow(eventData),
			onSearch: (eventData) => {
				this.isDebounce = true
				this.debouncedSearch(eventData)
			},
			seeMore: (eventData) => this.handleSeeMore(eventData),
			seeMoreChoice: (eventData) => this.handleSeeMoreChoice(eventData),
			close: (eventData) => this.handleSeeMoreClose(eventData),
			insert: () => this.handleOnInsert(),
			viewDetails: (eventData) => this.handleViewDetails(eventData)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Initializes listeners for events on which functions such as content reloading depend on
	 */
	initEvents()
	{
		// Reload control opttions when any limit is changed
		var dependencyEvents = ['RELOAD_ALL_LOOKUP_CONTROLS']

		// Add event to detect change of non-duplication prefix.
		if (this.modelFieldRef && !_isEmpty(this.modelFieldRef.area) && this.modelFieldRef.isUnique && !_isEmpty(this.modelFieldRef.uniquePrefixField))
		{
			const lookupArea = this.modelFieldRef.area,
				prefixFieldName = this.modelFieldRef.uniquePrefixField,
				prefixField = `${lookupArea}.${prefixFieldName}`.toLowerCase()

			dependencyEvents.push('fieldChange:' + prefixField)
		}

		// Events to detect changes in the value of limits
		if (!_isEmpty(this.controlLimits))
		{
			_forEach(this.controlLimits, (controlLimit) => {
				dependencyEvents = _unionWith(dependencyEvents, controlLimit.dependencyEvents)
			})
		}

		if (!_isEmpty(dependencyEvents) && this.vueContext.internalEvents)
			this.vueContext.internalEvents.onMany(dependencyEvents, () => this.reloadLookupContent(null, false))

		// Get dependent fields values that correspond to the selected value
		if (!_isEmpty(this.lookupKeyModelField.dependencyEvent) && this.vueContext.internalEvents)
			this.vueContext.internalEvents.on(this.lookupKeyModelField.dependencyEvent, () => this.getDependants())
	}

	/**
	 * Lookup search mechanism
	 * @param {String} searchQuery
	 */
	handleSearch(searchQuery)
	{
		// Server-side search
		this.reloadLookupContent(searchQuery, false, true)
	}

	/**
	 * Lookup content reloading
	 * @param {String} searchQuery
	 * @param {Boolean} lazyLoad
	 * @param {Boolean} isSearching
	 */
	reloadLookupContent(searchQuery, lazyLoad = false, isSearching = false)
	{
		if (!this.vueContext.formInfo || !this.vueContext.authData.isAllowed) // TODO: Change it!
			return

		// Keep the selected value of the lookup
		let selectedValue = ''

		const limitValues = {
				limits: {},
				queryParams: {},
				searchQuery
			},
			baseApiController = _capitalize(this.vueContext.formInfo.area)

		// Limits
		_assignIn(limitValues.limits, this.getLimitsValues())

		// In the case of indirect limitations it was necessary to have all keys (it is necessary to validate)
		const keys = this.externalProperties.modelKeys
		_forEach(keys, (keyField, keyAreaName) => Reflect.set(limitValues.limits, keyAreaName, keyField.value))

		// Apply search query
		if (searchQuery !== undefined && searchQuery !== null)
			Reflect.set(limitValues.queryParams, this.searchId, searchQuery)
		else if (!lazyLoad)
		{
			// If it was a reload, we need to remove the option currently selected
			// so that it is not added to the list when it does not belong
			selectedValue = limitValues.limits[this.dbArea]
			Reflect.set(limitValues.limits, this.dbArea, null)
		}

		// Reduce unnecessary requests when limits have not changed
		if (_isEqual(limitValues, this.prevLimitValues))
			return

		this.prevLimitValues = limitValues

		// Put the limit values in Navigation (history) before making the request to the server.
		if (typeof this.vueContext.setEntryValue !== 'function')
		{
			this.vueContext.$eventTracker.addError({
				origin: 'reloadLookupContent (fieldControl)',
				message: 'The control does not have access to history to set the limits - «setEntryValue».'
			})
			return
		}

		_forEach(limitValues.limits, (value, key) => {
			const entry = {
				navigationId: this.vueContext.navigationId,
				key,
				value
			}
			this.vueContext.setEntryValue(entry)
		})

		// Make request
		const params = {
			Identifier: this.id,
			Values: limitValues.queryParams
		}

		this.addLoadingProc(
			netAPI.postData(
				baseApiController,
				'ReloadDBEdit',
				params,
				(data, response) => {
					const requestNumber = response.headers['reloaddbeditrequestnumber']
					// The list can make more than one 'simultaneous' request to the server and only the response of the last request is interest
					if (Number(requestNumber) !== this.requestNumberReload) {
						this.isDebounce = false
						return
					}

					// Process the received data
					if (response.data.Success)
					{
						// Update model data
						this.modelFieldRef?.updateValue(data)
						// If the user is still searching for the desired record, we don't update the key
						if (!isSearching)
						{
							// The key should be updated with the previously selected value, if it's in the list, or an empty string otherwise
							const selectedValueInList = data.List.some((option) => option.key === selectedValue)
							this.lookupKeyModelFieldRef?.updateValue(selectedValueInList ? selectedValue : data.Selected)
						}
					}
					this.isDebounce = false
				},
				() => this.isDebounce = false,
				{
					headers: {
						ReloadDBEditRequestNumber: this.requestNumberReload += 1
					}
				},
				this.vueContext.navigationId))
	}

	/**
	 * Makes a request to the server to obtain the value of the fields dependent on it (and currently selected value), including the fields of the field itself.
	 */
	getDependants()
	{
		if (!this.vueContext.formInfo || !this.vueContext.authData.isAllowed) // TODO: Change it!
			return

		if (!this.lookupKeyModelFieldRef)
			return

		var values = {},
			baseApiController = _capitalize(this.vueContext.formInfo.area)

		// Limits
		_assignIn(values, this.getLimitsValues())

		// In the case of indirect limitations it was necessary to have all keys (it is necessary to validate)
		const keys = this.externalProperties.modelKeys

		_forEach(keys, (keyField, keyAreaName) => { Reflect.set(values, keyAreaName, keyField.value) })

		// Put the limit values in Navigation (history) before making the request to the server.
		if (typeof this.vueContext.setEntryValue !== 'function')
		{
			this.vueContext.$eventTracker.addError({
				origin: 'getDependants (fieldControl)',
				message: 'The control does not have access to history to set the limits - «setEntryValue».'
			})
			return
		}

		_forEach(values, (value, key) => {
			const entry = {
				navigationId: this.vueContext.navigationId,
				key,
				value
			}
			this.vueContext.setEntryValue(entry)
		})

		// Make request
		const params = {
			Identifier: this.id,
			Selected: this.lookupKeyModelFieldRef.value
		}

		this.addLoadingProc(
			netAPI.postData(
				baseApiController,
				'GetDependants',
				params,
				(data, response) => {
					const requestNumber = response.headers['getdependantsrequestnumber']
					// The list can make more than one 'simultaneous' request to the server and only the response of the last request is interest
					if (Number(requestNumber) !== this.requestNumberGetDependants)
						return

					// Process the received data
					if (response.data.Success)
					{
						// Update model data (including the Key/Value of the field itself)
						if (this.dependentFields)
						{
							let _depFieldsRef = this.dependentFields.call(this.vueContext)
							// Warning: Never remove the curly braces from the iteration function.
							// Without the braces, when filling in boolean dependents, assigning "false" will stop the cycle and no further fields will be filled
							_forEach(data, (depFieldValue, depFieldId) => { _depFieldsRef[depFieldId] = depFieldValue })
						}

						// Ensure that the chosen option exists
						if (this.modelFieldRef && this.lookupKeyModelFieldRef)
						{
							const selectedOption = {
								key: this.lookupKeyModelFieldRef.value,
								value: this.modelFieldRef.value
							}

							if (!_isEmpty(selectedOption.key) && !_isEmpty(selectedOption.value) && !_some(this.modelFieldRef.options, selectedOption))
								this.modelFieldRef.options.push(selectedOption)
						}
					}
				},
				undefined,
				{
					headers: {
						GetDependantsRequestNumber: this.requestNumberGetDependants += 1
					}
				},
				this.vueContext.navigationId),
			true)
	}

	/**
	 * Handle the modal closing event
	 */
	handleSeeMoreClose()
	{
		this.seeMoreIsVisible = false
		this.seeMoreParams = {}
	}

	/**
	 * Handle the Key selection event
	 */
	handleSeeMoreChoice(selectedItem)
	{
		this.handleSeeMoreClose()
		if (this.lookupKeyModelFieldRef)
			this.lookupKeyModelFieldRef.updateValue(selectedItem)
	}

	/**
	 * Handle the opening «See more..» event
	 */
	handleSeeMore()
	{
		this.seeMoreParams = {
			id: this.vueContext.primaryKeyValue,
			limits: this.getLimitsValues(),
			navigationId: this.vueContext.navigationId
		}
		this.seeMoreIsVisible = true
	}

	/**
	 * Handler for the "View details" event.
	 */
	handleViewDetails(rowId)
	{
		if (!_isEmpty(this.supportForm) && !_isEmpty(rowId))
			this.vueContext.navigateToForm(this.supportForm, 'SHOW', rowId, { isControlled: true })
	}

	/**
	 * Handler for the new record insertion event
	 */
	handleOnInsert()
	{
		if (!_isEmpty(this.supportForm))
			this.vueContext.navigateToForm(this.supportForm, 'NEW', undefined, { isControlled: true })
	}

	/**
	 * Handler to fetch the content of the lookup.
	 */
	handleBeforeShow()
	{
		this.reloadLookupContent(null, true, true)
	}

	/**
	 * Adds the async process to the watch list of loading requests.
	 * @param {Promise} cbPromise he «Promise» object of the process
	 * @param {Boolean} affectsParent If affects the parent context
	 */
	addLoadingProc(cbPromise, affectsParent)
	{
		if (affectsParent)
			this.addLoadingProcToParent(this.componentOnLoadProc.addWL(cbPromise))
		else
			this.componentOnLoadProc.addWL(cbPromise)
	}
}

/**
 * Form Table list control
 */
export class TableListControl extends BaseControl
{
	constructor(options, _vueContext, store)
	{
		let systemDataStore = store ?? {}
		if (typeof store === 'undefined')
			systemDataStore = useSystemDataStore()

		const importExportResources = new controlsResources.ImportExportResources(_vueContext.$getResource)
		const tableTexts = new controlsResources.TableListMainResources(_vueContext.$getResource)

		// Init default values of control properties
		super({
			/** The type of the control class */
			type: 'List',
			columns: [],
			columnsOriginal: [],
			columnsCustom: [],
			columnTotalizers: [],
			rows: [],
			rowFormProps: [],
			totalRows: 0,
			hasMorePages: false,
			headerLevel: 2,
			/** List of limits (value getter + identifier). Used in requests for the new rows list */
			controlLimits: [],
			/**
			 * List of limits with fixed value (value + identifier).
			 * Used, for example, in See More lists, to apply dynamic values received from the form (for example, 'Field' type limit).
			 */
			fixedControlLimits: undefined,
			isLoaded: false,
			/** Data already requested from the server at least once */
			dataAlreadyRequested: false,
			hydrate: listFunctions.hydrateTableData,
			rowsSelected: {},
			rowsChecked: {},
			rowsDirty: {},
			searchValue: '',
			advancedFilters: [],
			columnFilters: {},
			searchBarFilters: {},
			groupFilters: [],
			activeFilters: {},
			globalEvents: [],
			internalEvents: [],
			columnSorting: {},
			dataImportResponse: {},
			rowComponent: 'q-table-row',
			formName: '',
			newRowID: '',
			signal: {},
			subSignals: {
				config: {},
				columnConfig: {},
				advancedFilters: {},
				advancedFiltersNew: {},
				viewSave: {},
				views: {}
			},
			confirmChanges: false,
			config: {
				serverMode: computed(() => !!options?.config?.serverMode),
				perPageDefault: computed(() => systemDataStore.system ? systemDataStore.system.defaultListRows : options.config !== undefined ? options.config.perPage !== undefined ? options.config.perPage : 10 : 10),
				perPageSelected: null,
				page: 1,
				perPage: 10,
				perPageOptions: [],
				actionsPlacement: systemInfo.layout.DbEditActionPlacement,
				paginationPlacement: systemInfo.layout.DbEditPagerPlacement,
				rowActionDisplay: systemInfo.layout.RowActionDisplay,
				showRowActionText: systemInfo.layout.RowActionDisplay !== 'inline',
				hasTextWrap: false,
				rowValidation: {
					message: computed(() => tableTexts.pendingRecords),
					fnValidate: (row) => row.Fields.isValid
				},
				allowFileExport: false,
				allowFileImport: false,
				exportOptions: importExportResources.exportOptions,
				importOptions: importExportResources.importOptions,
				importTemplateOptions: importExportResources.importTemplateOptions,
				hasRowDragAndDrop: false,
				tableTitle: '',
				tableNamePlural: '',
				configOptions: [],
				configOptionsUse: [],
				viewManagement: qEnums.tableViewManagementModes.none,
				hasCustomColumns: false,
				searchBarConfig: {
					visibility: false,
					message: null,
				},
				filtersVisible: false,
				allowColumnFilters: false,
				allowColumnSort: false,
				defaultColumnSorting: {
					columnName: '',
					sortOrder: 'asc'
				},
				showRecordCount: false,
				showRowsSelectedCount: false,
				linkRowsSelectedAndChecked: false,
				menuForJump: '',
				sortByField: false,
				showRowDragAndDropOption: false,
				showLimitsInfo: false,
				showAfterFilter: false,
				columnResizeOptions: {},
				permissions: {
					canView: true,
					canEdit: true,
					canDuplicate: true,
					canDelete: true,
					canInsert: true
				},
				insertCondition: {
					fnFormula: () => true,
					dependencyEvents: []
				},
				canInsert: false,
				rowActionClasses: {
					'dropdown-item': true
				},
				rowKeyToScroll: '',
				resourcesPath: systemInfo.resourcesPath,
				navigatedRowKeyPath: null,
				emptyRowImg: 'empty_card_container.png',
				onLoadSelectFirst: false,
				rerenderRowsOnNextChange: false,
				setNavOnUpdate: false
			},
			texts: tableTexts,
			// The translation mechanism for the filter operators arrays
			filterOperators: searchFilterData.getWithTranslation(_vueContext.$getResource).operators.elements,
			allSelectedRows: 'false',
			headerRow: {
				isNavigated: false
			},
			// The custom callback method to hydrate the page view model data
			fnHydrateViewModel: undefined,
			linkedForm: undefined,
			activeViewModeId: 'LIST',
			locale: computed(() => systemDataStore.system.currentLang)
		}, _vueContext)

		_merge(this, options || {})

		// Set columns to use custom columns if defined, otherwise original columns (generated)
		this.columnsCustom = ref(this.columnsCustom)
		this.columnsOriginal = ref(this.columnsOriginal)
		this.columns = computed(() => !_isEmpty(this.columnsCustom.value) ? this.columnsCustom.value : this.columnsOriginal.value)

		// Set perPage to use selected value or default if no value was selected
		this.config.perPageDefault = ref(this.config.perPageDefault)
		this.config.perPageSelected = ref(this.config.perPageSelected)
		this.config.perPage = computed(() => this.config.perPageSelected.value ? this.config.perPageSelected.value : this.config.perPageDefault.value)

		// Create reactive copy of configuration options that accounts for whether the table is in readonly mode
		this.config.configOptions = ref(this.config.configOptions)
		this.config.configOptionsUse = computed(() => {
			let configOptions = cloneDeep(this.config.configOptions.value)
			listFunctions.updateConfigOptions(configOptions, this.config.viewManagement, this.confirmChanges, this.readonly)
			return configOptions
		})
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		this.isLoaded = false

		const genericDataStore = useGenericDataStore()

		// In maintenance mode, set server-mode tables to readonly mode
		this.readonly = computed(() => this.isBlocked || (this.config.serverMode && genericDataStore.maintenance.isActive))

		this.initEvents()
		this.initUserConfig()
	}

	/**
	 * Performs additional init operations after the table data is ready.
	 */
	initData()
	{
		if (this.config.permissions.canInsert)
		{
			const insertCondition = this.config.insertCondition

			if (typeof insertCondition.runFormula !== 'function')
			{
				insertCondition.runFormula = async () => {
					this.config.canInsert = await validateFormula(insertCondition, this.vueContext.model)
				}
				insertCondition.runFormula()

				const events = insertCondition.dependencyEvents

				// Add event handling if necessary
				// internalEvents does not exist in some cases like in "see more" popups
				this.vueContext.internalEvents?.offMany(events, insertCondition.runFormula)
				this.vueContext.internalEvents?.onMany(events, insertCondition.runFormula)
			}
		}
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			onChangeQuery: (eventData) => this.onTableListChangeQuery(eventData),
			saveView: (eventData) => this.onTableListSaveView(eventData),
			renameView: (eventData) => this.onTableListRenameView(eventData),
			copyView: (eventData) => this.onTableListCopyView(eventData),
			selectView: (eventData) => this.onTableListSelectView(eventData),
			closeView: (eventData) => this.onTableListCloseView(eventData),
			viewAction: (eventData) => this.onTableListViewAction(eventData),
			onExportData: (eventData) => this.onTableListExportData(eventData, false),
			onImportData: (eventData) => this.onTableListImportData(eventData),
			onExportTemplate: (eventData) => this.onTableListExportData(eventData, true),
			'update:active-view-mode': (eventData) => this.updateActiveViewMode(eventData),
			removeRow: (eventData) => this.onRemoveRow(eventData),
			rowAdd: (eventData) => this.onTableListRowAdd(eventData),
			rowEdit: (eventData) => this.onTableListRowEdit(eventData),
			rowsDelete: (eventData) => this.onTableListRowsDelete(eventData),
			rowReorder: (eventData) => this.onTableListRowReorder(eventData),
			toggleRowsDragDrop: () => this.onToggleRowsDragDrop(),
			rowGroupAction: (eventData) => this.onTableListRowGroupAction(eventData),
			goToRow: (eventData) => this.onGoToRow(eventData),
			selectRow: (eventData) => this.onSelectRow(eventData),
			unselectRow: (eventData) => this.onUnselectRow(eventData),
			selectRows: (eventData) => this.onSelectRows(eventData),
			unselectAllRows: (eventData) => this.onUnselectAllRows(eventData),
			executeAction: (eventData) => this.onTableListExecuteAction(eventData),
			rowAction: (eventData) => this.onTableListExecuteAction(eventData),
			cellAction: (eventData) => this.onTableListCellAction(eventData),
			updateCell: (eventData) => this.onTableListUpdateCell(eventData),
			applyColumnConfig: (eventData) => this.onTableListApplyColumnConfig(eventData),
			resetColumnConfig: (eventData) => this.onTableListResetColumnConfig(eventData),
			resetColumnSizes: (eventData) => this.onTableListResetColumnSizes(eventData),
			resetColumnOrdering: () => this.onTableListResetColumnOrdering(),
			showPopup: (eventData) => this.setModal(eventData),
			hidePopup: (eventData) => this.removeFieldModal(eventData),
			setInfoMessage: (eventData) => this.setInfoMessage(eventData),
			showAdvancedFilters: (eventData) => this.setAdvancedFiltersPopup(eventData),
			addAdvancedFilter: (eventData) => this.addAdvancedFilter(eventData),
			editAdvancedFilters: (eventData) => this.editAdvancedFilters(eventData),
			removeAdvancedFilter: (eventData) => this.removeAdvancedFilter(eventData),
			setAdvancedFilterState: (eventData) => this.setAdvancedFilterState(eventData),
			removeAllAdvancedFilters: () => this.removeAllAdvancedFilters(),
			removeColumnFilter: (eventData) => this.removeColumnFilter(eventData),
			'update:activeFilters': (eventData) => this.updateActiveFilters(eventData),
			'update:groupFilters': (eventData) => this.updateGroupFilters(eventData),
			updateConfig: () => this.updateConfig(),
			setProperty: (...args) => this.setProperty(...args),
			setRowIndexProperty: (...args) => this.setRowIndexProperty(...args),
			setArraySubPropWhere: (...args) => this.setArraySubPropWhere(...args),
			insertForm: (...args) => this.onTableListInsertForm(...args),
			cancelInsert: (...args) => this.onTableListCancelInsertRow(...args),
			signalComponent: (...args) => this.signalComponent(...args),
			toggleTextWrap: () => { this.config.hasTextWrap = !this.config.hasTextWrap },
			setQtableAllSelected: (eventData) => this.onSetQtableAllSelected(eventData),
			fetchQtableAllSelected: (eventData) => this.onFetchQtableAllSelected(eventData)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Initialization of listeners for events on which functions such as content reloading depend
	 */
	initEvents()
	{
		listFunctions.initTableEvents(this)
	}

	/**
	 * Set available user configuration options.
	 */
	initUserConfig()
	{
		const configOptions = []

		const allowBasicConfiguration = [
			qEnums.tableViewManagementModes.nonPersistent,
			qEnums.tableViewManagementModes.persistOne,
			qEnums.tableViewManagementModes.persistMany
		].includes(this.config.viewManagement)

		this.config.allowAdvancedFilters = this.config.allowColumnConfiguration =
			allowBasicConfiguration
		this.config.allowManageViews =
			this.config.viewManagement === qEnums.tableViewManagementModes.persistMany

		if (this.config.allowManageViews)
		{
			configOptions.push({
				id: 'viewSaveChanges',
				elementId: 'view-save-changes',
				icon: {
					icon: 'save'
				},
				text: this.texts.saveChanges,
				active: false,
				visible: true,
				inReadonly: false
			})
		}

		if (this.config.allowColumnConfiguration && this.activeViewModeId === 'LIST')
		{
			configOptions.push({
				id: 'columnConfig',
				elementId: 'column-config',
				componentId: 'columnConfig',
				icon: {
					icon: 'list'
				},
				text: this.texts.configureColumns,
				separatorBefore: true,
				active: true,
				visible: true
			})
		}

		if (this.config.allowAdvancedFilters)
		{
			configOptions.push({
				id: 'advancedFilters',
				elementId: 'advanced-filters',
				componentId: 'advancedFilters',
				icon: {
					icon: 'filter'
				},
				text: this.texts.configureFilters,
				active: true,
				visible: computed(() => this.advancedFilters?.length > 0 || !_isEmpty(this.subSignals.advancedFilters.columnFilter))
			})
		}

		if (this.config.allowManageViews)
		{
			configOptions.push({
				id: 'views',
				elementId: 'views',
				componentId: 'views',
				icon: {
					icon: 'view-manager'
				},
				text: this.texts.manageViews,
				active: true,
				visible: true,
				inReadonly: false
			})
			configOptions.push({
				id: 'viewSave',
				elementId: 'view-save',
				componentId: 'viewSave',
				icon: {
					icon: 'add'
				},
				text: this.texts.createView,
				separatorBefore: true,
				active: true,
				visible: true,
				inReadonly: false
			})
		}

		this.config.configOptions = configOptions
	}

	onTableListChangeQuery(eventData) { this.componentOnLoadProc.addWL(this.vueContext.onTableListChangeQuery(this, eventData)) }
	onTableListSaveView(eventData) { this.vueContext.onTableListSaveView(this, eventData) }
	onTableListRenameView(eventData) { this.componentOnLoadProc.addWL(this.vueContext.onTableListRenameView(this, eventData)) }
	onTableListCopyView(eventData) { this.vueContext.onTableListCopyView(this, eventData) }
	onTableListCloseView(eventData) { this.componentOnLoadProc.addWL(this.vueContext.onTableListCloseView(this, eventData)) }
	onTableListSelectView(eventData) { this.componentOnLoadProc.addWL(this.vueContext.onTableListSelectView(this, eventData)) }
	onTableListViewAction(eventData) { this.componentOnLoadProc.addWL(this.vueContext.onTableListViewAction(this, eventData)) }
	onTableListExportData(eventData, template) { asyncProcM.addBusy(this.vueContext.onTableListExportData(this, eventData, template), 'Export...') }
	onTableListImportData(eventData) { asyncProcM.addBusy(this.vueContext.onTableListImportData(this, eventData), 'Import...') }
	updateActiveViewMode(eventData) { this.vueContext.updateActiveViewMode(this, eventData) }
	onRemoveRow(eventData) { this.vueContext.onRemoveRow(this, eventData) }
	onTableListRowAdd(eventData) { this.vueContext.onTableListRowAdd(this, eventData) }
	onTableListRowEdit(eventData) { this.vueContext.onTableListRowEdit(this, eventData) }
	onTableListRowsDelete(eventData) { this.vueContext.onTableListRowsDelete(this, eventData) }
	onTableListRowReorder(eventData) { this.vueContext.onTableListRowReorder(this, eventData) }
	onToggleRowsDragDrop() { this.vueContext.onToggleRowsDragDrop(this) }
	onTableListRowGroupAction(eventData) { this.vueContext.onTableListRowGroupAction(this, eventData) }
	onGoToRow(eventData) { this.vueContext.onGoToRow(this, eventData) }
	onSelectRow(eventData) { this.vueContext.onSelectRow(this, eventData) }
	onUnselectRow(eventData) { this.vueContext.onUnselectRow(this, eventData) }
	onSelectRows(eventData) { this.vueContext.onSelectRows(this, eventData) }
	onUnselectAllRows(eventData) { this.vueContext.onUnselectAllRows(this, eventData) }
	onTableListExecuteAction(eventData) { this.vueContext.onTableListExecuteAction(this, eventData) }
	onTableListCellAction(eventData) { this.vueContext.onTableListCellAction(this, eventData) }
	onTableListUpdateCell(eventData) { this.vueContext.onTableListUpdateCell(this, eventData) }
	onTableListApplyColumnConfig(eventData) { this.vueContext.onTableListApplyColumnConfig(this, eventData) }
	onTableListResetColumnConfig(eventData) { this.vueContext.onTableListResetColumnConfig(this, eventData) }
	onTableListResetColumnSizes(eventData) { this.vueContext.onTableListResetColumnSizes(this, eventData) }
	onTableListResetColumnOrdering() { this.reload() }
	setInfoMessage(eventData) { this.vueContext.setInfoMessage(eventData) }
	setAdvancedFiltersPopup(eventData) { this.vueContext.setAdvancedFiltersPopup(this, eventData[0], eventData[1]) }
	addAdvancedFilter(eventData) { this.componentOnLoadProc.addWL(this.vueContext.addAdvancedFilter(this, eventData)) }
	editAdvancedFilters(eventData) { this.componentOnLoadProc.addWL(this.vueContext.editAdvancedFilters(this, eventData)) }
	removeAdvancedFilter(eventData) { this.componentOnLoadProc.addWL(this.vueContext.removeAdvancedFilter(this, eventData)) }
	setAdvancedFilterState(eventData) { this.componentOnLoadProc.addWL(this.vueContext.setAdvancedFilterState(this, eventData[0], eventData[1])) }
	removeAllAdvancedFilters() { this.componentOnLoadProc.addWL(this.vueContext.removeAllAdvancedFilters(this)) }
	removeColumnFilter(eventData) { this.vueContext.removeColumnFilter(this, eventData) }
	updateConfig(...args) { this.vueContext.updateConfig(this, ...args) }
	setProperty(...args) { this.vueContext.setProperty(this, ...args) }
	setRowIndexProperty(...args) { listFunctions.setRowIndexProperty(this, ...args) }
	setArraySubPropWhere(...args) { this.vueContext.setArraySubPropWhere(this, ...args) }
	onTableListInsertForm(...args) { this.vueContext.onTableListInsertForm(this, ...args) }
	onTableListCancelInsertRow(...args) { this.vueContext.onTableListCancelInsertRow(this, ...args) }
	signalComponent(...args) { this.vueContext.signalComponent(this, ...args) }
	onSetQtableAllSelected(eventData) { this.vueContext.onSetQtableAllSelected(this, eventData) }
	onFetchQtableAllSelected(eventData) { this.vueContext.onFetchQtableAllSelected(this, eventData) }

	/**
	 * Sets the value of the active filters
	 * @param {object} activeFilters The active filters
	 */
	updateActiveFilters(activeFilters)
	{
		this.activeFilters = activeFilters
		const params = {
			tableConfiguration: listFunctions.getTableConfiguration(this)
		}

		this.vueContext.updateConfig(this)
		this.reload(params)
	}

	/**
	 * Sets the value of the group filters
	 * @param {Array} groupFilters The group filters
	 */
	updateGroupFilters(groupFilters)
	{
		this.groupFilters = groupFilters
		const params = {
			tableConfiguration: listFunctions.getTableConfiguration(this)
		}

		this.vueContext.updateConfig(this)
		this.reload(params)
	}

	/**
	 * Searches for a row with the specified id
	 * @param {string || array} id The id to search
	 * @param {boolean} selectFirst Whether or not to select the first row
	 * @returns The row with specified id, or, depending on the "selectFirst" option, null or the first row
	 */
	getRow(id, selectFirst = false)
	{
		const rows = this.rows
		const rownNum = rows.length

		return listFunctions.getRowByKeyPath(rows, id) ?? (selectFirst && rownNum > 0 ? rows[0] : null)
	}

	/**
	 * Selects the desired row (if none is found selects the first)
	 * @param {string || array} id The desired id
	 */
	selectRow(id)
	{
		const row = this.getRow(id, true)

		// If row with this ID exists or first row exists
		if (row !== null)
			this.onSelectRow({ rowKeyPath: listFunctions.getRowKeyPath(this.rows, row) })
	}

	/**
	 * Runs after each time the table finishes loading
	 */
	afterLoaded()
	{
		// Use to select all the previously selected rows before navigating
		if (this.config.rowClickActionInternal !== 'selectSingle')
			return

		// Gets the base navigation level for the form
		let nav = this.vueContext.navigation.currentLevel
		while (nav.isNested)
			nav = nav.previousLevel

		// Selects the previously selected rows that weren't opened in a support form
		let rowId = this.vueContext.navigation.currentLevel.entries ? this.vueContext.navigation.currentLevel.entries[`TableListControl_${this.id}`] : null
		// Convert rowId to row key path array if it has multiple keys or a string if it is a single key
		if (rowId !== undefined && rowId !== null)
		{
			rowId = rowId.split(',')
			if (Array.isArray(rowId) && rowId.length === 1)
				rowId = rowId[0]
		}

		if (nav.params.returnControl === this.id) // If the opened record in a support form belongs to this table
			this.selectRow(nav.params.previouslyRemovedRowKey)
		else if (rowId) // If this row was selected to show an extended support form
			this.selectRow(rowId)
		else if (this.config.onLoadSelectFirst)
			this.selectRow()
	}

	/**
	 * Reloads the data of the list
	 * @param {object} params The parameters for loading the data which are passed to fetchListData()
	 */
	reload(params)
	{
		const model = this.vueContext.model?.serverObjModel
		if (model)
		{
			params = {
				...(params ?? {}),
				model
			}
		}

		return this.componentOnLoadProc.addWL(this.vueContext.fetchListData(this, params, this.fnHydrateViewModel))
	}
}

/**
 * Form Tree table list control
 */
export class TreeTableListControl extends TableListControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'TreeList',
			hydrate: listFunctions.hydrateTreeTableData,
			clipboard: {},
			rowComponent: 'q-tree-table-row',
			rawRows: [],
			config: {
				showRowActionText: false,
				allowColumnResize: false,
				filtersVisible: false,
				allowColumnFilters: false,
				allowColumnSort: false,
				globalSearch: {
					visibility: false
				},
				searchList: {
					empty: true,
					values: [],
					numRows: 0,
					currentIdx: 0
				},
				treeListDefinitions: {
					branchAreas: {},
					rowModel: (row) => row
				}
			}
		}, _vueContext)

		_mergeWith(this, options || {}, genericFunctions.mergeOptions)

		// Set the first column as tree Show/Hide (if none exist)
		if (this.columnsOriginal.length > 0 && !_some(this.columnsOriginal, { hasTreeShowHide: true }))
			Reflect.set(this.columnsOriginal[0], 'hasTreeShowHide', true)
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		// Apply the rest of the inherited handlers (which also don't override)
		super.initHandlers()

		const handlers = {
			getInsertFormName: (eventData) => this.getInsertFormName(eventData),
			treeLoadBranchData: (eventData) => this.treeLoadBranchData(this, eventData)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Runs after each time the table finishes loading
	 */
	afterLoaded()
	{
		// Override function to prevent selecting rows incorrectly
	}

	/**
	 * Return the name of the form to open depending on the selected row
	 * @param {object} row The selected row
	 */
	getInsertFormName(row)
	{
		const formsList = Object.entries(this.config.formsDefinition)

		// Default level if no row is selected
		let formLevel = 0

		// Checks for current level and finds the next one
		if (row)
			formLevel = this.config.formsDefinition[row.Form].level + 1

		// If the level is out of bounds, use the last level
		if (formLevel > formsList.length - 1)
			formLevel = formsList.length - 1

		// Get form name based on level
		const formToOpen = formsList.find((entry) => entry[1]?.level === formLevel)
		if (formToOpen)
			return formToOpen[0]
		return null
	}

	/**
	 * The method responsible for making the server request and loading the children of the branch (if any)
	 * @param {object} listConf The list configuration
	 * @param {object} eventData Event object that contains the current parent row
	 */
	treeLoadBranchData(listConf, eventData)
	{
		if (eventData.row?.alreadyLoaded === false)
		{
			// Set current row as row to navigate to after reloading
			listConf.config.navigatedRowKeyPath = listFunctions.getRowKeyPath(listConf.rows, eventData.row)

			this.componentOnLoadProc.addWL(this.vueContext.fetchListData(this, {
				queryParams: {
					currentBranch: eventData.row?.BranchId + 1,
					currentSelectedKey: eventData.row?.rowKey
				}
			},
			this.fnHydrateViewModel,
			(data) => {
				const rowKeyToScroll = this.vueContext.currentControl?.data?.rowKey ?? null
				eventData.row?.hydrateChildrenData(data.Tree, rowKeyToScroll)
				// Prevent double request
				eventData.row.alreadyLoaded = true
			}), 300)
		}
	}
}

/**
 * Form Multiple Values table list control
 */
export class MultipleValuesControl extends TableListControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'MultipleValuesList',
			modelFieldOptions: null,
			modelFieldOptionsRef: null,
			config: {
				filtersVisible: false,
				allowColumnFilters: false,
				allowColumnSort: false,
				globalSearch: {
					visibility: false
				},
				rowClickActionInternal: 'selectMultiple',
				showFooter: false
			}
		}, _vueContext)

		_mergeWith(this, options || {}, genericFunctions.mergeOptions)
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		// Set reference to the model field that contains the options
		if (!_isEmpty(this.modelFieldOptions) && this.vueContext.model)
			if (_has(this.vueContext.model, this.modelFieldOptions))
				this.modelFieldOptionsRef = _get(this.vueContext.model, this.modelFieldOptions)
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			setQtableAllSelected: (eventData) => this.onSetQtableAllSelected(eventData),
			fetchQtableAllSelected: (eventData) => this.onFetchQtableAllSelected(eventData)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	onSetQtableAllSelected(eventData)
	{
		super.onSetQtableAllSelected(eventData)
	}

	onFetchQtableAllSelected(eventData)
	{
		super.onFetchQtableAllSelected(eventData)
	}
}

/**
 * Multiple Values extension control
 */
export class MultipleValuesExtensionControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'MultipleValuesExtension',
			texts: new controlsResources.MultipleValuesExtensionResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Document control
 */
export class DocumentControl extends DatabaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'Document',
			versionsInfo: [],
			extensions: [],
			texts: new controlsResources.DocumentResources(_vueContext.$getResource),
			resourcesPath: systemInfo.resourcesPath,
			documentProperties: null,
			documentFK: null,
			fileProperties: {},
			documentVersions: {},
			editing: false,
			currentVersion: '1',
			versioningIsOn: false,
			usesTemplates: false,
			viewType: qEnums.documentViewTypeMode.preview,
			documentTemplateAction: undefined,
			documentTemplatesIsVisible: false,
			documentTemplatesParams: undefined
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			versioning: this.versioningIsOn,
			editing: this.editing,
			currentVersion: this.currentVersion,
			extensions: this.extensions,
			maxFileSize: this.maxFileSize,
			versions: this.documentVersions,
			versionsInfo: this.versionsInfo,
			fileProperties: this.fileProperties,
			popupIsVisible: this.popupIsVisible,
			resourcesPath: this.resourcesPath,
			usesTemplates: this.usesTemplates
		}
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		this.setTickets()

		this.documentProperties = computed(() => this.modelFieldRef.properties)
		this.documentFK = computed(() => this.modelFieldRef.documentFK)

		this.documentVersions = computed(() => this.documentProperties.value?.versions ?? {})
		this.editing = computed(() => this.documentProperties.value?.editing ?? false)
		this.currentVersion = computed(() => Object.keys(this.documentVersions).reduce((a, b) => Number(a) < Number(b) ? b : a, '1'))

		if (!_isEmpty(this.valueChangeEvent) && this.vueContext.internalEvents)
		{
			// This watcher should only be necessary for dependent document fields.
			this.vueContext.internalEvents.on(this.valueChangeEvent, () => {
				if (this.modelFieldRef.isFixed)
					this.setTickets()
			})
		}
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const deleteTypes = this.modelFieldRef.currentDocument.deleteTypes

		const handlers = {
			fileError: (eventData) => this.handleFileError(eventData),
			submitFile: (eventData) => this.setFile(eventData),
			editFile: () => this.setEditingState(),
			getProperties: () => this.getFileProperties(),
			getVersionHistory: () => this.getVersionsInfo(),
			getFile: (eventData) => this.handleGetFile(eventData),
			deleteLast: () => this.deleteFile(deleteTypes.current),
			deleteHistory: () => this.deleteFile(deleteTypes.versions),
			deleteFile: () => this.deleteFile(deleteTypes.all),
			showPopup: (eventData) => this.setModal(eventData),
			hidePopup: (eventData) => this.removeFieldModal(eventData),
			showTemplatesPopup: (eventData) => this.handleDocumentTemplates(eventData),
			documentTemplatesChoice: (eventData) => this.handleDocumentTemplatesChoice(eventData),
			documentTemplatesClose: (eventData) => this.handleDocumentTemplatesClose(eventData)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Sets the tickets to retrieve every document version from the server.
	 */
	setTickets()
	{
		const baseArea = this.modelFieldRef.area
		const areaKeyField = this.vueContext.dataApi.keys[baseArea.toLowerCase()]
		const navigationId = this.vueContext.navigationId

		this.modelFieldRef.setTickets(areaKeyField.value, navigationId)
	}

	/**
	 * Marks the document as being in editing mode.
	 */
	setEditingState()
	{
		if (typeof this.modelFieldRef?.tickets !== 'object' || this.editing)
			return

		this.documentProperties.value.editing = true
		this.downloadFile(this.currentVersion)
	}

	/**
	 * Creates a new version of the document.
	 * @param {object} fileData The document file's data
	 */
	setFile(fileData)
	{
		if (typeof this.modelFieldRef?.tickets !== 'object' || typeof fileData !== 'object')
			return

		const currentDocument = this.modelFieldRef.currentDocument
		const versionSubmitAction = currentDocument.versionSubmitAction
		const hasUnsavedFile = currentDocument.value.fileData !== null
		const currentVersion = this.currentVersion

		let submitMode = versionSubmitAction.insert
		if (typeof fileData.isNewVersion === 'boolean')
		{
			if (fileData.isNewVersion)
				submitMode = versionSubmitAction.submit
			else
				submitMode = versionSubmitAction.unlock
		}

		const properties = this.documentProperties.value

		if (submitMode !== versionSubmitAction.unlock)
		{
			currentDocument.setNewFile(fileData.file, submitMode, fileData.version)

			// Set the uploaded document as the current one.
			this.modelFieldRef.updateValue(currentDocument.properties.name)
			this.documentFK.updateValue('')

			// Set the versions.
			if (hasUnsavedFile)
			{
				if (properties.versions !== null)
					delete properties.versions[currentVersion]
				delete this.modelFieldRef.tickets[currentVersion]
			}

			if (properties.versions !== null)
				properties.versions[fileData.version] = ''
			this.modelFieldRef.tickets[fileData.version] = ''
		}

		properties.editing = false
	}

	/**
	 * Deletes the document.
	 * @param {number} deleteType The type of delete action
	 */
	deleteFile(deleteType)
	{
		if (typeof this.modelFieldRef?.tickets !== 'object' || typeof deleteType !== 'number')
			return

		const currentDocument = this.modelFieldRef.currentDocument
		const deleteTypes = currentDocument.deleteTypes

		if (!Object.values(deleteTypes).includes(deleteType))
			return

		const currentVersion = this.currentVersion
		// If the original value is empty, that means there's no file in the DB to delete.
		if (_isEmpty(this.modelFieldRef.originalValue))
			currentDocument.reset()
		else
			currentDocument.delete(deleteType)

		if (deleteType === deleteTypes.current)
		{
			if (currentDocument.value.fileData !== null)
			{
				// If the user had uploaded a new version of the file, we simply reset the field to it's original value.
				this.documentProperties.resetValue()
				this.modelFieldRef.resetValue()
				this.documentFK.resetValue()

				if (this.documentProperties.value.versions !== null)
					delete this.documentProperties.value.versions[currentVersion]
			}
			else
			{
				// If the user didn't upload any new file, we set the version before last as the current version.
				const prevVersion = Object.keys(this.documentVersions).reduce((a, b) => Number(a) < Number(b) && b !== currentVersion ? b : a)
				this.setFileProperties(prevVersion)

				delete this.modelFieldRef.tickets[currentVersion]
			}
		}
		else if (deleteType === deleteTypes.versions)
		{
			const versionTicket = this.modelFieldRef.tickets[currentVersion]
			const versionKey = this.documentVersions[currentVersion]

			this.documentProperties.value.versions = { [currentVersion]: versionKey }
			this.modelFieldRef.tickets = {
				main: this.modelFieldRef.tickets.main,
				[currentVersion]: versionTicket
			}
		}
		else
		{
			this.documentProperties.updateValue(currentDocument.getEmptyProperties())
			this.modelFieldRef.clearValue()
			this.documentFK.clearValue()
		}
	}

	/**
	 * Gets the properties of the current document and sets "fileProperties" with them.
	 */
	getFileProperties()
	{
		if (typeof this.modelFieldRef?.tickets !== 'object')
			return

		const currentDocument = this.modelFieldRef.currentDocument

		if (currentDocument.value.fileData !== null)
			this.fileProperties = currentDocument.properties
		else
			this.fileProperties = { ...this.documentProperties.value }
	}

	/**
	 * Fetches, from the server, the properties of the document with the specified version and sets it as the current one.
	 * @param {string} version The version of the document
	 * @returns A promise to be resolved when the request completes.
	 */
	setFileProperties(version)
	{
		if (typeof this.modelFieldRef?.tickets !== 'object' ||
			typeof version !== 'string' ||
			!Object.keys(this.modelFieldRef.tickets).includes(version))
			return null

		const versionTicket = this.modelFieldRef.tickets[version]
		if (typeof versionTicket !== 'string' || versionTicket.length === 0)
			return

		const baseArea = this.modelFieldRef.area
		const params = {
			ticket: versionTicket
		}

		return netAPI.postData(
			baseArea,
			'GetFileProperties',
			params,
			(data) => {
				const versions = { ...this.documentVersions }
				delete versions[this.currentVersion]

				this.documentProperties.updateValue(data)
				this.modelFieldRef.updateValue(data?.name ?? '')
				this.documentFK.updateValue(data?.documentId ?? '')

				this.documentProperties.value.versions = versions
			},
			undefined,
			undefined,
			this.vueContext.navigationId)
	}

	/**
	 * Handles the file get operation, may call either 'getFile' or 'downloadFile'.
	 * @param {object} data The data with the file version and whether to force the download
	 */
	handleGetFile(data)
	{
		if (data.download)
			this.downloadFile(data.version)
		else
			this.getFile(data.version)
	}

	/**
	 * Downloads the document.
	 * @param {string} version The desired version
	 */
	downloadFile(version)
	{
		// Here we use the GetFile function and specify that we want to download the file (hence viewType: print).
		this.getFile(version, qEnums.documentViewTypeMode.print)
	}

	/**
	 * Gets the document from the server and displays it according to the view mode.
	 * @param {string} version The desired version
	 * @param {number} fileViewType Overrides the file view mode
	 */
	getFile(version, fileViewType)
	{
		if (typeof this.modelFieldRef?.tickets !== 'object' ||
			typeof version !== 'string')
			return

		const currentDocument = this.modelFieldRef.currentDocument
		const fileData = currentDocument.value.fileData
		const viewType = fileViewType ?? this.viewType
		const newTab = viewType === qEnums.documentViewTypeMode.preview

		// If the file was just uploaded, the server doesn't have it yet.
		if (fileData !== null && version === this.currentVersion)
			netAPI.forceDownload(fileData, currentDocument.properties.name, fileData.type, newTab)
		else
		{
			// If there are multiple versions, use the entry for the specified version
			// If there is only one version, use the main entry (which is always there)
			const tickets = this.modelFieldRef.tickets
			const versionKeys = Object.keys(tickets)

			let versionTicket

			if (versionKeys.length > 1)
			{
				if (versionKeys.includes(version))
					versionTicket = tickets[version]
				else
					throw new Error(`Version ${version} not found in tickets.`)
			}
			else
				versionTicket = tickets.main

			if (typeof versionTicket !== 'string' || versionTicket.length === 0)
				return

			netAPI.getFile(
				this.modelFieldRef.area,
				versionTicket,
				viewType,
				this.vueContext.navigationId)
		}
	}

	/**
	 * Fetches a list of all the document versions from the server.
	 */
	getVersionsInfo()
	{
		if (typeof this.modelFieldRef?.tickets !== 'object')
			return

		const baseArea = this.modelFieldRef.area
		const params = {
			ticket: this.modelFieldRef.tickets.main
		}

		netAPI.postData(
			baseArea,
			'GetFileVersions',
			params,
			(data) => {
				if (typeof data.documentVersions !== 'object' || data.documentVersions === null)
					return

				const systemDataStore = useSystemDataStore()
				const elements = data.documentVersions.Elements
				const rows = []

				// If there's an unsaved new version, adds it to the list.
				const currentDocument = this.modelFieldRef.currentDocument
				if (currentDocument.value.fileData !== null)
				{
					const properties = currentDocument.properties
					const createdOn = genericFunctions.dateToString(currentDocument.value.fileData.lastModifiedDate, systemDataStore.system.currentLang)

					rows.push({
						author: properties.author,
						bytes: currentDocument.value.fileData.size,
						createdOn,
						fileName: properties.name,
						id: '',
						version: properties.version
					})
				}

				for (let el of elements)
				{
					// Exclude versions that were already deleted in the client-side or that are already in the list.
					if (!Object.keys(this.documentVersions).includes(el.version) ||
						rows.some((r) => r.version === el.version))
						continue

					let createdOn = el.createdOn
					if (createdOn instanceof Date)
						createdOn = genericFunctions.dateToString(createdOn, systemDataStore.system.currentLang)

					rows.push({
						...el,
						createdOn
					})
				}

				this.versionsInfo = rows
			},
			undefined,
			undefined,
			this.vueContext.navigationId)
	}

	/**
	 * Handles the error and presents the user with useful information.
	 * @param {number} errorCode The error code
	 */
	handleFileError(errorCode)
	{
		const extraInfo = {
			extensions: this.extensions,
			maxSize: this.maxFileSizeLabel
		}
		genericFunctions.handleFileError(errorCode, this.texts, extraInfo)
	}

	/**
	 * Handle the modal closing event.
	 */
	handleDocumentTemplatesClose()
	{
		this.documentTemplatesIsVisible = false
		this.documentTemplatesParams = undefined
	}

	/**
	 * Handle the Key selection event.
	 * Download the file at the end if generated successfully.
	 */
	handleDocumentTemplatesChoice(selectedItem)
	{
		this.handleDocumentTemplatesClose()
		const baseArea = this.modelFieldRef.area

		if (_isEmpty(this.documentTemplateAction) || _isEmpty(selectedItem))
			return

		asyncProcM.addBusy(
			netAPI.postData(
				baseArea,
				this.documentTemplateAction,
				{ id: selectedItem },
				(_, response) => {
					const fileName = response.headers.filename

					if (!fileName)
					{
						const contentType = response.headers['content-type']
						const erroMsg = this.texts.errorProcessingRequest

						if (contentType === 'application/json')
						{
							try
							{
								// Convert ArrayBuffer to a string
								const dataString = new TextDecoder().decode(response.data)
								// Convert string to a JSON
								const jsonData = JSON.parse(dataString)
								genericFunctions.displayMessage(jsonData?.Data?.message ?? erroMsg, 'error')
							}
							catch
							{
								genericFunctions.displayMessage(erroMsg, 'error')
							}
						}
						else
							genericFunctions.displayMessage(erroMsg, 'error')
					}
					else
						netAPI.forceDownload(response.data, fileName)
				},
				undefined,
				{ responseType: 'arraybuffer' },
				this.vueContext.navigationId))
	}

	/**
	 * Handle the opening «Document Templates..» event.
	 */
	handleDocumentTemplates()
	{
		this.documentTemplatesParams = {
			id: this.vueContext.primaryKeyValue,
			limits: this.getLimitsValues(),
			navigationId: this.vueContext.navigationId
		}
		this.documentTemplatesIsVisible = true
	}
}

/**
 * Image control
 */
export class ImageControl extends DatabaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'Image',
			image: null,
			fullSizeImage: null,
			defaultImage: computed(() => `${systemInfo.resourcesPath}no_img.png?v=${systemInfo.genio.buildVersion}`),
			extensions: ['.jpg', '.jpeg', '.png', '.gif', '.svg', '.webp', '.bmp'],
			isStatic: false,
			texts: new controlsResources.ImageResources(_vueContext.$getResource),
			isEmptyImage: false,
			dataTitle: null,
			imageWatcher: () => {}
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		const props = {
			...super.props,
			height: this.height,
			width: this.width,
			image: this.image,
			fullSizeImage: this.fullSizeImage,
			isEmptyImage: this.isEmptyImage,
			dataTitle: this.dataTitle
		}

		if (this.isStatic)
		{
			return {
				...props,
				readonly: true
			}
		}

		return {
			...props,
			extensions: this.extensions,
			isRequired: this.isRequired,
			maxFileSize: this.maxFileSize,
			popupIsVisible: this.popupIsVisible
		}
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		if (this.isStatic)
			this.image = this.icon?.icon
		else
		{
			// Remove the previous watcher
			this.imageWatcher()
			this.imageWatcher = watch(() => this.modelFieldRef.value, (value) => (this.image = value || this.defaultImage), { immediate: true })
		}

		this.isEmptyImage = computed(() => {
			const image = this.isStatic ? this.icon?.icon : this.modelFieldRef.value
			return typeof image === 'string' && image.length === 0 || typeof image === 'object' && !image?.data
		})

		// If the field doesn't have an associated image, gets the default image.
		if (_isEmpty(this.image))
			this.image = this.defaultImage
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			fileError: (event) => this.handleFileError(event),
			openImagePreview: () => this.getImage(),
			closeImagePreview: () => this.clearPreview(),
			submitImage: (event) => this.setImage(event),
			deleteImage: () => this.deleteImage(),
			showPopup: (event) => this.setModal(event),
			hidePopup: (event) => this.removeFieldModal(event)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Clears the image preview.
	 */
	clearPreview()
	{
		this.fullSizeImage = null
	}

	/**
	 * Retrieves the ID of the record, according to the type of the image field.
	 * @returns The ID of the record to which the image belongs.
	 */
	getId()
	{
		if (this.dependentModelField)
			return this.vueContext.model[this.dependentModelField].value
		return this.vueContext.primaryKeyValue
	}

	/**
	 * Gets the image from the server.
	 * @param {string} id The ID of the record
	 * @param {boolean} isPreview If true, it will get full-sized image, otherwise it will be resized to fit the component
	 */
	getImage(id, isPreview = true)
	{
		// If it's a static image, it will always be in the client-side, the server won't even know of it's existence.
		// If the field is dirty, it means the full-sized image is already client-side, since it was just uploaded by the user.
		// When we don't have a ticket to retrieve the image field value, we will not send a request to the server.
		if (this.isStatic || this.modelFieldRef.isDirty || this.image?.isThumbnail === false || _isEmpty(this.image?.ticket))
		{
			this.fullSizeImage = this.image
			return
		}

		if (typeof id !== 'string')
			id = this.getId()

		const baseArea = this.modelFieldRef.area
		const ticket =  this.image?.ticket

		const params = {
			ticket,
			formIdentifier: `F${this.vueContext.formInfo.name}`,
			nocache: Math.floor(Math.random() * 100000)
		}

		// If the image should be reduced, adds the max height and width to the params.
		if (!isPreview)
		{
			params.height = this.height
			params.width = this.width
		}

		this.componentOnLoadProc.addWL(
			netAPI.retrieveImage(
				baseArea,
				params,
				(data) => {
					if (isPreview)
						this.fullSizeImage = data
					this.image = data
				}))
	}

	/**
	 * Sets a new image.
	 * @param {object} imgData The image file data
	 */
	setImage(imgData)
	{
		if (typeof imgData !== 'object')
			return

		this.modelFieldRef.updateValue(imgData)
		this.image = imgData
		this.fullSizeImage = null
	}

	/**
	 * Deletes the image.
	 */
	deleteImage()
	{
		this.modelFieldRef.updateValue(null)
		this.image = this.defaultImage
		this.fullSizeImage = null
	}

	/**
	 * Handles the error and presents the user with useful information.
	 * @param {number} errorCode The error code
	 */
	handleFileError(errorCode)
	{
		const extraInfo = {
			extensions: this.extensions,
			maxSize: this.maxFileSizeLabel
		}
		genericFunctions.handleFileError(errorCode, this.texts, extraInfo)
	}
}

/**
 * Manual Filling Image control
 */
export class ManualFillingImageControl extends ImageControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'ManualFillingImage',
			image: null,
			fullSizeImage: null,
			defaultImage: computed(() => `${systemInfo.resourcesPath}no_img.png?v=${systemInfo.genio.buildVersion}`),
			isStatic: true,
			texts: new controlsResources.ImageResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Groupbox control
 */
export class GroupControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'Group',
			directChildren: [],
			anchoredChildren: [],
			isCollapsible: false,
			anchored: false,
			modelValue: false
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		this.isRequired = computed(() => {
			if (!this.vueContext.isEditable)
				return false
			if (this.mustBeFilled)
				return true

			for (let i in this.vueContext.controls)
			{
				const control = Reflect.get(this.vueContext.controls, i)
				if (this.id === control.container && control.isRequired)
					return true
			}

			return false
		})

		// When groups become visible, they re-emit an event for all their children
		this.showWhenConditions.addOnShowListener(() => {
			if (this.isCollapsible && !this.modelValue)
				return

			for (let childId of this.directChildren)
			{
				const child = this.vueContext.controls[childId]
				child.showWhenConditions.emitShowEvent()
			}
		})
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			'update:model-value': (eventData) => this.setState(eventData)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Sets the current state of the group, either open or closed
	 * @param {boolean} state If true, the group will be open, otherwise it'll be closed
	 */
	setState(state)
	{
		if (!this.isCollapsible || typeof state !== 'boolean')
			return

		this.modelValue = state

		if (this.vueContext)
		{
			this.vueContext.storeContainerState({
				navigationId: this.vueContext.navigationId,
				key: this.vueContext.storeKey,
				formInfo: this.vueContext.formInfo,
				fieldId: this.id,
				containerState: state
			})
		}

		if (state)
			this.showWhenConditions.emitShowEvent()
	}
}

/**
 * Accordion control
 */
export class AccordionControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'Accordion'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Timeline control
 */
export class TimelineControl extends TableListControl
{
	constructor(options, _vueContext)
	{
		const systemDataStore = useSystemDataStore()

		// Init default values of control properties
		super({
			type: 'Timeline',
			hydrate: listFunctions.hydrateTimelineData,
			timeLineData: {
				rows: []
			},
			config: {
				scale: '',
				dateTimeFormat: computed(() => systemDataStore.system?.dateFormat?.dateTime)
			},
			texts: new controlsResources.TimelineResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * Reloads the data of the timeline
	 */
	reload()
	{
		return this.componentOnLoadProc.addWL(this.vueContext.fetchTimelineData(this))
	}
}

/**
 * Button control
 */
export class ButtonControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Button'
		}, _vueContext)

		_merge(this, options || {})
	}
}

/**
 * Tab control
 */
export class TabControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Tab',
			directChildren: []
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		this.isRequired = computed(() => {
			if (!this.vueContext.isEditable)
				return false
			if (this.mustBeFilled)
				return true

			for (let i in this.vueContext.controls)
			{
				const control = Reflect.get(this.vueContext.controls, i)
				if (this.id === control.tab && control.isRequired)
					return true
			}

			return false
		})

		// When tabs become visible, they re-emit an event for all their children
		this.showWhenConditions.addOnShowListener(() => {
			for (let childId of this.directChildren)
			{
				const child = this.vueContext.controls[childId]
				child.showWhenConditions.emitShowEvent()
			}
		})
	}
}

/**
 * Tabs control
 */
export class TabsControl
{
	constructor(options, _vueContext)
	{
		this.vueContext = _vueContext

		// Init default values of control properties
		this.type = 'Tabs'
		this.alignTabs = 'left',
		this.tabControlsIds = []
		this.tabsList = []
		this.selectedTab = ''
		this.isVisible = false
		this.tabWatcher = () => {}
		this.texts = new controlsResources.TabsResources(_vueContext.$getResource)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			isVisible: this.isVisible,
			alignTabs: this.alignTabs,
			tabsList: this.tabsList,
			selectedTab: this.selectedTab,
			texts: this.texts
		}
	}

	/**
	 * Initializes the tab group
	 */
	init()
	{
		this.tabsList.splice(0)

		_forEach(this.tabControlsIds, (tabId) => {
			const tab = this.vueContext.controls[tabId]
			this.tabsList.push(tab)

			if (_isEmpty(this.selectedTab) && tab.isVisible && !tab.isBlocked)
				this.selectTab(tab.id)
		})

		this.isVisible = computed(() => _some(this.tabsList, { isVisible: true }))

		// Remove the previous watcher
		this.tabWatcher()
		// If the current tab becomes hidden, selects the first visible tab, if any.
		this.tabWatcher = watch(() => this.tabsList, () => {
			const currentTab = this.vueContext.controls[this.selectedTab]

			if (!_isEmpty(currentTab) && currentTab.isVisible && !currentTab.isBlocked)
				return

			this.selectFirstTab()
		},
		{ deep: true, immediate: true })
	}

	/**
	 * Selects the first tab available
	 */
	selectFirstTab()
	{
		for (let tab of this.tabsList)
		{
			if (!tab.isVisible || tab.isBlocked)
				continue

			this.selectTab(tab.id)
			return
		}
	}

	/**
	 * Selects the specified tab
	 * @param {string} tabId The identifier of the tab to select
	 */
	selectTab(tabId)
	{
		this.selectedTab = tabId ?? ''

		if (typeof tabId === 'string')
		{
			const tab = this.vueContext.controls[tabId]
			tab.showWhenConditions.emitShowEvent()
		}
		else
			this.selectFirstTab()
	}
}

/**
 * Subform control
 */
export class SubformControl extends NonBlockableControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Subform',
			directChildren: []
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		// When sub-forms become visible, they re-emit an event for all their children
		this.showWhenConditions.addOnShowListener(() => {
			for (let childId of this.directChildren)
			{
				const child = this.vueContext.controls[childId]
				child.showWhenConditions.emitShowEvent()
			}
		})
	}
}

/**
 * Container control for nested forms
 */
export class FormContainerControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			targetTableListId: null,
			supportForm: {
				name: null,
				component: null,
				mode: 'SHOW',
				fnKeySelector: () => null
			},
			formData: null,
			isDirty: false,
			fnOnRowChange: undefined,
			firstLoad: false,
			nestedFormConfig: new NestedFormConfig({
				mainForm: undefined,
				supportFormId: undefined,
				action: undefined,
				searchField: false,
				uiComponents: {
					header: true
				}
			}),
			allowFormActions: {
				show: true,
				edit: true,
				duplicate: true,
				delete: true,
				insert: true
			},
			rowComponentProps: {
				formButtonsOverride: null
			},
			resourcesPath: systemInfo.resourcesPath,
			texts: new controlsResources.FormContainerResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})

		if (this.nestedFormConfig.searchField)
			this.formData = {
				isNested: true,
				form: this.supportForm.name,
				component: this.supportForm.component,
			}

		this.initHeaderButtons()
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		if (this.targetTableListId)
		{
			if (this.vueContext.controls[this.targetTableListId])
				this.vueContext.controls[this.targetTableListId].linkedForm = this

			if (this.vueContext.internalEvents)
				this.vueContext.internalEvents.on('on-table-row-selected', (eventData) => (this.targetTableListId === eventData.tableId) ? this.handleRowSelected(eventData.row) : null)
		}
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			afterSaveForm: (eventData) => this.onAfterSaveForm(eventData),
			changeFormMode: (eventData) => this.onChangeFormMode(eventData),
			['update:nested-model']: (eventData) => (eventData.supportFormId === this.id) ? this.handleRowSelected(eventData) : () => {},
			close: (eventData) => this.onClose(eventData),
			closedForm: (eventData) => this.onClosedForm(eventData),
			customEvent: (eventData) => this.onCustomEvent(eventData),
			isFormDirty: (eventData) => this.onIsFormDirty(eventData),
			updateModelId: (eventData) => this.updateModelId(eventData),
			insertRecord: (eventData) => this.updateFormData({ mode: qEnums.formModes.new, id: eventData })
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Init the buttons shown in the header accordingly to the user access rights choice
	 */
	initHeaderButtons()
	{
		this.rowComponentProps.formButtonsOverride = {
			confirmBtn: { isActive: false },
			saveBtn: { isActive: true },
			changeToShow: { isActive: this.allowFormActions.show },
			changeToEdit: { isActive: this.allowFormActions.edit },
			changeToDuplicate: { isActive: this.allowFormActions.duplicate },
			changeToDelete: { isActive: this.allowFormActions.delete },
			changeToInsert: { isActive: this.allowFormActions.insert }
		}
	}

	onAfterSaveForm()
	{
		// Reloads the table list linked to this form
		if (this.vueContext.internalEvents)
			this.vueContext.internalEvents.emit('reload-list', { controlId: this.targetTableListId })

		this.isDirty = false
	}

	onChangeFormMode(mode)
	{
		if (mode === qEnums.formModes.new)
		{
			this.isDirty = true
			if (this.targetTableListId)
				this.vueContext.controls[this.targetTableListId].onUnselectAllRows()
		}

		if (!_isEmpty(this.formData))
			this.formData.mode = mode
	}

	onClose(eventData)
	{
		if (eventData.type === 'cancel' || eventData.type === 'delete')
		{
			this.setFormData(null)
			this.onClosedForm()
		}
	}

	onClosedForm()
	{
		// Resets the form container's dirty state
		this.isDirty = false

		// Resets the new row id if the form is closed
		if (this.targetTableListId && this.vueContext.controls[this.targetTableListId])
			this.vueContext.controls[this.targetTableListId].newRowID = undefined

		if (this.vueContext.internalEvents)
			this.vueContext.internalEvents.emit('closed-extended-support-form', { controlId: this.targetTableListId })
	}

	onCustomEvent(eventData)
	{
		if (this.vueContext.internalEvents)
			this.vueContext.internalEvents.emit('ctrl-custom-event', { id: this.id, data: eventData })
	}

	onIsFormDirty(eventData)
	{
		this.isDirty = eventData.isDirty

		if (this.vueContext.internalEvents)
			this.vueContext.internalEvents.emit('is-table-control-dirty', eventData)

		// Re-emit through all nested form layers until the main form, except after saving (only the saved nested form is now valid - not the others above)
		if (this.vueContext.isNested && !eventData.afterFormSave)
			this.vueContext.$emit('is-form-dirty', { isDirty: eventData.isDirty, afterFormSave: eventData.afterFormSave })
	}

	async handleRowSelected(row)
	{
		if (!row)
			return

		if (typeof this.fnOnRowChange === 'function')
			await Promise.resolve(this.fnOnRowChange(row))

		let id = (row.rowKey !== null && row.rowKey !== undefined) ? this.supportForm.fnKeySelector(row) : null
		let formMode = row.formMode ? row.formMode : this.supportForm.mode
		let prefillValues = row.prefillValues ? row.prefillValues : {}

		if (this.firstLoad) this.nestedFormConfig.recordSelected = true

		if (id || formMode === 'NEW') this.firstLoad = true

		if (_isEmpty(id) && formMode !== 'NEW')
			this.destroy()
		else
			this.updateFormData({ mode: formMode, id, prefillValues })
	}

	updateFormData({ mode, id, prefillValues })
	{
		this.setFormData({
			historyBranchId: this.vueContext.navigationId,
			isNested: true,
			form: this.supportForm.name,
			mode: mode,
			component: this.supportForm.component,
			modes: '',
			id,
			prefillValues: prefillValues ?? {}
		})
	}

	updateModelId(eventData)
	{
		// Since this record doesn't exist yet in the table rows, this need to be called to
		// set the record as dirty and show the pop up message if leaving without saving
		// (pop up messages in extended support forms only show if there are dirty rows on the table in the main form)
		this.onIsFormDirty({ isDirty: true, id: eventData })

		// Sets the new record in the table (as a row being created) to allow listConf actions over it
		if (this.targetTableListId && this.vueContext.controls[this.targetTableListId])
			this.vueContext.controls[this.targetTableListId].newRowID = eventData
	}

	handleLeaveForm(next)
	{
		if (this.vueContext.$refs[this.id])
			this.vueContext.$refs[this.id].handleLeaveForm(next)
	}

	setFormData(formData)
	{
		this.formData = formData
	}

	destroy()
	{
		super.destroy()
		this.setFormData(null)
	}
}

/**
 * Configuration of the nested forms
 */
export class NestedFormConfig
{
	constructor(options)
	{
		this.uiComponents = {
			header: false,
			headerButtons: true,
			footer: true
		}

		_merge(this, options || {})
	}
}

/**
 * The Grid Table List control
 */
export class GridTableListControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		// Init default values of control properties
		super({
			type: 'GridTableList',
			config: {
				name: '',
				tableTitle: undefined,
				formName: undefined,
				resourcesPath: systemInfo.resourcesPath
			},
			permissions: {
				canDelete: true,
				canInsert: true
			},
			columns: [],
			dataAlreadyRequested: false,
			data: undefined,
			gridWatcher: () => {},
			texts: new controlsResources.TableListMainResources(_vueContext.$getResource)
		}, _vueContext)

		_merge(this, options || {})

		this.config.formName = this.id
		this.config.tableTitle = this.label
	}

	get props()
	{
		return {
			...super.props,
			columns: this.columns
		}
	}

	get emptyRows()
	{
		return this.modelFieldRef.emptyRows
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		this.data = computed(() => this.modelFieldRef.value)
		const canInsert = this.permissions.canInsert !== false

		// Remove the previous watcher
		this.gridWatcher()
		this.gridWatcher = watch([() => this.loaded, () => this.emptyRows, () => this.readonly], () => {
			// Create an empty row if there is none,
			// the grid is editable and inserting rows is allowed
			if (canInsert && !this.emptyRows.length && !this.readonly)
				this.addNewModel()
			// Ensure editable grids only have one empty row,
			// and readonly grids display no empty rows
			else if (this.emptyRows.length > 0)
				this.trimEmptyRows()
		})

		this.initEvents()
	}

	/**
	 * Performs additional init operations after the table data is ready.
	 */
	initData()
	{
		// EMPTY
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			addNewRow: () => this.addNewModel(),
			markForDeletion: (row) => this.markForDeletion(row),
			undoDeletion: (row) => this.undoDeletion(row)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Initialization of listeners for events on which functions such as content reloading depend
	 */
	initEvents()
	{
		listFunctions.initTableEvents(this)
	}

	addNewModel()
	{
		this.modelFieldRef?.addNewModel()
	}

	/**
	 * Runs after each time the table finishes loading
	 */
	afterLoaded()
	{
		formFunctions.setValuesFromStore(this.modelFieldRef, this.vueContext)
	}

	trimEmptyRows()
	{
		this.modelFieldRef?.trimEmptyRows(this.readonly)
	}

	markForDeletion(row)
	{
		this.modelFieldRef?.markForDeletion(row)
	}

	undoDeletion(row)
	{
		this.modelFieldRef?.undoDeletion(row)
	}

	hydrate(_, listViewModel)
	{
		this.modelFieldRef?.hydrate(listViewModel)
	}

	reload()
	{
		return this.componentOnLoadProc.addWL(this.vueContext.fetchListData(this))
	}
}

/**
 * Wizard control
 */
export class WizardControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'Wizard',
			wizardData: {
				currentStep: computed(() => _vueContext.currentStepIndex),
				selectedStep: computed(() => _vueContext.selectedStepIndex),
				currentPath: [],
				texts: new controlsResources.WizardResources(_vueContext.$getResource)
			},
			dataWatcher: () => {}
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			stepClicked: (...args) => this.vueContext.stepClicked(...args)
		}

		_assignInWith(this.handlers, handlers, (objValue, srcValue) =>
			_isUndefined(objValue) ? srcValue : objValue
		)
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		this.isRequired = computed(() => {
			if (!this.vueContext.isEditable)
				return false
			if (this.mustBeFilled)
				return true

			for (let controlId of this.wizardData.stepFieldIds || [])
			{
				const control = Reflect.get(this.vueContext.controls, controlId)
				if (control.isRequired)
					return true
			}

			return false
		})

		this.wizardData.currentPath = this.vueContext.wizardPath

		// Remove the previous watcher
		this.dataWatcher()
		this.dataWatcher = watch(() => this.vueContext.wizardData, () => _merge(this.wizardData, this.vueContext.wizardData || {}), { deep: true, immediate: true })
	}
}

export class PropertyListControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		const propertyListResources = new controlsResources.PropertyListResources(_vueContext.$getResource)

		super({
			type: 'PropertyList',
			config: {
				fields: [],
				groups: [],
				noPanel: false,
				readonly: false,
				panelPosition: 'bottom',
				block: false,
				texts: {
					emptyMessage: propertyListResources.emptyMessage
				}
			}
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			fieldChange: (field, value) => this.onFieldChange(field, value)
		}

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		this.config.readonly = computed(() => this.readonly)
	}

	/**
	 * When a field changes, updates the model.
	 * @param {object} field The field that changed
	 * @param {any} value The new value of the field
	 */
	onFieldChange(field, value)
	{
		const fieldData = {
			rowId: field.rowId ?? '',
			id: field.id,
			name: field.name,
			value: this.parseToServerValue(value, field.type),
			type: field.type,
			isRowDirty: value !== field.defaultValue
		}

		if (!this.modelFieldRef.value)
			this.modelFieldRef.value = {}

		const propertyModel = this.modelFieldRef.value[field.id]
		if (propertyModel)
			this.modelFieldRef.value[field.id].value = value

		this.modelFieldRef.addProperty(fieldData)
	}

	parseToServerValue(value, fieldType)
	{
		const fieldTypeHandler = {
			date: (value) => genericFunctions.dateToISOString(value),
			default: (value) => value?.toString()
		}

		return (fieldTypeHandler[fieldType] || fieldTypeHandler['default'])(value)
	}

	initData()
	{
		// EMPTY
	}

	hydrate(listControl, viewModel)
	{
		this.modelFieldRef.hydrate(listControl, viewModel)
	}

	afterLoaded()
	{
		formFunctions.setValuesFromStore(this.modelFieldRef, this.vueContext)
	}

	reload()
	{
		return this.componentOnLoadProc.addWL(this.vueContext.fetchListData(this))
	}
}

export class KanbanControl extends BaseControl
{
	constructor(options, _vueContext)
	{
		const kanbanTexts = new controlsResources.KanbanResources(_vueContext.$getResource)

		super({
			type: 'Kanban',
			columnsTable: '',
			columns: [],
			cardsTable: '',
			cards: [],
			config: {
				crudActions: [],
				generalActions: [],
				rowClickAction: {},
				formsDefinition: {},
				allowColumnEdition: false,
				rowActionDisplay: systemInfo.layout.RowActionDisplay,
			},
			texts: kanbanTexts
		}, _vueContext)

		_merge(this, options || {})
	}

	/**
	 * @override
	 */
	async init(isEditableForm)
	{
		await super.init(isEditableForm)

		this.hasClickAction = computed(() => Object.keys(this.config.rowClickAction).length !== 0)
	}

	/**
	 * @override
	 */
	initHandlers()
	{
		super.initHandlers()

		const handlers = {
			'click:add': (column) => this.onCardAction({ action: 'insert', column }),
			'update:position': (eventData) => this.onCardDrag(eventData)
		}

		this.handlersCard = {
			'click:action': (eventData) => this.onCardAction(eventData)
		}

		if (this.hasClickAction)
			this.handlersCard.click = (eventData) => this.onCardClick({ card: eventData })

		// Apply handlers without overriding. The handler can come from outside at initialization.
		_assignInWith(this.handlers, handlers, (objValue, srcValue) => _isUndefined(objValue) ? srcValue : objValue)
	}

	/**
	 * Performs additional init operations after the table data is ready.
	 */
	initData()
	{
		// EMPTY
	}

	/**
	 * Runs after each time the table finishes loading
	 */
	afterLoaded()
	{
		formFunctions.setValuesFromStore(this.modelFieldRef, this.vueContext)
	}

	/**
	 * Reloads the data of the list
	 */
	async reload()
	{
		return this.componentOnLoadProc.addWL(this.vueContext.fetchListData(this, undefined, this.fnHydrateViewModel))
	}

	onCardDrag(eventData)
	{
		netAPI.postData(
			this.controller,
			`${this.action}_EventHandler`,
			{
				sourceKey: eventData.id,
				destinationKey: eventData.column,
				newOrder: 0,
				eventType: 'DragDrop',
				elementType: 'Card'
			})
	}

	onCardClick(eventData)
	{
		this.onCardAction({ action: this.config.rowClickAction.id, card: eventData.card })
	}

	onCardAction(eventData)
	{
		const { action, card, column } = eventData

		const listConf = this
		const allActions = [ ...listConf.config.crudActions, ...listConf.config.generalActions, listConf.config.rowClickAction ]
		const actionCfg = allActions.find(a => a.id === action)

		let formName = actionCfg.params.formName,
			mode = actionCfg.params.mode,
			id = null,
			formDef = listConf.config.formsDefinition[formName],
			options = {
				isPopup: formDef.isPopup,
				repeatInsert: actionCfg.params.repeatInsertion,
				isDuplicate: false,
				modes: ''
			},
			query = {},
			prefillValues = actionCfg.params.prefillValues || {}

		let tableName = listConf.controller[0] + listConf.controller.substring(1).toLowerCase()
		let tableViewModelName = listConf.action + '_ViewModel'
		this.vueContext.setEntryValue({ navigationId: this.navigationId, key: 'TableName', value: tableName })
		this.vueContext.setEntryValue({ navigationId: this.navigationId, key: 'TableViewModelName', value: tableViewModelName })

		if (mode === 'DUPLICATE')
			options.isDuplicate = true

		if (mode !== 'NEW')
			id = formDef.fnKeySelector(card)
		else
		{
			// The the column in each the record is being inserted
			const entry = {
				navigationId: this.navigationId,
				key: listConf.columnsTable,
				value: column
			}
			this.vueContext.setEntryValue(entry)
			options.isControlled = true
		}

		this.vueContext.navigateToForm(formName, mode, id, options, query, prefillValues)
	}
}

/**
 * Form markdown editor control
 */
export class MarkdownEditorControl extends MultilineStringControl
{
	constructor(options, _vueContext)
	{
		super({
			type: 'String',
			texts: new controlsResources.MarkdownEditorResources(_vueContext.$getResource),
			markdownOptions: null
		}, _vueContext)

		_merge(this, options || {})
	}

	get props()
	{
		return {
			...super.props,
			options: this.markdownOptions
		}
	}
}

export default {
	BaseControl,
	StringControl,
	MultilineStringControl,
	TextEditorControl,
	CodeEditorControl,
	PasswordControl,
	BooleanControl,
	NumberControl,
	CurrencyControl,
	DateControl,
	TimeControl,
	ArrayStringControl,
	ArrayNumberControl,
	ArrayBooleanControl,
	CoordinatesControl,
	MaskControl,
	LookupControl,
	TableListControl,
	TreeTableListControl,
	MultipleValuesControl,
	MultipleValuesExtensionControl,
	DocumentControl,
	ManualFillingImageControl,
	ImageControl,
	TimelineControl,
	GroupControl,
	AccordionControl,
	ButtonControl,
	TabControl,
	TabsControl,
	SubformControl,
	FormContainerControl,
	NestedFormConfig,
	GridTableListControl,
	WizardControl,
	PropertyListControl,
	KanbanControl,
	MarkdownEditorControl,
	...getSpecialRenderingControls(BaseControl, TableListControl)
}
