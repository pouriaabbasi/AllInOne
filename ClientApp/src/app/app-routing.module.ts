import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_guards/auth.guard';
import { AppLayoutComponent } from './_layouts/app-layout/app-layout.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { TodoComponent } from './pages/todo/todo.component';
import { BoxDashboardComponent } from './pages/box-dashboard/box-dashboard.component';
import { MyMoviesComponent } from './pages/my-movies/my-movies.component';
import { SearchImdbMovieComponent } from './pages/search-imdb-movie/search-imdb-movie.component';


const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    component: AppLayoutComponent,
    children: [
      { path: 'todo/:id', component: TodoComponent },
      { path: 'box-dashboard/:id', component: BoxDashboardComponent },
      { path: 'my-movies', component: MyMoviesComponent },
      { path: 'search-imdb-movies', component: SearchImdbMovieComponent }
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
