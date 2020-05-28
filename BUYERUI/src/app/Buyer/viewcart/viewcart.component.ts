import { Component, OnInit } from '@angular/core';
import { ItemsService } from 'src/app/services/items.service';
import { Router } from '@angular/router';
import { Items } from 'src/app/Models/items';
import { Cart } from 'src/app/Models/cart';

@Component({
  selector: 'app-viewcart',
  templateUrl: './viewcart.component.html',
  styleUrls: ['./viewcart.component.css']
})
export class ViewcartComponent implements OnInit {
  cartlist:Cart[]=[];
  item:Items;
  id:number;
    constructor(private route:Router,private service:ItemsService) {
     this.id=Number(localStorage.getItem('Buyerid'))
     this.View();
     }
     View()
     {
      this.service.GetCarts(this.id).subscribe(res=>{
        this.cartlist=res;
        console.log(this.cartlist);
      })
     }
    ngOnInit() {
    }
  BuyNow(items:Items){
        console.log(items);
        this.item=items;
        localStorage.setItem('items',JSON.stringify(this.item));
        this.route.navigateByUrl('/buyer/buyitem');
  }
  Remove(cartId:number)
  {
    console.log(cartId);
    let id=cartId;
    this.service.DeleteCart(id).subscribe(res=>{
      console.log('Item Removed from Cart');
      alert('Item Removed from Cart');
      this.View();
    })
  }
  Logout(){
    this.route.navigateByUrl('home');
  }
}
