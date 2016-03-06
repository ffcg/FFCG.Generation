module clientApp.ui {
    export class moviesController {
        private moviesService;
        constructor(moviesService) {
            this.moviesService = moviesService;
        }

        initialize() {
            var self = this;
            const moviesButton = document.getElementById('getMoviesButton');
            if (moviesButton) {
                moviesButton.addEventListener('click', event => {
                    self.moviesService
                        .getMovies()
                        .then(self.onReceivedMovies);
                }, false);
            }
        }

        private onReceivedMovies(data) {
            const moviesContainer: any = document.getElementById('moviesContainer');
            if (moviesContainer) {
                let moviesTemplate =
                    '<ul class="movies-list">' +
                        JSON.parse(data)
                        .sort(compareByName)
                        .map(toClientMovie)
                        .map(toMovieTemplate)
                        .join('') +
                    '</ul>';

                moviesContainer.movies = JSON.parse(data);
                moviesContainer.innerHTML = moviesTemplate;
            }

            function compareByName(a, b) {
                return +(a.name > b.name) || +(a.name === b.name) - 1;
            }

            function toClientMovie(m) {
                var genre = m.genre != null ? m.genre : 'Action/Adventure';
                var runtime = m.runTime != null ? m.runtime : '98 minutes';
                var logoUrl = m.logoUrl != null ? m.logoUrl :
                    "http://ia.media-imdb.com/images/M/MV5BMTg1NDE1NjE0Nl5BMl5BanBnXkFtZTgwMTAzNjM2MzE@._V1_.jpg";

                return ({ title: m.name, logoUrl: logoUrl, genre: genre, runtime: runtime });
            }

            function toMovieTemplate(m) {
                return '<li><img src="' + m.logoUrl + '" class="logo"/>' +
                        '<div>' +
                        '<h2>' + m.title + '</h2>' +
                        '<div><span style="font-weight: bold;"> Genre: </span><span>' + m.genre + '</span></div>' +
                        '<div><span style="font-weight: bold;"> Runtime: </span><span>' + m.runtime+ '</span></div>' +
                        '</div>' +
                       '</li>';
            }
        }
    }
}