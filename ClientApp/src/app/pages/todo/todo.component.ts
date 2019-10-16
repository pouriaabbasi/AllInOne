import { Component, OnInit } from '@angular/core';
import { TodoService } from 'src/app/services/todo.service';
import { ItemModel, AddItemModel } from 'src/app/models/todo.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from 'src/app/_components/base/base.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent extends BaseComponent implements OnInit {


  constructor(
    protected toastr: ToastrService,
    private route: ActivatedRoute,
    private todoService: TodoService
  ) {
    super(toastr);
  }

  listName = '';
  items: ItemModel[] = [];
  newItemModel: AddItemModel = new AddItemModel();

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const listId = params.get('id');
      this.getListInfo(listId);
      this.fetchData(listId);
    });
  }

  public addItem() {
    const listId = this.route.snapshot.paramMap.get('id');
    this.newItemModel.listId = listId === '0' ? null : Number(listId);
    this.todoService.addItem(this.newItemModel)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Add Item', 'Your item was added');
          this.fetchData(listId);
        }
      });
  }

  public changeItemStatus(itemId: number) {
    const listId = this.route.snapshot.paramMap.get('id');
    this.todoService.changeItemStatus(itemId)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Change Item\' Status', 'Your item\'s status was changed');
          this.fetchData(listId);
        }
      });
  }

  public deleteItem(itemId: number) {
    const listId = this.route.snapshot.paramMap.get('id');
    this.todoService.deleteItem(itemId)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Delete Item', 'Your item was deleted');
          this.fetchData(listId);
        }
      });
  }

  public editItem(itemId: number, itemName: string) {
    const listId = this.route.snapshot.paramMap.get('id');
    this.todoService.editItem(itemId, itemName)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Edit Item', 'Your item was edited');
          this.fetchData(listId);
        }
      });
  }

  private fetchData(listId: string) {
    if (listId !== '0') {
      this.todoService.getListItems(listId)
        .subscribe(result => {
          this.items = result;
          this.newItemModel = new AddItemModel();
        });
    } else {
      this.todoService.getOrphanItems()
        .subscribe(result => {
          this.items = result;
          this.newItemModel = new AddItemModel();
        });
    }
  }

  private getListInfo(listId: string) {
    if (listId !== '0') {
      this.todoService.getList(Number(listId))
        .subscribe(list => {
          if (list) {
            this.listName = list.name;
          }
        });
    } else {
      this.listName = 'Tasks';
    }
  }
}
