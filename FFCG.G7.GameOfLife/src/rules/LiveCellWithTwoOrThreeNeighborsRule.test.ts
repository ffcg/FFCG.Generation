import { LiveCellWithTwoOrThreeNeighborsRule } from "./LiveCellWithTwoOrThreeNeighborsRule";

describe('LiveCellWithTwoOrThreeNeighborsRule', () => {
    let rule: LiveCellWithTwoOrThreeNeighborsRule
    
    beforeEach(() => {
        rule = new LiveCellWithTwoOrThreeNeighborsRule()
    })

    it('should live if there are two or three neighbors', () => {
        expect(rule.shouldLive(2)).toBe(true)
        expect(rule.shouldLive(3)).toBe(true)
    })

    it('should not live if the amount of neighbours is not two or three', () => {
        expect(rule.shouldLive(1)).toBe(false)
        expect(rule.shouldLive(4)).toBe(false)
    })
})