import { Elf } from "./Elf";

describe('Elf', () => {
    it('should read directions', () => {
        const elf = new Elf()
        expect(elf.readDirections().length).toBe(8192)
    })
})