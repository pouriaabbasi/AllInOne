import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';
import { LoginModel } from 'src/app/models/security.model';
import { Router, ActivatedRoute } from '@angular/router';
import { TestService } from 'src/app/services/test.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: LoginModel = new LoginModel();
  returnUrl: string;

  constructor(
    private securityService: SecurityService,
    private testService: TestService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  public login() {
    console.log(this.testService.test());
    console.log(this.securityService.test());
    this.securityService.login(this.model)
      .subscribe(result => {
        if (result) {
          this.router.navigate([this.returnUrl]);
        }
      });
  }

}
