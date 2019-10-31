import { SwitchWordRule, ISwitchWordConfig } from "./SwitchWordRule"

describe('Switch word rule', () => {
    it('should switch word', () => {
        const rule = new SwitchWordRule([{ old: 'företaget', new: 'Forefront'}])
        expect(rule.manipulate('företaget')).toBe('Forefront')
    })

    it('should switch word if previous word starts with "s"', ()=> {
        const config: ISwitchWordConfig = { old: 'av', new: 'från', previousWordStart: 's'}

        const rule = new SwitchWordRule([config])
        const array = ['super', 'av']
        expect(rule.manipulate('av', 1, array)).toBe('från')
    })

    it('should switch word if previous word starts with "code is"', () => {
        const config: ISwitchWordConfig = {
            old: 'king',
            new: 'Queen',
            previousWords: ['code', 'is']
        }
        const rule = new SwitchWordRule([config])
        const array = ['Code', 'is', 'King']
        expect(rule.manipulate('king', 2, array)).toBe('Queen')  
    })
})