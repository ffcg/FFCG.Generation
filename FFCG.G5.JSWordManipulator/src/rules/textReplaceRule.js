class TextReplaceRule extends TextBaseRule {
    constructor(wordsToReplace) {
        super()
        this.wordsToReplace = wordsToReplace
        this.manipulationFunction = this.replace.bind(this)
    }

    replace(w) {
        let wordToReplace = this.wordsToReplace.find(x => {
            return x.original === w
        })

        return wordToReplace ? wordToReplace.new : w
    }
}