import { Bus } from './bus'
import { Colors } from './color';

describe('Bus', () => {
    let bus: Bus
    
    beforeEach(() => {
        bus = new Bus('BATMAN123')
    })

    it('should have a registration number', () => {
        expect(bus.registrationNumber).toBe('BATMAN123')
    })

    it('should have grey as default color', () => {
        expect(bus.color).toBe(Colors.grey)
    })
})