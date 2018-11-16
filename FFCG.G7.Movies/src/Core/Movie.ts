export class Movie {
    id: string;
    name: string;
    overview: string;
    popularity: any;
    posterPath: string;

    constructor(id: string, name: string) {
        this.id = id;
        this.name = name;
    }
}