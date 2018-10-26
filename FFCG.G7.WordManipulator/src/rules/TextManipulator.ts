import { IManipulateText } from "./IManipulateText";

export class TextManipulator {
    rules: [IManipulateText]

    constructor(rules) {
        this.rules = rules
    }

    manipulate(text: string) {
        return text.splitIntoSeparateWords()
                    .map(this.applyRule)
                    .putBackTogether()
    }

    private applyRule = (word, index, array) => {
        return [word].concat(
                        this.rules
                            .filter(rule => rule.canHandle(word))
                            .map(rule => rule.manipulate(word, index, array)))
                    .last()
    }
}

declare global {
    interface String {
        splitIntoSeparateWords: () => Array<string>
    }

    interface Array<T> {
        putBackTogether: () => string
        last: () => string
    }
}


String.prototype.splitIntoSeparateWords = function() {
    return this.replace(/\./g, ' . ')
                .replace(/\!/g, ' ! ')
                .split(' ')
}

Array.prototype.putBackTogether = function () {
    return this.join(' ')
                .replace(/\ ! /g, '!')
                .replace(/\ . /g, '.')
                .replace(/\  /g, ' ')
}

Array.prototype.last = function() {
    return this[this.length - 1]
}
