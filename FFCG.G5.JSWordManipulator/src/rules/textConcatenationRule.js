class TextConcatenationRule extends TextBaseRule {
    constructor(wordsToConcatenate) {
        super()
        this.wordsToConcatenate = wordsToConcatenate
        this.manipulationFunction = this.concatenate.bind(this)
    }

    concatenate(word, index, array) {
        const concatenateWord = (word, nextWord) => {
            const amountOfCharactersInFirstWord = Math.floor(word.length / 2)
            const amountOfCharactersInNextWord = word.length - amountOfCharactersInFirstWord
    
            return word.substring(0, amountOfCharactersInFirstWord) + 
                    nextWord.substring(0, amountOfCharactersInNextWord)   
        }

        let wordToConcatenate = this.wordsToConcatenate.find(x => {
            return x === word
        })

        return wordToConcatenate ? concatenateWord(word, array[index+1]) : word
    }
}
