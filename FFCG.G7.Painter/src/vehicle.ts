import { Colors } from './color';

export class Vehicle {
    registrationNumber: string
    color: Colors

    constructor(registrationNumber: string) {
        this.registrationNumber = registrationNumber
        this.color = Colors.grey
    }
}