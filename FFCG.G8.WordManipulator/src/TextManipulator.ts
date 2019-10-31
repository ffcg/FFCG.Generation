import { IManipulateText } from "./Rules/IManipulateText";

export class TextManipulator {
  rules: IManipulateText[];

  constructor(rules: IManipulateText[]) {
    this.rules = rules;
  }

  private applyRule = (word, index, sentenceArray) => {
    return [word]
      .concat(
        this.rules
          .filter(rule => rule.canHandle(word))
          .map(rule => rule.manipulate(word, index, sentenceArray))
      )
      .last();
  };

  manipulate(text: string) {
    return text
      .splitIntoSeparateWords()
      .map(this.applyRule)
      .putBackTogether();
  }

  //Motsvarande .map(this.applyRule)
  private applyRulesToText(wordArray) {
    for (var i = 0; i < wordArray.length; i++) {
      for (var j = 0; j < this.rules.length; j++) {
        if (this.rules[j].canHandle(wordArray[i])) {
          wordArray[i] = this.rules[j].manipulate(wordArray[i], i, wordArray);
        }
      }
    }

    return wordArray;
  }

  alternativeManipulate(text: string) {
    let separateWords = text.splitIntoSeparateWords();
    let textWithAppliedRules = this.applyRulesToText(separateWords);
    return textWithAppliedRules.putBackTogether();
  }
}

String.prototype.splitIntoSeparateWords = function() {
  return this.replace(/\./g, " . ")
    .replace(/\!/g, " ! ")
    .split(" ");
};

Array.prototype.last = function() {
  return this[this.length - 1];
};

Array.prototype.putBackTogether = function() {
  return this.join(" ")
    .replace(/\ ! /g, "!")
    .replace(/\ . /g, ".")
    .replace(/\  /g, " ");
};

declare global {
  interface String {
    splitIntoSeparateWords: () => Array<string>;
  }

  interface Array<T> {
    putBackTogether: () => string;
    last: () => string;
  }
}
