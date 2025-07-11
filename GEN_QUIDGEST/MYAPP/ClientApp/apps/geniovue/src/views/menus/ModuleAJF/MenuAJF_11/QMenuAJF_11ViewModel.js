﻿/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'

import MenuViewModelBase from '@/mixins/menuViewModelBase.js'
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
 * @extends MenuViewModelBase
 */
export default class ViewModel extends MenuViewModelBase
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
	}

	/**
	 * Creates a clone of the current QMenuAJF_11ViewModel instance.
	 * @returns {QMenuAJF_11ViewModel} A new instance of QMenuAJF_11ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}
}
