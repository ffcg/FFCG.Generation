import { ShoppingCartItem } from "./ShoppingCartItem";
import { IDiscount, IDiscountRule } from "../Discount/IDiscount";

export class ShoppingCart {
    items: Array<ShoppingCartItem> = []
    discountRules: Array<IDiscountRule>

    constructor(discountRules: Array<IDiscountRule> = []) {
        this.discountRules = discountRules
    }

    addItem(item: ShoppingCartItem) {
        this.items.push(item)
    }

    removeItem(item: ShoppingCartItem) {
        this.items = this.items.filter(i => i.product.id !== item.product.id)
    }

    calculateTotalPrice(): ShoppingCartTotal {
        let total = 0

        this.items.forEach(i => total += i.price)

        total = Math.round(total * 100) / 100

        let totalAfterDiscounts = total
        
        const discounts = this.discountRules
                                .filter(r => r.shouldApply(this.items, total))
                                .map(r => r.apply(this.items, total))
        discounts.forEach(d => totalAfterDiscounts -= d.amount)

        const totalWithShipping = totalAfterDiscounts + this.calculateShippingCost(total)

        return {
            total: totalWithShipping,
            totalBeforeDiscounts: total,
            totalAfterDiscounts: totalAfterDiscounts,
            discounts: [],
            shipping: 0
        }
    }

    calculateShippingCost(totalPrice: number): number {
        return totalPrice >= 1500 ? 0 : 49
    }
}

export interface ShoppingCartTotal {
    total: number
    totalBeforeDiscounts: number,
    totalAfterDiscounts: number,
    discounts: Array<IDiscount>
    shipping: number
}
