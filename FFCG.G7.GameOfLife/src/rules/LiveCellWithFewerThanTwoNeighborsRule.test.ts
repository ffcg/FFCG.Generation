import { LiveCellWithFewerThanTwoNeighborsRule } from "./LiveCellWithFewerThanTwoNeighborsRule";

describe('LiveCellWithFewerThanTwoNeighborsRule', () => {
    let rule: LiveCellWithFewerThanTwoNeighborsRule

    beforeEach(() => {
        rule = new LiveCellWithFewerThanTwoNeighborsRule()
    })

    it('should live if there are three neighbors', () => {
        expect(rule.shouldLive(2)).toBe(true)
        expect(rule.shouldLive(3)).toBe(true)
    })

    it('should not live if the amount of neighbours is not three', () => {
        expect(rule.shouldLive(1)).toBe(false)
    })
})