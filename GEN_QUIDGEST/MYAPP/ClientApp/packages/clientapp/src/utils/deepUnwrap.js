import { isRef, unref, isProxy, toRaw } from 'vue'

/**
 * Deeply unwraps Vue refs/reactive proxies and returns
 * a **plain, serialisable** structure (suitable for logs).
 *
 *  * Arrays, Maps, Sets and plain objects are copied recursively.
 *  * Dates, RegExps and Errors are copied with their sensible state.
 *  * Circular references are handled gracefully – the second
 *    occurrence is replaced by the string `"[Circular]"`.
 *
 * @param  {*} input                         anything
 * @param  {WeakMap<object, *>} [memo]       used internally to break cycles
 * @returns {*}                              de-proxied, plain clone
 */
export function deepUnwrap (input, memo = new WeakMap()) {
	// 1 · unwrap Vue Ref / reactive Proxy
	let value = isRef(input) ? unref(input) : input
	value = isProxy(value) ? toRaw(value) : value

	// 2 · primitives can be returned as they are
	if (
		value === null ||
		typeof value !== 'object' && typeof value !== 'function'
	) return value

	// 3 · circular-reference guard
	if (memo.has(value)) return '[Circular]'
	memo.set(value, true)

	/* ----- native special cases --------------------------------------- */
	if (value instanceof Date)    return new Date(value.getTime())
	if (value instanceof RegExp)  return new RegExp(value)
	if (value instanceof Error) {
		// copy basic properties; stack often enough for debugging
		return { name: value.name, message: value.message, stack: value.stack }
	}

	/* ----- Arrays ----------------------------------------------------- */
	if (Array.isArray(value)) {
		return value.map(v => deepUnwrap(v, memo))
	}

	/* ----- Map / Set -------------------------------------------------- */
	if (value instanceof Map) {
		const out = {}
		// keys converted to string – adequate for diagnostics
		value.forEach((v, k) => { out[String(k)] = deepUnwrap(v, memo) })
		return out
	}
	if (value instanceof Set) {
		return Array.from(value, v => deepUnwrap(v, memo))
	}

	/* ----- plain object (or class instance) --------------------------- */
	const out = {}
	for (const key of Reflect.ownKeys(value)) {
		// ignore non-enumerable/internal stuff
		if (!Object.prototype.propertyIsEnumerable.call(value, key)) continue
		out[key] = deepUnwrap(value[key], memo)
	}
	return out
}
