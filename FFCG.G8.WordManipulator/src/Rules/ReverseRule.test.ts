import { ReverseRule } from "./ReverseRule"

describe('Reverse rule', () => {
    let rule: ReverseRule

    beforeEach(() => {
        rule = new ReverseRule(['siht'])
    })

    it('should reverse word', () => {
        expect(rule.manipulate('siht')).toBe('this')
    })
})