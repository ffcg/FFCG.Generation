import { IRule } from "./IRule";

export class DoubleCharacterRule implements IRule {
  isNice(word: string) {
    return (
      word
        .split("")
        .map((character, index, word) => character === word[index - 1])
        .filter(isValid => isValid === true).length > 0
    );
  }
}
