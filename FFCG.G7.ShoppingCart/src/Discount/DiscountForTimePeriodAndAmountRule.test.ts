import { DiscountForTimePeriodAndAmountRule } from "./DiscountForTimePeriodAndAmountRule";

describe('Discount for time period', () => {
    it('should apply discount if within period', () => {
        const yesterday = new Date(new Date().setDate(new Date().getDate() - 1))
        const tomorrow = new Date(new Date().setDate(new Date().getDate() + 1))
        const discountRule = new DiscountForTimePeriodAndAmountRule(yesterday, tomorrow, 100, 1000)
        expect(discountRule.shouldApply([], 1500)).toBe(true)        
    })

    it('should apply discount amount', () => {
        const yesterday = new Date(new Date().setDate(new Date().getDate() - 1))
        const tomorrow = new Date(new Date().setDate(new Date().getDate() + 1))
        const discountRule = new DiscountForTimePeriodAndAmountRule(yesterday, tomorrow, 100, 1000)
        expect(discountRule.apply([], 1500).amount).toBe(100)             
    })

    it('should not apply discount if not within period', () => {
        const from = new Date(new Date().setDate(new Date().getDate() - 2))
        const to = new Date(new Date().setDate(new Date().getDate() - 1))
        const discountRule = new DiscountForTimePeriodAndAmountRule(from, to, 100, 1000)
        expect(discountRule.shouldApply([], 1500)).toBe(false)           
    })

    it('should not apply discount if the total amount is not high enough ', () => {
        const yesterday = new Date(new Date().setDate(new Date().getDate() - 1))
        const tomorrow = new Date(new Date().setDate(new Date().getDate() + 1))
        const discountRule = new DiscountForTimePeriodAndAmountRule(yesterday, tomorrow, 100, 1000)
        expect(discountRule.shouldApply([], 900)).toBe(false)           
    })
})