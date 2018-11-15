import { LetterTwiceInARowRule } from "./LetterTwiceInARowRule";

describe('Letter twice in a row rule', () => {
    let rule: LetterTwiceInARowRule

    beforeEach(() => {
        rule = new LetterTwiceInARowRule()
    })

    it('should indicate a word is nice if it contains two letters twice in a row', () => {
        ['xx', 'abcdde', 'aabbccdd'].forEach(w => expect(rule.isNice(w)).toBe(true))
    })

    it('should not indicate a word is nice if it does not contains two letters twice in a row', () => {
        ['x', 'abcde', 'xagelov'].forEach(w => expect(rule.isNice(w)).toBe(false))        
    })
})