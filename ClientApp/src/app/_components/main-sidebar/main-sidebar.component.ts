import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';
import { TodoMenu, TodoListModel } from 'src/app/models/todo.model';
import { TodoService } from 'src/app/services/todo.service';
import { BaseComponent } from '../base/base.component';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent extends BaseComponent implements OnInit {

  fullName = '';
  newListName = '';
  newGroupName = '';
  todoMenu = new TodoMenu();

  constructor(
    protected toastr: ToastrService,
    private securityService: SecurityService,
    private todoService: TodoService,
    private router: Router
  ) {
    super(toastr);
  }

  ngOnInit() {
    this.fullName = `${this.securityService.currentUserValue.firstName} ${this.securityService.currentUserValue.lastName}`;
    this.getLists();
  }

  private getLists() {
    this.todoService.getLists()
      .subscribe(lists => {
        if (lists) {
          this.todoMenu.lists = lists;
        }
      });
  }

  public addNewList() {
    this.todoService.addList(this.newListName)
      .subscribe(result => {
        if (result) {
          this.newListName = '';
          this.todoMenu.lists.push(result);
          this.showSuccess('Add List', 'Your list was added');
        }
      });
  }

  public addNewGroup() {
    this.todoService.addGroup(this.newGroupName)
      .subscribe(result => {
        if (result) {
          this.newGroupName = '';
          this.todoMenu.groups.push({ name: result.name, lists: new Array<TodoListModel>() });
          this.showSuccess('Add Group', 'Your group was added');
        }
      });
  }

  public removeList(listId: number) {
    this.todoService.removeList(listId)
      .subscribe(result => {
        if (result) {
          const listIndex = this.todoMenu.lists.findIndex(x => x.id === listId);
          this.todoMenu.lists.splice(listIndex, 1);
          this.showSuccess('Delete List', 'Your list was deleted');
          this.router.navigate(['/todo/0']);
        }
      });
  }

  public showInfo(listId) {
    const listName = listId === 0
      ? 'Tasks'
      : this.todoMenu.lists.find(x => x.id === listId).name;
    super.showInfo('Change List', `list '${listName}' selected`);
  }
}
