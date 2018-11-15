import { IRule } from "./IRule";

export class ContainsThreeVowelsRule implements IRule {
    vowels = ['a', 'e', 'i', 'o', 'u']

    isNice(word: string) {
        return word.split('').map(c => this.vowels.includes(c)).filter(x => x).length >= 3
    }
}