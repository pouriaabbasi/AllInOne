import { Injectable } from '@angular/core';
import { BaseService } from './base/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ItemModel, AddItemModel, TodoListModel, ListModel, GroupModel } from '../models/todo.model';

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

  public getListItems(listId: string): Observable<ItemModel[]> {
    return super.get(`TodoItem/GetListItems/${listId}`);
  }

  public getLists(): Observable<TodoListModel[]> {
    return super.get('TodoList/GetAllList');
  }

  public getOrphanItems(): Observable<ItemModel[]> {
    return super.get('TodoItem/GetOrphanItems');
  }

  public addItem(model: AddItemModel): Observable<ItemModel> {
    return super.post('TodoItem/AddItem', model);
  }

  public changeItemStatus(itemId: number): Observable<boolean> {
    return super.put('TodoItem/ChangeItemStatus/' + itemId.toString(), null);
  }

  public deleteItem(itemId: number): Observable<boolean> {
    return super.delete('TodoItem/DeleteItem/' + itemId.toString());
  }

  public addList(listName: string): Observable<TodoListModel> {
    return super.post('TodoList/AddList', { name: listName });
  }

  public removeList(listId: number): Observable<boolean> {
    return super.delete(`TodoList/DeleteList/${listId}`);
  }

  public editItem(itemId: number, itemName: string): Observable<ItemModel> {
    return super.put(`TodoItem/EditItem/${itemId}`, { name: itemName });
  }

  public getList(listId: number): Observable<ListModel> {
    return this.get(`TodoList/GetList/${listId}`);
  }

  public addGroup(gorupName: string): Observable<GroupModel> {
    return this.post('TodoGroup/AddGroup', { name: gorupName });
  }
}
