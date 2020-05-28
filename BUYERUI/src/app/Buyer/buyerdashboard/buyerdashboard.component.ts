import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ItemsService } from 'src/app/services/items.service';

@Component({
  selector: 'app-buyerdashboard',
  templateUrl: './buyerdashboard.component.html',
  styleUrls: ['./buyerdashboard.component.css']
})
export class BuyerdashboardComponent implements OnInit {
  count:number;
  username:string;
    constructor(private route:Router,private service:ItemsService) {
      if(localStorage.getItem('Buyerid'))
      {
        let bid=Number(localStorage.getItem('Buyerid'));
        this.service.GetCount(bid).subscribe(res=>{
          this.count=res;
          console.log(this.count);
        })
      }
      else 
      {
        alert(' please login in first');
        this.route.navigateByUrl('/home/login');
      }
     }
  
  ngOnInit() {
  }
  Logout(){
    this.route.navigateByUrl('home');
  }
}
