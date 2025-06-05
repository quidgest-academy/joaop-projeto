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
			name: 'F_CNTRCT',
			area: 'CONTR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_CNTRCT',
				updateFilesTickets: 'UpdateFilesTicketsF_CNTRCT'
			}
		})

		/** The primary key. */
		this.ValCodcontr = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcontr',
			originId: 'ValCodcontr',
			area: 'CONTR',
			field: 'CODCONTR',
			description: '',
		}).cloneFrom(values?.ValCodcontr))
		watch(() => this.ValCodcontr.value, (newValue, oldValue) => this.onUpdate('contr.codcontr', this.ValCodcontr, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodagent = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodagent',
			originId: 'ValCodagent',
			area: 'CONTR',
			field: 'CODAGENT',
			relatedArea: 'AGENT',
			isFixed: true,
			description: computed(() => this.Resources.FK_AGENT38232),
		}).cloneFrom(values?.ValCodagent))
		watch(() => this.ValCodagent.value, (newValue, oldValue) => this.onUpdate('contr.codagent', this.ValCodagent, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodplayr = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodplayr',
			originId: 'ValCodplayr',
			area: 'CONTR',
			field: 'CODPLAYR',
			relatedArea: 'PLAYR',
			description: computed(() => this.Resources.FK_PLAYER18756),
		}).cloneFrom(values?.ValCodplayr))
		watch(() => this.ValCodplayr.value, (newValue, oldValue) => this.onUpdate('contr.codplayr', this.ValCodplayr, newValue, oldValue))

		this.ValCodclub = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodclub',
			originId: 'ValCodclub',
			area: 'CONTR',
			field: 'CODCLUB',
			relatedArea: 'CLUB',
			description: computed(() => this.Resources.FK_CLUB57683),
		}).cloneFrom(values?.ValCodclub))
		watch(() => this.ValCodclub.value, (newValue, oldValue) => this.onUpdate('contr.codclub', this.ValCodclub, newValue, oldValue))

		/** The remaining form fields. */
		this.TablePlayrName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePlayrName',
			originId: 'ValName',
			area: 'PLAYR',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME_OF_THE_PLAYER61428),
		}).cloneFrom(values?.TablePlayrName))
		watch(() => this.TablePlayrName.value, (newValue, oldValue) => this.onUpdate('playr.name', this.TablePlayrName, newValue, oldValue))

		this.TableClubName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableClubName',
			originId: 'ValName',
			area: 'CLUB',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.CLUB_S_NAME65517),
		}).cloneFrom(values?.TableClubName))
		watch(() => this.TableClubName.value, (newValue, oldValue) => this.onUpdate('club.name', this.TableClubName, newValue, oldValue))

		this.AgentValEmail = reactive(new modelFieldType.String({
			id: 'AgentValEmail',
			originId: 'ValEmail',
			area: 'AGENT',
			field: 'EMAIL',
			maxLength: 50,
			maskType: 'EM',
			isFixed: true,
			description: computed(() => this.Resources.AGENT_S_EMAIL56414),
		}).cloneFrom(values?.AgentValEmail))
		watch(() => this.AgentValEmail.value, (newValue, oldValue) => this.onUpdate('agent.email', this.AgentValEmail, newValue, oldValue))

		this.ValStartdat = reactive(new modelFieldType.Date({
			id: 'ValStartdat',
			originId: 'ValStartdat',
			area: 'CONTR',
			field: 'STARTDAT',
			description: computed(() => this.Resources.STARTING_DATE47975),
		}).cloneFrom(values?.ValStartdat))
		watch(() => this.ValStartdat.value, (newValue, oldValue) => this.onUpdate('contr.startdat', this.ValStartdat, newValue, oldValue))

		this.ValFindate = reactive(new modelFieldType.Date({
			id: 'ValFindate',
			originId: 'ValFindate',
			area: 'CONTR',
			field: 'FINDATE',
			description: computed(() => this.Resources.FINISH_DATE41863),
		}).cloneFrom(values?.ValFindate))
		watch(() => this.ValFindate.value, (newValue, oldValue) => this.onUpdate('contr.findate', this.ValFindate, newValue, oldValue))

		this.ValSalary = reactive(new modelFieldType.Number({
			id: 'ValSalary',
			originId: 'ValSalary',
			area: 'CONTR',
			field: 'SALARY',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.SALARY_OF_THE_PLAYER18170),
		}).cloneFrom(values?.ValSalary))
		watch(() => this.ValSalary.value, (newValue, oldValue) => this.onUpdate('contr.salary', this.ValSalary, newValue, oldValue))

		this.ValCtrdurat = reactive(new modelFieldType.Number({
			id: 'ValCtrdurat',
			originId: 'ValCtrdurat',
			area: 'CONTR',
			field: 'CTRDURAT',
			maxDigits: 2,
			decimalDigits: 0,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: Year([CONTR->FINDATE]) - Year([CONTR->STARTDAT])
					return qApi.Year(this.ValFindate.value)-qApi.Year(this.ValStartdat.value)
				},
				dependencyEvents: ['fieldChange:contr.findate', 'fieldChange:contr.startdat'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.CONTRACT_DURATION31225),
		}).cloneFrom(values?.ValCtrdurat))
		watch(() => this.ValCtrdurat.value, (newValue, oldValue) => this.onUpdate('contr.ctrdurat', this.ValCtrdurat, newValue, oldValue))

		this.ValTransval = reactive(new modelFieldType.Number({
			id: 'ValTransval',
			originId: 'ValTransval',
			area: 'CONTR',
			field: 'TRANSVAL',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.TRANSFER_VALUE12168),
		}).cloneFrom(values?.ValTransval))
		watch(() => this.ValTransval.value, (newValue, oldValue) => this.onUpdate('contr.transval', this.ValTransval, newValue, oldValue))

		this.ValComiseur = reactive(new modelFieldType.Number({
			id: 'ValComiseur',
			originId: 'ValComiseur',
			area: 'CONTR',
			field: 'COMISEUR',
			maxDigits: 10,
			decimalDigits: 0,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					// Formula: [CONTR->TRANSVAL]*[AGENT->PERC_COM]
					return this.ValTransval.value*this.AgentValPerc_com.value
				},
				dependencyEvents: ['fieldChange:contr.transval', 'fieldChange:agent.perc_com'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.MONETARY_VALUE_COMIS27197),
		}).cloneFrom(values?.ValComiseur))
		watch(() => this.ValComiseur.value, (newValue, oldValue) => this.onUpdate('contr.comiseur', this.ValComiseur, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.AgentValPerc_com = reactive(new modelFieldType.Number({
			id: 'AgentValPerc_com',
			originId: 'ValPerc_com',
			area: 'AGENT',
			field: 'PERC_COM',
			maxDigits: 1,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.PERCENTAGE_OF_THE_CO01872),
		}).cloneFrom(values?.AgentValPerc_com))
		watch(() => this.AgentValPerc_com.value, (newValue, oldValue) => this.onUpdate('agent.perc_com', this.AgentValPerc_com, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFCntrctViewModel instance.
	 * @returns {QFormFCntrctViewModel} A new instance of QFormFCntrctViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcontr'

	get QPrimaryKey() { return this.ValCodcontr.value }
	set QPrimaryKey(value) { this.ValCodcontr.updateValue(value) }
}
