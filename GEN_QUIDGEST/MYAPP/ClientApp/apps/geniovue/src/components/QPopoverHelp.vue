<template>
	<q-button
		:id="popoverId"
		:title="texts?.showHelp"
		class="btn-popover"
		variant="ghost"
		color="neutral">
		<q-icon :icon="icon" />
	</q-button>

	<q-popover
		:anchor="anchorPopoverId"
		:title="label"
		:text="popoverText" />
</template>


<script>
	import HelpControl from '@/mixins/helpControls.js'

	export default {
		name: 'PopoverHelp',

		mixins: [HelpControl],

		expose: [],

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * The label text for the input field.
			 */
			label: String,

			/**
			 * Icon for the button
			 */
			icon: {
				type: String,
				default: 'help'
			},

			/**
			 * Text strings which might be used to override default texts within the component.
			 */
			texts: Object
		},

		computed: {
			popoverId() {
				return `popover_${this.id}`
			},

			anchorPopoverId() {
				return `#popover_${this.id}`
			}
		}
	}
</script>
