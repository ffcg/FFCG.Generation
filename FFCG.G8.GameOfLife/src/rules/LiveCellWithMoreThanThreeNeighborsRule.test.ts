import { LiveCellWithMoreThanThreeNeighborsRule } from "./LiveCellWithMoreThanThreeNeighborsRule";

describe("Live cell with more than three neighbors", () => {
  let rule: LiveCellWithMoreThanThreeNeighborsRule;

  beforeEach(() => {
    rule = new LiveCellWithMoreThanThreeNeighborsRule();
  });

  it("should not live on to the next generation", () => {
    expect(rule.shouldLive(4)).toBe(false);
  });
});
