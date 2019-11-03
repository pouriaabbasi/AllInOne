import { Injectable } from '@angular/core';
import { BaseService } from './base/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ImdbSearchFilterModel, ImdbSearchResultModel } from '../models/movie.model';

@Injectable({
  providedIn: 'root'
})
export class MovieService extends BaseService {

  constructor(
    protected http: HttpClient
  ) {
    super(http);
  }

  public searchImdbMovie(model: ImdbSearchFilterModel): Observable<ImdbSearchResultModel> {
    return super.post('MovieMovie/SearchImdbFilms', model);
  }
}
