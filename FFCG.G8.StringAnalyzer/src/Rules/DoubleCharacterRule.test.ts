import { DoubleCharacterRule } from "./DoubleCharacterRule";

describe("DoubleCharacterRule", () => {
  let rule: DoubleCharacterRule;

  beforeEach(() => {
    rule = new DoubleCharacterRule();
  });

  it("should indicate a word is nice if it contains the same two characters in a row", () => {
    ["xx", "abcdde", "aabbccdd"].forEach(w =>
      expect(rule.isNice(w)).toBe(true)
    );
  });

  it("should not indicate a word is nice if it does not contains two letters twice in a row", () => {
    ["x", "abcde", "xagelov"].forEach(w => expect(rule.isNice(w)).toBe(false));
  });
});
