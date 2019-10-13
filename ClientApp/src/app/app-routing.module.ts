import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_guards/auth.guard';
import { AppLayoutComponent } from './_layouts/app-layout/app-layout.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { TodoComponent } from './pages/todo/todo.component';
import { BoxDashboardComponent } from './pages/box-dashboard/box-dashboard.component';


const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    component: AppLayoutComponent,
    children: [
      { path: 'todo/:id', component: TodoComponent },
      { path: 'box-dashboard/:id', component: BoxDashboardComponent }
    ]
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
