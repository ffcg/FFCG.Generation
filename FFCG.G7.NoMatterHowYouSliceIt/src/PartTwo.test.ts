import { Claim } from "./Claim";
import { OverlapCalculator } from "./OverlapCalculator";
import { readFileSync } from "fs";

describe('Part two', () => {
    it('should find only claim with no overlap in example', () => {
        let claims = ['#1 @ 1,3: 4x4',  '#2 @ 3,1: 4x4', '#3 @ 5,5: 2x2'].map(x=>new Claim(x))

        let overlappingFabricIds = [].concat(...new OverlapCalculator().calculate(claims).map(x => x.claims));

        let claimWithNoOverlap = claims.find(claim => !overlappingFabricIds.includes(claim.id))
        
        expect(claimWithNoOverlap.id).toBe(3)
    })

    it('should find claims with no overlap', () => {
        let claims = readFileSync('input.txt').toString().split('\n').map(x => new Claim(x))

        let overlappingFabricIds = [].concat(...new OverlapCalculator().calculate(claims).map(x => x.claims));

        let claimWithNoOverlap = claims.find(claim => !overlappingFabricIds.includes(claim.id))
        
        expect(claimWithNoOverlap.id).toBe(695)
    })
})
