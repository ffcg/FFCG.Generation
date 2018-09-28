import { IDivisibleRule } from './IDivisibleRule'

export class DivisibleByThree implements IDivisibleRule {
    matches(number: number): boolean {
        return number % 3 == 0
    }

    word = "Fizz";
}