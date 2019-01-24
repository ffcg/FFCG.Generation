import { Cell } from "./Cell";
import { DeadCellWithThreeNeighbors } from "./rules/DeadCellWithThreeNeighbors";
import { LiveCellWithFewerThanTwoNeighborsRule } from "./rules/LiveCellWithFewerThanTwoNeighborsRule";
import { LiveCellWithMoreThanThreeNeighborsRule } from "./rules/LiveCellWithMoreThanThreeNeighborsRule";
import { LiveCellWithTwoOrThreeNeighborsRule } from "./rules/LiveCellWithTwoOrThreeNeighborsRule";

describe('Cell', () => {
    it('should split into new live cell if all life rules are fulfilled', () => {
        const lifeRules = [
            new DeadCellWithThreeNeighbors(), 
            new LiveCellWithFewerThanTwoNeighborsRule(), 
            new LiveCellWithMoreThanThreeNeighborsRule(), 
            new LiveCellWithTwoOrThreeNeighborsRule()]
        const cell = new Cell(lifeRules, true)

        const newCell = cell.split(3)

        expect(newCell.isAlive).toBe(true)
    })
})