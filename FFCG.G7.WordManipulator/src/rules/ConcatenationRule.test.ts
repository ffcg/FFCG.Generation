import { ConcatenationRule } from "./ConcatenationRule";

describe('Concatenation rule', () => {
    let rule: ConcatenationRule

    beforeEach(() => {
        rule = new ConcatenationRule(['regel rätta'])
    })

    it('should concatenate words', () => {
        const array = 'Dessa regel rätta kodninjor.'.split(' ')

        expect(rule.manipulate('regel', 1, array)).toBe('')
        expect(rule.manipulate('rätta', 2, array)).toBe('regelrätta')
    })

    it('should handle', () => {
        expect(rule.canHandle('rätta')).toBe(true)
    })
})