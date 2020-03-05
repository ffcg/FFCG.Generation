import { ILifeRule } from "./ILifeRule";

export class LiveCellWithFewerThanTwoNeighborsRule implements ILifeRule {
  canHandle = (isAlive: boolean) => isAlive === true;
  shouldLive(numberOfNeighbors: number) {
    return numberOfNeighbors >= 2;
  }
}
