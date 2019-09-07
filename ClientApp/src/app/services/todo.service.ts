import { Injectable } from '@angular/core';
import { BaseService } from './base/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ItemModel } from '../models/todo.model';

@Injectable({
  providedIn: 'root'
})
export class TodoService extends BaseService {

  constructor(
    protected http: HttpClient
  ) {
    super(http);
  }

  public getAllItems(): Observable<ItemModel[]> {
    return super.get('TodoItem/GetAllItems');
  }
}
