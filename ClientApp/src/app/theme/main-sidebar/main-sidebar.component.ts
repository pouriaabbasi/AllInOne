import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';
import { TodoMenu, TodoGroupModel, TodoListModel } from 'src/app/models/todo.model';
import { TodoService } from 'src/app/services/todo.service';
import { ToastrService } from 'ngx-toastr';
import { BaseComponent } from 'src/app/pages/base/base.component';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent extends BaseComponent implements OnInit {

  fullName = '';
  newListName = '';
  todoMenu = new TodoMenu();

  constructor(
    protected toastr: ToastrService,
    private securityService: SecurityService,
    private todoService: TodoService
  ) {
    super(toastr);
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
          this.showSuccess('Add List', 'Your list was added');
          this.newListName = '';
          this.todoMenu.lists.push(result);
        }
      });
  }

  public removeList(listId: number) {
    this.todoService.removeList(listId)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Delete List', 'Your list was deleted');
          const listIndex = this.todoMenu.lists.findIndex(x => x.id === listId);
          this.todoMenu.lists.splice(listIndex, 1);
        }
      });
  }

}
