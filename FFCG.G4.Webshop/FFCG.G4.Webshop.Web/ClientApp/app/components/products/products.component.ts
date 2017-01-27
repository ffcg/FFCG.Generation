import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { IProduct } from '../shared/product'
import { ShoppingcartService } from '../shoppingcart/shoppingcart.service'

@Component({
    selector: 'products',
    template: require('./products.component.html'),
    styles: [require('./products.component.css')]
})
export class ProductsComponent {
    public products: IProduct[]

    constructor(http: Http, private shoppingcartService: ShoppingcartService){
        http.get('/api/products').subscribe(result => {
            this.products = result.json();
        });     
    }

    addToCart(product: IProduct) {
        this.shoppingcartService.addToCart(product)
    }
}
