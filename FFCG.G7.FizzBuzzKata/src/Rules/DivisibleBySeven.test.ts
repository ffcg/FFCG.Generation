import { DivisibleBySeven } from "./DivisibleBySeven";

describe('Divisible by seven rule', () => {
    let rule: DivisibleBySeven

    beforeEach(() => {
        rule = new DivisibleBySeven()
    })

    it('should match numbers divisible by seven', () => {
        expect(rule.matches(7)).toBe(true)
    })

    it('should not match numbers not divisible by seven', () => {
        expect(rule.matches(4)).toBe(false)        
    })

    it('should have "Foo" as word', () => {
        expect(rule.word).toBe("Foo")
    })
})