class TextReverseRule extends TextBaseRule {
    constructor(wordsToReverse) {
        super()
        this.wordsToReverse = wordsToReverse
        this.manipulationFunction = this.reverse.bind(this)
    }

    reverse(word) {
        let wordToReverse = this.wordsToReverse.find(x => {
            return x === word
        })

        return wordToReverse ?
                wordToReverse.split('').reverse().join('') 
                : word
    }
}