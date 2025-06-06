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
			name: 'F_CLUB',
			area: 'CLUB',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_CLUB',
				updateFilesTickets: 'UpdateFilesTicketsF_CLUB'
			}
		})

		/** The primary key. */
		this.ValCodclub = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodclub',
			originId: 'ValCodclub',
			area: 'CLUB',
			field: 'CODCLUB',
			description: '',
		}).cloneFrom(values?.ValCodclub))
		watch(() => this.ValCodclub.value, (newValue, oldValue) => this.onUpdate('club.codclub', this.ValCodclub, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'CLUB',
			field: 'CODCNTRY',
			relatedArea: 'CNTRY',
			description: computed(() => this.Resources.FK_COUNTRY04348),
		}).cloneFrom(values?.ValCodcntry))
		watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('club.codcntry', this.ValCodcntry, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'CLUB',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.CLUB_S_NAME65517),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('club.name', this.ValName, newValue, oldValue))

		this.TableCntryCountry = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCntryCountry',
			originId: 'ValCountry',
			area: 'CNTRY',
			field: 'COUNTRY',
			maxLength: 50,
			description: computed(() => this.Resources.COUNTRY64133),
		}).cloneFrom(values?.TableCntryCountry))
		watch(() => this.TableCntryCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.TableCntryCountry, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFClubViewModel instance.
	 * @returns {QFormFClubViewModel} A new instance of QFormFClubViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodclub'

	get QPrimaryKey() { return this.ValCodclub.value }
	set QPrimaryKey(value) { this.ValCodclub.updateValue(value) }
}
