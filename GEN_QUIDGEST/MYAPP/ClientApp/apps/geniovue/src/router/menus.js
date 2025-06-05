// eslint-disable-next-line no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/AJF/menu/AJF_21',
			name: 'menu-AJF_21',
			component: () => import('@/views/menus/ModuleAJF/MenuAJF_21/QMenuAjf21.vue'),
			meta: {
				routeType: 'menu',
				module: 'AJF',
				order: '21',
				baseArea: 'PLAYR',
				hasInitialPHE: false,
				humanKeyFields: ['ValName', 'ValBirthdat'],
			}
		},
		{
			path: '/:culture/:system/AJF/menu/AJF_611',
			name: 'menu-AJF_611',
			component: () => import('@/views/menus/ModuleAJF/MenuAJF_611/QMenuAjf611.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'AJF',
				order: '611',
				baseArea: 'PLAYR',
				hasInitialPHE: false,
				humanKeyFields: ['ValName', 'ValBirthdat'],
				limitations: ['agent' /* DB */]
			}
		},
		{
			path: '/:culture/:system/AJF/menu/AJF_51',
			name: 'menu-AJF_51',
			component: () => import('@/views/menus/ModuleAJF/MenuAJF_51/QMenuAjf51.vue'),
			meta: {
				routeType: 'menu',
				module: 'AJF',
				order: '51',
				baseArea: 'CNTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/AJF/menu/AJF_31',
			name: 'menu-AJF_31',
			component: () => import('@/views/menus/ModuleAJF/MenuAJF_31/QMenuAjf31.vue'),
			meta: {
				routeType: 'menu',
				module: 'AJF',
				order: '31',
				baseArea: 'CONTR',
				hasInitialPHE: false,
				humanKeyFields: ['ValCodplayr', 'ValCodclub'],
			}
		},
		{
			path: '/:culture/:system/AJF/menu/AJF_711',
			name: 'menu-AJF_711',
			component: () => import('@/views/menus/ModuleAJF/MenuAJF_711/QMenuAjf711.vue'),
			meta: {
				routeType: 'menu',
				module: 'AJF',
				order: '711',
				baseArea: 'CONTR',
				hasInitialPHE: false,
				humanKeyFields: ['ValCodplayr', 'ValCodclub'],
			}
		},
		{
			path: '/:culture/:system/AJF/menu/AJF_41',
			name: 'menu-AJF_41',
			component: () => import('@/views/menus/ModuleAJF/MenuAJF_41/QMenuAjf41.vue'),
			meta: {
				routeType: 'menu',
				module: 'AJF',
				order: '41',
				baseArea: 'CLUB',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/AJF/menu/AJF_11',
			name: 'menu-AJF_11',
			component: () => import('@/views/menus/ModuleAJF/MenuAJF_11/QMenuAjf11.vue'),
			meta: {
				routeType: 'menu',
				module: 'AJF',
				order: '11',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValEmail', 'ValPhone'],
			}
		},
		{
			path: '/:culture/:system/AJF/menu/AJF_61',
			name: 'menu-AJF_61',
			component: () => import('@/views/menus/ModuleAJF/MenuAJF_61/QMenuAjf61.vue'),
			meta: {
				routeType: 'menu',
				module: 'AJF',
				order: '61',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValEmail', 'ValPhone'],
			}
		},
	]
}
