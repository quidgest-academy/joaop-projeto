/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'F_CNTRY',
			area: 'CNTRY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_CNTRY',
				updateFilesTickets: 'UpdateFilesTicketsF_CNTRY'
			}
		})

		/** The primary key. */
		this.ValCodcntry = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'CNTRY',
			field: 'CODCNTRY',
			description: '',
		}).cloneFrom(values?.ValCodcntry))
		watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('cntry.codcntry', this.ValCodcntry, newValue, oldValue))

		/** The remaining form fields. */
		this.ValCountry = reactive(new modelFieldType.String({
			id: 'ValCountry',
			originId: 'ValCountry',
			area: 'CNTRY',
			field: 'COUNTRY',
			maxLength: 50,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.ValCountry))
		watch(() => this.ValCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.ValCountry, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFCntryViewModel instance.
	 * @returns {QFormFCntryViewModel} A new instance of QFormFCntryViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcntry'

	get QPrimaryKey() { return this.ValCodcntry.value }
	set QPrimaryKey(value) { this.ValCodcntry.updateValue(value) }
}
