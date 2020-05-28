import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Account/home/home.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { BuyerdashboardComponent } from './Buyer/buyerdashboard/buyerdashboard.component';
import { SearchComponent } from './Buyer/search/search.component';
import { ViewcartComponent } from './Buyer/viewcart/viewcart.component';
import { PurchasehistoryComponent } from './Buyer/purchasehistory/purchasehistory.component';
import { ViewprofileComponent } from './Buyer/viewprofile/viewprofile.component';
import { BuyitemComponent } from './Buyer/buyitem/buyitem.component';
const routes: Routes = [
  {path:'home',component:HomeComponent,children:[
       {path:'login',component:LoginComponent},
       {path:'register',component:RegisterComponent}]},
       {path:'buyer',component:BuyerdashboardComponent,children:[
        {path:'search',component:SearchComponent},
        {path:'viewcart',component:ViewcartComponent},
        {path:'purchasehistory',component:PurchasehistoryComponent},
        {path:'viewprofile',component:ViewprofileComponent},
        {path:'buyitem',component:BuyitemComponent}]},
        {path:'',redirectTo:'home',pathMatch:'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
