import { ILifeRule } from "./rules/ILifeRule";

export class Cell {
    lifeRules: Array<ILifeRule>
    isAlive: boolean

    constructor(lifeRules: Array<ILifeRule>, isAlive = false) {
        this.lifeRules = lifeRules
        this.isAlive = isAlive
    }

    split(numberOfNeighbors): Cell {
        const shouldLive = this.lifeRules.filter(r => r.canHandle(this.isAlive)).every(r => r.shouldLive(numberOfNeighbors))
        return new Cell(this.lifeRules, shouldLive)
    }
}