import { Claim } from "./Claim";
import { readFileSync } from 'fs'
import { OverlapCalculator } from "./OverlapCalculator";

describe('Part one', () => {
    it('should parse claim', () => {
        let claim = new Claim("#123 @ 1,3: 5x4")

        expect(claim.id).toBe(123)
        expect(claim.squareList.length).toBe(20)            
    })

    it('should read input file', () => {
        expect(readFileSync('input.txt').toString().split('\n').length).toBe(1295)
    })

    it('should find square inches of fabric within two or more claims in example', () => {
        let claims = ['#1 @ 1,3: 4x4',  '#2 @ 3,1: 4x4', '#3 @ 5,5: 2x2'].map(x=>new Claim(x))
        let overlaps = new OverlapCalculator().calculate(claims)

        expect(overlaps.length).toBe(4)
    })

    it('should find square inches of fabric within two or more claims', () => {
        let claims = readFileSync('input.txt').toString().split('\n').map(x => new Claim(x))
        let overlaps = new OverlapCalculator().calculate(claims)

        expect(overlaps.length).toBe(104126)
    })
})
