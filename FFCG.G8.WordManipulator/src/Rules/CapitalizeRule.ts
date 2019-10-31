import { ManipulateWordBaseRule } from "./ManipulateWordBaseRule";

export class CapitalizeRule extends ManipulateWordBaseRule {
  manipulate(text: string, index?: number, array?: Array<any>) {
      return text[0].toUpperCase() + text.substring(1)
  }
}
