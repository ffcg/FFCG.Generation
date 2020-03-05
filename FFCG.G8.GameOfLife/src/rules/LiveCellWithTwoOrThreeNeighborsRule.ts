import { ILifeRule } from "./ILifeRule";

export class LiveCellWithTwoOrThreeNeighborsRule implements ILifeRule {
  canHandle = (isAlive: boolean) => isAlive === true;

  shouldLive(numberOfNeighbors: number) {
    return numberOfNeighbors === 2 || numberOfNeighbors === 3;
  }
}
