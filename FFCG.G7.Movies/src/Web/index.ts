import { Movie } from "../Core/Movie";

fetch('http://localhost:8081/movies')
    .then(response => response.json())
    .then(movies => {
        console.log(movies);
        return movies;
    })
    .then(movies => {
        const moviesContainer = document.getElementById('movies-container')
        const posterPath = (posterSubPath: string) => 'http://image.tmdb.org/t/p/w185' + posterSubPath
        const getMovieListItem = (movie: Movie) => '<li><img src="' + posterPath(movie.posterPath) + '"><p>' + movie.name + '</p></li>'
        moviesContainer.innerHTML = '<ul>' + movies.map(getMovieListItem).join('') + '</ul>'
    })