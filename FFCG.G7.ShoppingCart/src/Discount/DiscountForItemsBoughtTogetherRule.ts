import { IDiscountRule, IDiscount } from "./IDiscount";
import { ShoppingCartItem } from "../ShoppingCart/ShoppingCartItem";
import { Product } from "../Product/Product";

export class DiscountForItemsBoughtTogetherRule implements IDiscountRule {
    itemsBoughtTogether: Array<Product>
    discountAmountPercentage: number
    
    constructor(itemsBoughtTogether: Array<Product>, discountAmountPercentage: number) {
        this.itemsBoughtTogether = itemsBoughtTogether
        this.discountAmountPercentage = discountAmountPercentage
    }

    shouldApply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): boolean {
        return this.itemsBoughtTogether
                    .map(i => items.map(item => item.product.id).includes(i.id))
                    .every(x => x === true)
    }    
    
    apply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): IDiscount {
        return {
            amount: this.discountAmountPercentage * this.itemsBoughtTogether.map(i => i.price).reduce((acc, val) => acc + val)
        }
    }
}