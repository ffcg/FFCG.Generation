import { SwitchPositionRule } from './SwitchPositionRule'

describe('Switch position rule', () => {
    it('should switch position of first and second half of word', () => {
        const rule = new SwitchPositionRule(['ortgj'])
        expect(rule.manipulate('ortgj')).toBe('gjort')
    })
})