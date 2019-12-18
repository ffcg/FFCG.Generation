import { IPasswordRule } from "./PasswordRules/IPasswordRule";

export class PasswordValidator {
  private min: number;
  private max: number;
  private rules: IPasswordRule[];

  constructor(
    rules: IPasswordRule[],
    min: number = 100000,
    max: number = 999999
  ) {
    this.rules = rules;
    this.min = min;
    this.max = max;
  }

  validate(password: number): boolean {
    const passwordCharacters = password.toString();

    const passwordRuleResults = [];
    for (var i = 0; i < this.rules.length; i++) {
      passwordRuleResults.push(this.rules[i].isValid(password));
    }
    const atleastOneTestFailed =
      passwordRuleResults.filter(x => x === false).length > 0;
    if (atleastOneTestFailed) return false;

    if (password <= this.min || password > this.max) return false;

    let hasAdjacentDigits = false;
    for (var i = 1; i < passwordCharacters.length; i++) {
      if (passwordCharacters[i] === passwordCharacters[i - 1]) {
        hasAdjacentDigits = true;
      }
    }

    let hasIncreasingDigits = true;
    for (var i = 1; i < passwordCharacters.length; i++) {
      if (passwordCharacters[i] < passwordCharacters[i - 1]) {
        hasIncreasingDigits = false;
      }
    }

    if (!hasIncreasingDigits) return false;

    if (!hasAdjacentDigits) {
      return false;
    }

    return true;
  }
}
