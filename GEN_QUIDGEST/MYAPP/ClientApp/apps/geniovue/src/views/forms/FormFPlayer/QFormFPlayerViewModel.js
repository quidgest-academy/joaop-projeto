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
			name: 'F_PLAYER',
			area: 'PLAYR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_PLAYER',
				updateFilesTickets: 'UpdateFilesTicketsF_PLAYER'
			}
		})

		/** The primary key. */
		this.ValCodplayr = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodplayr',
			originId: 'ValCodplayr',
			area: 'PLAYR',
			field: 'CODPLAYR',
			description: computed(() => this.Resources.PK_PLAYER25733),
		}).cloneFrom(values?.ValCodplayr))
		watch(() => this.ValCodplayr.value, (newValue, oldValue) => this.onUpdate('playr.codplayr', this.ValCodplayr, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodagent = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodagent',
			originId: 'ValCodagent',
			area: 'PLAYR',
			field: 'CODAGENT',
			relatedArea: 'AGENT',
			isFixed: true,
			description: computed(() => this.Resources.FK_AGENTE54597),
		}).cloneFrom(values?.ValCodagent))
		watch(() => this.ValCodagent.value, (newValue, oldValue) => this.onUpdate('playr.codagent', this.ValCodagent, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodcntry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcntry',
			originId: 'ValCodcntry',
			area: 'PLAYR',
			field: 'CODCNTRY',
			relatedArea: 'CNTRY',
			description: computed(() => this.Resources.FK_COUNTRY04348),
		}).cloneFrom(values?.ValCodcntry))
		watch(() => this.ValCodcntry.value, (newValue, oldValue) => this.onUpdate('playr.codcntry', this.ValCodcntry, newValue, oldValue))

		/** The remaining form fields. */
		this.ValUndctc = reactive(new modelFieldType.Number({
			id: 'ValUndctc',
			originId: 'ValUndctc',
			area: 'PLAYR',
			field: 'UNDCTC',
			maxDigits: 1,
			decimalDigits: 0,
			description: computed(() => this.Resources.UNDER_CONTRACT_12632),
		}).cloneFrom(values?.ValUndctc))
		watch(() => this.ValUndctc.value, (newValue, oldValue) => this.onUpdate('playr.undctc', this.ValUndctc, newValue, oldValue))

		this.ValGender = reactive(new modelFieldType.String({
			id: 'ValGender',
			originId: 'ValGender',
			area: 'PLAYR',
			field: 'GENDER',
			maxLength: 1,
			arrayOptions: computed(() => qProjArrays.QArrayGender.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.GENDER44172),
		}).cloneFrom(values?.ValGender))
		watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('playr.gender', this.ValGender, newValue, oldValue))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PLAYR',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME_OF_THE_PLAYER61428),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('playr.name', this.ValName, newValue, oldValue))

		this.ValBirthdat = reactive(new modelFieldType.Date({
			id: 'ValBirthdat',
			originId: 'ValBirthdat',
			area: 'PLAYR',
			field: 'BIRTHDAT',
			description: computed(() => this.Resources.BIRTHDATE22743),
		}).cloneFrom(values?.ValBirthdat))
		watch(() => this.ValBirthdat.value, (newValue, oldValue) => this.onUpdate('playr.birthdat', this.ValBirthdat, newValue, oldValue))

		this.ValAge = reactive(new modelFieldType.Number({
			id: 'ValAge',
			originId: 'ValAge',
			area: 'PLAYR',
			field: 'AGE',
			maxDigits: 3,
			decimalDigits: 0,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: Year([Today])- Year([PLAYR->BIRTHDAT])
					return qApi.Year(qApi.Hoje())-qApi.Year(this.ValBirthdat.value)
				},
				dependencyEvents: ['fieldChange:playr.birthdat'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.PLAYER_S_AGE12664),
		}).cloneFrom(values?.ValAge))
		watch(() => this.ValAge.value, (newValue, oldValue) => this.onUpdate('playr.age', this.ValAge, newValue, oldValue))

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

		this.ValPosic = reactive(new modelFieldType.String({
			id: 'ValPosic',
			originId: 'ValPosic',
			area: 'PLAYR',
			field: 'POSIC',
			maxLength: 50,
			description: computed(() => this.Resources.POSITION54869),
		}).cloneFrom(values?.ValPosic))
		watch(() => this.ValPosic.value, (newValue, oldValue) => this.onUpdate('playr.posic', this.ValPosic, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFPlayerViewModel instance.
	 * @returns {QFormFPlayerViewModel} A new instance of QFormFPlayerViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodplayr'

	get QPrimaryKey() { return this.ValCodplayr.value }
	set QPrimaryKey(value) { this.ValCodplayr.updateValue(value) }
}
