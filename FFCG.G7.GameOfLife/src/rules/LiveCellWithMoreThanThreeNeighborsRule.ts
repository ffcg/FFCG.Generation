import { ILifeRule } from "./ILifeRule";

export class LiveCellWithMoreThanThreeNeighborsRule implements ILifeRule {
    canHandle = (isAlive: boolean) => isAlive === true

    shouldLive(numberOfNeighbors: number) {
        return numberOfNeighbors <= 3
    }
}