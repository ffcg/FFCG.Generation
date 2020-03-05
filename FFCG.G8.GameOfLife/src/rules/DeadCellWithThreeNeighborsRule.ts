import { ILifeRule } from "./ILifeRule";

export class DeadCellWithThreeNeighborsRule implements ILifeRule {
  canHandle = (isAlive: boolean) => isAlive === false;

  shouldLive(numberOfNeighbors: number) {
    return numberOfNeighbors === 3;
  }
}
