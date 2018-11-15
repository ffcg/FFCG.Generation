import { IRule } from "./IRule";

export class LetterTwiceInARowRule implements IRule {
    isNice(word: string) {
        return word.split('').map((c,i,a) => c === a[i-1]).filter(x => x).length > 0
    }
}