import { ManipulateWordBaseRule } from "./ManipulateWordBaseRule";

export class ReverseRule extends ManipulateWordBaseRule {
    manipulate(text: string) {
        return text.split('').reverse().join('')
    }
}