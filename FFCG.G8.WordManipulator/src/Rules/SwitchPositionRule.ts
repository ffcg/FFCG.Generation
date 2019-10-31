import { ManipulateWordBaseRule } from "./ManipulateWordBaseRule";

export class SwitchPositionRule extends ManipulateWordBaseRule {
    manipulate(text: string) {
        const half = Math.ceil(text.length / 2)
        return text.substring(half) + text.substring(0, half)
    }
}