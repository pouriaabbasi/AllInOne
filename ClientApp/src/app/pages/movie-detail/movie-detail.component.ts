import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from 'src/app/_components/base/base.component';
import { MovieModel } from 'src/app/models/movie.model';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent extends BaseComponent implements OnInit {

  movieModel: MovieModel = new MovieModel();
  imdbId: string;

  constructor(
    protected toastr: ToastrService,
    private activeModal: NgbActiveModal,
    private movieService: MovieService
  ) {
    super(toastr);
  }

  ngOnInit() {
  }

  // tslint:disable-next-line: use-lifecycle-interface
  ngAfterViewInit() {
    if (this.imdbId) {
      this.movieService.getImdbMovieInfo(this.imdbId)
        .subscribe(result => {
          this.movieModel = result;
        });
    }
  }

  public close() {
    this.activeModal.close(false);
  }

  public addToMyMovies() {
    this.activeModal.close(true);
  }

}
