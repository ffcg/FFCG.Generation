import { IStorage } from "./IStorage";
import { Movie } from "./Movie";

export class MovieCollection {
    private _storage: IStorage<Movie>;

    constructor(storage: IStorage<Movie>) {
        this._storage = storage
    }

    addMovie(movie: Movie) {
        this._storage.store(movie)
    }

    public get movies(): Array<Movie> {
        return this._storage.all();
    }
}
