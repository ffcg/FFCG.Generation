import { Cell } from "./cell";
import { ILifeRule } from "./rules/ILifeRule";
import { DeadCellWithThreeNeighbors } from "./rules/DeadCellWithThreeNeighbors";
import { LiveCellWithFewerThanTwoNeighborsRule } from "./rules/LiveCellWithFewerThanTwoNeighborsRule";
import { LiveCellWithMoreThanThreeNeighborsRule } from "./rules/LiveCellWithMoreThanThreeNeighborsRule";
import { LiveCellWithTwoOrThreeNeighborsRule } from "./rules/LiveCellWithTwoOrThreeNeighborsRule";

export class GameOfLife {
    rows: number
    columns: number

    cells: Array<Array<Cell>> = []
    lifeRules: Array<ILifeRule>

    constructor(rows: number, columns: number) {
        this.rows = rows
        this.columns = columns
        this.createCells()
    }

    private createCells(): void {
        this.lifeRules = [
            new DeadCellWithThreeNeighbors(),
            new LiveCellWithFewerThanTwoNeighborsRule(),
            new LiveCellWithMoreThanThreeNeighborsRule(),
            new LiveCellWithTwoOrThreeNeighborsRule()
        ]

        for (var x = 0; x < this.rows; x++) {
            this.cells[x] = []
            
            for (var y = 0; y < this.columns; y++)
                this.cells[x][y] = new Cell(this.lifeRules)
        }
    }

    setLivingCell = (x: number, y: number) => this.cells[x][y].isAlive = true

    countLivingNeighbors(x: number, y: number) {
        const surroundingCellPositions = [
            [x - 1, y - 1],
            [x - 1, y],
            [x - 1, y + 1],
            [x, y - 1],
            [x, y + 1],
            [x + 1, y - 1],
            [x + 1, y],
            [x + 1, y + 1]
        ]

        return surroundingCellPositions.filter(p => this.isWithinGrid(p[0], p[1]) && this.cells[p[0]][p[1]].isAlive).length
    }

    private isWithinGrid = (row: number, column: number) => row >= 0 && column >= 0 && row < this.rows && column < this.columns

    computeNextGeneration() {
        const nextGeneration = []

        for (var x = 0; x < this.rows; x++) {
            nextGeneration[x] = []
            
            for (var y = 0; y < this.columns; y++)
            nextGeneration[x][y] = this.cells[x][y].next(this.countLivingNeighbors(x, y))
        }

        this.cells = nextGeneration
    }
}