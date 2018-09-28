import { DivisibleByThree } from './DivisibleByThree'

describe('Divisible by three rule', () => {
    let rule: DivisibleByThree;

    beforeEach(() => {
        rule = new DivisibleByThree()
    })

    it('should match numbers divisible by three', () => {
        const numbers = [3, 6, 9 ,12]

        numbers.forEach(number => expect(rule.matches(number)).toBe(true))
    })

    it('should not match numbers not divisible by three', () => {
        expect(rule.matches(2)).toBe(false)
    })

    it('should have "Fizz" as word', () => {
        expect(rule.word).toBe("Fizz")
    })
})