import { DiscountForItemsBoughtTogetherRule } from "./DiscountForItemsBoughtTogetherRule";
import { Product } from "../Product/Product";
import { ShoppingCartItem } from "../ShoppingCart/ShoppingCartItem";

describe('Discount for items bought together rule', () => {
    let discountRule: DiscountForItemsBoughtTogetherRule
    let cashmereSweater: Product
    let sunglasses: Product

    beforeEach(() => {
        cashmereSweater = new Product('Cashmere Sweater', 2199)
        sunglasses = new Product('Sunglasses', 1499)

        const itemsBoughtTogether = [
            cashmereSweater,
            sunglasses
        ]

        discountRule = new DiscountForItemsBoughtTogetherRule(itemsBoughtTogether, 0.1)
    })

    it('should apply if the correct items are in the shopping cart', () => {
        const shoppingCartItems = [
            new ShoppingCartItem(cashmereSweater, 1),
            new ShoppingCartItem(sunglasses, 1)
        ]

        expect(discountRule.shouldApply(shoppingCartItems, 2199+1499)).toBe(true)
    })

    it('should apply discount once', () => {
        const shoppingCartItems = [
            new ShoppingCartItem(cashmereSweater, 2),
            new ShoppingCartItem(sunglasses, 3)
        ]

        expect(discountRule.apply(shoppingCartItems, 2*2199+3*1499).amount).toBe(0.1 * (2199+1499))
    })
})