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

  listName = '';

  constructor(
    protected toastr: ToastrService,
    private route: ActivatedRoute,
    private todoService: TodoService
  ) {
    super(toastr);
  }

  items: ItemModel[] = [];
  newItemModel: AddItemModel = new AddItemModel();

  ngOnInit() {
    this.getListInfo();
    this.fetchData();
  }

  public addItem() {
    this.route.paramMap.subscribe(params => {
      const listId = params.get('id');
      this.newItemModel.listId = listId === '0' ? null : Number(listId);
      this.todoService.addItem(this.newItemModel)
        .subscribe(result => {
          if (result) {
            this.showSuccess('Add Item', 'Your item was added');
            this.fetchData();
          }
        });
    });
  }

  public changeItemStatus(itemId: number) {
    this.todoService.changeItemStatus(itemId)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Change Item\' Status', 'Your item\'s status was changed');
          this.fetchData();
        }
      });
  }

  public deleteItem(itemId: number) {
    this.todoService.deleteItem(itemId)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Delete Item', 'Your item was deleted');
          this.fetchData();
        }
      });
  }

  public editItem(itemId: number, itemName: string) {
    this.todoService.editItem(itemId, itemName)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Edit Item', 'Your item was edited');
          this.fetchData();
        }
      });
  }

  private fetchData() {
    this.route.paramMap.subscribe(params => {
      const listId = params.get('id');
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
    });
  }

  private getListInfo() {
    this.route.paramMap.subscribe(params => {
      const listId = params.get('id');
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
    });
  }
}