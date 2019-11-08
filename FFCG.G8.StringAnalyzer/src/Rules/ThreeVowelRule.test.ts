import { ThreeVowelRule } from "./ThreeVowelRule";

describe("ThreeVowelRule", () => {
  let rule: ThreeVowelRule;

  beforeEach(() => {
    rule = new ThreeVowelRule();
  });

  it("should indicate a word is nice if it contais at least three valid vowels", () => {
    const wordsWithThreeOrMoreVowels = ["aei", "xazegov", "aeiouaeiouaeiou"];

    wordsWithThreeOrMoreVowels.forEach(word =>
      expect(rule.isNice(word)).toBe(true)
    );
  });

  it("should not indicate a word is nice if it contais fewer than three vowels", () => {
    const wordsWithFewerThanThreeVowels = ["ae", "xazegv", "qwertyu"];

    wordsWithFewerThanThreeVowels.forEach(word =>
      expect(rule.isNice(word)).toBe(false)
    );
  });
});
