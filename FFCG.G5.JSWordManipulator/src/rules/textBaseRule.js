class TextBaseRule {
    manipulate(text) {
        return text
                .replace(/\./g, ' . ')
                .split(' ')
                .map((w, i, a) => this.manipulationFunction(w, i, a))
                .join(' ')
                .replace(/\ . /g, '.')
    }
}
