import { IStorage } from "../Core/IStorage";
import { Movie } from "../Core/Movie";
import { IHttpClient } from "./HttpClient/IHttpClient";

export class ApiConsumer {
    private _httpClient: IHttpClient
    private _storage: IStorage<Movie>;

    constructor(httpClient: IHttpClient, storage: IStorage<Movie>) {        
        this._httpClient = httpClient;
        this._storage = storage
    }

    syncMovies(): Promise<any> {
        return this.getTopRatedMovies().then(movies => this.saveToDatabase(movies))
    }

    getTopRatedMovies(): Promise<Array<Movie>> {
        const urlToMoviesDb = ''

        return this._httpClient.get(urlToMoviesDb).then(response => {
            const externalMovies: Array<IExternalMovie> = JSON.parse(response).results;
            
            const movies = externalMovies.map(em => {
                const movie = new Movie(em.id.toString(), em.title, em.poster_path);
                movie.overview = em.overview
                movie.popularity = em.popularity
                return movie
            })
            return movies
        })
    }

    private saveToDatabase(movies: Array<Movie>) {
        movies.forEach(movie => {
            this._storage.store(movie)
        })
    }
}

interface IMoviesResponse {
    results: Array<IExternalMovie>
}

interface IExternalMovie {
    id: string
    title: string
    poster_path: string
    popularity: number
    overview: string
}
