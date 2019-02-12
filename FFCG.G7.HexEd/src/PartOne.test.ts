import { GridWalker } from "./GridWalker";
import { readFileSync } from "fs";

describe('Part One', () => {
    let gridWalker: GridWalker

    beforeEach(() => {
        gridWalker = new GridWalker()
    })

    it('should find shortest distance in examples', () => {
        const examples = [
            { path: 'ne,ne,ne', expectedDistance: 3 },
            { path: 'ne,ne,sw,sw', expectedDistance: 0 },
            { path: 'ne,ne,s,s', expectedDistance: 2 },
            { path: 'se,sw,se,sw,sw', expectedDistance: 3 }
        ]

        examples.forEach(example => {
            expect(gridWalker.walk(example.path).slice(-1)[0]).toBe(example.expectedDistance)
        })
    })

    it('should find shortest distance', () => {
        const path = readFileSync('input.txt').toString()
        expect(gridWalker.walk(path).slice(-1)[0]).toBe(707)
    })
})
