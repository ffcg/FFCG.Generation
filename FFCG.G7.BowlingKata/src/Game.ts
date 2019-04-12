export class Game {
    private rolls: Array<number>
    private currentRoll: number

    constructor() {
        this.rolls = []
        this.currentRoll = 0       
    }

    roll(pins: number) {
        this.rolls[this.currentRoll++] = pins
    }

    score() {
       let score = 0
       let roll = 0

       for (let frame = 0; frame < 10; frame++) {
           if (this.isStrike(roll)) {
                score += 10 + this.strikeBonus(roll)
                roll++
           }
           else if (this.isSpare(roll)) {
                score += 10 + this.spareBonus(roll)
                roll += 2
           } else {
                score += this.sumOfBallsInFrame(roll)
                roll += 2
           }
       }

        return score
    }

    private isSpare = (roll: number) => this.rolls[roll] + this.rolls[roll + 1] === 10
    private isStrike = (roll: number) => this.rolls[roll] === 10
    private strikeBonus = (roll: number) => this.rolls[roll + 1] + this.rolls[roll + 2]
    private spareBonus = (roll: number) => this.rolls[roll + 2]
    private sumOfBallsInFrame = (roll: number) => this.rolls[roll] + this.rolls[roll +1]
}