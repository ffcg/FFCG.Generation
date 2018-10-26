import { ManipulateWordBaseRule } from "./ManipulateWordBaseRule";

export class SwitchPositionRule extends ManipulateWordBaseRule {
    manipulate(word: string) {
        const half = Math.ceil(word.length / 2)
        return word.substring(half, word.length) + word.substring(0, half)
    }
}