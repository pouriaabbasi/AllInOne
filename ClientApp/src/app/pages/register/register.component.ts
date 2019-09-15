import { Component, OnInit } from '@angular/core';
import { RegisterModel } from 'src/app/models/security.model';
import { SecurityService } from 'src/app/services/security.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model = new RegisterModel();
  constructor(
    private securityService: SecurityService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  public register() {
    this.securityService.register(this.model)
      .subscribe(result => {
        if (result) {
          this.router.navigate(['/login']);
        }
      });
  }

}
