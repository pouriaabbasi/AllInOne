import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';
import { TodoMenu, TodoGroupModel, TodoListModel } from 'src/app/models/todo.model';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent implements OnInit {

  fullName = '';
  newListName = '';
  todoMenu = new TodoMenu();

  constructor(
    private securityService: SecurityService,
    private todoService: TodoService
  ) {
    this.todoMenu.lists = new Array<TodoListModel>();
  }

  ngOnInit() {
    this.fullName = `${this.securityService.currentUserValue.firstName} ${this.securityService.currentUserValue.lastName}`;
    this.getLists();
  }

  private getLists() {
    this.todoService.getLists()
      .subscribe(result => {
        if (result) {
          this.todoMenu.lists = result;
        }
      });
  }

  public addNewList() {
    this.todoService.addList(this.newListName)
      .subscribe(result => {
        if (result) {
          this.newListName = '';
          this.todoMenu.lists.push(result);
        }
      });
  }

  public removeList(listId: number) {
    this.todoService.removeList(listId)
      .subscribe(result => {
        if (result) {
          const listIndex = this.todoMenu.lists.findIndex(x => x.id === listId);
          this.todoMenu.lists.splice(listIndex, 1);
        }
      });
  }

}
