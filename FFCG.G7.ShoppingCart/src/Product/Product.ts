import { timingSafeEqual } from "crypto";

export interface IProduct {
    id: string
    name: string
    price: number
}

export class Product implements IProduct {
    id: string
    name: string
    price: number
    type: string

    constructor(name: string, price: number, type = 'generic') {
        this.generateId()
        this.name = name
        this.price = price
        this.type = type
    }

    private generateId(): void {
        this.id = this.uuidv4()
    }

    private uuidv4(): string {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
          var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
          return v.toString(16);
        });
      }
}

export class FoodProduct extends Product {
    constructor(name: string, price: number, type = 'food') {
        super(name, price, type)
    }
}
