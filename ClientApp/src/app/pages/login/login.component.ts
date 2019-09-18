import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';
import { LoginModel } from 'src/app/models/security.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: LoginModel = new LoginModel();
  returnUrl = '';

  constructor(
    private securityService: SecurityService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  public login() {
    this.securityService.login(this.model)
      .subscribe(result => {
        if (result) {
          this.router.navigate([this.returnUrl]);
        }
      });
  }

}
