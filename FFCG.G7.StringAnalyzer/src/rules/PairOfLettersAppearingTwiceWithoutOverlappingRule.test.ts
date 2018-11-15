import { PairOfLettersAppearingTwiceWithoutOverlappingRule } from "./PairOfLettersAppearingTwiceWithoutOverlappingRule";

describe('Pair of letters appearing twice without overlapping rule', () => {
    let rule: PairOfLettersAppearingTwiceWithoutOverlappingRule

    beforeEach(() => {
        rule = new PairOfLettersAppearingTwiceWithoutOverlappingRule()
    })

    it('should indicate words that follow the rule as nice', () => {
        ['xyxy', 'aabcdefgaa', 'aaaa'].forEach(word => expect(rule.isNice(word)).toBe(true))
    })

    it('should not indicate words that do not follow the rule as nice', () => {
        ['aaa'].forEach(word => expect(rule.isNice(word)).toBe(false))
    })
})