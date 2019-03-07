import { DiscountForTypeAndAmountRule } from "./DiscountForTypeAndAmountRule";
import { FoodProduct, Product } from "../Product/Product";
import { ShoppingCartItem } from "../ShoppingCart/ShoppingCartItem";

describe('Discount for type and amount rule', () => {
    let discountRule: DiscountForTypeAndAmountRule

    beforeEach(() => {
        discountRule = new DiscountForTypeAndAmountRule("food", 200, 20)
    })

    it('should apply discount if the type is matched and if the total amount is high enough', () => {
        const apple = new FoodProduct("apple", 39)
        const items = [new ShoppingCartItem(apple, 0.5)]
        const shouldApply = discountRule.shouldApply(items, 200)
        expect(shouldApply).toBe(true)
    })
})
