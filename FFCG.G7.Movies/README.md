//CONSUMERAPI

const settings = new Settings('./settings.local.txt')
const storage = new JsonStorage(settings)

const externalMovies = getMoviesResponse()
const fakeHttpClient = new FakeHttpClient(externalMovies)
const apiConsumer = new ApiConsumer(fakeHttpClient, storage)
syncMovies()

async function syncMovies() {
    await apiConsumer.syncMovies()
}

//WEBAPI

import { Settings } from "../Settings";
import { JsonStorage } from "../Storage/JsonStorage";
import { MovieCollection } from "../Core/movieCollection";

const express = require('express');
const app = express();

const settings = new Settings('./settings.local.txt')
const storage = new JsonStorage(settings)
const movieCollection = new MovieCollection(storage)

app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*")
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept")
    next()
})

app.get('/movies', function (req, res) {
    const moviesResponse = JSON.stringify(movieCollection.movies)
    res.end(moviesResponse)
})

const server = app.listen(settings.apiPort, function () {
   const host = server.address().address
   const port = server.address().port
   console.log("Example app listening at http://%s:%s", host, port)
})

//WEB

import { Movie } from "../Core/Movie";

fetch('http://localhost:8081/movies')
    .then(response => response.json())
    .then(movies => {
        console.log('These are the movies', movies)
        return movies
    })
    .then(movies => {
        const moviesContainer = document.getElementById('movies-container')
        const getPosterPath = (posterSubPath: string) => 'http://image.tmdb.org/t/p/w185/' + posterSubPath
        const getMovieListItem = (movie: Movie) => '<li><img src="' + getPosterPath(movie.posterPath) + '"><p>' + movie.name + '</p></li>'
        moviesContainer.innerHTML = '<ul>' + movies.map(getMovieListItem).join('') + '</ul>'
    })
