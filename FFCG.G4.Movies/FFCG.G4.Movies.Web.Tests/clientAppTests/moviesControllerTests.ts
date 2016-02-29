/// <reference path="../../ffcg.g4.movies.web/clientapp/moviescontroller.ts" />

describe('Movies controller', () => {
    var moviesController,
        getMoviesButton,
        moviesContainer;

    beforeEach(() => {
        setUpFakeViewComponents();

        var moviesService = {
            getMovies() {
                return {
                    then(callback) {
                        var movies = [{ id: 1, name: 'Star Wars' }, { id: 2, name: 'The Matrix' }];
                        callback(JSON.stringify(movies));
                    }
                }
            }
        }
        moviesController = new clientApp.ui.moviesController(moviesService);
        moviesController.initialize();
    });

    describe('When clicking the get movies button', () => {
        beforeEach(() => {
            getMoviesButton.click();
        });

        it('should display movies', () => {
            expect(moviesContainer.innerHTML)
                .toBe('<ul><li id="movie-1">Star Wars</li><li id="movie-2">The Matrix</li></ul>');
        });
    });

    function setUpFakeViewComponents() {
        getMoviesButton = document.createElement('button');
        moviesContainer = document.createElement('container');

        document.getElementById = jasmine.createSpy('HTML Element').and.callFake(id => {
            if (id === 'getMoviesButton')
                return getMoviesButton;

            if (id === 'moviesContainer')
                return moviesContainer;

            return null;
        });
    }
})