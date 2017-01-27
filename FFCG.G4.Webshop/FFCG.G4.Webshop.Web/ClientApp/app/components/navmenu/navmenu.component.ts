import { Component } from '@angular/core';
import { ShoppingcartService } from '../shoppingcart/shoppingcart.service'

@Component({
    selector: 'nav-menu',
    template: require('./navmenu.component.html'),
    styles: [require('./navmenu.component.css')]
})
export class NavMenuComponent {
    public numberOfProductsAdded: number

    constructor(shoppingcartService: ShoppingcartService){
        shoppingcartService.cartChanged$.subscribe(
            numberOfProducts =>  {
                this.numberOfProductsAdded = numberOfProducts
            }
        )
    }
}
