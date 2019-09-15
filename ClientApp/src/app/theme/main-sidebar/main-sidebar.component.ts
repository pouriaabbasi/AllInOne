import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';
import { TodoMenu, TodoGroupModel, TodoListModel } from 'src/app/models/todo.model';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent implements OnInit {

  fullName = '';
  todoMenu = new TodoMenu();

  constructor(
    private securityService: SecurityService
  ) {
    this.todoMenu.lists = new Array<TodoListModel>();
    this.todoMenu.lists.push({ name: 'list 1', id: 5 });
    this.todoMenu.lists.push({ name: 'list 2', id: 6 });
  }

  ngOnInit() {
    this.fullName = `${this.securityService.currentUserValue.firstName} ${this.securityService.currentUserValue.lastName}`;
  }

}
