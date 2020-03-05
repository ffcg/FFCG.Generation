import { LiveCellWithTwoOrThreeNeighborsRule } from "./LiveCellWithTwoOrThreeNeighborsRule";

describe("Live cell with two or three neighbors", () => {
  let rule: LiveCellWithTwoOrThreeNeighborsRule;

  beforeEach(() => {
    rule = new LiveCellWithTwoOrThreeNeighborsRule();
  });

  it("should live if number neighbors is two", () => {
    expect(rule.shouldLive(2)).toBe(true);
  });

  it("should live if number neighbors is three", () => {
    expect(rule.shouldLive(3)).toBe(true);
  });

  it("should not live if number neighbors is not two or three", () => {
    expect(rule.shouldLive(1)).toBe(false);
  });
});
