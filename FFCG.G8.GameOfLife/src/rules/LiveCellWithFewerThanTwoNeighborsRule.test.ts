import { LiveCellWithFewerThanTwoNeighborsRule } from "./LiveCellWithFewerThanTwoNeighborsRule";

describe("Live cell with fewer than two neighbors", () => {
  let rule: LiveCellWithFewerThanTwoNeighborsRule;

  beforeEach(() => {
    rule = new LiveCellWithFewerThanTwoNeighborsRule();
  });

  it("should live if number of neighbors is two or greater", () => {
    const numberOfNeighbors = 2;
    expect(rule.shouldLive(numberOfNeighbors)).toBe(true);
  });
});
