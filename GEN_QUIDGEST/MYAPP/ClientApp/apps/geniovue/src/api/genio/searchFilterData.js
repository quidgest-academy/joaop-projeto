import { computed, isRef } from 'vue'

import hardcodedTexts from '@/hardcodedTexts.js'

// Search filter condition operators
export const operators = {
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		const vm = this
		return {
			'text': {
				'EQ': {
					key: 'EQ',
					resourceId: hardcodedTexts.isEqualTo,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-equal',
						type: 'svg'
					}
				},
				'NOTEQ': {
					key: 'NOTEQ',
					resourceId: hardcodedTexts.notEqual,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-different',
						type: 'svg'
					}
				},
				'CON': {
					key: 'CON',
					resourceId: hardcodedTexts.contains,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-contains',
						type: 'svg'
					}
				},
				'NOTCON': {
					key: 'NOTCON',
					resourceId: hardcodedTexts.notContains,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-no-contains',
						type: 'svg'
					}
				},
				'STRTWTH': {
					key: 'STRTWTH',
					resourceId: hardcodedTexts.startsWith,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-starts-with',
						type: 'svg'
					}
				},
				'LIKE': {
					key: 'LIKE',
					resourceId: hardcodedTexts.isLike,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					placeholderResourceId: hardcodedTexts.keyword,
					get Placeholder() { return '%' + (vm.fnResources ? vm.fnResources(this.placeholderResourceId) : this.placeholderResourceId) + '%' },
					icon: {
						icon: 'filter-is-like',
						type: 'svg'
					}
				},
				'SET': {
					key: 'SET',
					resourceId: hardcodedTexts.hasValue,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'filter-has-value-text',
						type: 'svg'
					}
				},
				'NOTSET': {
					key: 'NOTSET',
					resourceId: hardcodedTexts.noValue,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'filter-no-value',
						type: 'svg'
					}
				}
			},
			'num': {
				'EQ': {
					key: 'EQ',
					resourceId: hardcodedTexts.isEqualTo,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-equal',
						type: 'svg'
					}
				},
				'NOTEQ': {
					key: 'NOTEQ',
					resourceId: hardcodedTexts.notEqual,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-different',
						type: 'svg'
					}
				},
				'GREAT': {
					key: 'GREAT',
					resourceId: hardcodedTexts.greaterThan,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-greater',
						type: 'svg'
					}
				},
				'LESS': {
					key: 'LESS',
					resourceId: hardcodedTexts.lessThan,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-less',
						type: 'svg'
					}
				},
				'GREATEQ': {
					key: 'GREATEQ',
					resourceId: hardcodedTexts.greaterOrEqual,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-greater-or-equal',
						type: 'svg'
					}
				},
				'LESSEQ': {
					key: 'LESSEQ',
					resourceId: hardcodedTexts.lessOrEqual,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-less-or-equal',
						type: 'svg'
					}
				},
				'BETW': {
					key: 'BETW',
					resourceId: hardcodedTexts.isBetween,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 2,
					icon: {
						icon: 'filter-between',
						type: 'svg'
					}
				},
				'SET': {
					key: 'SET',
					resourceId: hardcodedTexts.hasValue,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'filter-has-value-number',
						type: 'svg'
					}
				},
				'NOTSET': {
					key: 'NOTSET',
					resourceId: hardcodedTexts.noValue,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'filter-no-value',
						type: 'svg'
					}
				}
			},
			'bool': {
				'TRUE': {
					key: 'TRUE',
					resourceId: hardcodedTexts.isTrue,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'ok',
						type: 'svg'
					}
				},
				'FALSE': {
					key: 'FALSE',
					resourceId: hardcodedTexts.isFalse,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'close',
						type: 'svg'
					}
				}
			},
			'date': {
				'EQ': {
					key: 'EQ',
					resourceId: hardcodedTexts.isEqualTo,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-equal',
						type: 'svg'
					}
				},
				'NOTEQ': {
					key: 'NOTEQ',
					resourceId: hardcodedTexts.notEqual,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-different',
						type: 'svg',
					}
				},
				'AFTEQ': {
					key: 'AFTEQ',
					resourceId: hardcodedTexts.afterOrEqual,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-greater-or-equal',
						type: 'svg'
					}
				},
				'BEFEQ': {
					key: 'BEFEQ',
					resourceId: hardcodedTexts.beforeOrEqual,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-less-or-equal',
						type: 'svg'
					}
				},
				'BETW': {
					key: 'BETW',
					resourceId: hardcodedTexts.isBetween,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 2,
					icon: {
						icon: 'filter-between',
						type: 'svg'
					}
				},
				'SET': {
					key: 'SET',
					resourceId: hardcodedTexts.hasValue,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'filter-has-value-number',
						type: 'svg'
					}
				},
				'NOTSET': {
					key: 'NOTSET',
					resourceId: hardcodedTexts.noValue,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'filter-no-value',
						type: 'svg'
					}
				}
			},
			'enum': {
				'IS': {
					key: 'IS',
					resourceId: hardcodedTexts.is,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-equal',
						type: 'svg'
					}
				},
				'ISNOT': {
					key: 'ISNOT',
					resourceId: hardcodedTexts.isNot,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					icon: {
						icon: 'filter-different',
						type: 'svg'
					}
				},
				'IN': {
					key: 'IN',
					resourceId: hardcodedTexts.oneOf,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 1,
					inputComponent: 'q-edit-check-list',
					defaultValue: [],
					icon: {
						icon: 'filter-between',
						type: 'svg'
					}
				},
				'SET': {
					key: 'SET',
					resourceId: hardcodedTexts.hasValue,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'filter-has-value-text',
						type: 'svg'
					}
				},
				'NOTSET': {
					key: 'NOTSET',
					resourceId: hardcodedTexts.noValue,
					get Title() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
					ValueCount: 0,
					icon: {
						icon: 'filter-no-value',
						type: 'svg'
					}
				}
			}
		}
	}
}

export const searchBarOperator = function (dataType, searchValue)
{
	var condOperator = ''
	switch (dataType)
	{
		case 'text':
			condOperator = 'CON'
			break
		case 'num':
			condOperator = 'EQ'
			break
		case 'bool':
			if (searchValue.toUpperCase() === 'TRUE')
				condOperator = 'TRUE'
			else if (searchValue.toUpperCase() === 'FALSE')
				condOperator = 'FALSE'
			else
				condOperator = 'TRUE'
			break
		case 'date':
			condOperator = 'EQ'
			break
		case 'enum':
			condOperator = 'IS'
			break
	}
	return condOperator
}

export const defaultValue = function (column)
{
	var value = ''
	switch (column.searchFieldType)
	{
		case 'text':
			value = ''
			break
		case 'num':
			value = 0
			break
		case 'bool':
			value = false
			break
		case 'date':
			value = ''
			break
		case 'enum':
			for (let key in column.array)
			{
				value = column.array[key]
				if (isRef(value))
					value = value.value
				break
			}
			break
	}
	return value
}

// Components used by advanced filters, column filters and editable fields in normal tables
// (different than the ones in the editable table lists)
export const inputComponents = {
	text: 'q-edit-text',
	num: 'q-edit-numeric',
	bool: 'q-edit-boolean',
	date: 'q-edit-datetime',
	enum: 'q-edit-enumeration'
}

export default {
	operators,
	searchBarOperator,
	defaultValue,
	inputComponents,
	getWithTranslation(fnResources)
	{
		return {
			operators: operators.setResources(fnResources),
			searchBarOperator,
			defaultValue,
			inputComponents
		}
	}
}
