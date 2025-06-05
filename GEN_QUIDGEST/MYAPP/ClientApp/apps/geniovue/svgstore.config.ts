import { readdirSync, readFileSync, writeFileSync } from 'node:fs'
import { dirname, extname, join, parse } from 'node:path'
import { fileURLToPath } from 'node:url'

//@ts-expect-error svgstore does not export types
import svgstore from 'svgstore'

/**
 * Specific bundling setup for this project.
 */
function ProjectPack() {
	const __filename = fileURLToPath(import.meta.url)
	const __dirname = dirname(__filename)

	PackSvg(join(__dirname, './public/Content/svg/'), join(__dirname, './public/Content/svgbundle.svg'))
}

/**
 * Bundles all the svg files found in a souce directory into an single svg output file.
 * @param dirname - The path to the directory containing all the svgs to be bundled
 * @param output - The full filename of the desired output bundle
 */
function PackSvg(dirname: string, output: string) {
	let sprites = svgstore()
	const files = readdirSync(dirname)

	files.forEach((file) => {
		if (extname(file) === '.svg') {
			let id = parse(file).name
			let content = readFileSync(join(dirname, file), 'utf8')
			sprites.add(id, content)
		}
	})

	writeFileSync(output, sprites.toString())
}

export default ProjectPack
