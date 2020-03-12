import { Cell } from "./Cell";
import { ILifeRule } from "./rules/ILifeRule";
import { DeadCellWithThreeNeighborsRule } from "./rules/DeadCellWithThreeNeighborsRule";
import { LiveCellWithFewerThanTwoNeighborsRule } from "./rules/LiveCellWithFewerThanTwoNeighborsRule";
import { LiveCellWithMoreThanThreeNeighborsRule } from "./rules/LiveCellWithMoreThanThreeNeighborsRule";
import { LiveCellWithTwoOrThreeNeighborsRule } from "./rules/LiveCellWithTwoOrThreeNeighborsRule";

export class GameOfLife {
  private rows: number;
  private columns: number;
  public cells: Array<Array<Cell>> = [];

  constructor(rows: number, columns: number) {
    this.rows = rows;
    this.columns = columns;
    this.createCells();
  }

  private createCells() {
    const lifeRules: Array<ILifeRule> = [
      new DeadCellWithThreeNeighborsRule(),
      new LiveCellWithFewerThanTwoNeighborsRule(),
      new LiveCellWithMoreThanThreeNeighborsRule(),
      new LiveCellWithTwoOrThreeNeighborsRule()
    ];

    for (var x = 0; x < this.rows; x++) {
      this.cells[x] = [];

      for (var y = 0; y < this.columns; y++) {
        this.cells[x][y] = new Cell(lifeRules);
      }
    }
  }

  setLivingCell(x: number, y: number) {
    this.cells[x][y].isAlive = true;
  }

  countLivingNeighbors(x: number, y: number) {
    const neighborPositions = [
      [x - 1, y - 1],
      [x - 1, y],
      [x - 1, y + 1],
      [x, y - 1],
      [x, y + 1],
      [x + 1, y - 1],
      [x + 1, y],
      [x + 1, y + 1]
    ];

    const allValidLiveNeighbors = p =>
      this.isWithinGrid(p[0], p[1]) && this.cells[p[0]][p[1]].isAlive;

    return neighborPositions.filter(allValidLiveNeighbors).length;
  }

  private isWithinGrid = (row: number, column: number) =>
    row >= 0 && column >= 0 && row < this.rows && column < this.columns;

  computeNextGeneration() {
    const nextGeneration = [];

    for (var x = 0; x < this.rows; x++) {
      nextGeneration[x] = [];

      for (var y = 0; y < this.columns; y++) {
        nextGeneration[x][y] = this.cells[x][y].goToNextGeneration(
          this.countLivingNeighbors(x, y)
        );
      }
    }

    this.cells = nextGeneration;
  }
}
