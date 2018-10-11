import { Colors } from './color';
import { Vehicle } from './vehicle';

export class Painter {
    paint(vehicle: Vehicle, color: Colors) {
        vehicle.color = color
    }
}