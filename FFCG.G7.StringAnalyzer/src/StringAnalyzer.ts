import { IRule } from "./rules/IRule";

export class StringAnalyzer {
    rules: Array<IRule>

    constructor(rules: Array<IRule>) {
        this.rules = rules
    }

    stringIsNice(input: string) {
        return this.rules.every(r => r.isNice(input))
    }
}