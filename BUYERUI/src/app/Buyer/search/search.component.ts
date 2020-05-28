import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Items } from 'src/app/Models/items';
import { Cart } from 'src/app/Models/cart';
import { ItemsService } from 'src/app/services/items.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  itemform:FormGroup;
  submitted=false;
  list:Items[]=[];
  item:Items
  num:number;
  cart:Cart;
  id:number;
id2:number;
  constructor(private builder:FormBuilder,private service:ItemsService,private route:Router) {
 }

  ngOnInit() {
    this.itemform=this.builder.group({
      productName:['']
    })
   
  }


  Search()
  {
    
    this.service.SearchItems(this.itemform.value['productName']).subscribe(res=>
      {
        
       this.list=res;
        console.log(this.list);
      },
      err=>{
        console.log(err);
      }
      )
  }
  Buy(items:Items){
    console.log(items);
    localStorage.setItem('items',JSON.stringify(items));
    this.route.navigateByUrl('/buyer/buyitem');
  }
  AddtoCart(items:Items){
    console.log(items);
   this.cart=new Cart();
   this.cart.cartId=Math.round(Math.random()*1000);
   this.cart.itemName=items.productName;
   this.cart.buyerId=Number(localStorage.getItem('Buyerid'));
   this.cart.stockno=items.stockno;
   this.cart.price=items.price;
   this.cart.itemId=items.productId;
   this.cart.description=items.description;
   this.cart.remarks=items.remarks;
   this.cart.imageName=items.imageName;
   console.log(this.cart);
   this.service.AddToCart(this.cart).subscribe(res=>{
     console.log("Record added To Cart");
     alert('Added To Cart');
     this.route.navigateByUrl('/buyer/search');
   })
  }
  Logout(){
    this.route.navigateByUrl('home');
  }
}
