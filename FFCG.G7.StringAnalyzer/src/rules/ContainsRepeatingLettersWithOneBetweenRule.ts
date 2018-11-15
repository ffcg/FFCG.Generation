import { IRule } from './IRule'

export class ContainsRepeatingLettersWithOneBetweenRule implements IRule {
    isNice(word: string) {
        return word.split('').map((c, i, a) => c === a[i+2]).filter(x => x).length > 0
    }
}