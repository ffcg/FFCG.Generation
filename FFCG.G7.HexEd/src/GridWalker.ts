export class GridWalker {
    private deltas = {
        'n': new Coordinate(0, 1, -1),
        'ne': new Coordinate(1, 0, -1),
        'se': new Coordinate(1, -1, 0),
        's': new Coordinate(0, -1, 1),
        'sw': new Coordinate(-1, 0, 1),
        'nw': new Coordinate(-1, 1, 0)
    }

    walk(path: string): Array<number> {
        return this.walkPath(path.split(',')).map(this.toDistance)    
    }

    private walkPath(directions: Array<string>): Array<Coordinate> {
        let location = new Coordinate(0, 0, 0)
        const visitedLocations = [location]

        directions.forEach(d => {
            const delta = this.deltas[d]
            location = new Coordinate(location.x + delta.x, location.y + delta.y, location.z + delta.z)
            visitedLocations.push(location)
        })
        
        return visitedLocations
    }

    private toDistance(coord: Coordinate)
    {
        return (Math.abs(coord.x) + Math.abs(coord.y) + Math.abs(coord.z)) / 2;
    }
}

export class Coordinate {
    x: number
    y: number
    z: number

    constructor(x: number, y: number, z: number) {
        this.x = x
        this.y = y
        this.z = z
    }
}
