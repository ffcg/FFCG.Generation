import { IDiscountRule, IDiscount } from "./IDiscount";
import { ShoppingCartItem } from "../ShoppingCart/ShoppingCartItem";

export class DiscountForTotalAmount implements IDiscountRule {
    amountCondition: number
    discountPercentage: number

    constructor(amountCondition: number, discountPercentage: number) {
        this.amountCondition = amountCondition
        this.discountPercentage = discountPercentage
    }

    shouldApply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): boolean {
        return totalBeforeDiscount >= this.amountCondition
    }    
    
    apply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): IDiscount {
        return {
            amount: this.discountPercentage * totalBeforeDiscount
        }
    }
}
