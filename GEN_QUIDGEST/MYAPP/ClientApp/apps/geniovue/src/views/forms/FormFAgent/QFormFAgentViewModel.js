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
			name: 'F_AGENT',
			area: 'AGENT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_AGENT',
				updateFilesTickets: 'UpdateFilesTicketsF_AGENT'
			}
		})

		/** The primary key. */
		this.ValCodagent = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodagent',
			originId: 'ValCodagent',
			area: 'AGENT',
			field: 'CODAGENT',
			description: '',
		}).cloneFrom(values?.ValCodagent))
		watch(() => this.ValCodagent.value, (newValue, oldValue) => this.onUpdate('agent.codagent', this.ValCodagent, newValue, oldValue))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'AGENT',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO_S_AGENT28065),
		}).cloneFrom(values?.ValPhoto))
		watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('agent.photo', this.ValPhoto, newValue, oldValue))

		this.ValGender = reactive(new modelFieldType.String({
			id: 'ValGender',
			originId: 'ValGender',
			area: 'AGENT',
			field: 'GENDER',
			maxLength: 1,
			arrayOptions: computed(() => qProjArrays.QArrayGender.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.GENDER44172),
		}).cloneFrom(values?.ValGender))
		watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('agent.gender', this.ValGender, newValue, oldValue))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'AGENT',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.AGENT_S_NAME23140),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('agent.name', this.ValName, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'AGENT',
			field: 'EMAIL',
			maxLength: 50,
			maskType: 'EM',
			description: computed(() => this.Resources.AGENT_S_EMAIL56414),
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('agent.email', this.ValEmail, newValue, oldValue))

		this.ValPhone = reactive(new modelFieldType.String({
			id: 'ValPhone',
			originId: 'ValPhone',
			area: 'AGENT',
			field: 'PHONE',
			maxLength: 14,
			maskType: 'MP',
			maskFormat: '+000 000000000',
			maskRequired: '+000 000000000',
			description: computed(() => this.Resources.AGENT_S_PHONE23147),
		}).cloneFrom(values?.ValPhone))
		watch(() => this.ValPhone.value, (newValue, oldValue) => this.onUpdate('agent.phone', this.ValPhone, newValue, oldValue))

		this.ValPerc_com = reactive(new modelFieldType.Number({
			id: 'ValPerc_com',
			originId: 'ValPerc_com',
			area: 'AGENT',
			field: 'PERC_COM',
			maxDigits: 1,
			decimalDigits: 2,
			description: computed(() => this.Resources.PERCENTAGE_OF_THE_CO01872),
		}).cloneFrom(values?.ValPerc_com))
		watch(() => this.ValPerc_com.value, (newValue, oldValue) => this.onUpdate('agent.perc_com', this.ValPerc_com, newValue, oldValue))

		this.ValTotcomis = reactive(new modelFieldType.Number({
			id: 'ValTotcomis',
			originId: 'ValTotcomis',
			area: 'AGENT',
			field: 'TOTCOMIS',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.TOTAL_EARN_THROUGH_C21845),
		}).cloneFrom(values?.ValTotcomis))
		watch(() => this.ValTotcomis.value, (newValue, oldValue) => this.onUpdate('agent.totcomis', this.ValTotcomis, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFAgentViewModel instance.
	 * @returns {QFormFAgentViewModel} A new instance of QFormFAgentViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodagent'

	get QPrimaryKey() { return this.ValCodagent.value }
	set QPrimaryKey(value) { this.ValCodagent.updateValue(value) }
}
