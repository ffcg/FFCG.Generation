import { DeadCellWithThreeNeighborsRule } from "./DeadCellWithThreeNeighborsRule";

describe("Dead cell with three neighbors", () => {
  let rule: DeadCellWithThreeNeighborsRule;

  beforeEach(() => {
    rule = new DeadCellWithThreeNeighborsRule();
  });

  it("should live in the next generation", () => {
    expect(rule.shouldLive(3)).toBe(true);
  });
});
