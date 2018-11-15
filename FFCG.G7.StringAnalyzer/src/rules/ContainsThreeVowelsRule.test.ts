import { ContainsThreeVowelsRule } from "./ContainsThreeVowelsRule";

describe('Contains three vowels rule', () => {
    let rule: ContainsThreeVowelsRule

    beforeEach(() => {
        rule = new ContainsThreeVowelsRule()
    })

    it('should indicate a word is nice if it has three or more vowels', () => {
        const wordsWithThreeOrMoreVowels = ['aei', 'xazegov', 'aeiouaeiouaeiou']

        wordsWithThreeOrMoreVowels.forEach(w => expect(rule.isNice(w)).toBe(true))
    })

    it('should not indicate a word is nice if it has fewer than three vowels', () => {
        const wordsWithFewerThanThreeVowels = ['ae', 'xazegv', 'qwertyu']

        wordsWithFewerThanThreeVowels.forEach(w => expect(rule.isNice(w)).toBe(false))
    })
})