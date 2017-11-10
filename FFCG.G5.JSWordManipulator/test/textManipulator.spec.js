describe('Text Manipulator', () => {
    let textManipulator

    it('should replace words', () => {
        let wordsToReplace = [{ original: 'foo', new: 'bar'}, { original: 'sentence', new: 'cake'}]
        
        const textReplaceRule = new TextReplaceRule(wordsToReplace)

        textManipulator = new TextManipulator([textReplaceRule]) 

        let input = "Here is foo. Here is another sentence."

        let result = textManipulator.manipulateText(input)

        expect(result).toBe('Here is bar. Here is another cake.')
    })

    it('should reverse words', () => {
        const textReverseRule = new TextReverseRule(["foo", "another"])
        
        let input = "Here is foo. Here is another sentence."

        textManipulator = new TextManipulator([textReverseRule])

        let result = textManipulator.manipulateText(input)

        expect(result).toBe('Here is oof. Here is rehtona sentence.')
    })

    it('should capitalize first and last letter in specified words', function() {
        const textCapitalizeRule = new TextCapitalizeRule(["another"])

        let input = "Here is foo. Here is another sentence."

        textManipulator = new TextManipulator([textCapitalizeRule])

        let result = textManipulator.manipulateText(input)
        
        expect(result).toBe('Here is foo. Here is AnotheR sentence.')
    })

    it('should concatenate words', () => {
        const textConcatenationRule = new TextConcatenationRule(["pengar"])

        textManipulator = new TextManipulator([textConcatenationRule])

        let input = "Spara pengar genom att späda ut mjölk."

        let result = textManipulator.manipulateText(input)

        expect(result).toBe("Spara pengen genom att späda ut mjölk.")
    })
})