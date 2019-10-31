import { CapitalizeRule } from "./CapitalizeRule";

describe("CapitalizeRule", () => {
  let rule: CapitalizeRule;

  beforeEach(() => {
    const words = ["företaget"];
    rule = new CapitalizeRule(words);
  });

  it("should capitalize first letter", () => {
    expect(rule.manipulate("företaget")).toBe("Företaget");
  });

  it('should handle specified word', () => {
      expect(rule.canHandle('Företaget')).toBe(true)
  })

  it('should ot handle unspecified word', () => {
    expect(rule.canHandle('kalleanka')).toBe(false)
})
});
