import { IPasswordRule } from "./IPasswordRule";

export class PasswordIsSixDigitsLongRule implements IPasswordRule {
  isValid = (password: number) => password.toString().length === 6;
}
