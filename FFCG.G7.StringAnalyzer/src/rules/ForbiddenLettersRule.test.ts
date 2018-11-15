import { ForbiddenLettersRule } from "./ForbiddenLettersRule";

describe('Forbidden letters rule', () => {
    let rule: ForbiddenLettersRule

    beforeEach(() => {
        rule = new ForbiddenLettersRule()
    })

    it('should indicate a word is nice if it does not contain forbidden letters', () => {
        ['aaa', 'ugknbfddgicrmopn'].forEach(w => expect(rule.isNice(w)).toBe(true))
    })

    it('should not indicate a word is nice if it contains forbidden letters', () => {
        ['uydafcd', 'aiusdpqasd'].forEach(w => expect(rule.isNice(w)).toBe(false))
    })
})