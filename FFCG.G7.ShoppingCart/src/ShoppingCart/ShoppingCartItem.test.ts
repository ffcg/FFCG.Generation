import { ShoppingCartItem } from "./ShoppingCartItem";
import { Product } from "../Product/Product";

describe('Shopping cart item', () => {
    let shoppingCartItem: ShoppingCartItem

    beforeEach(() => {
        let product = new Product('apple', 39)
        shoppingCartItem = new ShoppingCartItem(product, 0.521)
    })

    it('should have an amount', () => {
        expect(shoppingCartItem.amount).toBe(0.521)
    })

    it('should have a total price', () => {
        expect(shoppingCartItem.price).toBe(0.521*39)
    })
})
