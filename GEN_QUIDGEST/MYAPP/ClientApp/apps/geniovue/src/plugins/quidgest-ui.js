import { createFramework } from '@quidgest/ui/framework'

const framework = createFramework({
	themes: {
		defaultTheme: 'Light',
		themes: [
			{
				name: 'Light',
				mode: 'light',
				colors: {
					primaryDark: '#1e2436',
					secondary: '#1e2436',
					primaryLight: '#fff',
					primary: '#1e2436',
					highlight: '#17a2b8',
				}
			}
		]
	},
	defaults: {
		QIconSvg: {
			bundle: 'Content/svgbundle.svg?v=18'
		},
		QCollapsible: {
			icons: {
				chevron: {
					icon: 'expand'
				}
			}
		},
		QListItem: {
			icons: {
				check: {
					icon: 'ok'
				},
				description: {
					icon: 'help'
				}
			}
		},
		QSelect: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		},
		QCombobox: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		},
		QPropertyList: {
			icons: {
				open: {
					icon: 'square-minus',
				},
				close: {
					icon: 'square-plus',
				}
			}
		}
	}
})

export default framework
