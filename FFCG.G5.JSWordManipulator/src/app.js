const textReplaceRule = new TextReplaceRule([{ original: 'Here', new: 'Här'}, { original: 'is', new: 'ere'}])
const textReverseRule = new TextReverseRule(["another"])
const textCapitalizeRule = new TextCapitalizeRule(["another"])
const textConcatenationRule = new TextConcatenationRule(["pengar"])

textManipulator = new TextManipulator([textReplaceRule, textReverseRule, textCapitalizeRule, textConcatenationRule]) 

let inputElement = document.getElementById('textinput')
let outputElement = document.getElementById('textoutput')

inputElement.onkeyup = function(event) {
    let manipulatedText = textManipulator.manipulateText(event.target.value)
    outputElement.innerHTML = manipulatedText
}