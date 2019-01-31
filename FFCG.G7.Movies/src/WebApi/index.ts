import { Settings } from "../Settings";
import { JsonStorage } from "../Storage/JsonStorage";
import { MovieCollection } from "../Core/movieCollection";

const express = require('express');
const app = express();

const settings = new Settings('./settings.local.txt')
const storage = new JsonStorage(settings)
const moviesCollection = new MovieCollection(storage)

app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*")
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept")
    next()
})

app.get('/movies', function(req, res) {
    const moviesResponse = JSON.stringify(moviesCollection.movies)
    res.end(moviesResponse)
})

const server = app.listen(settings.apiPort, function () {
    const host = server.address().address
    const port = server.address().port
    console.log("Example app listening at http://%s:%s", host, port)
 })
 