import { Component, OnInit } from '@angular/core';
import { TodoService } from 'src/app/services/todo.service';
import { ItemModel, AddItemModel } from 'src/app/models/todo.model';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {

  constructor(
    private todoService: TodoService
  ) { }

  items: ItemModel[] = [];
  newItemModel: AddItemModel = new AddItemModel();

  ngOnInit() {
    this.fetchData();
  }

  public addItem() {
    this.newItemModel.listId = null;
    this.todoService.addItem(this.newItemModel)
      .subscribe(result => {
        if (result) {
          this.fetchData();
        }
      });
  }

  public changeItemStatus(itemId: number) {
    this.todoService.changeItemStatus(itemId)
      .subscribe(result => {
        if (result) {
          this.fetchData();
        }
      });
  }

  public deleteItem(itemId: number) {
    this.todoService.deleteItem(itemId)
      .subscribe(result => {
        if (result) {
          this.fetchData();
        }
      });
  }

  private fetchData() {
    this.todoService.getAllItems()
      .subscribe(result => {
        this.items = result;
        this.newItemModel = new AddItemModel();
      });
  }
}
