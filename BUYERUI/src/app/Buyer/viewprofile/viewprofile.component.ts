import { Component, OnInit } from '@angular/core';
import { Buyer } from 'src/app/Models/buyer';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Items } from 'src/app/Models/items';
import { BuyerService } from 'src/app/services/buyer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-viewprofile',
  templateUrl: './viewprofile.component.html',
  styleUrls: ['./viewprofile.component.css']
})
export class ViewprofileComponent implements OnInit {
  buyer:Buyer
  buyerForm:FormGroup;
  id:number;
  item:Items;
      constructor(private frombuilder:FormBuilder,private service:BuyerService,private route:Router) {
        this.id=JSON.parse(localStorage.getItem('Buyerid')) ;
       }
    
      ngOnInit() {
        this.buyerForm=this.frombuilder.group({
          buyerId:[''],
          userName:[''],
          password:[''],
          dateTime:[''],
          mobileNo:[''],
          emailId:['']
        })
        this.buyerprofile()
      }
      buyerprofile()
      {
        this.service.GetBuyerProfile(this.id).subscribe(res=>  
          {
            
            this.buyer=res;
            console.log(this.buyer);
            this.buyerForm.patchValue({
              buyerId:Number(this.buyer.buyerId),
              userName:this.buyer.userName,
              emailId:this.buyer.emailId,
              password:this.buyer.password,
              mobileNo:this.buyer.mobileNo,
              
            })
           })
      }
      
      Edit()
      {
        this.buyer=new Buyer();
        this.buyer.buyerId=Number(this.buyerForm.value["buyerId"]),
        this.buyer.userName=this.buyerForm.value["userName"],
        this.buyer.emailId=this.buyerForm.value["emailId"],
        this.buyer.password=this.buyerForm.value["password"],
        this.buyer.mobileNo=this.buyerForm.value["mobileNo"],
        this.service.EditBuyerProfile(this.buyer).subscribe(res=>{console.log(this.buyer),alert("updated succesfully"),this.buyerprofile()},err=>{
          console.log(err)
        })
      }
      Logout(){
        this.route.navigateByUrl('home');
      }
    }
