export interface ILifeRule {
  canHandle(isAlive: boolean): boolean;
  shouldLive(numberOfNeighbors: number): boolean;
}
