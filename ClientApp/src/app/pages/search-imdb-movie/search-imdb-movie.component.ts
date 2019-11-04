import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/services/movie.service';
import { ImdbSearchFilterModel, ImdbSearchResultModel } from 'src/app/models/movie.model';

@Component({
  selector: 'app-search-imdb-movie',
  templateUrl: './search-imdb-movie.component.html',
  styleUrls: ['./search-imdb-movie.component.css']
})
export class SearchImdbMovieComponent implements OnInit {

  movieName = '';
  currentPage: number;
  pages: number[];
  result: ImdbSearchResultModel = new ImdbSearchResultModel();

  constructor(
    private movieService: MovieService
  ) { }

  ngOnInit() {
  }

  public searchMovie(page: number) {
    if (!page) {
      this.currentPage = 1;
    } else {
      this.currentPage = page;
    }

    const filterModel: ImdbSearchFilterModel = new ImdbSearchFilterModel();
    filterModel.name = this.movieName;
    filterModel.page = this.currentPage;
    this.movieService.searchImdbMovie(filterModel)
      .subscribe(result => {
        this.result = result;
        const totalPages = Math.ceil(this.result.totalResults / 10);
        // totalPages += this.result.totalResults % 10 > 0 ? 1 : 0;
        this.pages = Array(totalPages).fill(1).map((x, i) => (i + 1));
      });
  }

}
