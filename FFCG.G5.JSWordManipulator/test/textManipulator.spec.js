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
})