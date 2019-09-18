import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent implements OnInit {

  fullName = '';

  constructor(
    private securityService: SecurityService
  ) { }

  ngOnInit() {
    this.fullName = `${this.securityService.currentUserValue.firstName} ${this.securityService.currentUserValue.lastName}`;
  }

}
