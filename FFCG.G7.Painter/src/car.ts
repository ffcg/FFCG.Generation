import { CarType } from './carType'
import { Vehicle } from './vehicle'

export class Car extends Vehicle {
    type: CarType

    constructor(registrationNumber: string, carType: CarType = CarType.Batmobile) {
        super(registrationNumber)
        this.type = carType;
    }
}