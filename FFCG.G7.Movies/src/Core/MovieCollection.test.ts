import { MovieCollection } from "./movieCollection";
import { IStorage } from "./IStorage";
import { Movie } from "./movie";

describe('Movie collection', () => {
    let movieCollection: MovieCollection

    beforeEach(() => {
        const fakeStorage = new FakeStorage()
        movieCollection = new MovieCollection(fakeStorage)
    })

    it('should be able to add movie', () => {
        const theLionKing = new Movie("1", "The Lion King")

        movieCollection.addMovie(theLionKing)

        expect(movieCollection.movies[0]).toEqual(theLionKing)
    })
})

class FakeStorage implements IStorage<Movie> {
    private _movies = []

    load(id: string) {
        return this._movies.find(m => m.id === id)
    }

    store(movie: Movie) {
        this._movies.push(movie)
    }

    delete(movie: Movie) {
        this._movies = this._movies.filter(m => m.id !== movie.id)
    }

    all() {
        return this._movies
    }
}