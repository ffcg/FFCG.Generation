import { IDiscountRule, IDiscount } from "./IDiscount";
import { ShoppingCartItem } from "../ShoppingCart/ShoppingCartItem";
import { Product } from "../Product/Product";

export class DiscountForTypeAndAmountRule implements IDiscountRule {
    productType: string
    conditionAmount: number
    discountAmount: number

    constructor(productType: string, conditionAmount: number, discountAmount: number) {
        this.productType = productType
        this.conditionAmount = conditionAmount
        this.discountAmount = discountAmount
    }

    shouldApply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): boolean {
        return totalBeforeDiscount >= this.conditionAmount && 
                items.filter(x => x.product.type === this.productType).length > 0
    }    
    
    apply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): IDiscount {
        return {
            amount: this.discountAmount
        }
    }
}