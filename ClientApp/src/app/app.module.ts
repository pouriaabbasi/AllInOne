import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppLayoutComponent } from './_layouts/app-layout/app-layout.component';
import { MainHeaderComponent } from './_components/main-header/main-header.component';
import { MainSidebarComponent } from './_components/main-sidebar/main-sidebar.component';
import { MainFooterComponent } from './_components/main-footer/main-footer.component';
import { ControlSidebarComponent } from './_components/control-sidebar/control-sidebar.component';
import { LoginComponent } from './pages/login/login.component';
import { NoneLayoutComponent } from './_layouts/none-layout/none-layout.component';
import { RegisterComponent } from './pages/register/register.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { TodoComponent } from './pages/todo/todo.component';
import { JwtInterceptor } from './_helpers/jwt.interceptor';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { BaseComponent } from './_components/base/base.component';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { BoxDashboardComponent } from './pages/box-dashboard/box-dashboard.component';
import { QuestionComponent } from './pages/question/question.component';
import { AnswerQuestionComponent } from './pages/answer-question/answer-question.component';
import { NgbModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { AgGridModule } from 'ag-grid-angular';
import { MyMoviesComponent } from './pages/my-movies/my-movies.component';
import { SearchImdbMovieComponent } from './pages/search-imdb-movie/search-imdb-movie.component';
import { MovieDetailComponent } from './pages/movie-detail/movie-detail.component';

@NgModule({
  declarations: [
    AppLayoutComponent,
    MainHeaderComponent,
    MainSidebarComponent,
    MainFooterComponent,
    ControlSidebarComponent,
    LoginComponent,
    NoneLayoutComponent,
    RegisterComponent,
    TodoComponent,
    BaseComponent,
    BoxDashboardComponent,
    QuestionComponent,
    AnswerQuestionComponent,
    MyMoviesComponent,
    SearchImdbMovieComponent,
    MovieDetailComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    BrowserAnimationsModule,
    NgbModule,
    NgbModalModule,
    ToastrModule.forRoot(),
    AgGridModule.withComponents([])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [NoneLayoutComponent],
  entryComponents: [
    QuestionComponent,
    AnswerQuestionComponent,
    MovieDetailComponent
  ]
})
export class AppModule { }
