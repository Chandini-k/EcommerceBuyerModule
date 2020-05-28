import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Items } from 'src/app/Models/items';
import { Purchasehistory } from 'src/app/Models/purchasehistory';
import { Router } from '@angular/router';
import { BuyerService } from 'src/app/services/buyer.service';
import { ItemsService } from 'src/app/services/items.service';


@Component({
  selector: 'app-buyitem',
  templateUrl: './buyitem.component.html',
  styleUrls: ['./buyitem.component.css']
})
export class BuyitemComponent implements OnInit {
  payform:FormGroup;
  pay:boolean=false;
  items:Items;
  list:Items[]=[];
  id:string;
  id1:number;
  today=new Date();
  purchase:Purchasehistory;
  disabled:boolean=false;
  total:number;
  submitted=false;
    constructor(private fromb:FormBuilder,private route:Router,private service:ItemsService, router:Router) {
      this.items=JSON.parse(localStorage.getItem('items'));
      this.list.push(this.items)
       console.log(this.list)
    }  
     get f()
    {
      return this.payform.controls;
    }
  
    ngOnInit() {
      this.payform=this.fromb.group({
        cardnumber:['',[Validators.required,Validators.pattern("[0-9]{16}")]],
        cvv:['',[Validators.required,Validators.pattern("[0-9]{3}")]],
        select:['',Validators.required],
        transactionType:['',Validators.required],
        remarks:['',Validators.required],
        noOfItems:['',[Validators.required,Validators.min(1)]],
        total:['',Validators.required]
  
      })
      
    }
  card(){
   
    this.id=this.payform.value['transactionType']
    
    if(this.id=='Cash'){
      this.pay=false
    }
    else{
      this.pay=true;
      
    }
    
  
  }
  key(event){
   this.id1=Number(this.payform.value['noOfItems'])
    
      console.log(this.total=this.id1*this.items.price);
    
      
  }
  
   
    onsubmit()
    {
    this.submitted=true;
    if(this.payform.valid){
     return this.Buy()
    }
    
  }
  
  Buy(){
    this.purchase=new Purchasehistory();
    this.purchase.purchaseId=Number(Math.floor(Math.random()*1000));
    this.purchase.buyerId=Number(localStorage.getItem('Buyerid'));
    this.purchase.transactionType=this.payform.value['transactionType']
    this.purchase.itemId=this.items.productId;
    this.purchase.itemName=this.items.productName;
    this.purchase.noOfItems=this.payform.value['noOfItems']
    this.purchase.dateTime=this.today;
    this.purchase.remarks=this.payform.value['remarks']
    this.purchase.transactionStatus="paid";
    console.log(this.purchase);
  
    this.service.BuyItem(this.purchase).subscribe(res=>{alert("payment Success"),this.route.navigateByUrl('/buyer/vieworders')
    
    })
  }
  }
