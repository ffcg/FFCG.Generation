import { GameOfLife } from "./GameOfLife";

describe('Game of Life', () => {
    let gameOfLife: GameOfLife

    beforeEach(() => {
        gameOfLife = new GameOfLife(4, 8)
    })

    it('should be able to specify cells starting out alive', () => {
        gameOfLife.setLivingCell(1, 2)
        expect(gameOfLife.cells[1][2].isAlive).toBe(true)
    })

    it('should count living neighbors', () => {
        gameOfLife.setLivingCell(2, 3);
        gameOfLife.setLivingCell(2, 4);
        gameOfLife.setLivingCell(1, 2);
        gameOfLife.setLivingCell(1, 3);

        expect(gameOfLife.countLivingNeighbors(2, 3)).toBe(3)       
    })

    it('should count living neighbors for corner cells', () => {
        gameOfLife.setLivingCell(0, 0);
        gameOfLife.setLivingCell(0, 1);
        gameOfLife.setLivingCell(1, 1);

        expect(gameOfLife.countLivingNeighbors(0, 0)).toBe(2)      
    })

    it('should generate next generation', () => {
        gameOfLife.setLivingCell(1, 4);
        gameOfLife.setLivingCell(2, 3);
        gameOfLife.setLivingCell(2, 4);

        gameOfLife.computeNextGeneration();
        
        expect(gameOfLife.cells[1][3].isAlive).toBe(true)
        expect(gameOfLife.cells[1][4].isAlive).toBe(true)
        expect(gameOfLife.cells[2][3].isAlive).toBe(true)
        expect(gameOfLife.cells[2][4].isAlive).toBe(true)
    })
})