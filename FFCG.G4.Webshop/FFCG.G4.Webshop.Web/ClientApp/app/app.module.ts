import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ProductsComponent } from './components/products/products.component'
import { ShoppingcartService } from './components/shoppingcart/shoppingcart.service'
import { ShoppingcartComponent } from './components/shoppingcart/shoppingcart.component'

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ProductsComponent,
        ShoppingcartComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'products', component: ProductsComponent },
            { path: 'cart', component: ShoppingcartComponent },
            { path: '**', redirectTo: 'home' },
        ])
    ],
    providers: [ShoppingcartService]
})
export class AppModule {
}
