import { Painter } from './painter';
import { Car } from './car';
import { Colors } from './color';
import { Bus } from './bus';
import { Tank } from './tank'

describe('Painter', () => {
    let painter: Painter

    beforeEach(() => {
        painter = new Painter()
    })

    it('should be able to paint a car', () => {
        const car = new Car('BATMAN123')
        painter.paint(car, Colors.green)
        expect(car.color).toBe(Colors.green)
    })

    it('should be able to paint a bus', () => {
        const bus = new Bus('BATMAN123')
        painter.paint(bus, Colors.yellow)
        expect(bus.color).toBe(Colors.yellow)
    })

    it('should be able to paint a tank', () => {
        const tank = new Tank('BATMAN123')
        painter.paint(tank, Colors.red)
        expect(tank.color).toBe(Colors.red)
    })
})