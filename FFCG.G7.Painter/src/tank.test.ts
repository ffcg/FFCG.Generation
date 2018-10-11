import { Tank } from './tank'
import { Colors } from './color';

describe('Tank', () => {
    let tank: Tank
    
    beforeEach(() => {
        tank = new Tank('BATMAN123')
    })

    it('should have registration number', () => {
        expect(tank.registrationNumber).toBe('BATMAN123')
    })

    it('should have grey as default color', () => {
        expect(tank.color).toBe(Colors.grey)
    })
})