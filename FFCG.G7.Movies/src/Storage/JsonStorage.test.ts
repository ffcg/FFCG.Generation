import { JsonStorage } from "./JsonStorage";
import { Settings } from "../Settings";
import { Movie } from "../Core/Movie";

describe('Json Storage', () => {
    let jsonStorage: JsonStorage

    beforeEach(() => {
        const settings = new Settings('settings.local.txt')
        const initialMovies = [new Movie('1', 'The Matrix'), new Movie('2', 'The Lion King')]
        jsonStorage = new JsonStorage(settings, initialMovies)
    }) 

    it('should read all movies from database', () => {
        expect(jsonStorage.all().length).toBe(2)
    })

    it('should load specific movie', () => {
        expect(jsonStorage.load('2').name).toBe('The Lion King')
    })
})