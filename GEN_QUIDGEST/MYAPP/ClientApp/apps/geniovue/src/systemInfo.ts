﻿// @ts-expect-error genericFunctions does not export type definitions yet
import { getLayoutVariables } from '@quidgest/clientapp/utils/genericFunctions'

import layoutConfigJson from './assets/config/Layoutconfig.json'

export const systemInfo = {
	applicationName: 'Agent Finder',

	genio: {
		buildVersion: 20,
		dbIdxVersion: 7,
		dbVersion: '2507',
		genioVersion: '369,93',
		trackChangesVersion: '0',
		assemblyVersion: '369,93.2507.0.20',
		generationDate: {
			year: 2025,
			month: 6,
			day: 6
		}
	},

	system: {
		acronym: 'QUIDGEST',
		name: 'Quidgest',
		baseCurrency: {
			symbol: '€',
			code: 'EUR',
			precision: 2
		}
	},

	locale: {
		defaultLocale: 'en-US',
		availableLocales: [
			{
				language: 'en-US',
				acronym: 'EN',
				displayName: 'English'
			},
		]
	},

	// FIXME: This should be the generator's responsibility, not the client app.
	layout: getLayoutVariables(layoutConfigJson),

	authConfig: {
		useCertificate: false,
		maxUsrSize: 100,
		maxPswSize: 150
	},

	cookies: {
		cookieText: '',
		cookieActive: false,
		filePath: ''
	},

	isCavAvailable: false,

	isChatBotAvailable: false,

	isSuggestionsAvailable: true,

	appAlerts: [
	],

	userRegistration: {
		allowRegistration: false,
		registrationTypes: [
		]
	},

	resourcesPath: 'Content/img/'
}
