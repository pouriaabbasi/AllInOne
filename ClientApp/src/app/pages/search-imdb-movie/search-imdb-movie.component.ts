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
  result: ImdbSearchResultModel = new ImdbSearchResultModel();

  constructor(
    private movieService: MovieService
  ) { }

  ngOnInit() {
  }

  public searchMovie() {
    const filterModel: ImdbSearchFilterModel = new ImdbSearchFilterModel();
    filterModel.name = this.movieName;
    this.movieService.searchImdbMovie(filterModel)
      .subscribe(result => {
        this.result = result;
      });
  }

}
