import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseResultModel } from 'src/app/models/base.model';

// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class BaseService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(
    protected http: HttpClient
  ) { }

  protected get<T>(url: string): Observable<T> {
    return this.http
      .get<BaseResultModel<T>>(`${this.baseUrl}${url}`)
      .pipe(
        map(result => result.data)
      );
  }

  protected post<T>(url: string, model: any): Observable<T> {
    return this.http
      .post<BaseResultModel<T>>(`${this.baseUrl}${url}`, model)
      .pipe(
        map(result => result.data)
      );
  }

  protected put<T>(url: string, model: any): Observable<T> {
    return this.http
      .put<BaseResultModel<T>>(`${this.baseUrl}${url}`, model)
      .pipe(
        map(result => result.data)
      );
  }

  protected delete<T>(url: string): Observable<T> {
    return this.http
      .delete<BaseResultModel<T>>(`${this.baseUrl}${url}`)
      .pipe(
        map(result => result.data)
      );
  }
}
