import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/services/movie.service';
import { ImdbSearchFilterModel, ImdbSearchResultModel } from 'src/app/models/movie.model';
import { BaseComponent } from 'src/app/_components/base/base.component';
import { ToastrService } from 'ngx-toastr';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MovieDetailComponent } from '../movie-detail/movie-detail.component';

@Component({
  selector: 'app-search-imdb-movie',
  templateUrl: './search-imdb-movie.component.html',
  styleUrls: ['./search-imdb-movie.component.css']
})
export class SearchImdbMovieComponent extends BaseComponent implements OnInit {

  movieName = '';
  currentPage: number;
  pages: number[];
  result: ImdbSearchResultModel = new ImdbSearchResultModel();

  constructor(
    protected toastr: ToastrService,
    private modalService: NgbModal,
    private movieService: MovieService
  ) {
    super(toastr);
  }

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
        this.pages = Array(totalPages).fill(1).map((x, i) => (i + 1));
      });
  }

  public openMovieDetail(imdbId: string) {
    const modalRef = this.modalService.open(MovieDetailComponent, {
      centered: true,
      size: 'lg'
    });
    modalRef.componentInstance.imdbId = imdbId;
    modalRef.result.then(result => {
      if (result) {
        console.log('test');
      }
    }, () => { });
  }

  public addMovieFromImdb(imdbId: string) {
    this.movieService.addMovieFromImdb(imdbId)
      .subscribe(result => {
        if (result) {
          super.showSuccess('Add Movie', 'Movie was added successfuly');
        }
      });
  }
}
