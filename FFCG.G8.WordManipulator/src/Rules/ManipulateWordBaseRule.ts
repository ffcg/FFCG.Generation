import { IManipulateText } from "./IManipulateText";

export abstract class ManipulateWordBaseRule implements IManipulateText {
    words: Array<string>;

    constructor(words: Array<string>) {
      this.words = words;
    }

    abstract manipulate(text: string, index?: number, array?: Array<any>): string

    canHandle(text: string): boolean {
        return this.words.map(x => x.toLowerCase()).includes(text.toLowerCase())
    }
}