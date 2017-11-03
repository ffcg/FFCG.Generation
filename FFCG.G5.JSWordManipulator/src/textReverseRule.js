class TextReverseRule {
    constructor(wordsToReverse) {
        this.wordsToReverse = wordsToReverse
    }

    manipulate(text) {
        return text
        .replace(/\./g, ' . ')
        .split(' ')
        .map(w => this.reverse(w))
        .join(' ')
        .replace(/\ . /g, '.')
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