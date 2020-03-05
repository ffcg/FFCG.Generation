import { ILifeRule } from "./rules/ILifeRule";

export class Cell {
  public isAlive: boolean;
  private lifeRules: Array<ILifeRule>;

  constructor(lifeRules: Array<ILifeRule>, isAlive: boolean = false) {
    this.lifeRules = lifeRules;
    this.isAlive = isAlive;
  }

  goToNextGeneration(numberOfNeighbors: number): Cell {
    const livesNextGeneration = this.lifeRules
      .filter((rule: ILifeRule) => rule.canHandle(this.isAlive))
      .every(r => r.shouldLive(numberOfNeighbors));

    return new Cell(this.lifeRules, livesNextGeneration);
  }
}
