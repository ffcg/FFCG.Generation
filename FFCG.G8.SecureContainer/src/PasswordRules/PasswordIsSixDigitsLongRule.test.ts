import { PasswordIsSixDigitsLongRule } from "./PasswordIsSixDigitsLongRule";

describe("Password is six digits long rule", () => {
  it("should validate passwords that are six digits", () => {
    const rule = new PasswordIsSixDigitsLongRule();

    const isValid = rule.isValid(123456);

    expect(isValid).toBe(true);
  });
});
