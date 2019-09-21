import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export class BaseComponent implements OnInit {

  constructor(
    protected toastr: ToastrService
  ) { }

  ngOnInit() {
  }

  protected showSuccess(title: string, message: string) {
    this.toastr.success(message, title, {
      closeButton: true,
      progressBar: true
    });
  }

  protected showError(title: string, message: string) {
    this.toastr.error(message, title, {
      closeButton: true,
      progressBar: true
    });
  }

  protected showWarning(title: string, message: string) {
    this.toastr.warning(message, title, {
      closeButton: true,
      progressBar: true
    });
  }

  protected showInfo(title: string, message: string) {
    this.toastr.info(message, title, {
      closeButton: true,
      progressBar: true
    });
  }
}
