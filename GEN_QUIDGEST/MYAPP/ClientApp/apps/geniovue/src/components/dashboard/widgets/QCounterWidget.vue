﻿<template>
	<div class="q-counter-widget">
		<h5 class="q-counter-widget__title">{{ $props.title }}</h5>

		<div class="q-counter-widget__info">
			<span class="q-counter-widget__value">
				{{ count }}
			</span>

			<q-icon :icon="$props.icon" />
		</div>
	</div>
</template>

<script>
	export default {
		name: 'QCounterWidget',

		inheritAttrs: false,

		props: {
			/**
			 * The title to be displayed on the widget.
			 */
			title: {
				type: String,
				required: true
			},

			/**
			 * The value to be animated and displayed on the widget.
			 */
			value: {
				type: Number,
				required: true
			},

			/**
			 * Icon to be displayed on the widget.
			 */
			icon: {
				type: String,
				default: ''
			}
		},

		expose: [],

		data()
		{
			return {
				count: 0
			}
		},

		methods: {
			/**
			 * Animates the displayed number from 0 to target number.
			 * @param {number} numberToDisplay - The target number to be displayed after animation.
			 * @param {function} callback - The function to be called during each step of the animation.
			 */
			animateNumber(numberToDisplay, callback)
			{
				let currentDisplayedNumber = 0

				if (numberToDisplay === currentDisplayedNumber)
					return

				const interval = window.setInterval(() => {
					if (currentDisplayedNumber < numberToDisplay)
					{
						let change = (numberToDisplay - currentDisplayedNumber) / 10
						change = change >= 0 ? Math.ceil(change) : Math.floor(change)
						currentDisplayedNumber = currentDisplayedNumber + change

						if (typeof callback === 'function')
							callback(currentDisplayedNumber)
					}
					else
						clearInterval(interval)
				}, 20)
			}
		},

		watch: {
			value: {
				handler(newVal)
				{
					if (newVal)
					{
						this.animateNumber(newVal, (currentNumber) => {
							this.count = currentNumber
						})
					}
				},
				immediate: true
			}
		}
	}
</script>
