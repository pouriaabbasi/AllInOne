import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/_components/base/base.component';
import { ToastrService } from 'ngx-toastr';
import { MovieService } from 'src/app/services/movie.service';
import { MovieModel } from 'src/app/models/movie.model';

@Component({
  selector: 'app-my-movies',
  templateUrl: './my-movies.component.html',
  styleUrls: ['./my-movies.component.css']
})
export class MyMoviesComponent extends BaseComponent implements OnInit {

  columnDefs = [
    { headerName: 'Title', field: 'title', sortable: true, filter: true, resizable: true, checkboxSelection: true },
    { headerName: 'Year', field: 'year', sortable: true, resizable: true, filter: true },
    { headerName: 'Director', field: 'director', sortable: true, resizable: true, filter: true },
    { headerName: 'Type', field: 'type', sortable: true, resizable: true, filter: true }
  ];

  rowData: MovieModel[] = [];

  constructor(
    protected toastrService: ToastrService,
    private movieService: MovieService
  ) {
    super(toastrService);
  }

  ngOnInit() {
    this.movieService.getMyMovies()
      .subscribe(result => {
        if (result) {
          this.rowData = result;
        }
      });
  }

}
