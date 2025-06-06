import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/F_AGENT/:mode/:id?',
			name: 'form-F_AGENT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFAgent/QFormFAgent.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AGENT',
				humanKeyFields: ['ValEmail', 'ValPhone']
			}
		},
		{
			path: '/:culture/:system/:module/form/F_CLUB/:mode/:id?',
			name: 'form-F_CLUB',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFClub/QFormFClub.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CLUB',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/F_CNTRCT/:mode/:id?',
			name: 'form-F_CNTRCT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFCntrct/QFormFCntrct.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CONTR',
				humanKeyFields: ['ValCodplayr', 'ValCodclub']
			}
		},
		{
			path: '/:culture/:system/:module/form/F_CNTRY/:mode/:id?',
			name: 'form-F_CNTRY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFCntry/QFormFCntry.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CNTRY',
				humanKeyFields: ['ValCountry']
			}
		},
		{
			path: '/:culture/:system/:module/form/F_PLAYER/:mode/:id?',
			name: 'form-F_PLAYER',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFPlayer/QFormFPlayer.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PLAYR',
				humanKeyFields: ['ValName', 'ValBirthdat']
			}
		},
	]
}
