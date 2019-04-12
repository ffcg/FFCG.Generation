import { Game } from "./Game";

describe('Bowling Kata', () => {
    let game: Game

    beforeEach(() => {
        game = new Game()
    })

    it('Gutter game scores 0', () => {
        rollMany(20, 0)

        expect(game.score()).toBe(0)
    })

    it('Test all ones', () => {
        rollMany(20, 1)

        expect(game.score()).toBe(20)
    })

    it('Test one spare', () => {
        rollSpare()
        game.roll(3)
        rollMany(17, 0)

        expect(game.score()).toBe(16)
    })

    it('Test one strike', () => {
        rollStrike()
        game.roll(3)
        game.roll(4)
        rollMany(16, 0)

        expect(game.score()).toBe(24)
    })

    it('Test perfect game', () => {
        rollMany(12, 10)

        expect(game.score()).toBe(300)
    })

    function rollMany(rolls: number, pins: number) {
        for (var i = 0; i < rolls; i++)
            game.roll(pins)
    }

    function rollSpare() {
        game.roll(5)
        game.roll(5)
    }

    function rollStrike() {
        game.roll(10)
    }
})
