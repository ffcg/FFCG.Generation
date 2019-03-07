import { Product } from './Product'

describe('Product', () => {
    let someProduct: Product

    beforeEach(() =>{
        someProduct = new Product('Calculator', 1200)
    })

    it('should have id', () => {
        expect(someProduct.id.length).toBeGreaterThan(0)
    })

    it('should have name', () => {
        expect(someProduct.name).toBe('Calculator')
    })

    it('should have a price', () => {
        expect(someProduct.price).toBe(1200)
    })
})
