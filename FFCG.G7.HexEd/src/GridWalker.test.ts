import { GridWalker } from "./GridWalker";

describe('Grid walker', () => {
    let gridWalker: GridWalker

    beforeEach(() => {
        gridWalker = new GridWalker()
    })

    it('should walk expected distance in examples', () => {
        const examples = [
            { path: 'ne, ne, ne', expectedDistance: 3},
            { path: 'ne,ne,sw,sw', expectedDistance: 0},
            { path: 'ne,ne,s,s', expectedDistance: 2},
            { path: 'se,sw,se,sw,sw', expectedDistance: 3}
        ]

        examples.forEach(example => {
            expect(gridWalker.walkPath(example.path).slice(-1)[0]).toBe(example.expectedDistance)
        })
    })
})
