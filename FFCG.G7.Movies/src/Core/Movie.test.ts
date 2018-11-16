import { Movie } from "./Movie";

describe('Movie', () => {
    let movie: Movie

    beforeEach(() => {
        movie = new Movie("1", "Harry Potter and The Goblet of Fire")
    })

    it('should be created with id', () => {
        expect(movie.id).toBe("1")
    })

    it('should be created with name', () => {
        expect(movie.name).toBe("Harry Potter and The Goblet of Fire")
    })
})