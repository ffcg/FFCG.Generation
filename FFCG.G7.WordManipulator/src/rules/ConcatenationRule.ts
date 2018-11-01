import { ManipulateWordBaseRule } from "./ManipulateWordBaseRule";

export class ConcatenationRule extends ManipulateWordBaseRule {
    wordParts: IWordParts[]
    constructor(wordsInTwoParts) {
        const wordParts = wordsInTwoParts.map(w => {
            const splitWord = w.split(' ')
            return {
                one: splitWord[0],
                two: splitWord[1]
            }
        })
        const separateWords = wordParts.map(x => x.two).concat(wordParts.map(x => x.one))
        super(separateWords)
        this.wordParts = wordParts
    }

    manipulate(word: string, index?: number, array?: Array<string>) {
        const wordParts = this.wordParts.find(x => x.two === word || x.one === word)

        if(array[index + 1] === wordParts.two) {
            array[index + 1] = ''
            return wordParts.one + wordParts.two.toLowerCase()
        }
        
        return word
    }
}

interface IWordParts {
    one: string
    two: string
}
