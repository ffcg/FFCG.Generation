import { CapitalizeRule } from "./capitalizeRule";

describe('Capitalize Rule', () => {
    let rule: CapitalizeRule
    
    beforeEach(() => {
        const words = ['företaget']
        rule = new CapitalizeRule(words)
    })

    it('should capitalize first letter', () => {
        expect(rule.manipulate('företaget')).toBe('Företaget')
    })

    it('should handle specified word', () => {
        expect(rule.canHandle('Företaget')).toBe(true)
    })

    it('should not handle unspecified word', () => {
        expect(rule.canHandle('kalleanka')).toBe(false)      
    })
})
