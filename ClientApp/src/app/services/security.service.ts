import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserModel, LoginModel, RegisterModel } from '../models/security.model';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base/base.service';

@Injectable({
  providedIn: 'root'
})
export class SecurityService extends BaseService {
  private currentUserSubject: BehaviorSubject<UserModel>;
  public currentUser: Observable<UserModel>;

  constructor(
    protected http: HttpClient
  ) {
    super(http);
    this.currentUserSubject = new BehaviorSubject<UserModel>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): UserModel {
    if (this.currentUserSubject == null) {
      return null;
    }
    return this.currentUserSubject.value;
  }

  public login(model: LoginModel): Observable<UserModel> {
    return super.post<UserModel>('SecurityLogin/Login', model)
      .pipe(
        map(user => {
          if (user && user.token) {
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.currentUserSubject.next(user);
          }
          return user;
        }));
  }

  public register(model: RegisterModel): Observable<boolean> {
    return super.post<boolean>('SecurityLogin/Register', model);
  }

  public logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
