import { IRule } from "./IRule";

export class ForbiddenLettersRule implements IRule {
    forbiddenLetters = ['ab', 'cd', 'pq', 'xy']

    isNice(word: string) {
        return this.forbiddenLetters.map(fl => word.includes(fl)).filter(x => x).length === 0
    }
}