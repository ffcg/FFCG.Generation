import { ShoppingCartItem } from "../ShoppingCart/ShoppingCartItem";
import { IDiscount, IDiscountRule } from "./IDiscount";

export class DiscountRule implements IDiscountRule {
    forProductId: string
    percentage: number

    constructor(forProductId: string, percentage: number) {
        this.forProductId = forProductId
        this.percentage = percentage
    }

    shouldApply(items: Array<ShoppingCartItem>): boolean {
        return items.filter(i => i.product.id === this.forProductId).length > 0
    }

    apply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): IDiscount {
        return {
            amount: totalBeforeDiscount * this.percentage
        }
    }
}
