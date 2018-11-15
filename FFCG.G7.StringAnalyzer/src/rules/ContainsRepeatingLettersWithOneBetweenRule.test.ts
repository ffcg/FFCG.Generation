import { ContainsRepeatingLettersWithOneBetweenRule } from "./ContainsRepeatingLettersWithOneBetweenRule";

describe('Contains repeating letters with one between rule', () => {
    let rule: ContainsRepeatingLettersWithOneBetweenRule

    beforeEach(() => {
        rule = new ContainsRepeatingLettersWithOneBetweenRule()
    })

    it('should indicate words following rule as nice', () => {
        ['xyx', 'abcdefeghi', 'aaa'].forEach(word => expect(rule.isNice(word)).toBe(true))
    })

    it('should not indicate words that do not follow the rule as nice', () => {
        ['abc', 'abba'].forEach(word => expect(rule.isNice(word)).toBe(false))
    })
})