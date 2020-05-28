import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BuyerdashboardComponent } from './Buyer/buyerdashboard/buyerdashboard.component';
import { SearchComponent } from './Buyer/search/search.component';
import {HttpClientModule} from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BuyitemComponent } from './Buyer/buyitem/buyitem.component';
import { PurchasehistoryComponent } from './Buyer/purchasehistory/purchasehistory.component';
import { ViewcartComponent } from './Buyer/viewcart/viewcart.component';
import { ViewprofileComponent } from './Buyer/viewprofile/viewprofile.component';
import { HomeComponent } from './Account/home/home.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';



@NgModule({
  declarations: [
    AppComponent,
    BuyerdashboardComponent,
    SearchComponent,
    BuyitemComponent,
    PurchasehistoryComponent,
    ViewcartComponent,
    ViewprofileComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent
   

    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
