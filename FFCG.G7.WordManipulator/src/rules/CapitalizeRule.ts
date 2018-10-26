import { ManipulateWordBaseRule } from "./ManipulateWordBaseRule";

export class CapitalizeRule extends ManipulateWordBaseRule {
    manipulate(text: string) {
        return text[0].toUpperCase() + text.substring(1)
    }
}
