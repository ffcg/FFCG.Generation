import { DeadCellWithThreeNeighbors } from "./DeadCellWithThreeNeighbors";

describe('DeadCellWithThreeNeighbors', () => {
    let rule: DeadCellWithThreeNeighbors

    beforeEach(() => {
        rule = new DeadCellWithThreeNeighbors()
    })

    it('should live if there are three neighbors', () => {
        expect(rule.shouldLive(3)).toBe(true)
    })

    it('should not live if the amount of neighbours is not three', () => {
        expect(rule.shouldLive(2)).toBe(false)
    })
})