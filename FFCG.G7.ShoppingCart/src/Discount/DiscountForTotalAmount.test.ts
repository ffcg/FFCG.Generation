import { DiscountForTotalAmount } from "./DiscountForTotalAmount";

describe('Discount for total amount rule', () => {
    let discountRule: DiscountForTotalAmount

    beforeEach(() => {
        discountRule = new DiscountForTotalAmount(3000, 0.02)
    })

    it('should apply if total amount is large enough', () => {
        expect(discountRule.shouldApply([], 3000)).toBe(true)
    })

    it('should apply discount', () => {
        expect(discountRule.apply([], 3000).amount).toBe(60)
    })
})