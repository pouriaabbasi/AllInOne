import { Component, OnInit } from '@angular/core';
import { TodoService } from 'src/app/services/todo.service';
import { ItemModel } from 'src/app/models/todo.model';

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

  ngOnInit() {
    this.fetchData();
  }

  private fetchData() {
    this.todoService.getAllItems()
      .subscribe(result => {
        console.log(result);
        this.items = result;
      });
  }
}
