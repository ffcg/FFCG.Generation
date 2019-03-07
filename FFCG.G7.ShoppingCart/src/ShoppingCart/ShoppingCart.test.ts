import { ShoppingCart } from "./ShoppingCart";
import { Product, FoodProduct } from "../Product/Product";
import { ShoppingCartItem } from "./ShoppingCartItem";
import { DiscountRule } from "../Discount/DiscountRule";
import { DiscountForTimePeriodAndAmountRule } from "../Discount/DiscountForTimePeriodAndAmountRule";
import { DiscountForTypeAndAmountRule } from "../Discount/DiscountForTypeAndAmountRule";
import { DiscountForItemsBoughtTogetherRule } from "../Discount/DiscountForItemsBoughtTogetherRule";
import { DiscountForTotalAmount } from "../Discount/DiscountForTotalAmount";

describe('Shopping cart', () => {
    let shoppingCart: ShoppingCart
    let productWithDiscount: Product
    let cashmereSweater: Product
    let sunglasses: Product

    beforeEach(() => {
        productWithDiscount = new Product('some product', 100)

        const yesterday = new Date(new Date().setDate(new Date().getDate() - 1))
        const tomorrow = new Date(new Date().setDate(new Date().getDate() + 1))

        cashmereSweater = new Product('Cashmere Sweater', 2199)
        sunglasses = new Product('Sunglasses', 1499)

        const itemsBoughtTogether = [
            cashmereSweater,
            sunglasses
        ]

        const discountRules = [
            new DiscountRule(productWithDiscount.id, 0.15),
            new DiscountForTimePeriodAndAmountRule(yesterday, tomorrow, 100, 1000),
            new DiscountForTypeAndAmountRule('food', 200, 20),
            new DiscountForItemsBoughtTogetherRule(itemsBoughtTogether, 0.1),
            new DiscountForTotalAmount(3000, 0.02)
        ]

        shoppingCart = new ShoppingCart(discountRules)
    })

    it('should round price to nearest two decimals', () => {
        const product = new Product('apple', 39)
        const shoppingCartItem = new ShoppingCartItem(product, 0.432)
        shoppingCart.addItem(shoppingCartItem)
        expect(shoppingCart.calculateTotalPrice().totalBeforeDiscounts).toBe(16.85)
    })

    it('should apply discount', () => {
        const productWithDiscountItem = new ShoppingCartItem(productWithDiscount, 1)
        shoppingCart.addItem(productWithDiscountItem)
        expect(shoppingCart.calculateTotalPrice().totalAfterDiscounts).toBe(85)
    })

    it('should calculate total price for shopping cart 1', () => {
        const apple = new FoodProduct('Apple', 39)
        const perfume = new Product('Perfume', 649)
        const chocolate = new FoodProduct('Chocolate', 22)

        const shoppingCartItems = [
            new ShoppingCartItem(apple, 4.09),
            new ShoppingCartItem(perfume, 1),
            new ShoppingCartItem(chocolate, 9)
        ]

        shoppingCartItems.forEach(i => shoppingCart.addItem(i))

        expect(shoppingCart.calculateTotalPrice().total).toBe(1006.51-100-20+49)
    })

    it('should calculate total price for shopping cart 2', () => {
        const kitten = new Product('Kitten', 299)

        const shoppingCartItems = [
            new ShoppingCartItem(cashmereSweater, 1),
            new ShoppingCartItem(sunglasses, 2),
            new ShoppingCartItem(kitten, 3)
        ]

        shoppingCartItems.forEach(i => shoppingCart.addItem(i))

        expect(shoppingCart.calculateTotalPrice().total).toBe(6094-100+0-(0.1 * (2199 + 1499))-(0.02*6094))
    })

    it('should calculate total price for shopping cart 3', () => {
        
    })
})
