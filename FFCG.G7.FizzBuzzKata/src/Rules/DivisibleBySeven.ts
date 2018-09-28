import { IDivisibleRule } from './IDivisibleRule'

export class DivisibleBySeven implements IDivisibleRule {
    matches(number: number): boolean {
        return number % 7 == 0
    }

    word = "Foo";
}