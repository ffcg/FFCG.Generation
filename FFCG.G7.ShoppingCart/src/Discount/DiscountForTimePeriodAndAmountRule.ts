import { IDiscountRule, IDiscount } from "./IDiscount";
import { ShoppingCartItem } from "../ShoppingCart/ShoppingCartItem";

export class DiscountForTimePeriodAndAmountRule implements IDiscountRule {
    startDate: Date
    endDate: Date
    discountAmount: number
    conditionAmount: number

    constructor(startDate: Date, endDate: Date, discountAmount: number, conditionAmount: number) {
        this.startDate = startDate
        this.endDate = endDate
        this.discountAmount = discountAmount
        this.conditionAmount = conditionAmount
    }

    shouldApply(items: Array<ShoppingCartItem> = [], totalBeforeDiscount: number): boolean {
        const today = new Date().getTime();
        const isWithinTimePeriod = today >= this.startDate.getTime() && today <= this.endDate.getTime();
        return isWithinTimePeriod && totalBeforeDiscount >= this.conditionAmount
    }    
    
    apply(items: Array<ShoppingCartItem>, totalBeforeDiscount: number): IDiscount {
        return {
            amount: this.discountAmount
        }
    }
}