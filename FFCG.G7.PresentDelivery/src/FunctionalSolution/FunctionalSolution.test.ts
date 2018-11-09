import { Elf } from "../Elf";

describe('Functional solution', () => {
    it('should solve part one', () => {
        expect(new Elf().readDirections().visitHouses().removeDuplicates().length).toBe(2592)
    })

    it('should solve part two', () => {
        const directions = new Elf().readDirections()
        const santasHouses = directions.filter((d, i) => i % 2 == 0).visitHouses()
        const roboSantasHouses = directions.filter((d, i) => i % 2 != 0).visitHouses()

        expect(santasHouses.concat(roboSantasHouses).removeDuplicates().length).toBe(2360)     
    })
})

Array.prototype.visitHouses = function() {
    const getNext = (direction, {x, y}) => {
        switch (direction)
        {
            case ('>'): return { x: x + 1, y: y};
            case ('<'): return { x: x - 1, y: y};
            case ('^'): return { x: x, y: y + 1};
            case ('v'): return { x: x, y: y - 1};
        }
    }

    return ([[{x:0, y:0}]] as any[])
    .concat(this)
    .reduce((acc, cur, i) => acc.concat([getNext(cur, acc[i-1])]))
}

Array.prototype.removeDuplicates = function() {
    return this.filter((l, i, self) => self.findIndex(t => t.x === l.x && t.y === l.y) === i)
}

declare global {
    interface Array<T> {
        visitHouses: () => any
        removeDuplicates: () => any
    }
}
