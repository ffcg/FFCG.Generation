import { ILifeRule } from "./ILifeRule";

export class DeadCellWithThreeNeighbors implements ILifeRule {
    canHandle = (isAlive: boolean) => isAlive === false
    
    shouldLive(numberOfNeighbours: number): boolean {
        return numberOfNeighbours === 3
    }
}