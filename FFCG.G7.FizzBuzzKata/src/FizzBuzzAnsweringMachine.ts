import { IDivisibleRule } from "./Rules/IDivisibleRule";

export class FizzBuzzAnsweringMachine {
    rules: IDivisibleRule[]

    constructor(rules: IDivisibleRule[]) {
        this.rules = rules
    }

    answer(number: number): string {
        const words = this.rules
                        .filter(rule => rule.matches(number))
                        .map(rule => rule.word)

        if (words.length != 0)
            return words.join('')
        else 
            return number.toString()
    }
}