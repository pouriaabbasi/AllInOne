export class ImdbSearchFilterModel {
    name: string;
    searchType: number;
    year: number;
    page: number;
}

export class ImdbSearchResultModel {
    search: ImdbSearchMovieResultModel[];
    totalResults: number;
}

export class ImdbSearchMovieResultModel {
    title: string;
    year: number;
    imdbID: string;
    type: string;
    poster: string;
}

export class MovieModel {
    title: string;
    year: string;
    rated: string;
    released: string;
    runtime: string;
    genre: string;
    director: string;
    writer: string;
    actors: string;
    plot: string;
    language: string;
    country: string;
    awards: string;
    poster: string;
    metascore: string;
    imdbRating: string;
    imdbVotes: string;
    imdbID: string;
    type: string;
    dVD: string;
    boxOffice: string;
    production: string;
    website: string;
    response: string;
}
