
import { ShoppingCartItem } from "../ShoppingCart/ShoppingCartItem";

export interface IDiscountRule {
    shouldApply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): boolean
    apply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): IDiscount
}

export interface IDiscount {
    amount: number
}