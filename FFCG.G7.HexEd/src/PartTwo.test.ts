import { GridWalker } from "./GridWalker";
import { readFileSync } from "fs";

describe('Part Two', () => {
    it('should find the distance furthest away from the starting position', () => {
        const gridWalker = new GridWalker()
        const path = readFileSync('input.txt').toString()
        expect(Math.max(...gridWalker.walk(path))).toBe(1490)
    })
})
