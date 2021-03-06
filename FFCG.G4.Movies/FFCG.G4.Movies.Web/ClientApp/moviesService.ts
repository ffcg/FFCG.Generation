﻿module clientApp.services {

    export class MoviesService {
        private httpService;
        private baseUrl;

        constructor(httpService) {
            this.httpService = httpService;
            this.baseUrl = 'http://localhost/Movies.App/api/movies';
        }

        getMovies() {
            return this.httpService.get(this.baseUrl);
        }

        getMovie(id) {
            return this.httpService.get(this.baseUrl + id);
        }

        createMovie(movie) {
            return this.httpService.post(this.baseUrl, movie);
        }
    }
}