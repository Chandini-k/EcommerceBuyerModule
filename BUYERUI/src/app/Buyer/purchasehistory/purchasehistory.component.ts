import { Component, OnInit } from '@angular/core';
import { Purchasehistory } from 'src/app/Models/purchasehistory';
import { Items } from 'src/app/Models/items';
import { ItemsService } from 'src/app/services/items.service';

@Component({
  selector: 'app-purchasehistory',
  templateUrl: './purchasehistory.component.html',
  styleUrls: ['./purchasehistory.component.css']
})
export class PurchasehistoryComponent implements OnInit {
  purchase:Purchasehistory[]=[];
  purchase1:Purchasehistory
  items:Items[]=[]
  id:number;
    constructor(private service:ItemsService) { 
   this.id=JSON.parse(localStorage.getItem('Buyerid')),
  
      this.service.PurchaseHistory(this.id).subscribe(res=>
        {
          this.purchase=res;
      console.log(this.purchase);
    },err=>{
      console.log(err)
    })
        }
  
  ngOnInit() {
  }

}
