export class Claim {
    id: number
    squareList: Array<string> = []

    constructor(claimString: string) {
        let inputParts = claimString.split(" ")
        this.id = parseInt(claimString.substring(1))

        let coordinates = inputParts[2].split(',')
        let leftMargin = parseInt(coordinates[0])
        let topMargin = parseInt(coordinates[1].substring(0, coordinates[1].length - 1))

        let dimensions = inputParts[3].split('x')
        let width = parseInt(dimensions[0])
        let height = parseInt(dimensions[1])

        for(var x = leftMargin; x < leftMargin + width; x++)
            for(var y = topMargin; y < topMargin + height; y++)
                this.squareList.push(x + ',' + y)      
    }
}
