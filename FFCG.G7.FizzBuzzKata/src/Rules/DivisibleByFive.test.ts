import { DivisibleByFive } from "./DivisibleByFive";

describe('Divisible by five rule', () => {
    let rule: DivisibleByFive

    beforeEach(() => {
        rule = new DivisibleByFive()
    })

    it('should match numbers divisible by five', () => {
        expect(rule.matches(5)).toBe(true)
    })

    it('should not match numbers not divisible by five', () => {
        expect(rule.matches(4)).toBe(false)        
    })

    it('should have "Buzz" as word', () => {
        expect(rule.word).toBe("Buzz")
    })
})