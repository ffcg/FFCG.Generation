class TextCapitalizeRule extends TextBaseRule {
    constructor(wordsToCapitalize) {
        super()
        this.wordsToCapitalize = wordsToCapitalize
        this.manipulationFunction = this.capitalize.bind(this)
    }

    capitalize(word) {
        const capitalizationFunction = function(t) {
            return t
                    .split('')
                    .map((c, index, array) => {
                        if (index === 0 || index === array.length - 1)
                            return c.toUpperCase()

                        return c
                    })
                    .join('')
        }

        let wordToCapitalize = this.wordsToCapitalize.find(x => {
            return x === word
        })

        return wordToCapitalize ? capitalizationFunction(word) : word
    }
}