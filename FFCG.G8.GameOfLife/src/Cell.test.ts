import { Cell } from "./Cell";
import { LiveCellWithMoreThanThreeNeighborsRule } from "./rules/LiveCellWithMoreThanThreeNeighborsRule";
import { LiveCellWithTwoOrThreeNeighborsRule } from "./rules/LiveCellWithTwoOrThreeNeighborsRule";
import { LiveCellWithFewerThanTwoNeighborsRule } from "./rules/LiveCellWithFewerThanTwoNeighborsRule";
import { DeadCellWithThreeNeighborsRule } from "./rules/DeadCellWithThreeNeighborsRule";

describe("Cell", () => {
  let cell: Cell;

  beforeEach(() => {
    const lifeRules = [
      new LiveCellWithMoreThanThreeNeighborsRule(),
      new LiveCellWithTwoOrThreeNeighborsRule(),
      new LiveCellWithFewerThanTwoNeighborsRule(),
      new DeadCellWithThreeNeighborsRule()
    ];
    cell = new Cell(lifeRules);
  });

  it("should live if alive and number of neighbors is two", () => {
    //Arrange
    cell.isAlive = true;

    //Act
    const newCell = cell.goToNextGeneration(2);

    //Assert
    expect(newCell.isAlive).toBe(true);
  });

  it("should live if dead and number of neighbors is three", () => {
    //Arrange
    cell.isAlive = false;

    //Act
    const newCell = cell.goToNextGeneration(3);

    //Assert
    expect(newCell.isAlive).toBe(true);
  });
});
