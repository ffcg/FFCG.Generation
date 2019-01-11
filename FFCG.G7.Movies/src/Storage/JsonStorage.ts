import { IStorage } from "../Core/IStorage";
import { Movie } from "../Core/Movie";
import { writeFileSync, exists, readFileSync } from 'fs'
import { Settings } from "../Settings";

export class JsonStorage implements IStorage<Movie> {
    private connectionString: string

    constructor(settings: Settings, initialMovies = []) {
        this.connectionString = settings.connectionString

        exists(this.connectionString, exists =>  {
            if (exists) {
                console.log('Database exists')
            } else {
                this.saveMoviesToDb(initialMovies)
                console.log('Database was created!')
            }
        })
    }

    load(id: string): Movie {
        return this.readMoviesFromDb().find(m => m.id === id)
    }

    store(movie: Movie) {
        const movies = this.readMoviesFromDb()
        movies.push(movie)
        this.saveMoviesToDb(movies)
    }

    delete(movie: Movie) {
        const movies = this.readMoviesFromDb().filter(m => m.id !== movie.id)
        this.saveMoviesToDb(movies)
    }

    all() {
        return this.readMoviesFromDb()
    }

    private readMoviesFromDb(): Array<Movie> {
        const moviesTextData = readFileSync(this.connectionString, { encoding: 'utf8' })
        return JSON.parse(moviesTextData)
    }

    private saveMoviesToDb(movies: Array<Movie>): void {
        writeFileSync(this.connectionString, JSON.stringify(movies))        
    }
}