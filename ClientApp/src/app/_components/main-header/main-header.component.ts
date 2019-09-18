import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';

@Component({
  selector: 'app-main-header',
  templateUrl: './main-header.component.html',
  styleUrls: ['./main-header.component.css']
})
export class MainHeaderComponent implements OnInit {

  fullName = '';

  constructor(
    private securityService: SecurityService
  ) { }

  ngOnInit() {
    this.fullName = `${this.securityService.currentUserValue.firstName} ${this.securityService.currentUserValue.lastName}`;
  }

}
