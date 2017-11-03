class TextReplaceRule {
    constructor(wordsToReplace) {
        this.wordsToReplace = wordsToReplace
    }

    manipulate(text) {
        return text
                .replace(/\./g, ' . ')
                .split(' ')
                .map(w => {
                    let wordToReplace = this.wordsToReplace.find(x => {
                        return x.original === w
                    })

                    return wordToReplace ? wordToReplace.new : w
                })
                .join(' ')
                .replace(/\ . /g, '.')
    }
}