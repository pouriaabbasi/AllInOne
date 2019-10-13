import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';
import { TodoMenu, TodoListModel } from 'src/app/models/todo.model';
import { TodoService } from 'src/app/services/todo.service';
import { BaseComponent } from '../base/base.component';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { LeitnerService } from 'src/app/services/leitner.service';
import { LeitnerBoxModel } from 'src/app/models/leitner.model';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent extends BaseComponent implements OnInit {

  fullName = '';
  newListName = '';
  newGroupName = '';
  newBoxName = '';
  todoMenu = new TodoMenu();
  leitnerBoxes: LeitnerBoxModel[] = [];

  constructor(
    protected toastr: ToastrService,
    private securityService: SecurityService,
    private todoService: TodoService,
    private leitnerService: LeitnerService,
    private router: Router
  ) {
    super(toastr);
  }

  ngOnInit() {
    this.fullName = `${this.securityService.currentUserValue.firstName} ${this.securityService.currentUserValue.lastName}`;
    this.getLists();
    this.getBoxes();
  }

  private getLists() {
    this.todoService.getLists()
      .subscribe(lists => {
        if (lists) {
          this.todoMenu.lists = lists;
        }
      });
  }

  private getBoxes() {
    this.leitnerService.getBoxes()
      .subscribe(boxes => {
        if (boxes) {
          this.leitnerBoxes = boxes;
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

  public addNewBox() {
    this.leitnerService.addBox(this.newBoxName)
      .subscribe(result => {
        if (result) {
          this.newBoxName = '';
          this.leitnerBoxes.push(result);
          this.showSuccess('Add Box', 'Your box was added');
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

  public removeBox(boxId: number) {
    this.leitnerService.removeBox(boxId)
      .subscribe(result => {
        if (result) {
          const boxIndex = this.leitnerBoxes.findIndex(x => x.id === boxId);
          this.leitnerBoxes.splice(boxIndex, 1);
          this.showSuccess('Delete Box', 'Your box was deleted');
          this.router.navigate(['/']);
        }
      });
  }

  public showInfo(listId) {
    const listName = listId === 0
      ? 'Tasks'
      : this.todoMenu.lists.find(x => x.id === listId).name;
    super.showInfo('Change List', `list '${listName}' selected`);
  }

  public showBoxInfo(boxId) {
    const boxName = this.leitnerBoxes.find(x => x.id === boxId).name;
    super.showInfo('Change Box', `box '${boxName}' selected`);
  }
}
