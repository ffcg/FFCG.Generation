import { Car } from './car'
import { Colors } from './color';
import { CarType } from './carType';

describe('Car', () => {
    let car: Car

    beforeEach(() => {
        car = new Car('BATMAN123')
    }) 

    it('should be created with registration number', () => {
        expect(car.registrationNumber).toBe('BATMAN123')
    })

    it('should have grey as default color', () => {
        expect(car.color).toBe(Colors.grey);
    })

    it('should have Batmobile as default type', () => {
        expect(car.type).toBe(CarType.Batmobile);
    })

    it('should be createable with any type', () => {
        const newCar = new Car('BATMAN123', CarType.Saaaaaab)
        expect(newCar.type).toBe(CarType.Saaaaaab)
    })
})