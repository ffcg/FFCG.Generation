import { IDivisibleRule } from './IDivisibleRule'

export class DivisibleByFive implements IDivisibleRule {
    matches(number: number): boolean {
        return number % 5 == 0
    }

    word = "Buzz";
}