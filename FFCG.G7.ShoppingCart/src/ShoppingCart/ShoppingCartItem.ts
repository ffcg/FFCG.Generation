import { Product } from "../Product/Product";

export class ShoppingCartItem {
    amount: number
    product: Product
    price: number

    constructor(product: Product, amount: number) {
        this.product = product
        this.amount = amount
        this.price = this.product.price * this.amount
    }
}
