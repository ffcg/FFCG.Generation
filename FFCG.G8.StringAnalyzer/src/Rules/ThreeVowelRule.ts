import { IRule } from "./IRule";

export class ThreeVowelRule implements IRule {
  validVowels = ["a", "e", "i", "o", "u"];

  isNice(word: string) {
    return (
      word
        .split("")
        .map(c => this.validVowels.includes(c))
        .filter(vowelIsValid => vowelIsValid === true).length >= 3
    );
  }
}
