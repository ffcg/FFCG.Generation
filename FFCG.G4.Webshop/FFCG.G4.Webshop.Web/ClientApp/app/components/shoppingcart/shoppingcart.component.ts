import { Component } from '@angular/core';
import { IProduct } from '../shared/product'
import { ShoppingcartService } from '../shoppingcart/shoppingcart.service'

@Component({
    selector: 'cart',
    template: require('./shoppingcart.component.html'),
    styles: [require('./shoppingcart.component.css')]
})
export class ShoppingcartComponent {
    public products: IProduct[]

    constructor(private shoppingcartService: ShoppingcartService){
        this.products = shoppingcartService.getProducts()
    }

    removeFromCart(product: IProduct) {
        this.shoppingcartService.removeFromCart(product)
    }

    sum() {
        return this.products.map(x => x.price).reduce((a,b) => a + b)
    }
}
