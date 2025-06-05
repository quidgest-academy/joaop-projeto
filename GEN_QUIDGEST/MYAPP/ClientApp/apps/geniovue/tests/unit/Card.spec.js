import '@testing-library/jest-dom'

import { render } from './utils'

import QCard from '@/components/containers/QCard.vue'

test('renders the card title when title prop is passed', () => {
	const title = 'Test Card Title'

	const { getByText } = render(QCard, {
		props: {
			title
		}
	})

	expect(getByText(title)).toBeInTheDocument()
})

test('renders the card subtitle when subtitle prop is passed', () => {
	const subtitle = 'Test Card Subtitle'

	const { getByText } = render(QCard, {
		props: {
			subtitle
		}
	})

	expect(getByText(subtitle)).toBeInTheDocument()
})

test('renders the card size based on the size prop', () => {
	const size = 'small'

	const { getByTestId } = render(QCard, {
		props: {
			size
		}
	})

	expect(getByTestId('q-card-view')).toHaveClass(`q-card-view--size-${size}`)
})

test('renders the card content aligned to center when contentAlignment prop is set to center', () => {
	const contentAlignment = 'center'

	const { getByTestId } = render(QCard, {
		props: {
			contentAlignment
		}
	})

	expect(getByTestId('q-card-view')).toHaveClass('q-card-view--centered')
})
