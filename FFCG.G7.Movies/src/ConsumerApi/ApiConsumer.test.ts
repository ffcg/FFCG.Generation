import { ApiConsumer } from "./ApiConsumer";
import { Movie } from "../Core/Movie";
import { IStorage } from "../Core/IStorage";
import { IHttpClient } from "./HttpClient/IHttpClient";

describe('Api Consumer', () => {
    let apiConsumer: ApiConsumer
    let storage: IStorage<Movie>

    beforeEach(() => {
        const externalMovies = getMoviesResponse()
        const fakeHttpClient = new FakeHttpClient(externalMovies)
        storage = new FakeStorage();
        apiConsumer = new ApiConsumer(fakeHttpClient, storage)
    })

    it('should be able to retrieve top rated movies', async (done) => {
        let movies = await apiConsumer.getTopRatedMovies()

        verifyMovies(movies)

        done()
    })

    it('when syncing movies should save to storage', async (done) => {
        await apiConsumer.syncMovies()

        let movies = storage.all()

        verifyMovies(movies)

        done()
    })

    function verifyMovies(movies: Array<Movie>) {
        expect(movies.length).toBe(20)
        expect(movies[0].id).toBe('335983')
        expect(movies[0].name).toBe('Venom')
        expect(movies[1].id).toBe('338952')
        expect(movies[1].name).toBe('Fantastic Beasts: The Crimes of Grindelwald')
    }
})

class FakeHttpClient implements IHttpClient {
    response: string

    constructor(response: string) {
        this.response = response
    }

    get(url: string): Promise<string> {
        return Promise.resolve(this.response)
    }
}

class FakeStorage implements IStorage<Movie> {
    private _movies = []

    load(id: string): Movie {
        return this._movies.find(m => m.id === id)
    }

    store(movie: Movie) {
        this._movies.push(movie)
    }

    delete(movie: Movie) {
        this._movies = this._movies.filter(m => m.id !== movie.id)
    }

    all() {
        return this._movies
    }
}

function getMoviesResponse() {
return `
{
    "page": 1,
    "total_results": 390158,
    "total_pages": 19508,
    "results": [
        {
            "vote_count": 2455,
            "id": 335983,
            "video": false,
            "vote_average": 6.5,
            "title": "Venom",
            "popularity": 368.719,
            "poster_path": "/2uNW4WbgBXL25BAbXGLnLqX71Sw.jpg",
            "original_language": "en",
            "original_title": "Venom",
            "genre_ids": [
                878
            ],
            "backdrop_path": "/VuukZLgaCrho2Ar8Scl9HtV3yD.jpg",
            "adult": false,
            "overview": "Eddie Brock is a reporter, investigating people who want to go unnoticed. But after he makes a terrible discovery at the Life Foundation, he begins to transform into ‘Venom’.  The Foundation has discovered creatures called symbiotes, and believes they’re the key to the next step in human evolution. Unwittingly bonded with one, Eddie discovers he has incredible new abilities - and a voice in his head that’s telling him to embrace the darkness.  One of Marvel’s most celebrated anti-heroes comes to the big screen in ‘Venom’, starring Tom Hardy, Michelle Williams and Riz Ahmed.",
            "release_date": "2018-10-03"
        },
        {
            "vote_count": 1473,
            "id": 338952,
            "video": false,
            "vote_average": 7,
            "title": "Fantastic Beasts: The Crimes of Grindelwald",
            "popularity": 315.827,
            "poster_path": "/uyJgTzAsp3Za2TaPiZt2yaKYRIR.jpg",
            "original_language": "en",
            "original_title": "Fantastic Beasts: The Crimes of Grindelwald",
            "genre_ids": [
                10751,
                14,
                12
            ],
            "backdrop_path": "/xgbeBCjmFpRYHDF7tQ7U98EREWp.jpg",
            "adult": false,
            "overview": "Gellert Grindelwald has escaped imprisonment and has begun gathering followers to his cause—elevating wizards above all non-magical beings. The only one capable of putting a stop to him is the wizard he once called his closest friend, Albus Dumbledore. However, Dumbledore will need to seek help from the wizard who had thwarted Grindelwald once before, his former student Newt Scamander, who agrees to help, unaware of the dangers that lie ahead. Lines are drawn as love and loyalty are tested, even among the truest friends and family, in an increasingly divided wizarding world.",
            "release_date": "2018-11-14"
        },
        {
            "vote_count": 75,
            "id": 507569,
            "video": false,
            "vote_average": 5.9,
            "title": "The Seven Deadly Sins: Prisoners of the Sky",
            "popularity": 252.2,
            "poster_path": "/r6pPUVUKU5eIpYj4oEzidk5ZibB.jpg",
            "original_language": "en",
            "original_title": "劇場版 七つの大罪 天空の囚われ人",
            "genre_ids": [
                28,
                12,
                14,
                16
            ],
            "backdrop_path": "/uKwOX7MtKlAaGeCQe6c4jc1vZpj.jpg",
            "adult": false,
            "overview": "Traveling in search of the rare ingredient, “sky fish”  Meliodas and Hawk arrive at a palace that floats above the clouds. The people there are busy preparing a ceremony, meant to protect their home from a ferocious beast that awakens once every 3,000 years. But before the ritual is complete, the Six Knights of Black—a Demon Clan army—removes the seal on the beast, threatening the lives of everyone in the Sky Palace.",
            "release_date": "2018-08-18"
        },
        {
            "vote_count": 937,
            "id": 346910,
            "video": false,
            "vote_average": 5.2,
            "title": "The Predator",
            "popularity": 179.214,
            "poster_path": "/wMq9kQXTeQCHUZOG4fAe5cAxyUA.jpg",
            "original_language": "en",
            "original_title": "The Predator",
            "genre_ids": [
                878,
                28,
                53,
                12
            ],
            "backdrop_path": "/f4E0ocYeToEuXvczZv6QArrMDJ.jpg",
            "adult": false,
            "overview": "When a kid accidentally triggers the universe's most lethal hunters' return to Earth, only a ragtag crew of ex-soldiers and a disgruntled female scientist can prevent the end of the human race.",
            "release_date": "2018-09-13"
        },
        {
            "vote_count": 1420,
            "id": 424694,
            "video": false,
            "vote_average": 8.2,
            "title": "Bohemian Rhapsody",
            "popularity": 162.23,
            "poster_path": "/lHu1wtNaczFPGFDTrjCSzeLPTKN.jpg",
            "original_language": "en",
            "original_title": "Bohemian Rhapsody",
            "genre_ids": [
                18,
                10402
            ],
            "backdrop_path": "/pbXgLEYh8rlG2Km5IGZPnhcnuSz.jpg",
            "adult": false,
            "overview": "Singer Freddie Mercury, guitarist Brian May, drummer Roger Taylor and bass guitarist John Deacon take the music world by storm when they form the rock 'n' roll band Queen in 1970. Hit songs become instant classics. When Mercury's increasingly wild lifestyle starts to spiral out of control, Queen soon faces its greatest challenge yet – finding a way to keep the band together amid the success and excess.",
            "release_date": "2018-10-24"
        },
        {
            "vote_count": 289,
            "id": 463821,
            "video": false,
            "vote_average": 6.4,
            "title": "The House with a Clock in Its Walls",
            "popularity": 155.089,
            "poster_path": "/qM66Hv4ByAxnilr0jaqCA9uOD4Y.jpg",
            "original_language": "en",
            "original_title": "The House with a Clock in Its Walls",
            "genre_ids": [
                27,
                14,
                53,
                10751,
                9648
            ],
            "backdrop_path": "/meyZ0ZZLLNaKIrvbmVpuXzZ11sD.jpg",
            "adult": false,
            "overview": "Ten-year-old Lewis goes to live with his uncle in a creaky old house that contains a mysterious ticktock noise. When Lewis accidentally awakens the dead, the town's sleepy facade magically springs to life with a secret world of witches and warlocks.",
            "release_date": "2018-09-15"
        },
        {
            "vote_count": 173,
            "id": 360920,
            "video": false,
            "vote_average": 6.2,
            "title": "The Grinch",
            "popularity": 152.814,
            "poster_path": "/rWQVj6Z8kPdsbt7XPjVBCltxq90.jpg",
            "original_language": "en",
            "original_title": "The Grinch",
            "genre_ids": [
                16,
                10751,
                35,
                14
            ],
            "backdrop_path": "/zRDkmww7Bu11wiz2g86RxSreiY4.jpg",
            "adult": false,
            "overview": "The Grinch hatches a scheme to ruin Christmas when the residents of Whoville plan their annual holiday celebration.",
            "release_date": "2018-11-08"
        },
        {
            "vote_count": 72,
            "id": 375588,
            "video": false,
            "vote_average": 6.6,
            "title": "Robin Hood",
            "popularity": 133.976,
            "poster_path": "/AiRfixFcfTkNbn2A73qVJPlpkUo.jpg",
            "original_language": "en",
            "original_title": "Robin Hood",
            "genre_ids": [
                12,
                28
            ],
            "backdrop_path": "/AuA50D7T7S7OEVcGo0ZKaMhERn0.jpg",
            "adult": false,
            "overview": "A war-hardened Crusader and his Moorish commander mount an audacious revolt against the corrupt English crown.",
            "release_date": "2018-09-01"
        },
        {
            "vote_count": 2378,
            "id": 353081,
            "video": false,
            "vote_average": 7.2,
            "title": "Mission: Impossible - Fallout",
            "popularity": 129.802,
            "poster_path": "/AkJQpZp9WoNdj7pLYSj1L0RcMMN.jpg",
            "original_language": "en",
            "original_title": "Mission: Impossible - Fallout",
            "genre_ids": [
                28,
                53,
                12
            ],
            "backdrop_path": "/aw4FOsWr2FY373nKSxbpNi3fz4F.jpg",
            "adult": false,
            "overview": "When an IMF mission ends badly, the world is faced with dire consequences. As Ethan Hunt takes it upon himself to fulfill his original briefing, the CIA begin to question his loyalty and his motives. The IMF team find themselves in a race against time, hunted by assassins while trying to prevent a global catastrophe.",
            "release_date": "2018-07-13"
        },
        {
            "vote_count": 74,
            "id": 404368,
            "video": false,
            "vote_average": 7.4,
            "title": "Ralph Breaks the Internet",
            "popularity": 117.495,
            "poster_path": "/m110vLaDDOCca4hfOcS5mK5cDke.jpg",
            "original_language": "en",
            "original_title": "Ralph Breaks the Internet",
            "genre_ids": [
                10751,
                16
            ],
            "backdrop_path": "/ivhK1NjnFji6lD5dkAThSzd3Mgq.jpg",
            "adult": false,
            "overview": "Taking place six years following the events of the first film, the story will center on Ralph's adventures in the Internet data space when a Wi-Fi router gets plugged into the arcade as he must find a replacement part to fix Sugar Rush.",
            "release_date": "2018-11-20"
        },
        {
            "vote_count": 1586,
            "id": 439079,
            "video": false,
            "vote_average": 5.7,
            "title": "The Nun",
            "popularity": 114.786,
            "poster_path": "/sFC1ElvoKGdHJIWRpNB3xWJ9lJA.jpg",
            "original_language": "en",
            "original_title": "The Nun",
            "genre_ids": [
                27,
                9648,
                53
            ],
            "backdrop_path": "/fgsHxz21B27hOOqQBiw9L6yWcM7.jpg",
            "adult": false,
            "overview": "When a young nun at a cloistered abbey in Romania takes her own life, a priest with a haunted past and a novitiate on the threshold of her final vows are sent by the Vatican to investigate. Together they uncover the order’s unholy secret. Risking not only their lives but their faith and their very souls, they confront a malevolent force in the form of the same demonic nun that first terrorized audiences in “The Conjuring 2” as the abbey becomes a horrific battleground between the living and the damned.",
            "release_date": "2018-09-05"
        },
        {
            "vote_count": 9575,
            "id": 299536,
            "video": false,
            "vote_average": 8.3,
            "title": "Avengers: Infinity War",
            "popularity": 101.706,
            "poster_path": "/7WsyChQLEftFiDOVTGkv3hFpyyt.jpg",
            "original_language": "en",
            "original_title": "Avengers: Infinity War",
            "genre_ids": [
                12,
                878,
                28,
                14
            ],
            "backdrop_path": "/lmZFxXgJE3vgrciwuDib0N8CfQo.jpg",
            "adult": false,
            "overview": "As the Avengers and their allies have continued to protect the world from threats too large for any one hero to handle, a new danger has emerged from the cosmic shadows: Thanos. A despot of intergalactic infamy, his goal is to collect all six Infinity Stones, artifacts of unimaginable power, and use them to inflict his twisted will on all of reality. Everything the Avengers have fought for has led up to this moment - the fate of Earth and existence itself has never been more uncertain.",
            "release_date": "2018-04-25"
        },
        {
            "vote_count": 144,
            "id": 527435,
            "video": false,
            "vote_average": 7.3,
            "title": "The Christmas Chronicles",
            "popularity": 100.215,
            "poster_path": "/5Il2EMSF2KecrUKZPuen6BZmaCP.jpg",
            "original_language": "en",
            "original_title": "The Christmas Chronicles",
            "genre_ids": [
                35,
                12,
                10751,
                14
            ],
            "backdrop_path": "/vUbWBVHngojXOu1kBgH6xFkZZTA.jpg",
            "adult": false,
            "overview": "Siblings Kate and Teddy try to prove Santa Claus is real, but when they accidentally cause his sleigh to crash, they have to save Christmas.",
            "release_date": "2018-11-22"
        },
        {
            "vote_count": 165,
            "id": 458594,
            "video": false,
            "vote_average": 6.4,
            "title": "Peppermint",
            "popularity": 95.167,
            "poster_path": "/jrzxS0vcbzIIay1sdYm0rgI2QfJ.jpg",
            "original_language": "en",
            "original_title": "Peppermint",
            "genre_ids": [
                28,
                53,
                18
            ],
            "backdrop_path": "/14HPHJnNUVAdbYKnG46WnBh4OD6.jpg",
            "adult": false,
            "overview": "A grieving mother transforms herself into a vigilante following the murders of her husband and daughter, eluding the authorities to deliver her own personal brand of justice.",
            "release_date": "2018-09-06"
        },
        {
            "vote_count": 1104,
            "id": 345887,
            "video": false,
            "vote_average": 6.2,
            "title": "The Equalizer 2",
            "popularity": 80.009,
            "poster_path": "/cQvc9N6JiMVKqol3wcYrGshsIdZ.jpg",
            "original_language": "en",
            "original_title": "The Equalizer 2",
            "genre_ids": [
                53,
                28,
                80
            ],
            "backdrop_path": "/z7noaCJ4KtmhwHw7QcNtnMMo4Qy.jpg",
            "adult": false,
            "overview": "Robert McCall, who serves an unflinching justice for the exploited and oppressed, embarks on a relentless, globe-trotting quest for vengeance when a long-time girl friend is murdered.",
            "release_date": "2018-07-19"
        },
        {
            "vote_count": 1858,
            "id": 332562,
            "video": false,
            "vote_average": 7.4,
            "title": "A Star Is Born",
            "popularity": 73.935,
            "poster_path": "/wrFpXMNBRj2PBiN4Z5kix51XaIZ.jpg",
            "original_language": "en",
            "original_title": "A Star Is Born",
            "genre_ids": [
                18,
                10402,
                10749
            ],
            "backdrop_path": "/840rbblaLc4SVxm8gF3DNdJ0YAE.jpg",
            "adult": false,
            "overview": "Seasoned musician Jackson Maine discovers—and falls in love with—struggling artist Ally. She has just about given up on her dream to make it big as a singer—until Jack coaxes her into the spotlight. But even as Ally's career takes off, the personal side of their relationship is breaking down, as Jack fights an ongoing battle with his own internal demons.",
            "release_date": "2018-10-03"
        },
        {
            "vote_count": 3876,
            "id": 260513,
            "video": false,
            "vote_average": 7.6,
            "title": "Incredibles 2",
            "popularity": 72.403,
            "poster_path": "/x1txcDXkcM65gl7w20PwYSxAYah.jpg",
            "original_language": "en",
            "original_title": "Incredibles 2",
            "genre_ids": [
                28,
                12,
                16,
                10751
            ],
            "backdrop_path": "/mabuNsGJgRuCTuGqjFkWe1xdu19.jpg",
            "adult": false,
            "overview": "Elastigirl springs into action to save the day, while Mr. Incredible faces his greatest challenge yet – taking care of the problems of his three children.",
            "release_date": "2018-06-14"
        },
        {
            "vote_count": 118,
            "id": 446807,
            "video": false,
            "vote_average": 5.2,
            "title": "The Girl in the Spider's Web",
            "popularity": 66.727,
            "poster_path": "/w4ibr8R702DCjwYniry1D1XwQXj.jpg",
            "original_language": "en",
            "original_title": "The Girl in the Spider's Web",
            "genre_ids": [
                18,
                53,
                9648,
                80,
                28
            ],
            "backdrop_path": "/zYZeoInDyCziwCD8psOaryL8ntR.jpg",
            "adult": false,
            "overview": "Lisbeth Salander and Mikael Blomkvist find themselves caught in a web of spies, cyber-criminals and corrupt government officials - both in Sweden and in the United States - whom are only known as The Spider Society.",
            "release_date": "2018-10-26"
        },
        {
            "vote_count": 243,
            "id": 454293,
            "video": false,
            "vote_average": 6.4,
            "title": "Night School",
            "popularity": 66.054,
            "poster_path": "/1NSMAaBPSbWv7sGmF8oLGMNb8Qm.jpg",
            "original_language": "en",
            "original_title": "Night School",
            "genre_ids": [
                35
            ],
            "backdrop_path": "/jJBimY3DXIaIaL4NeGHfR0U0rSh.jpg",
            "adult": false,
            "overview": "Teddy Walker is a successful salesman whose life takes an unexpected turn when he accidentally blows up his place of employment. Forced to attend night school to get his GED, Teddy soon finds himself dealing with a group of misfit students, his former high school nemesis and a feisty teacher who doesn't think he's too bright.",
            "release_date": "2018-09-27"
        },
        {
            "vote_count": 1735,
            "id": 345940,
            "video": false,
            "vote_average": 5.9,
            "title": "The Meg",
            "popularity": 62.196,
            "poster_path": "/eyWICPcxOuTcDDDbTMOZawoOn8d.jpg",
            "original_language": "en",
            "original_title": "The Meg",
            "genre_ids": [
                28,
                878,
                53
            ],
            "backdrop_path": "/2uSCHUsmzb6KkQPFSxBQ7bgfJLE.jpg",
            "adult": false,
            "overview": "A deep sea submersible pilot revisits his past fears in the Mariana Trench, and accidentally unleashes the seventy foot ancestor of the Great White Shark believed to be extinct.",
            "release_date": "2018-08-09"
        }
    ]
}
`
}
