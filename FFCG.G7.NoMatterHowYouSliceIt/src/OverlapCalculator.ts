import { Claim } from "./Claim";

export class OverlapCalculator {
    
    calculate(claims: Array<Claim>){
        let positions = {}
 
        claims.forEach(c => {
            c.squareList.forEach(square => {
                if (!positions[square])
                    positions[square] = [c.id]
                else
                    positions[square].push(c.id)
            })
        });

        let overlappingClaims = Object.keys(positions).reduce(function (filtered, key) {
            if (positions[key].length > 1) filtered[key] = positions[key];
            return filtered;
        }, {});

        return Object.keys(overlappingClaims).map(key => { return { position: key, claims: overlappingClaims[key] }})
    }
}
