import { LiveCellWithMoreThanThreeNeighborsRule } from "./LiveCellWithMoreThanThreeNeighborsRule";

describe('LiveCellWithMoreThanThreeNeighborsRule', () => {
    let rule: LiveCellWithMoreThanThreeNeighborsRule

    beforeEach(() => {
        rule = new LiveCellWithMoreThanThreeNeighborsRule()
    })

    it('should live if there are three or fewer neighbors', () => {
        expect(rule.shouldLive(2)).toBe(true)
        expect(rule.shouldLive(3)).toBe(true)
    })

    it('should not live if the amount of neighbours is above three', () => {
        expect(rule.shouldLive(4)).toBe(false)
    })
})