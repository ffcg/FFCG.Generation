class TextManipulator {
    constructor(manipulatorRules) {
        this.manipulatorRules = manipulatorRules
    }

    manipulateText(text) {
        let manipulatedText = text

        this.manipulatorRules.forEach(rule => {
            manipulatedText = rule.manipulate(manipulatedText)
        })

        return manipulatedText
    }
}