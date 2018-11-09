import { Santa } from "./Santa";
import { Elf } from "./Elf";

describe('Santa should deliver presents to houses according to directions', () => {
    let santa: Santa

    const deliveryScenarios = [
        { directions: '>', numberOfHouses: 2 },
        { directions: '^>v<', numberOfHouses: 4 },
        { directions: '^v ^v ^v ^v ^v', numberOfHouses: 2 }
    ]

    beforeEach(() => {
        santa = new Santa()
    })

    deliveryScenarios.forEach(scenario => {
        it(`should deliver presents to ${scenario.numberOfHouses} for the directions ${scenario.directions}`, () => {
            santa.deliverPresents(scenario.directions.split(''))
            expect(santa.visitedHouses.length).toBe(scenario.numberOfHouses)
        })
    })

    it('should deliver presents to all houses in directions', () => {
        const directions = new Elf().readDirections()
        santa.deliverPresents(directions)
        expect(santa.visitedHouses.length).toBe(2592)
    })

    it('should work together with robo Santa', () => {
        const directions = new Elf().readDirections()
        const isEven = (d, i) => i % 2 === 0
        const isOdd = (d, i) => i % 2 !== 0
        const santasDirections = directions.filter(isEven)
        const roboSantasDirections = directions.filter(isOdd)
        const roboSanta = new Santa()

        santa.deliverPresents(santasDirections)
        roboSanta.deliverPresents(roboSantasDirections)

        const unionOfVisitedHouses = 
            santa.visitedHouses
                    .concat(roboSanta.visitedHouses)
                    .filter((house, index, self) => self.findIndex(
                        other => {return (other.x === house.x && other.y === house.y)}) === index
                    )

        expect(unionOfVisitedHouses.length).toBe(2360)
    })
})
