import { PasswordValidator } from "./PasswordValidator";
import { PasswordIsSixDigitsLongRule } from "./PasswordRules/PasswordIsSixDigitsLongRule";
import { IPasswordRule } from "./PasswordRules/IPasswordRule";

describe("PasswordValidator", () => {
  let passwordValidator: PasswordValidator;
  let rules: IPasswordRule[];

  beforeEach(() => {
    rules = [new PasswordIsSixDigitsLongRule()];
    passwordValidator = new PasswordValidator(rules);
  });

  it("should validate that password are six digit numbers", () => {
    //Arrange
    const password = 113456;

    //Act
    const isValid = passwordValidator.validate(password);

    //Assert
    expect(isValid).toBe(true);
  });

  it("should validate that the password is within a given range", () => {
    const passwordValidator = new PasswordValidator(rules, 100000, 200000);
    const password = 300000;

    const isValid = passwordValidator.validate(password);

    expect(isValid).toBe(false);
  });

  it("should validate that passwords have two adjacent digits that are the same", () => {
    //Arrange
    const falsePassword = 123456;
    const truePassword = 112345;

    //Act
    const resultOne = passwordValidator.validate(falsePassword);
    const resultTwo = passwordValidator.validate(truePassword);

    //Assert
    expect(resultOne).toBe(false);
    expect(resultTwo).toBe(true);
  });

  it("should validate that passwords digits never decrease when going from left to right", () => {
    const password = 113454;

    const isValid = passwordValidator.validate(password);

    expect(isValid).toBe(false);
  });

  it("should correctly validate examples", () => {
    //Arrange
    const examples = [
      { password: 111111, isValid: true },
      { password: 223450, isValid: false },
      { password: 123789, isValid: false }
    ];

    //Act
    const results = examples.map(
      e => passwordValidator.validate(e.password) === e.isValid
    );

    //Assert
    expect(results.every(x => x)).toBe(true);
  });
});
