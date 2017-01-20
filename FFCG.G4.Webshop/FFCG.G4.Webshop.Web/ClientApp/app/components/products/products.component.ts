import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'products',
    template: require('./products.component.html'),
    styles: [require('./products.component.css')]
})
export class ProductsComponent {
    public products: IProducts[]

    constructor(http: Http){
        http.get('/api/products').subscribe(result => {
            this.products = result.json();
        });       
    }
}

interface IProducts {
    name: string;
    id: string;
    category: string;
    description: string;
    price: number;
    image: string;
}
