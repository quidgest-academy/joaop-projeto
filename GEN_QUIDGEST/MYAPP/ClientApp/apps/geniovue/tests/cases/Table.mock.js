﻿import cloneDeep from 'lodash-es/cloneDeep'

import controlClass from '@/mixins/fieldControl.js'
import listFunctions from '@/mixins/listFunctions.js'

function getTableTest(context)
{
	return new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						Text: 'Lorem ipsum dolor',
						Numeric: 45,
						Date: '2021-02-16 23:24:12',
						Boolean: 1,
						Array: '1',
						Currency: 27.18,
						HyperLink: 'http://www.google.com',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						Text: 'sit amet',
						Numeric: 260,
						Date: '2021-01-14 13:57:43',
						Boolean: 1,
						Array: '3',
						Currency: 67.86,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						Text: 'consectetur adipiscing elit',
						Numeric: 2800,
						Date: '2021-03-04 07:58:31',
						Boolean: 0,
						Array: '3',
						Currency: 84.02,
						HyperLink: 'http://www.google.com',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						Text: 'sed do eiusmod tempor',
						Numeric: 14000,
						Date: '2021-01-28 03:50:20',
						Boolean: 1,
						Array: '5',
						Currency: 63.79,
						HyperLink: 'http://www.google.com',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						backgroundColor: '#E0E0E0',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						Text: 'incididunt ut labore',
						Numeric: 330000,
						Date: '2021-02-23 23:46:50',
						Boolean: 0,
						Array: '3',
						Currency: 601.7,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						foregroundColor: '#00A000',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						Text: 'et dolore magna aliqua',
						Numeric: 2400000,
						Date: '2021-03-08 16:17:47',
						Boolean: 1,
						Array: '5',
						Currency: 24.49,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						backgroundColor: '#E0E0E0',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						Text: 'Ut enim ad minim veniam',
						Numeric: 80000000,
						Date: '2021-02-12 09:40:16',
						Boolean: 1,
						Array: '1',
						Currency: 688.2,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						foregroundColor: '#00A000',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						Text: 'quis nostrud exercitation ullamco',
						Numeric: 18.01,
						Date: '2021-01-28 17:00:27',
						Boolean: 0,
						Array: '1',
						Currency: 9.028,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						Text: 'laboris nisi ut aliquip ex ea',
						Numeric: 220.23,
						Date: '2021-03-01 12:48:48',
						Boolean: 0,
						Array: '3',
						Currency: 57.13,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: false
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						Text: 'commodo consequat',
						Numeric: 70000000.0456,
						Date: '',
						Boolean: 0,
						Array: '5',
						Currency: 8.675,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						columns: [
							{ order: 1 },
							{ order: 2 },
							{ order: 3 },
							{ order: 4, foregroundColor: '#C08000' },
							{ order: 5 },
							{ order: 6 },
							{ order: 7 },
							{ order: 8 },
							{ order: 9 },
							{ order: 10 }
						],
						isValid: false
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					order: 1,
					label: '',
					area: 'DFLDS',
					field: 'PrimaryKey',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					order: 2,
					label: 'KEY',
					area: 'DFLDS',
					field: 'KEY',
					name: 'Key',
					dataType: 'Text',
					searchFieldType: 'text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					searchable: true,
					initialSortOrder: 'asc',
					params: {
						type: 'form',
						formName: 'FORMX',
						mode: 'SHOW',
						isPopup: false
					},
					cellAction: true
				},
				{
					order: 3,
					label: 'VALUE',
					area: 'DFLDS',
					field: 'VAL',
					name: 'Val',
					dataType: 'Text',
					searchFieldType: 'text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					isDefaultSearch: true,
					sortable: true,
					searchable: true,
					distinctValues: [
						'thing',
						'things',
						'thang',
						'stuff',
						'cool',
						'asfd',
						'nkef',
						'dyn',
						'mgh',
						'nm'
					]
				},
				{
					order: 4,
					label: 'Text',
					area: 'DFLDS',
					field: 'TEXT',
					name: 'Text',
					dataType: 'Text',
					searchFieldType: 'text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					searchable: true
				},
				{
					order: 5,
					label: 'Numeric',
					area: 'DFLDS',
					field: 'NUMERIC',
					name: 'Numeric',
					dataType: 'Numeric',
					searchFieldType: 'num',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 3,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					searchable: true
				},
				{
					order: 6,
					label: 'Date',
					area: 'DFLDS',
					field: 'DATE',
					name: 'Date',
					dataType: 'Date',
					searchFieldType: 'date',
					dataDisplay: listFunctions.dateDisplayCell,
					dataSearch: listFunctions.dateSearchCell,
					dateTimeType: 'dateTimeSeconds',
					sortable: true,
					searchable: true
				},
				{
					order: 7,
					label: 'Boolean',
					area: 'DFLDS',
					field: 'BOOLEAN',
					name: 'Boolean',
					dataType: 'Boolean',
					searchFieldType: 'bool',
					dataDisplay: listFunctions.booleanDisplayCell,
					dataSearch: listFunctions.booleanSearchCell,
					sortable: true,
					searchable: true,
					supportForm: '',
					component: 'q-render-boolean'
				},
				{
					order: 8,
					label: 'Array',
					area: 'DFLDS',
					field: 'ARRAY',
					name: 'Array',
					dataType: 'Array',
					searchFieldType: 'enum',
					dataDisplay: listFunctions.enumerationDisplayCell,
					dataSearch: listFunctions.enumerationSearchCell,
					arrayAsObj: {
						1: 'Low',
						3: 'Medium',
						5: 'High'
					},
					sortable: true,
					searchable: true
				},
				{
					order: 9,
					label: 'Currency',
					area: 'DFLDS',
					field: 'CURRENCY',
					name: 'Currency',
					dataType: 'Currency',
					searchFieldType: 'num',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					searchable: true
				},
				{
					order: 10,
					label: 'HyperLink',
					area: 'DFLDS',
					field: 'HYPERLINK',
					name: 'HyperLink',
					dataType: 'HyperLink',
					searchFieldType: 'text',
					dataDisplay: listFunctions.hyperLinkDisplayCell,
					dataSearch: listFunctions.hyperLinkSearchCell,
					component: 'q-render-hyperlink'
				}
			],
			config: {
				name: 'DFLDS',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Basic Types',
				lcid: 'pt-PT',
				serverMode: false,
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					placeholder: 'PESQUISAR34506',
					visibility: true
				},
				viewManagement: 'T',
				signalOpenAdvancedFilters: null,
				allowColumnFilters: true,
				customActions: [
					{
						id: 'show_table',
						title: 'custom',
						icon: {
							icon: 'duplicate'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMY', mode: 'SHOW' }
					}
				],
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						isInReadOnly: true,
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' },
						separator: true
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				rowClickAction: {
					id: 'EDIT',
					title: 'EDITAR11616',
					icon: {
						icon: 'pencil'
					},
					params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
				},
				actionsPlacement: 'left',
				rowValidation: {
					fnValidate: (row) => row.Fields.isValid,
					message: 'ATENCAO__ESTA_FICHA_24725'
				},
				allowFileExport: true,
				exportOptions: [
					{ id: 'pdf', text: 'FORMATO_DE_DOCUMENTO48724' },
					{ id: 'ods', text: 'FOLHA_DE_CALCULO__OD46941' },
					{ id: 'xlsx', text: 'FOLHA_DE_CALCULO_EXC59518' },
					{ id: 'csv', text: 'VALORES_SEPARADOS_PO10397' },
					{ id: 'xml', text: 'FORMATO_XML__XML_44251' }
				],
				allowFileImport: true,
				importOptions: [{ key: 'xlsx', value: 'FOLHA_DE_CALCULO_EXC59518' }],
				importTemplateOptions: [{ key: 'xlsx', value: 'DOWNLOAD_DE_TEMPLATE48385' }],
				columnConfigIsVisible: false,
				rowClickActionInternal: 'selectMultiple',
				hasTextWrap: false,
				defaultSearchColumnName: 'Key',
				resourcesPath: 'dist/Content/img/',
				canInsert: true
			},
			readonly: false,
			advancedFilters: [],
			groupFilters: [
				{
					id: 'filter_GQT_Menu_111_DEVOLUCAO',
					isMultiple: false,
					value: '2',
					filters: [
						{
							key: '0',
							value: 'POR_DEVOLVER13204',
							selected: false,
							id: 'filter_GQT_Menu_111_DEVOLUCAO_0'
						},
						{
							key: '1',
							value: 'DEVOLVIDOS52106',
							selected: false,
							id: 'filter_GQT_Menu_111_DEVOLUCAO_1'
						},
						{
							key: '2',
							value: 'TODOS59977',
							selected: true,
							id: 'filter_GQT_Menu_111_DEVOLUCAO_2'
						}
					]
				}
			],
			activeFilters: {
				options: [
					{
						key: '0',
						value: 'ACTIVE',
						selected: false,
						id: 'filter_GQT_Menu_111_ActiveFilter_A'
					},
					{
						key: '1',
						value: 'INACTIVE',
						selected: false,
						id: 'filter_GQT_Menu_111_ActiveFilter_I'
					},
					{
						key: '2',
						value: 'FUTURE',
						selected: true,
						id: 'filter_GQT_Menu_111_ActiveFilter_F'
					}
				],
				dateValue: {
					type: 'date',
					title: 'Date',
					id: 'GQT_Menu_111_dataRef',
					value: ''
				}
			},
			rowsChecked: {},
			dataImportResponse: {}
		},
		context || {
			$getResource: (resId) => resId
		},
		{}
	)
}

export default {
	tableTest: getTableTest(),
	getTableTest,
	tableTestEdit: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						Text: 'Lorem ipsum dolor',
						Numeric: 45,
						Date: '2021-02-16 23:24:12',
						Boolean: 1,
						Array: '1',
						Currency: 27.18,
						Checkbox: 0,
						HyperLink: 'http://www.google.com',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						Text: 'sit amet',
						Numeric: 260,
						Date: '2021-01-14 13:57:43',
						Boolean: 1,
						Array: '3',
						Currency: 67.86,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						Text: 'consectetur adipiscing elit',
						Numeric: 2800,
						Date: '2021-03-04 07:58:31',
						Boolean: 0,
						Array: '3',
						Currency: 84.02,
						Checkbox: 0,
						HyperLink: 'http://www.google.com',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						Text: 'sed do eiusmod tempor',
						Numeric: 14000,
						Date: '2021-01-28 03:50:20',
						Boolean: 1,
						Array: '5',
						Currency: 63.79,
						Checkbox: 0,
						HyperLink: 'http://www.google.com',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						Text: 'incididunt ut labore',
						Numeric: 330000,
						Date: '2021-02-23 23:46:50',
						Boolean: 0,
						Array: '3',
						Currency: 601.7,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						Text: 'et dolore magna aliqua',
						Numeric: 2400000,
						Date: '2021-03-08 16:17:47',
						Boolean: 1,
						Array: '5',
						Currency: 24.49,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						Text: 'Ut enim ad minim veniam',
						Numeric: 80000000,
						Date: '2021-02-12 09:40:16',
						Boolean: 1,
						Array: '1',
						Currency: 688.2,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						Text: 'quis nostrud exercitation ullamco',
						Numeric: 18.01,
						Date: '2021-01-28 17:00:27',
						Boolean: 0,
						Array: '1',
						Currency: 9.028,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						Text: 'laboris nisi ut aliquip ex ea',
						Numeric: 220.23,
						Date: '2021-03-01 12:48:48',
						Boolean: 0,
						Array: '3',
						Currency: 57.13,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: false
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						Text: 'commodo consequat',
						Numeric: 70000000.0456,
						Date: '',
						Boolean: 0,
						Array: '5',
						Currency: 8.675,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: false
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					initialSort: true,
					initialSortOrder: 'asc',
					params: {
						type: 'form',
						formName: 'FORMX',
						mode: 'SHOW',
						isPopup: false
					},
					cellAction: true
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: [],
					component: 'q-edit-text',
					componentOptions: {}
				},
				{
					label: 'Text',
					name: 'Text',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true
				},
				{
					label: 'Numeric',
					name: 'Numeric',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 3,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					component: 'q-edit-numeric',
					componentOptions: {
						maxDigits: 10,
						isDecimal: true,
						thousandsSep: ' ',
						decimalSep: '.'
					}
				},
				{
					label: 'Date',
					name: 'Date',
					dataType: 'Date',
					dataDisplay: listFunctions.dateDisplayCell,
					dataSearch: listFunctions.dateSearchCell,
					dateTimeType: 'dateTimeSeconds',
					sortable: true
				},
				{
					label: 'Boolean',
					name: 'Boolean',
					dataType: 'Boolean',
					dataDisplay: listFunctions.booleanDisplayCell,
					dataSearch: listFunctions.booleanSearchCell,
					sortable: true,
					supportForm: '',
					component: 'q-edit-boolean'
				},
				{
					label: 'Array',
					name: 'Array',
					dataType: 'Array',
					dataDisplay: listFunctions.enumerationDisplayCell,
					dataSearch: listFunctions.enumerationSearchCell,
					arrayAsObj: {
						1: 'Low',
						3: 'Medium',
						5: 'High'
					},
					sortable: true
				},
				{
					label: 'Currency',
					name: 'Currency',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				},
				{
					label: 'HyperLink',
					name: 'HyperLink',
					dataType: 'HyperLink',
					dataDisplay: listFunctions.hyperLinkDisplayCell,
					dataSearch: listFunctions.hyperLinkSearchCell,
					component: 'q-render-hyperlink'
				}
			],
			config: {
				name: 'DFLDS',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Basic Types (Edit)',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'show_table',
						title: 'custom',
						icon: {
							icon: 'duplicate'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMY', mode: 'SHOW' }
					},
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						isInReadOnly: true,
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' },
						separator: true
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				rowClickAction: {
					id: 'EDIT',
					title: 'EDITAR11616',
					icon: {
						icon: 'pencil'
					},
					params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
				},
				actionsPlacement: 'left',
				rowValidation: {
					fnValidate: (row) => row.Fields.isValid,
					message: 'ATENCAO__ESTA_FICHA_24725'
				},
				allowFileExport: true,
				exportOptions: [
					{ id: 'pdf', text: 'FORMATO_DE_DOCUMENTO48724' },
					{ id: 'ods', text: 'FOLHA_DE_CALCULO__OD46941' },
					{ id: 'xlsx', text: 'FOLHA_DE_CALCULO_EXC59518' },
					{ id: 'csv', text: 'VALORES_SEPARADOS_PO10397' },
					{ id: 'xml', text: 'FORMATO_XML__XML_44251' }
				],
				allowFileImport: true,
				importOptions: [{ key: 'xlsx', value: 'FOLHA_DE_CALCULO_EXC59518' }],
				importTemplateOptions: [{ key: 'xlsx', value: 'DOWNLOAD_DE_TEMPLATE48385' }],
				resourcesPath: 'dist/Content/img/'
			},
			readonly: false,
			groupFilters: [
				{
					id: 'filter_GQT_Menu_111_DEVOLUCAO',
					isMultiple: false,
					value: '2',
					filters: [
						{
							key: '0',
							value: 'POR_DEVOLVER13204',
							selected: false,
							id: 'filter_GQT_Menu_111_DEVOLUCAO_0'
						},
						{
							key: '1',
							value: 'DEVOLVIDOS52106',
							selected: false,
							id: 'filter_GQT_Menu_111_DEVOLUCAO_1'
						},
						{
							key: '2',
							value: 'TODOS59977',
							selected: true,
							id: 'filter_GQT_Menu_111_DEVOLUCAO_2'
						}
					]
				}
			],
			activeFilters: {
				options: [
					{
						key: '0',
						value: 'ACTIVE',
						selected: false,
						id: 'filter_GQT_Menu_111_ActiveFilter_A'
					},
					{
						key: '1',
						value: 'INACTIVE',
						selected: false,
						id: 'filter_GQT_Menu_111_ActiveFilter_I'
					},
					{
						key: '2',
						value: 'FUTURE',
						selected: true,
						id: 'filter_GQT_Menu_111_ActiveFilter_F'
					}
				],
				dateValue: {
					type: 'date',
					title: 'Date',
					id: 'GQT_Menu_111_dataRef',
					value: ''
				}
			},
			dataImportResponse: {}
		},
		{},
		{}
	),
	tableTestReorder: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						Text: 'Lorem ipsum dolor',
						Numeric: 1,
						Date: '2021-02-16 23:24:12',
						Boolean: 1,
						Array: '1',
						Currency: 27.18,
						Checkbox: 0,
						HyperLink: 'http://www.google.com',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						Text: 'sit amet',
						Numeric: 2,
						Date: '2021-01-14 13:57:43',
						Boolean: 1,
						Array: '3',
						Currency: 67.86,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						Text: 'consectetur adipiscing elit',
						Numeric: 3,
						Date: '2021-03-04 07:58:31',
						Boolean: 0,
						Array: '3',
						Currency: 84.02,
						Checkbox: 0,
						HyperLink: 'http://www.google.com',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						Text: 'sed do eiusmod tempor',
						Numeric: 4,
						Date: '2021-01-28 03:50:20',
						Boolean: 1,
						Array: '5',
						Currency: 63.79,
						Checkbox: 0,
						HyperLink: 'http://www.google.com',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						Text: 'incididunt ut labore',
						Numeric: 5,
						Date: '2021-02-23 23:46:50',
						Boolean: 0,
						Array: '3',
						Currency: 601.7,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						Text: 'et dolore magna aliqua',
						Numeric: 6,
						Date: '2021-03-08 16:17:47',
						Boolean: 1,
						Array: '5',
						Currency: 24.49,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						Text: 'Ut enim ad minim veniam',
						Numeric: 7,
						Date: '2021-02-12 09:40:16',
						Boolean: 1,
						Array: '1',
						Currency: 688.2,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						Text: 'quis nostrud exercitation ullamco',
						Numeric: 8,
						Date: '2021-01-28 17:00:27',
						Boolean: 0,
						Array: '1',
						Currency: 9.028,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						Text: 'laboris nisi ut aliquip ex ea',
						Numeric: 9,
						Date: '2021-03-01 12:48:48',
						Boolean: 0,
						Array: '3',
						Currency: 57.13,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: false
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						Text: 'commodo consequat',
						Numeric: 10,
						Date: '',
						Boolean: 0,
						Array: '5',
						Currency: 8.675,
						Checkbox: 0,
						HyperLink: '',
						Image: '',
						Document: '',
						Action: '',
						Geographic: '',
						Unknown: '',
						isValid: false
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					params: {
						type: 'form',
						formName: 'FORMX',
						mode: 'SHOW',
						isPopup: false
					},
					cellAction: true
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: [],
					component: 'q-edit-text',
					componentOptions: {}
				},
				{
					label: 'Text',
					name: 'Text',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true
				},
				{
					label: 'Numeric',
					name: 'Numeric',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					dataOnChange: listFunctions.reCalcCellOrder,
					decimalPlaces: 3,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					component: 'q-edit-numeric',
					componentOptions: {
						maxDigits: 10,
						isDecimal: false,
						thousandsSep: ' ',
						decimalSep: '.'
					},
					isOrderingColumn: true
				},
				{
					label: 'Date',
					name: 'Date',
					dataType: 'Date',
					dataDisplay: listFunctions.dateDisplayCell,
					dataSearch: listFunctions.dateSearchCell,
					dateTimeType: 'dateTimeSeconds',
					sortable: true
				},
				{
					label: 'Boolean',
					name: 'Boolean',
					dataType: 'Boolean',
					dataDisplay: listFunctions.booleanDisplayCell,
					dataSearch: listFunctions.booleanSearchCell,
					sortable: true,
					supportForm: '',
					component: 'q-edit-boolean'
				},
				{
					label: 'Array',
					name: 'Array',
					dataType: 'Array',
					dataDisplay: listFunctions.enumerationDisplayCell,
					dataSearch: listFunctions.enumerationSearchCell,
					arrayAsObj: {
						1: 'Low',
						3: 'Medium',
						5: 'High'
					},
					sortable: true
				},
				{
					label: 'Currency',
					name: 'Currency',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'EUR',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				},
				{
					label: 'HyperLink',
					name: 'HyperLink',
					dataType: 'HyperLink',
					dataDisplay: listFunctions.hyperLinkDisplayCell,
					dataSearch: listFunctions.hyperLinkSearchCell,
					component: 'q-render-hyperlink'
				}
			],
			config: {
				name: 'DFLDS_REORDER',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Basic Types (Reorder)',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'show_table',
						title: 'custom',
						icon: {
							icon: 'duplicate'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMY', mode: 'SHOW' }
					},
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						isInReadOnly: true,
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' },
						separator: true
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						isInReadOnly: false,
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				rowClickAction: {
					id: 'EDIT',
					title: 'EDITAR11616',
					icon: {
						icon: 'pencil'
					},
					params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
				},
				actionsPlacement: 'left',
				rowValidation: {
					fnValidate: (row) => row.Fields.isValid,
					message: 'ATENCAO__ESTA_FICHA_24725'
				},
				allowFileExport: true,
				exportOptions: [
					{ id: 'pdf', text: 'FORMATO_DE_DOCUMENTO48724' },
					{ id: 'ods', text: 'FOLHA_DE_CALCULO__OD46941' },
					{ id: 'xlsx', text: 'FOLHA_DE_CALCULO_EXC59518' },
					{ id: 'csv', text: 'VALORES_SEPARADOS_PO10397' },
					{ id: 'xml', text: 'FORMATO_XML__XML_44251' }
				],
				allowFileImport: true,
				importOptions: [{ key: 'xlsx', value: 'FOLHA_DE_CALCULO_EXC59518' }],
				importTemplateOptions: [{ key: 'xlsx', value: 'DOWNLOAD_DE_TEMPLATE48385' }],
				hasRowDragAndDrop: false,
				showRowDragAndDropOption: true,
				resourcesPath: 'dist/Content/img/'
			},
			readonly: false,
			groupFilters: [
				{
					id: 'filter_GQT_Menu_111_DEVOLUCAO',
					isMultiple: false,
					value: '2',
					filters: [
						{
							key: '0',
							value: 'POR_DEVOLVER13204',
							selected: false,
							id: 'filter_GQT_Menu_111_DEVOLUCAO_0'
						},
						{
							key: '1',
							value: 'DEVOLVIDOS52106',
							selected: false,
							id: 'filter_GQT_Menu_111_DEVOLUCAO_1'
						},
						{
							key: '2',
							value: 'TODOS59977',
							selected: true,
							id: 'filter_GQT_Menu_111_DEVOLUCAO_2'
						}
					]
				}
			],
			activeFilters: {
				options: [
					{
						key: '0',
						value: 'ACTIVE',
						selected: false,
						id: 'filter_GQT_Menu_111_ActiveFilter_A'
					},
					{
						key: '1',
						value: 'INACTIVE',
						selected: false,
						id: 'filter_GQT_Menu_111_ActiveFilter_I'
					},
					{
						key: '2',
						value: 'FUTURE',
						selected: true,
						id: 'filter_GQT_Menu_111_ActiveFilter_F'
					}
				],
				dateValue: {
					type: 'date',
					title: 'Date',
					id: 'GQT_Menu_111_dataRef',
					value: ''
				}
			},
			dataImportResponse: {}
		},
		{},
		{}
	),
	tableTestDates: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						Date: '2021-02-16',
						DateTime: '2021-02-16 23:24',
						DateTimeSeconds: '2021-02-16 23:24:12',
						Time: '23:24',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						Date: '2021-01-14',
						DateTime: '2021-01-14 13:57',
						DateTimeSeconds: '2021-01-14 13:57:43',
						Time: '13:57',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						Date: '2021-03-04',
						DateTime: '2021-03-04 07:58',
						DateTimeSeconds: '2021-03-04 07:58:31',
						Time: '07:58',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						Date: '2021-01-28',
						DateTime: '2021-01-28 03:50',
						DateTimeSeconds: '2021-01-28 03:50:20',
						Time: '03:50',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						Date: '2021-02-23',
						DateTime: '2021-02-23 23:46',
						DateTimeSeconds: '2021-02-23 23:46:50',
						Time: '23:46',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						Date: '2021-03-08',
						DateTime: '2021-03-08 16:17',
						DateTimeSeconds: '2021-03-08 16:17:47',
						Time: '16:17',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						Date: '2021-02-12',
						DateTime: '2021-02-12 09:40',
						DateTimeSeconds: '2021-02-12 09:40:16',
						Time: '09:40',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						Date: '2021-01-28',
						DateTime: '2021-01-28 17:00',
						DateTimeSeconds: '2021-01-28 17:00:27',
						Time: '17:00',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						Date: '2021-03-01',
						DateTime: '2021-03-01 12:48',
						DateTimeSeconds: '2021-03-01 12:48:48',
						Time: '12:48',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						Date: '2021-02-25',
						DateTime: '2021-02-25 18:20',
						DateTimeSeconds: '2021-02-25 18:20:59',
						Time: '00:00',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: 'Date',
					name: 'Date',
					dataType: 'Date',
					dataDisplay: listFunctions.dateDisplayCell,
					dataSearch: listFunctions.dateSearchCell,
					dateTimeType: 'date',
					sortable: true
				},
				{
					label: 'DateTime',
					name: 'DateTime',
					dataType: 'Date',
					dataDisplay: listFunctions.dateDisplayCell,
					dataSearch: listFunctions.dateSearchCell,
					dateTimeType: 'dateTime',
					sortable: true
				},
				{
					label: 'DateTimeSeconds',
					name: 'DateTimeSeconds',
					dataType: 'Date',
					dataDisplay: listFunctions.dateDisplayCell,
					dataSearch: listFunctions.dateSearchCell,
					dateTimeType: 'dateTimeSeconds',
					sortable: true
				},
				{
					label: 'Time',
					name: 'Time',
					dataType: 'Date',
					dataDisplay: listFunctions.dateDisplayCell,
					dataSearch: listFunctions.dateSearchCell,
					dateTimeType: 'time',
					sortable: true
				}
			],
			config: {
				name: 'DDATE',
				pkColumn: '',
				tableTitle: 'Date Types',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				]
			}
		},
		{},
		{}
	),
	tableTestOther: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '355a012d-0a48-4a2b-abba-a17d73cbc3f4',
					FormMode: '',
					Fields: {
						Key: '355a012d-0a48-4a2b-abba-a17d73cbc3f4',
						Image: {
							data: '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',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: 'Bomb',
							titleText: 'Bomb'
						},
						Document: {
							fileName: 'recmp_formcontroller.txt',
							title: 'Descarregar',
							ticket: 'VDttUZkdKgTvAZrFfsCtPY9pS5j00Yhp7M7SjR3FIWahjDEs5FoDXiIv5RgGOsTjpi6BTroZCLcSmtN7w746Hbetpag9_qa3pHyaA24kJEbZRKSKhSU7hQqPC3K5C.YghdUq0emuDNmZApO4K0rSKXZ.1qBDhfs.npbQeXIJy.1oDpaGCBU5iuYOftLN_1fhtXF8CpSYOJF_syKV51DF0EKqzO9WYJSMetujGWCFdZ85MW_Jh8QVTGY9JDDdGlqR_.aLZx4XJKx6avJalGmBIT6jhrf3NhWrlW1DVWjayU8eN0RXlMZNqL771569eAbz32ZZap_MsUl7bGxe1QtkGZaAoZfJ_nGdph0wA_72hzBATjcCf8VQutuzcTVxvcAZ'
						},
						Geographic: {
							Lat: -8.1986484000000246,
							Long: 39.4621054
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						Key: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Image: {
							data: '',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: '',
							titleText: ''
						},
						Document: {
							fileName: 'thing.txt',
							title: 'Thing',
							ticket: 'VDttUZkdKgTvAZrFfsCtPY9pS5j00Yhp7M7SjR3FIWahjDEs5FoDXiIv5RgGOsTjpi6BTroZCLcSmtN7w746Hbetpag9_qa3pHyaA24kJEbZRKSKhSU7hQqPC3K5C.YghdUq0emuDNmZApO4K0rSKXZ.1qBDhfs.npbQeXIJy.1oDpaGCBU5iuYOftLN_1fhtXF8CpSYOJF_syKV51DF0EKqzO9WYJSMetujGWCFdZ85MW_Jh8QVTGY9JDDdGlqR_.aLZx4XJKx6avJalGmBIT6jhrf3NhWrlW1DVWjayU8eN0RXlMZNqL771569eAbz32ZZap_MsUl7bGxe1QtkGZaAoZfJ_nGdph0wA_72hzBATjcCf8VQutuzcTVxvcAZ'
						},
						Geographic: {
							Lat: -8.629105299999992,
							Long: 41.1579438
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						Key: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Image: {
							data: '',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: '',
							titleText: ''
						},
						Document: {
							fileName: 'stuff.txt',
							title: 'Stuff',
							ticket: 'VDttUZkdKgTvAZrFfsCtPY9pS5j00Yhp7M7SjR3FIWahjDEs5FoDXiIv5RgGOsTjpi6BTroZCLcSmtN7w746Hbetpag9_qa3pHyaA24kJEbZRKSKhSU7hQqPC3K5C.YghdUq0emuDNmZApO4K0rSKXZ.1qBDhfs.npbQeXIJy.1oDpaGCBU5iuYOftLN_1fhtXF8CpSYOJF_syKV51DF0EKqzO9WYJSMetujGWCFdZ85MW_Jh8QVTGY9JDDdGlqR_.aLZx4XJKx6avJalGmBIT6jhrf3NhWrlW1DVWjayU8eN0RXlMZNqL771569eAbz32ZZap_MsUl7bGxe1QtkGZaAoZfJ_nGdph0wA_72hzBATjcCf8VQutuzcTVxvcAZ'
						},
						Geographic: {
							Lat: 13.237557039208923,
							Long: -8.8307042105525753
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						Key: '47556088-f88e-47fd-b618-323112f96176',
						Image: {
							data: '',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: '',
							titleText: ''
						},
						Document: {
							fileName: '',
							title: '',
							ticket: ''
						},
						Geographic: {
							Lat: 13.219532594628845,
							Long: -8.820465516128893
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						Key: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Image: {
							data: '',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: '',
							titleText: ''
						},
						Document: {
							fileName: '',
							title: '',
							ticket: ''
						},
						Geographic: {
							Lat: -8.2486727000000428,
							Long: 39.450292900000008
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						Key: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Image: {
							data: '',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: '',
							titleText: ''
						},
						Document: {
							fileName: '',
							title: '',
							ticket: ''
						},
						Geographic: {
							Lat: 0,
							Long: 0
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						Key: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Image: {
							data: '',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: '',
							titleText: ''
						},
						Document: {
							fileName: '',
							title: '',
							ticket: ''
						},
						Geographic: {
							Lat: '',
							Long: ''
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						Key: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Image: {
							data: '',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: '',
							titleText: ''
						},
						Document: {
							fileName: '',
							title: '',
							ticket: ''
						},
						Geographic: {
							Lat: '',
							Long: ''
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						Key: '557e6424-39da-435b-ae56-895ed932a0b7',
						Image: {
							data: '',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: '',
							titleText: ''
						},
						Document: {
							fileName: '',
							title: '',
							ticket: ''
						},
						Geographic: {
							Lat: '',
							Long: ''
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						Key: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Image: {
							data: '',
							dataFormat: 'image/jpg',
							encoding: 'base64',
							altText: '',
							titleText: ''
						},
						Document: {
							fileName: '',
							title: '',
							ticket: ''
						},
						Geographic: {
							Lat: '',
							Long: ''
						},
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: 'Image',
					name: 'Image',
					dataType: 'Image',
					dataDisplay: listFunctions.imageDisplayCell,
					dataSearch: listFunctions.imageSearchCell,
					component: 'q-render-image',
					cellAction: true
				},
				{
					label: 'Document',
					name: 'Document',
					dataType: 'Document',
					dataDisplay: listFunctions.documentDisplayCell,
					dataSearch: listFunctions.documentSearchCell,
					component: 'q-render-document',
					cellAction: true
				},
				{
					label: 'Geographic',
					name: 'Geographic',
					dataType: 'Geographic',
					dataDisplay: listFunctions.geographicDisplayCell,
					dataSearch: listFunctions.geographicSearchCell
				}
			],
			config: {
				name: 'DMISC',
				pkColumn: 'Key',
				tableTitle: 'Other Types',
				lcid: 'pt-PT',
				system: 0,
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				]
			}
		},
		{},
		{}
	),
	tableTestTotaler: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						Numeric1: 5.344,
						Numeric2: 8.84,
						Numeric3: 23,
						Currency1: 4.24,
						Currency2: 35.37,
						Currency3: 6.38,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						Numeric1: 2.568,
						Numeric2: 6.03,
						Numeric3: 18,
						Currency1: 3.89,
						Currency2: 47.45,
						Currency3: 12.56,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						Numeric1: 4.846,
						Numeric2: 10.37,
						Numeric3: 26,
						Currency1: 4.35,
						Currency2: 53.5,
						Currency3: 67.35,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						Numeric1: 8.662,
						Numeric2: 7.87,
						Numeric3: 85,
						Currency1: 5.23,
						Currency2: 28.37,
						Currency3: 45.24,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						Numeric1: 6.983,
						Numeric2: 5.73,
						Numeric3: 67,
						Currency1: 7.38,
						Currency2: 67.34,
						Currency3: 34.34,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						Numeric1: 9.275,
						Numeric2: 12.53,
						Numeric3: 32,
						Currency1: 5.28,
						Currency2: 73.85,
						Currency3: 46.54,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						Numeric1: 3.827,
						Numeric2: 57.54,
						Numeric3: 57,
						Currency1: 7.55,
						Currency2: 89.5,
						Currency3: 25.0,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						Numeric1: 8.325,
						Numeric2: 57.67,
						Numeric3: 86,
						Currency1: 6.64,
						Currency2: 68.84,
						Currency3: 45.75,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						Numeric1: 7.745,
						Numeric2: 38.98,
						Numeric3: 76,
						Currency1: 5.36,
						Currency2: 67.68,
						Currency3: 64.58,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						Numeric1: 6.926,
						Numeric2: 38.57,
						Numeric3: 27,
						Currency1: 9.36,
						Currency2: 78.93,
						Currency3: 86.46,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					initialSort: true,
					initialSortOrder: 'asc'
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: []
				},
				{
					label: 'Numeric1',
					name: 'Numeric1',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 3,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric2',
					name: 'Numeric2',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 2,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric3',
					name: 'Numeric3',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 0,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				},
				{
					label: 'Currency1',
					name: 'Currency1',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency2',
					name: 'Currency2',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency3',
					name: 'Currency3',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				}
			],
			config: {
				name: 'DFLDS',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Column Totalers',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				actionsPlacement: 'left'
			},
			rowsSelected: {},
			rowsChecked: {}
		},
		{},
		{}
	),
	tableTestTotalerSelected: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						Numeric1: 5.344,
						Numeric2: 8.84,
						Numeric3: 23,
						Currency1: 4.24,
						Currency2: 35.37,
						Currency3: 6.38,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						Numeric1: 2.568,
						Numeric2: 6.03,
						Numeric3: 18,
						Currency1: 3.89,
						Currency2: 47.45,
						Currency3: 12.56,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						Numeric1: 4.846,
						Numeric2: 10.37,
						Numeric3: 26,
						Currency1: 4.35,
						Currency2: 53.5,
						Currency3: 67.35,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						Numeric1: 8.662,
						Numeric2: 7.87,
						Numeric3: 85,
						Currency1: 5.23,
						Currency2: 28.37,
						Currency3: 45.24,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						Numeric1: 6.983,
						Numeric2: 5.73,
						Numeric3: 67,
						Currency1: 7.38,
						Currency2: 67.34,
						Currency3: 34.34,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						Numeric1: 9.275,
						Numeric2: 12.53,
						Numeric3: 32,
						Currency1: 5.28,
						Currency2: 73.85,
						Currency3: 46.54,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						Numeric1: 3.827,
						Numeric2: 57.54,
						Numeric3: 57,
						Currency1: 7.55,
						Currency2: 89.5,
						Currency3: 25.0,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						Numeric1: 8.325,
						Numeric2: 57.67,
						Numeric3: 86,
						Currency1: 6.64,
						Currency2: 68.84,
						Currency3: 45.75,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						Numeric1: 7.745,
						Numeric2: 38.98,
						Numeric3: 76,
						Currency1: 5.36,
						Currency2: 67.68,
						Currency3: 64.58,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						Numeric1: 6.926,
						Numeric2: 38.57,
						Numeric3: 27,
						Currency1: 9.36,
						Currency2: 78.93,
						Currency3: 86.46,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					initialSort: true,
					initialSortOrder: 'asc'
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: []
				},
				{
					label: 'Numeric1',
					name: 'Numeric1',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 3,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric2',
					name: 'Numeric2',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 2,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric3',
					name: 'Numeric3',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 0,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				},
				{
					label: 'Currency1',
					name: 'Currency1',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency2',
					name: 'Currency2',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency3',
					name: 'Currency3',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				}
			],
			config: {
				name: 'DFLDS',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Column Totalers (selected)',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				actionsPlacement: 'left',
				rowClickActionInternal: 'selectMultiple',
				rowBgColorSelected: '#e0e0e0',
				showRowsSelectedCount: true
			},
			rowsSelected: {},
			rowsChecked: {}
		},
		{},
		{}
	),
	tableTestSelectMultiple: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						Numeric1: 5.344,
						Numeric2: 8.84,
						Numeric3: 23,
						Currency1: 4.24,
						Currency2: 35.37,
						Currency3: 6.38,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						Numeric1: 2.568,
						Numeric2: 6.03,
						Numeric3: 18,
						Currency1: 3.89,
						Currency2: 47.45,
						Currency3: 12.56,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						Numeric1: 4.846,
						Numeric2: 10.37,
						Numeric3: 26,
						Currency1: 4.35,
						Currency2: 53.5,
						Currency3: 67.35,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						Numeric1: 8.662,
						Numeric2: 7.87,
						Numeric3: 85,
						Currency1: 5.23,
						Currency2: 28.37,
						Currency3: 45.24,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						Numeric1: 6.983,
						Numeric2: 5.73,
						Numeric3: 67,
						Currency1: 7.38,
						Currency2: 67.34,
						Currency3: 34.34,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						Numeric1: 9.275,
						Numeric2: 12.53,
						Numeric3: 32,
						Currency1: 5.28,
						Currency2: 73.85,
						Currency3: 46.54,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						Numeric1: 3.827,
						Numeric2: 57.54,
						Numeric3: 57,
						Currency1: 7.55,
						Currency2: 89.5,
						Currency3: 25.0,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						Numeric1: 8.325,
						Numeric2: 57.67,
						Numeric3: 86,
						Currency1: 6.64,
						Currency2: 68.84,
						Currency3: 45.75,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						Numeric1: 7.745,
						Numeric2: 38.98,
						Numeric3: 76,
						Currency1: 5.36,
						Currency2: 67.68,
						Currency3: 64.58,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						Numeric1: 6.926,
						Numeric2: 38.57,
						Numeric3: 27,
						Currency1: 9.36,
						Currency2: 78.93,
						Currency3: 86.46,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					initialSort: true,
					initialSortOrder: 'asc'
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: []
				},
				{
					label: 'Numeric1',
					name: 'Numeric1',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 3,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric2',
					name: 'Numeric2',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 2,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric3',
					name: 'Numeric3',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 0,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				},
				{
					label: 'Currency1',
					name: 'Currency1',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency2',
					name: 'Currency2',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency3',
					name: 'Currency3',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				}
			],
			config: {
				name: 'DFLDS_SELECT_CHECK',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Select Multiple Rows',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				actionsPlacement: 'left',
				rowClickActionInternal: 'selectMultiple',
				menuForJump: 'MENU_FOLLOWUP',
				rowBgColorSelected: '#e0e0e0',
				showRowsSelectedCount: true
			},
			rowsSelected: {},
			rowsChecked: {}
		},
		{},
		{}
	),
	tableTestSelectMultipleMultiAction: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						Numeric1: 5.344,
						Numeric2: 8.84,
						Numeric3: 23,
						Currency1: 4.24,
						Currency2: 35.37,
						Currency3: 6.38,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						Numeric1: 2.568,
						Numeric2: 6.03,
						Numeric3: 18,
						Currency1: 3.89,
						Currency2: 47.45,
						Currency3: 12.56,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						Numeric1: 4.846,
						Numeric2: 10.37,
						Numeric3: 26,
						Currency1: 4.35,
						Currency2: 53.5,
						Currency3: 67.35,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						Numeric1: 8.662,
						Numeric2: 7.87,
						Numeric3: 85,
						Currency1: 5.23,
						Currency2: 28.37,
						Currency3: 45.24,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						Numeric1: 6.983,
						Numeric2: 5.73,
						Numeric3: 67,
						Currency1: 7.38,
						Currency2: 67.34,
						Currency3: 34.34,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						Numeric1: 9.275,
						Numeric2: 12.53,
						Numeric3: 32,
						Currency1: 5.28,
						Currency2: 73.85,
						Currency3: 46.54,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						Numeric1: 3.827,
						Numeric2: 57.54,
						Numeric3: 57,
						Currency1: 7.55,
						Currency2: 89.5,
						Currency3: 25.0,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						Numeric1: 8.325,
						Numeric2: 57.67,
						Numeric3: 86,
						Currency1: 6.64,
						Currency2: 68.84,
						Currency3: 45.75,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						Numeric1: 7.745,
						Numeric2: 38.98,
						Numeric3: 76,
						Currency1: 5.36,
						Currency2: 67.68,
						Currency3: 64.58,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						Numeric1: 6.926,
						Numeric2: 38.57,
						Numeric3: 27,
						Currency1: 9.36,
						Currency2: 78.93,
						Currency3: 86.46,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					initialSort: true,
					initialSortOrder: 'asc'
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: []
				},
				{
					label: 'Numeric1',
					name: 'Numeric1',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 3,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric2',
					name: 'Numeric2',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 2,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric3',
					name: 'Numeric3',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 0,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				},
				{
					label: 'Currency1',
					name: 'Currency1',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency2',
					name: 'Currency2',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency3',
					name: 'Currency3',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				}
			],
			config: {
				name: 'DFLDS_SELECT_CHECK_MULTI',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Select Multiple Rows (Multiple Actions)',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				actionsPlacement: 'left',
				rowClickActionInternal: 'selectMultiple',
				menuForJump: 'MENU_FOLLOWUP',
				groupActions: [
					{
						id: 'ROUTINE_1',
						title: 'ROUTINE_1',
						icon: {
							icon: 'view'
						},
						params: {
							type: 'routine',
							action: 'openRoutineAction',
							actionName: 'XXX_MenuR_Fun1'
						}
					},
					{
						id: 'ROUTINE_2',
						title: 'ROUTINE_2',
						icon: {
							icon: 'pencil'
						},
						params: {
							type: 'routine',
							action: 'openRoutineAction',
							actionName: 'XXX_MenuR_Fun2'
						}
					},
					{
						id: 'ROUTINE_3',
						title: 'ROUTINE_3',
						icon: {
							icon: 'duplicate'
						},
						params: {
							type: 'routine',
							action: 'openRoutineAction',
							actionName: 'XXX_MenuR_Fun3'
						}
					}
				],
				rowBgColorSelected: '#e0e0e0',
				showRowsSelectedCount: true
			},
			rowsSelected: {},
			rowsChecked: {}
		},
		{},
		{}
	),
	tableTestSelectSingle: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						Numeric1: 5.344,
						Numeric2: 8.84,
						Numeric3: 23,
						Currency1: 4.24,
						Currency2: 35.37,
						Currency3: 6.38,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						Numeric1: 2.568,
						Numeric2: 6.03,
						Numeric3: 18,
						Currency1: 3.89,
						Currency2: 47.45,
						Currency3: 12.56,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						Numeric1: 4.846,
						Numeric2: 10.37,
						Numeric3: 26,
						Currency1: 4.35,
						Currency2: 53.5,
						Currency3: 67.35,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						Numeric1: 8.662,
						Numeric2: 7.87,
						Numeric3: 85,
						Currency1: 5.23,
						Currency2: 28.37,
						Currency3: 45.24,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						Numeric1: 6.983,
						Numeric2: 5.73,
						Numeric3: 67,
						Currency1: 7.38,
						Currency2: 67.34,
						Currency3: 34.34,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						Numeric1: 9.275,
						Numeric2: 12.53,
						Numeric3: 32,
						Currency1: 5.28,
						Currency2: 73.85,
						Currency3: 46.54,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						Numeric1: 3.827,
						Numeric2: 57.54,
						Numeric3: 57,
						Currency1: 7.55,
						Currency2: 89.5,
						Currency3: 25.0,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						Numeric1: 8.325,
						Numeric2: 57.67,
						Numeric3: 86,
						Currency1: 6.64,
						Currency2: 68.84,
						Currency3: 45.75,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						Numeric1: 7.745,
						Numeric2: 38.98,
						Numeric3: 76,
						Currency1: 5.36,
						Currency2: 67.68,
						Currency3: 64.58,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						Numeric1: 6.926,
						Numeric2: 38.57,
						Numeric3: 27,
						Currency1: 9.36,
						Currency2: 78.93,
						Currency3: 86.46,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					initialSort: true,
					initialSortOrder: 'asc'
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: []
				},
				{
					label: 'Numeric1',
					name: 'Numeric1',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 3,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric2',
					name: 'Numeric2',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 2,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Numeric3',
					name: 'Numeric3',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 0,
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				},
				{
					label: 'Currency1',
					name: 'Currency1',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency2',
					name: 'Currency2',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true,
					showTotal: true
				},
				{
					label: 'Currency3',
					name: 'Currency3',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					columnClasses: 'c-table__cell-numeric row-numeric',
					columnHeaderClasses: 'c-table__head-numeric',
					sortable: true
				}
			],
			config: {
				name: 'DFLDS',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Select Single Row',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				actionsPlacement: 'left',
				rowClickActionInternal: 'selectSingle',
				rowBgColorSelected: '#e0e0e0'
			},
			rowsSelected: {},
			rowsChecked: {}
		},
		{},
		{}
	),
	tableTestRemoveRows: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						Numeric1: 5.344,
						Numeric2: 8.84,
						Numeric3: 23,
						Currency1: 4.24,
						Currency2: 35.37,
						Currency3: 6.38,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						Numeric1: 2.568,
						Numeric2: 6.03,
						Numeric3: 18,
						Currency1: 3.89,
						Currency2: 47.45,
						Currency3: 12.56,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						Numeric1: 4.846,
						Numeric2: 10.37,
						Numeric3: 26,
						Currency1: 4.35,
						Currency2: 53.5,
						Currency3: 67.35,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						Numeric1: 8.662,
						Numeric2: 7.87,
						Numeric3: 85,
						Currency1: 5.23,
						Currency2: 28.37,
						Currency3: 45.24,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						Numeric1: 6.983,
						Numeric2: 5.73,
						Numeric3: 67,
						Currency1: 7.38,
						Currency2: 67.34,
						Currency3: 34.34,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						Numeric1: 9.275,
						Numeric2: 12.53,
						Numeric3: 32,
						Currency1: 5.28,
						Currency2: 73.85,
						Currency3: 46.54,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						Numeric1: 3.827,
						Numeric2: 57.54,
						Numeric3: 57,
						Currency1: 7.55,
						Currency2: 89.5,
						Currency3: 25.0,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						Numeric1: 8.325,
						Numeric2: 57.67,
						Numeric3: 86,
						Currency1: 6.64,
						Currency2: 68.84,
						Currency3: 45.75,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						Numeric1: 7.745,
						Numeric2: 38.98,
						Numeric3: 76,
						Currency1: 5.36,
						Currency2: 67.68,
						Currency3: 64.58,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						Numeric1: 6.926,
						Numeric2: 38.57,
						Numeric3: 27,
						Currency1: 9.36,
						Currency2: 78.93,
						Currency3: 86.46,
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					initialSort: true,
					initialSortOrder: 'asc'
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: []
				},
				{
					label: 'Numeric1',
					name: 'Numeric1',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 3,
					sortable: true,
					showTotal: true,
					isVisible: false
				},
				{
					label: 'Numeric2',
					name: 'Numeric2',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 2,
					sortable: true,
					showTotal: true,
					isVisible: false
				},
				{
					label: 'Numeric3',
					name: 'Numeric3',
					dataType: 'Numeric',
					dataDisplay: listFunctions.numericDisplayCell,
					dataSearch: listFunctions.numericSearchCell,
					decimalPlaces: 0,
					sortable: true,
					isVisible: false
				},
				{
					label: 'Currency1',
					name: 'Currency1',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					sortable: true,
					showTotal: true,
					isVisible: false
				},
				{
					label: 'Currency2',
					name: 'Currency2',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					sortable: true,
					showTotal: true,
					isVisible: false
				},
				{
					label: 'Currency3',
					name: 'Currency3',
					dataType: 'Currency',
					dataDisplay: listFunctions.currencyDisplayCell,
					dataSearch: listFunctions.currencySearchCell,
					decimalPlaces: 2,
					currency: 'eur',
					sortable: true,
					isVisible: false
				}
			],
			config: {
				name: 'DFLDS',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Remove Rows',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				supportForm: {
					name: 'FORMX',
					type: 'popup',
					mode: 'insert',
					repeatInsert: false
				},
				globalSearch: {
					visibility: true
				},
				actionsPlacement: 'left',
				rowClickActionInternal: '',
				rowBgColorSelected: '#e0e0e0',
				showRowsSelectedCount: false,
				extendedActions: ['remove', 'remove-reset'],
				perPage: 5
			},
			rowsSelected: {},
			rowsChecked: {}
		},
		{},
		{}
	),
	tableTestPaginationNormal: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					initialSort: true,
					initialSortOrder: 'asc'
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: []
				}
			],
			config: {
				name: 'DFLDS',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Pagination (normal)',
				lcid: 'pt-PT',
				serverMode: false,
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				actionsPlacement: 'left',
				rowClickActionInternal: '',
				perPage: 1,
				numVisibilePaginationButtons: 5,
				showRecordCount: true
			}
		},
		{},
		{}
	),
	tableTestPaginationNormalServer: new controlClass.TableListControl(
		{
			config: {
				name: 'DFLDS',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Pagination (normal, server)',
				lcid: 'pt-PT',
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				actionsPlacement: 'left',
				rowClickActionInternal: '',
				perPage: 1,
				numVisibilePaginationButtons: 5,
				showRecordCount: true,
				serverMode: true,
				canEmitQueries: true,
				hydrate: listFunctions.hydrateTableData
			}
		},
		{},
		{}
	),
	tableTestPaginationAlt: new controlClass.TableListControl(
		{
			rows: [
				{
					Rownum: 0,
					rowKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
					FormMode: '',
					Fields: {
						PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
						Key: 'this',
						Val: 'thing',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 1,
					rowKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
					FormMode: '',
					Fields: {
						PrimaryKey: 'e669f856-2ee3-49ee-bf0f-13eaa21c7b18',
						Key: 'that',
						Val: 'stuff',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 2,
					rowKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
					FormMode: '',
					Fields: {
						PrimaryKey: '54420e72-68b4-41c2-a41e-1d7afbcb6924',
						Key: 'these',
						Val: 'things',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 3,
					rowKey: '47556088-f88e-47fd-b618-323112f96176',
					FormMode: '',
					Fields: {
						PrimaryKey: '47556088-f88e-47fd-b618-323112f96176',
						Key: 'those',
						Val: 'thangs',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 4,
					rowKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
					FormMode: '',
					Fields: {
						PrimaryKey: '97c468d4-8b0f-4d8a-b40b-37841684e234',
						Key: 'wow',
						Val: 'cool',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 5,
					rowKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
					FormMode: '',
					Fields: {
						PrimaryKey: 'c33510bf-85e1-42c0-b5fe-3ab6d0f1adcf',
						Key: 'fgh',
						Val: 'asfd',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 6,
					rowKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
					FormMode: '',
					Fields: {
						PrimaryKey: '295e851b-f97a-45e7-ac22-4fdedd769e6a',
						Key: 'ui',
						Val: 'mgh',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 7,
					rowKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
					FormMode: '',
					Fields: {
						PrimaryKey: 'ee7ecd97-84fd-4ec8-a780-6f46583a3108',
						Key: 'yif',
						Val: 'nm',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 8,
					rowKey: '557e6424-39da-435b-ae56-895ed932a0b7',
					FormMode: '',
					Fields: {
						PrimaryKey: '557e6424-39da-435b-ae56-895ed932a0b7',
						Key: 'sgj',
						Val: 'dyn',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				},
				{
					Rownum: 9,
					rowKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
					FormMode: '',
					Fields: {
						PrimaryKey: '92bb35d5-b86c-4f33-935f-9cbd3f261777',
						Key: 'sefr',
						Val: 'nkef',
						isValid: true
					},
					btnPermission: {
						editBtnDisabled: false,
						viewBtnDisabled: false,
						deleteBtnDisabled: false,
						insertBtnDisabled: false
					}
				}
			],
			totalRows: 10,
			columnsOriginal: [
				{
					label: '',
					name: 'PrimaryKey',
					dataType: 'Text',
					isVisible: false
				},
				{
					label: 'KEY',
					name: 'Key',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					initialSort: true,
					initialSortOrder: 'asc'
				},
				{
					label: 'VALUE',
					name: 'Val',
					dataType: 'Text',
					dataDisplay: listFunctions.textDisplayCell,
					dataSearch: listFunctions.textSearchCell,
					sortable: true,
					distinctValues: []
				}
			],
			config: {
				name: 'DFLDS',
				pkColumn: 'PrimaryKey',
				tableTitle: 'Pagination (alternate)',
				lcid: 'pt-PT',
				serverMode: false,
				numberFormat: {
					decimalSeparator: ',',
					groupSeparator: '.'
				},
				dateFormats: {
					date: 'yyyy/MM/dd',
					dateTime: 'yyyy/MM/dd HH:mm',
					dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
					hours: 'HH:mm',
					use12Hour: false
				},
				globalSearch: {
					visibility: true
				},
				crudActions: [
					{
						id: 'SHOW',
						title: 'CONSULTAR57388',
						icon: {
							icon: 'view'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
					},
					{
						id: 'EDIT',
						title: 'EDITAR11616',
						icon: {
							icon: 'pencil'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
					},
					{
						id: 'DUPLICATE',
						title: 'DUPLICAR09748',
						icon: {
							icon: 'duplicate'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
					},
					{
						id: 'DELETE',
						title: 'ELIMINAR21155',
						icon: {
							icon: 'delete'
						},
						params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
					}
				],
				generalActions: [
					{
						id: 'insert',
						name: 'insert',
						title: 'Insert',
						icon: {
							icon: 'add'
						},
						isInReadOnly: false,
						params: {
							type: 'form',
							formName: 'FORMX',
							mode: 'NEW',
							repeatInsertion: false,
							isControlled: true
						}
					}
				],
				actionsPlacement: 'left',
				rowClickActionInternal: '',
				perPage: 1,
				showAlternatePagination: true
			}
		},
		{},
		{}
	),
	columns01: [
		{
			label: '',
			area: 'DFLDS',
			field: 'PrimaryKey',
			name: 'PrimaryKey',
			dataType: 'Text',
			isVisible: false
		},
		{
			label: 'KEY',
			area: 'DFLDS',
			field: 'KEY',
			name: 'Key',
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataSearch: listFunctions.textSearchCell,
			searchable: true,
			sortable: true,
			initialSortOrder: 'asc',
			params: {
				type: 'form',
				formName: 'FORMX',
				mode: 'SHOW',
				isPopup: false
			},
			cellAction: true
		},
		{
			label: 'VALUE',
			area: 'DFLDS',
			field: 'VAL',
			name: 'Val',
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataSearch: listFunctions.textSearchCell,
			isDefaultSearch: true,
			sortable: true,
			distinctValues: [
				'thing',
				'things',
				'thang',
				'stuff',
				'cool',
				'asfd',
				'nkef',
				'dyn',
				'mgh',
				'nm'
			]
		},
		{
			label: 'Text',
			area: 'DFLDS',
			field: 'TEXT',
			name: 'Text',
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataSearch: listFunctions.textSearchCell,
			sortable: true
		},
		{
			label: 'Numeric',
			area: 'DFLDS',
			field: 'NUMERIC',
			name: 'Numeric',
			dataType: 'Numeric',
			searchFieldType: 'num',
			dataDisplay: listFunctions.numericDisplayCell,
			dataSearch: listFunctions.numericSearchCell,
			decimalPlaces: 3,
			columnClasses: 'c-table__cell-numeric row-numeric',
			columnHeaderClasses: 'c-table__head-numeric',
			sortable: true
		},
		{
			label: 'Date',
			area: 'DFLDS',
			field: 'DATE',
			name: 'Date',
			dataType: 'Date',
			searchFieldType: 'date',
			dataDisplay: listFunctions.dateDisplayCell,
			dataSearch: listFunctions.dateSearchCell,
			dateTimeType: 'dateTimeSeconds',
			sortable: true
		},
		{
			label: 'Boolean',
			area: 'DFLDS',
			field: 'BOOLEAN',
			name: 'Boolean',
			dataType: 'Boolean',
			searchFieldType: 'bool',
			dataDisplay: listFunctions.booleanDisplayCell,
			dataSearch: listFunctions.booleanSearchCell,
			sortable: true,
			supportForm: '',
			component: 'q-render-boolean'
		},
		{
			label: 'Array',
			area: 'DFLDS',
			field: 'ARRAY',
			name: 'Array',
			dataType: 'Array',
			searchFieldType: 'enum',
			dataDisplay: listFunctions.enumerationDisplayCell,
			dataSearch: listFunctions.enumerationSearchCell,
			arrayAsObj: {
				1: 'Low',
				3: 'Medium',
				5: 'High'
			},
			sortable: true
		},
		{
			label: 'Currency',
			area: 'DFLDS',
			field: 'CURRENCY',
			name: 'Currency',
			dataType: 'Currency',
			searchFieldType: 'num',
			dataDisplay: listFunctions.currencyDisplayCell,
			dataSearch: listFunctions.currencySearchCell,
			decimalPlaces: 2,
			currency: 'eur',
			columnClasses: 'c-table__cell-numeric row-numeric',
			columnHeaderClasses: 'c-table__head-numeric',
			sortable: true
		},
		{
			label: 'HyperLink',
			area: 'DFLDS',
			field: 'HYPERLINK',
			name: 'HyperLink',
			dataType: 'HyperLink',
			searchFieldType: 'text',
			dataDisplay: listFunctions.hyperLinkDisplayCell,
			dataSearch: listFunctions.hyperLinkSearchCell,
			component: 'q-render-hyperlink'
		}
	],
	searchableColumns01TableName: 'search_columns_01_table',
	searchableColumns01: [
		{
			label: 'KEY',
			area: 'DFLDS',
			field: 'KEY',
			name: 'Key',
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataSearch: listFunctions.textSearchCell,
			sortable: true,
			initialSortOrder: 'asc',
			params: {
				type: 'form',
				formName: 'FORMX',
				mode: 'SHOW',
				isPopup: false
			},
			cellAction: true
		},
		{
			label: 'VALUE',
			area: 'DFLDS',
			field: 'VAL',
			name: 'Val',
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataSearch: listFunctions.textSearchCell,
			isDefaultSearch: true,
			sortable: true,
			distinctValues: [
				'thing',
				'things',
				'thang',
				'stuff',
				'cool',
				'asfd',
				'nkef',
				'dyn',
				'mgh',
				'nm'
			]
		},
		{
			label: 'Text',
			area: 'DFLDS',
			field: 'TEXT',
			name: 'Text',
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataSearch: listFunctions.textSearchCell,
			sortable: true
		},
		{
			label: 'Numeric',
			area: 'DFLDS',
			field: 'NUMERIC',
			name: 'Numeric',
			dataType: 'Numeric',
			searchFieldType: 'num',
			dataDisplay: listFunctions.numericDisplayCell,
			dataSearch: listFunctions.numericSearchCell,
			decimalPlaces: 3,
			columnClasses: 'c-table__cell-numeric row-numeric',
			columnHeaderClasses: 'c-table__head-numeric',
			sortable: true
		},
		{
			label: 'Date',
			area: 'DFLDS',
			field: 'DATE',
			name: 'Date',
			dataType: 'Date',
			searchFieldType: 'date',
			dataDisplay: listFunctions.dateDisplayCell,
			dataSearch: listFunctions.dateSearchCell,
			dateTimeType: 'dateTimeSeconds',
			sortable: true
		},
		{
			label: 'Boolean',
			area: 'DFLDS',
			field: 'BOOLEAN',
			name: 'Boolean',
			dataType: 'Boolean',
			searchFieldType: 'bool',
			dataDisplay: listFunctions.booleanDisplayCell,
			dataSearch: listFunctions.booleanSearchCell,
			sortable: true,
			supportForm: '',
			component: 'q-render-boolean'
		},
		{
			label: 'Array',
			area: 'DFLDS',
			field: 'ARRAY',
			name: 'Array',
			dataType: 'Array',
			searchFieldType: 'enum',
			dataDisplay: listFunctions.enumerationDisplayCell,
			dataSearch: listFunctions.enumerationSearchCell,
			arrayAsObj: {
				1: 'Low',
				3: 'Medium',
				5: 'High'
			},
			sortable: true
		},
		{
			label: 'Currency',
			area: 'DFLDS',
			field: 'CURRENCY',
			name: 'Currency',
			dataType: 'Currency',
			searchFieldType: 'num',
			dataDisplay: listFunctions.currencyDisplayCell,
			dataSearch: listFunctions.currencySearchCell,
			decimalPlaces: 2,
			currency: 'eur',
			columnClasses: 'c-table__cell-numeric row-numeric',
			columnHeaderClasses: 'c-table__head-numeric',
			sortable: true
		},
		{
			label: 'HyperLink',
			area: 'DFLDS',
			field: 'HYPERLINK',
			name: 'HyperLink',
			dataType: 'HyperLink',
			searchFieldType: 'text',
			dataDisplay: listFunctions.hyperLinkDisplayCell,
			dataSearch: listFunctions.hyperLinkSearchCell,
			component: 'q-render-hyperlink'
		}
	],
	columns02: [
		{
			label: '',
			area: 'DFLDS',
			field: 'PrimaryKey',
			name: 'PrimaryKey',
			dataType: 'Text',
			isVisible: false
		},
		{
			label: 'KEY',
			area: 'DFLDS',
			field: 'KEY',
			name: 'Key',
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataSearch: listFunctions.textSearchCell,
			sortable: true,
			initialSortOrder: 'asc',
			params: {
				type: 'form',
				formName: 'FORMX',
				mode: 'SHOW',
				isPopup: false
			},
			cellAction: true
		},
		{
			label: 'VALUE',
			area: 'DFLDS',
			field: 'VAL',
			name: 'Val',
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataSearch: listFunctions.textSearchCell,
			isDefaultSearch: true,
			sortable: true,
			distinctValues: [
				'thing',
				'things',
				'thang',
				'stuff',
				'cool',
				'asfd',
				'nkef',
				'dyn',
				'mgh',
				'nm'
			]
		},
		{
			label: 'Text',
			area: 'DFLDS',
			field: 'TEXT',
			name: 'Text',
			dataType: 'Text',
			searchFieldType: 'text',
			dataDisplay: listFunctions.textDisplayCell,
			dataSearch: listFunctions.textSearchCell,
			sortable: true
		},
		{
			label: 'Date',
			area: 'DFLDS',
			field: 'DATE',
			name: 'Date',
			dataType: 'Date',
			searchFieldType: 'date',
			dataDisplay: listFunctions.dateDisplayCell,
			dataSearch: listFunctions.dateSearchCell,
			dateTimeType: 'dateTimeSeconds',
			sortable: true
		},
		{
			label: 'Array',
			area: 'DFLDS',
			field: 'ARRAY',
			name: 'Array',
			dataType: 'Array',
			searchFieldType: 'enum',
			dataDisplay: listFunctions.enumerationDisplayCell,
			dataSearch: listFunctions.enumerationSearchCell,
			arrayAsObj: {
				1: 'Low',
				3: 'Medium',
				5: 'High'
			},
			sortable: true
		},
		{
			label: 'HyperLink',
			area: 'DFLDS',
			field: 'HYPERLINK',
			name: 'HyperLink',
			dataType: 'HyperLink',
			searchFieldType: 'text',
			dataDisplay: listFunctions.hyperLinkDisplayCell,
			dataSearch: listFunctions.hyperLinkSearchCell,
			component: 'q-render-hyperlink'
		}
	],
	rowsInvalid: [
		{
			Rownum: 0,
			FormMode: '',
			Fields: {
				PrimaryKey: '81cc095a-03f7-43a6-a820-087c8d41a83d',
				Key: 'this',
				Val: 'thing',
				Text: 'Lorem ipsum dolor',
				Numeric: 45,
				Date: '2021-02-16 23:24:12',
				Boolean: 1,
				Array: '1',
				Currency: 27.18,
				HyperLink: 'http://www.google.com',
				Image: '',
				Document: '',
				Action: '',
				Geographic: '',
				Unknown: '',
				isValid: false
			},
			btnPermission: {
				editBtnDisabled: false,
				viewBtnDisabled: false,
				deleteBtnDisabled: false,
				insertBtnDisabled: false
			}
		}
	],
	actionsMenu0: {
		crudActions: [],
		customActions: [],
		readonly: false
	},
	actionsMenu1: {
		crudActions: [
			{
				id: 'SHOW',
				title: 'CONSULTAR57388',
				icon: {
					icon: 'view'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
			}
		],
		customActions: [],
		readonly: false
	},
	actionsMenuN: {
		crudActions: [
			{
				id: 'SHOW',
				title: 'CONSULTAR57388',
				icon: {
					icon: 'view'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
			},
			{
				id: 'EDIT',
				title: 'EDITAR11616',
				icon: {
					icon: 'pencil'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
			},
			{
				id: 'DUPLICATE',
				title: 'DUPLICAR09748',
				icon: {
					icon: 'duplicate'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
			},
			{
				id: 'DELETE',
				title: 'ELIMINAR21155',
				icon: {
					icon: 'delete'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
			}
		],
		customActions: [
			{
				id: 'show_table',
				title: 'custom',
				icon: {
					icon: 'view'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMY', mode: 'SHOW' }
			}
		],
		readonly: false
	},
	actionsMenu1ReadOnly0: {
		crudActions: [
			{
				id: 'SHOW',
				title: 'CONSULTAR57388',
				icon: {
					icon: 'view'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
			}
		],
		customActions: [],
		readonly: true
	},
	actionsMenu1ReadOnly1: {
		crudActions: [
			{
				id: 'SHOW',
				title: 'CONSULTAR57388',
				icon: {
					icon: 'view'
				},
				isInReadOnly: true,
				params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
			}
		],
		customActions: [],
		readonly: true
	},
	actionsMenuNReadOnly0: {
		crudActions: [
			{
				id: 'SHOW',
				title: 'CONSULTAR57388',
				icon: {
					icon: 'view'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
			},
			{
				id: 'EDIT',
				title: 'EDITAR11616',
				icon: {
					icon: 'pencil'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
			},
			{
				id: 'DUPLICATE',
				title: 'DUPLICAR09748',
				icon: {
					icon: 'duplicate'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
			},
			{
				id: 'DELETE',
				title: 'ELIMINAR21155',
				icon: {
					icon: 'delete'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
			}
		],
		customActions: [
			{
				id: 'show_table',
				title: 'custom',
				icon: {
					icon: 'view'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMY', mode: 'SHOW' }
			}
		],
		readonly: true
	},
	actionsMenuNReadOnly1: {
		crudActions: [
			{
				id: 'SHOW',
				title: 'CONSULTAR57388',
				icon: {
					icon: 'view'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
			},
			{
				id: 'EDIT',
				title: 'EDITAR11616',
				icon: {
					icon: 'pencil'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
			},
			{
				id: 'DUPLICATE',
				title: 'DUPLICAR09748',
				icon: {
					icon: 'duplicate'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
			},
			{
				id: 'DELETE',
				title: 'ELIMINAR21155',
				icon: {
					icon: 'delete'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
			}
		],
		customActions: [
			{
				id: 'show_table',
				title: 'custom',
				icon: {
					icon: 'view'
				},
				isInReadOnly: true,
				params: { type: 'form', formName: 'FORMY', mode: 'SHOW' }
			}
		],
		readonly: true
	},
	actionsMenuNReadOnlyN: {
		crudActions: [
			{
				id: 'SHOW',
				title: 'CONSULTAR57388',
				icon: {
					icon: 'view'
				},
				isInReadOnly: true,
				params: { type: 'form', formName: 'FORMX', mode: 'SHOW' }
			},
			{
				id: 'EDIT',
				title: 'EDITAR11616',
				icon: {
					icon: 'pencil'
				},
				isInReadOnly: true,
				params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
			},
			{
				id: 'DUPLICATE',
				title: 'DUPLICAR09748',
				icon: {
					icon: 'duplicate'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'DUPLICATE' }
			},
			{
				id: 'DELETE',
				title: 'ELIMINAR21155',
				icon: {
					icon: 'delete'
				},
				isInReadOnly: false,
				params: { type: 'form', formName: 'FORMX', mode: 'DELETE' }
			}
		],
		customActions: [
			{
				id: 'show_table',
				title: 'custom',
				icon: {
					icon: 'view'
				},
				isInReadOnly: true,
				params: { type: 'form', formName: 'FORMY', mode: 'SHOW' }
			}
		],
		readonly: true
	},
	searchbar01: {
		globalSearch: {
			placeholder: 'PESQUISAR34506',
			visibility: true
		},
		tableTitle: 'Basic Types'
	},
	exportOptions01: [
		{ id: 'pdf', text: 'FORMATO_DE_DOCUMENTO48724' },
		{ id: 'ods', text: 'FOLHA_DE_CALCULO__OD46941' },
		{ id: 'xlsx', text: 'FOLHA_DE_CALCULO_EXC59518' },
		{ id: 'csv', text: 'VALORES_SEPARADOS_PO10397' },
		{ id: 'xml', text: 'FORMATO_XML__XML_44251' }
	],
	importOptions01: [{ key: 'xlsx', value: 'FOLHA_DE_CALCULO_EXC59518' }],
	importTemplateOptions01: [{ key: 'xlsx', value: 'DOWNLOAD_DE_TEMPLATE48385' }],
	groupFiltersSingle01: [
		{
			id: 'filter_thing',
			isMultiple: false,
			value: '2',
			filters: [
				{
					key: '0',
					value: 'VALUE_0',
					selected: false,
					id: 'filter_thing_0'
				},
				{
					key: '1',
					value: 'VALUE_1',
					selected: false,
					id: 'filter_thing_1'
				},
				{
					key: '2',
					value: 'VALUE_2',
					selected: true,
					id: 'filter_thing_2'
				}
			]
		}
	],
	groupFiltersMultiple01: [
		{
			id: 'filter_stuff',
			isMultiple: true,
			value: '2',
			filters: [
				{
					key: '0',
					value: 'VALUE_0',
					selected: false,
					id: 'filter_stuff_0'
				},
				{
					key: '1',
					value: 'VALUE_1',
					selected: false,
					id: 'filter_stuff_1'
				},
				{
					key: '2',
					value: 'VALUE_2',
					selected: true,
					id: 'filter_stuff_2'
				}
			]
		}
	],
	activeFilters01: {
		options: [
			{
				key: '0',
				value: 'ACTIVE',
				selected: false,
				id: 'active_filter_ActiveFilter_A'
			},
			{
				key: '1',
				value: 'INACTIVE',
				selected: false,
				id: 'active_filter_ActiveFilter_I'
			},
			{
				key: '2',
				value: 'FUTURE',
				selected: true,
				id: 'active_filter_ActiveFilter_F'
			}
		],
		dateValue: {
			type: 'date',
			title: 'Date',
			id: 'active_filter_dataRef',
			value: ''
		}
	},
	paginationNormal01: {
		page: 5,
		perPage: 10,
		rowCount: 100,
		numVisibilePaginationButtons: 5
	},
	paginationAlt01: {
		page: 5,
		perPage: 10,
		rowCount: 100,
		hasMore: true
	},
	tableLimits01: [
		{
			Order: 0,
			Type: 'DB',
			Area: '',
			AreaPlural: '',
			Field: 'FLD',
			Value: '0',
			ValueMin: '',
			ValueMax: '',
			AreaN: '',
			AreaNPlural: '',
			FieldN: '',
			ValueN: '0',
			AreaToCompare: '',
			FieldToCompare: '',
			Value_compare: '',
			OperatorType: '=',
			OperatorThreshold: '',
			ManualHTMLText: '',
			ApplyOnlyIfExists: true
		},
		{
			Order: 1,
			Type: 'F',
			Area: 'TBL',
			AreaPlural: '',
			Field: 'FLD',
			Value: '0',
			ValueMin: '',
			ValueMax: '',
			AreaN: '',
			AreaNPlural: '',
			FieldN: '',
			ValueN: '0',
			AreaToCompare: '',
			FieldToCompare: '',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '',
			ManualHTMLText: '',
			ApplyOnlyIfExists: false
		},
		{
			Order: 2,
			Type: 'V',
			Area: 'TBL',
			AreaPlural: '',
			Field: 'FLD',
			Value: '0',
			ValueMin: '',
			ValueMax: '',
			AreaN: 'TBL_N',
			AreaNPlural: '',
			FieldN: 'FLD_N',
			ValueN: '0',
			AreaToCompare: '',
			FieldToCompare: '',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '',
			ManualHTMLText: '',
			ApplyOnlyIfExists: false
		},
		{
			Order: 3,
			Type: 'E',
			Area: 'TBL',
			AreaPlural: '',
			Field: 'FLD',
			Value: '0',
			ValueMin: '',
			ValueMax: '',
			AreaN: 'TBL_N',
			AreaNPlural: '',
			FieldN: 'FLD_N',
			ValueN: '0',
			AreaToCompare: '',
			FieldToCompare: '',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '',
			ManualHTMLText: '',
			ApplyOnlyIfExists: false
		},
		{
			Order: 4,
			Type: 'E',
			Area: 'TBL',
			AreaPlural: '',
			Field: 'FLD',
			Value: '0',
			ValueMin: '',
			ValueMax: '',
			AreaN: 'TBL_N',
			AreaNPlural: '',
			FieldN: 'FLD_N',
			ValueN: '0',
			AreaToCompare: 'TBL_C',
			FieldToCompare: 'FLD_C',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '',
			ManualHTMLText: '',
			ApplyOnlyIfExists: false
		},
		{
			Order: 5,
			Type: 'C',
			Area: 'TBL',
			AreaPlural: '',
			Field: 'FLD',
			Value: '0',
			ValueMin: '',
			ValueMax: '',
			AreaN: 'TBL_N',
			AreaNPlural: '',
			FieldN: 'FLD_N',
			ValueN: '0',
			AreaToCompare: 'TBL_C',
			FieldToCompare: 'FLD_C',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '',
			ManualHTMLText: '',
			ApplyOnlyIfExists: false
		},
		{
			Order: 6,
			Type: 'SE',
			Area: 'TBL',
			AreaPlural: '',
			Field: 'FLD',
			Value: '0',
			ValueMin: 'MIN',
			ValueMax: 'MAX',
			AreaN: 'TBL_N',
			AreaNPlural: '',
			FieldN: 'FLD_N',
			ValueN: '0',
			AreaToCompare: 'TBL_C',
			FieldToCompare: 'FLD_C',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '',
			ManualHTMLText: '',
			ApplyOnlyIfExists: false
		},
		{
			Order: 7,
			Type: 'SU',
			Area: 'TBL',
			AreaPlural: '',
			Field: 'FLD',
			Value: '0',
			ValueMin: 'MIN',
			ValueMax: 'MAX',
			AreaN: 'TBL_N',
			AreaNPlural: '',
			FieldN: 'FLD_N',
			ValueN: '0',
			AreaToCompare: 'TBL_C',
			FieldToCompare: 'FLD_C',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '=',
			ManualHTMLText: '',
			ApplyOnlyIfExists: false
		},
		{
			Order: 8,
			Type: 'DM',
			Area: 'TBL',
			AreaPlural: 'TBLPlural',
			Field: 'FLD',
			Value: '0',
			ValueMin: 'MIN',
			ValueMax: 'MAX',
			AreaN: 'TBL_N',
			AreaNPlural: '',
			FieldN: 'FLD_N',
			ValueN: '0',
			AreaToCompare: 'TBL_C',
			FieldToCompare: 'FLD_C',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '=',
			ManualHTMLText: '',
			ApplyOnlyIfExists: false
		},
		{
			Order: 9,
			Type: 'AFILTER',
			Area: 'TBL',
			AreaPlural: 'TBLPlural',
			Field: 'FLD',
			Value: '0',
			ValueMin: 'MIN',
			ValueMax: 'MAX',
			AreaN: 'TBL_N',
			AreaNPlural: '',
			FieldN: 'FLD_N',
			ValueN: '0',
			AreaToCompare: 'TBL_C',
			FieldToCompare: 'FLD_C',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '=',
			ManualHTMLText: '',
			ApplyOnlyIfExists: false
		},
		{
			Order: 10,
			Type: 'OVERRQ',
			Area: 'TBL',
			AreaPlural: 'TBLPlural',
			Field: 'FLD',
			Value: '0',
			ValueMin: 'MIN',
			ValueMax: 'MAX',
			AreaN: 'TBL_N',
			AreaNPlural: '',
			FieldN: 'FLD_N',
			ValueN: '0',
			AreaToCompare: 'TBL_C',
			FieldToCompare: 'FLD_C',
			Value_compare: '',
			OperatorType: '',
			OperatorThreshold: '=',
			ManualHTMLText: 'Manual HTML',
			ApplyOnlyIfExists: false
		}
	],
	tableLimitsText01: {
		tableNamePlural: 'TABLE X'
	},
	checklistCheckboxRow01: {
		value: false,
		tableName: 'TABLE X',
		readonly: false,
		rowKey: 'F8C4'
	},
	columnFilter01: {
		name: '',
		active: true,
		conditions: [
			{
				name: '',
				active: true,
				field: 'DFLDS.BOOLEAN',
				operator: '',
				values: []
			}
		]
	},
	filterArray01: [
		{
			name: '',
			active: true,
			conditions: [
				{
					name: 'filter 1',
					active: true,
					field: 'DFLDS.KEY',
					operator: '',
					values: []
				}
			]
		},
		{
			name: '',
			active: true,
			conditions: [
				{
					name: 'filter 2',
					active: true,
					field: 'DFLDS.VAL',
					operator: '',
					values: []
				}
			]
		}
	],
	filterHash01: {
		column01: {
			name: '',
			active: true,
			conditions: [
				{
					name: 'filter a',
					active: true,
					field: 'DFLDS.TEXT',
					operator: '',
					values: []
				}
			]
		},
		column02: {
			name: '',
			active: true,
			conditions: [
				{
					name: 'filter b',
					active: true,
					field: 'DFLDS.NUMERIC',
					operator: '',
					values: []
				}
			]
		}
	},
	filterHash02: {
		columnA: {
			name: '',
			active: true,
			conditions: [
				{
					name: 'filter a',
					active: true,
					field: 'DFLDS.DATE',
					operator: '',
					values: []
				}
			]
		}
	},
	cssClasses: {
		invalidRow: 'c-table__row--pending'
	},
	config01: {
		name: 'DFLDS',
		pkColumn: 'PrimaryKey',
		tableTitle: 'Rows with empty field values',
		lcid: 'pt-PT',
		serverMode: false,
		dateFormats: {
			date: 'yyyy/MM/dd',
			dateTime: 'yyyy/MM/dd HH:mm',
			dateTimeSeconds: 'yyyy/MM/dd HH:mm:ss',
			hours: 'HH:mm',
			use12Hour: false
		},
		globalSearch: {
			placeholder: 'PESQUISAR34506',
			visibility: true
		},
		signalOpenAdvancedFilters: null,
		allowColumnFilters: true,
		rowClickAction: {
			id: 'EDIT',
			title: 'EDITAR11616',
			icon: {
				icon: 'pencil'
			},
			params: { type: 'form', formName: 'FORMX', mode: 'EDIT' }
		},
		actionsPlacement: 'left',
		rowValidation: {
			fnValidate: (row) => row.Fields.isValid,
			message: 'ATENCAO__ESTA_FICHA_24725'
		},
		columnConfigIsVisible: false,
		hasTextWrap: false,
		defaultSearchColumnName: 'Key',
		resourcesPath: 'dist/Content/img/'
	},
	simpleUsageMethods: {
		runAction(eventName, emittedAction)
		{
			var str = eventName + ':\n' + JSON.stringify(emittedAction)
			alert(str)
		},
		displayEmit(emittedAction)
		{
			var str = JSON.stringify(emittedAction)
			alert(str)
		},
		displayAction(eventName, emittedAction)
		{
			var str = eventName + ':\n' + JSON.stringify(emittedAction)
			alert(str)
		},
		executeAction(emittedAction)
		{
			this.runAction('execute-action', emittedAction)
		},
		rowAction(emittedAction)
		{
			this.runAction('row-action', emittedAction)
		},
		cellAction(emittedAction)
		{
			this.runAction('cell-action', emittedAction)
		},
		exportDataAction(emittedAction)
		{
			this.displayAction('export-data-action', emittedAction)
		},
		importDataAction(emittedAction)
		{
			this.displayAction('import-data-action', emittedAction)
		},
		exportTemplateAction(emittedAction)
		{
			this.displayAction('export-template-action', emittedAction)
		},
		showPopupAction(emittedAction, popupName)
		{
			this.$emit('show-popup', emittedAction)

			if (popupName === 'column-config')
				emittedAction.config.columnConfigIsVisible = true;
			else if (popupName === 'advanced-filters')
				emittedAction.config.advancedFiltersIsVisible = true;
		},
		hidePopupAction(emittedAction, popupName)
		{
			this.$emit('hide-popup', emittedAction)

			if (popupName === 'column-config') emittedAction.config.columnConfigIsVisible = false
			else if (popupName === 'advanced-filters')
				emittedAction.config.advancedFiltersIsVisible = false
		},
		saveColumnConfig(emittedAction)
		{
			this.displayAction('save-column-config', emittedAction)
		},
		resetColumnConfig(emittedAction)
		{
			this.displayAction('reset-column-config', emittedAction)
		},
		//FOR: EXTENDED ROW ACTIONS - REMOVE
		removeRow(rows, rowKey)
		{
			var rowIdx = rows.findIndex((elem) => elem.rowKey === rowKey);
			rows.splice(rowIdx, 1);
		},
		/**
		 * Add row to array of selected rows
		 * @param rowArray {Object}
		 * @param rowKey {Object}
		 * @returns Boolean
		 */
		selectRow(rowArray, rowKey)
		{
			rowArray[rowKey] = true
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Remove row from array of selected rows
		 * @param rowArray {Object}
		 * @param rowKey {Object}
		 * @returns Boolean
		 */
		unselectRow(rowArray, rowKey)
		{
			delete rowArray[rowKey]
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Add row to array of selected rows
		 * @param rowArray {Object}
		 * @param rowKey {Object}
		 * @returns Boolean
		 */
		selectRows(rowArray, rowKeys)
		{
			for (let rowKey in rowKeys) rowArray[rowKey] = true
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Remove rows from array of selected rows
		 * @param rowArray {Object}
		 * @param rowKey {Object}
		 * @returns Boolean
		 */
		unselectRows(rowArray, rowKeys)
		{
			for (let rowKey in rowKeys) delete rowArray[rowKey]
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Remove all rows from array of selected rows
		 * @param rowArray {Object}
		 * @returns Boolean
		 */
		unselectAllRows(rowArray)
		{
			for (let rowKey in rowArray) delete rowArray[rowKey]
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Add row to array of rows checked in checklist column
		 * @param rowArray {Object}
		 * @param rowKey {Object}
		 * @returns Boolean
		 */
		checkRow(rowArray, rowKey)
		{
			rowArray[rowKey] = true
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Remove row from array of rows checked in checklist column
		 * @param rowArray {Object}
		 * @param rowKey {Object}
		 * @returns Boolean
		 */
		uncheckRow(rowArray, rowKey)
		{
			delete rowArray[rowKey]
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Add row to array of rows checked in checklist column
		 * @param rowArray {Object}
		 * @param rowKey {Object}
		 * @returns Boolean
		 */
		checkRows(rowArray, rowKeys)
		{
			for (let rowKey in rowKeys) rowArray[rowKey] = true
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Remove rows from array of rows checked in checklist column
		 * @param rowArray {Object}
		 * @param rowKey {Object}
		 * @returns Boolean
		 */
		uncheckRows(rowArray, rowKeys)
		{
			for (let rowKey in rowKeys) delete rowArray[rowKey]
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Remove all rows from array of rows checked in checklist column
		 * @param rowArray {Object}
		 * @returns Boolean
		 */
		uncheckAllRows(rowArray)
		{
			for (let rowKey in rowArray) delete rowArray[rowKey]
			alert(JSON.stringify(rowArray))
		},
		/**
		 * Copy checked rows to selected rows
		 * @param table {Object}
		 * @returns Boolean
		 */
		selectCheckedRows(table)
		{
			table.rowsSelected = cloneDeep(table.rowsChecked) //alert(JSON.stringify(table.rowsSelected));
		},
		/**
		 * Copy selected rows to checked rows
		 * @param table {Object}
		 * @returns Boolean
		 */
		checkSelectedRows(table)
		{
			table.rowsChecked = cloneDeep(table.rowsSelected) //alert(JSON.stringify(table.rowsChecked));
		},
		rowGroupAction(emittedAction)
		{
			this.runAction('row-group-action', emittedAction)
		},
		/**
		 * Add advanced filter
		 * @param {object} listConf The list configuration
		 * @param filter {Object}
		 */
		addAdvancedFilter(listConf, filter)
		{
			listConf.advancedFilters.push(filter)
		},

		/**
		 * Edit advanced filter
		 * @param {object} listConf The list configuration
		 * @param filter {Object}
		 * @param index {number}
		 */
		editAdvancedFilters(listConf, filters)
		{
			listConf.advancedFilters = filters
		},

		/**
		 * Set advanced filter state
		 * @param {object} listConf The list configuration
		 * @param {number} index : index
		 * @param {boolean} active : active state
		 */
		setAdvancedFilterState(listConf, index, active)
		{
			listConf.advancedFilters[index].active = active
		},

		/**
		 * Set multiple advanced filter states
		 * @param {object} listConf The list configuration
		 * @param {Array} selectedFilterIdxs : index
		 * @param {boolean} active : active state
		 */
		setAdvancedFilterStates(listConf, selectedFilterIdxs, active)
		{
			var selectedFilterIdx = -1
			for (let idx in selectedFilterIdxs)
			{
				selectedFilterIdx = selectedFilterIdxs[idx]
				listConf.advancedFilters[selectedFilterIdx].active = active
			}
		},

		/**
		 * Set advanced filter state
		 * @param {object} listConf The list configuration
		 * @param {number} index : index
		 */
		removeAdvancedFilter(listConf, index)
		{
			listConf.advancedFilters.splice(index, 1)
		},
		/**
		 * Clear all advanced filters
		 * @param {object} listConf The list configuration
		 */
		clearAdvancedFilters(listConf)
		{
			listConf.advancedFilters = []
		},

		/**
		 * Open advanced filters
		 * @param {object} listConf The list configuration
		 * @param {boolean} visible
		 * @param {number} selectedFilterIdx
		 */
		setAdvancedFiltersPopup(listConf, visible, selectedFilterIdx)
		{
			var useVisible = false
			if (visible !== undefined)
			{
				useVisible = !!visible
			}

			var useSelectedFilterIdx = null
			if (selectedFilterIdx !== undefined)
			{
				useSelectedFilterIdx = selectedFilterIdx
			}

			//Set advanced filters open config to show and select corresponding filter by index
			listConf.config.signalOpenAdvancedFilters = {
				show: useVisible,
				selectedFilterIdx: useSelectedFilterIdx
			}
		}
	}
}
