import { IManipulateText } from "./IManipulateText";

export abstract class ManipulateWordBaseRule implements IManipulateText {
    words: Array<string>

    constructor(words: Array<string>) {
        this.words = words
    }

    abstract manipulate(text: string): string

    canHandle(text: string): boolean {
        return this.words.map(w => w.toLowerCase()).includes(text.toLowerCase())
    }
}
