import { StringAnalyzer } from "./StringAnalyzer";
import { ContainsThreeVowelsRule } from "./rules/ContainsThreeVowelsRule";
import { LetterTwiceInARowRule } from "./rules/LetterTwiceInARowRule";
import { ForbiddenLettersRule } from "./rules/ForbiddenLettersRule";
import { readFileSync } from 'fs'
import { ContainsRepeatingLettersWithOneBetweenRule } from "./rules/ContainsRepeatingLettersWithOneBetweenRule";
import { PairOfLettersAppearingTwiceWithoutOverlappingRule } from "./rules/PairOfLettersAppearingTwiceWithoutOverlappingRule";

describe('String analyzer', () => {
    let analyzer: StringAnalyzer

    beforeEach(() => {
        const rules = [new ContainsThreeVowelsRule(), new LetterTwiceInARowRule(), new ForbiddenLettersRule()]
        analyzer = new StringAnalyzer(rules)
    })

    it('should indicate nice words', () => {
        const niceWords = ['ugknbfddgicrmopn', 'aaa']

        niceWords.forEach(w => expect(analyzer.stringIsNice(w)).toBe(true))
    })

    it('should indicate bad words', () => {
        const badWords = ['jchzalrnumimnmhp', 'haegwjzuvuyypxyu', 'dvszwmarrgswjxmb']

        badWords.forEach(w => expect(analyzer.stringIsNice(w)).toBe(false))
    })

    it('should count nice words in list', () => {
        const list = readFileSync('input.txt').toString().split('\n')

        expect(list.map(w => analyzer.stringIsNice(w)).filter(x => x).length).toBe(238)
    })

    describe('when using new rules', () => {
        beforeEach(() => {
            analyzer = new StringAnalyzer([new PairOfLettersAppearingTwiceWithoutOverlappingRule(), new ContainsRepeatingLettersWithOneBetweenRule()])
        })

        it('should correctly analyze examples', () => {
            [{ word: 'qjhvhtzxzqqjkmpb', isNice: true},
            { word: 'xxyxx', isNice: true},
            { word: 'uurcxstgmygtbstg', isNice: false},
            { word: 'ieodomkazucvgmuy', isNice: false}].forEach(example => expect(analyzer.stringIsNice(example.word)).toBe(example.isNice))
        })

        it('should count nice word in list with new rules', () => {
            const list = readFileSync('input.txt').toString().split('\n')
    
            expect(list.map(w => analyzer.stringIsNice(w)).filter(x => x).length).toBe(69)
        })
    })
})