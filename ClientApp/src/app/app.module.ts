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

@NgModule({
  declarations: [
    AppLayoutComponent,
    MainHeaderComponent,
    MainSidebarComponent,
    MainFooterComponent,
    ControlSidebarComponent,
    LoginComponent,
    NoneLayoutComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [NoneLayoutComponent]
})
export class AppModule { }
