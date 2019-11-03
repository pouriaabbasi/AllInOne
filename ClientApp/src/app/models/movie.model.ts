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