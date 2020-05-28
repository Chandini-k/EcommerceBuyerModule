import { Component, OnInit } from '@angular/core';
import { Buyer } from 'src/app/Models/buyer';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  list:Buyer[]=[];
  buyer:Buyer;
  submitted=false;
  buyerForm:FormGroup;
    constructor(private frombuilder:FormBuilder,private service:UserService,private route:Router) { }
  
    ngOnInit() {
      this.buyerForm=this.frombuilder.group({
        userName:['',[Validators.required,Validators.pattern("^[A-Za-z]{0,}$")]],
        password:['',[Validators.required,Validators.pattern("^[A-Za-z]{7,}[!@#$%^&*]")]],
        mobileNo:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
        emailId:['',Validators.required],
        dateTime:['',Validators.required]
      });
    }
    onSubmitBuyer(){
      this.submitted=true;
      if(this.buyerForm.invalid){
       return;
      }
        else{
          this.buyer=new Buyer();
        this.buyer.buyerId=Math.floor(Math.random()*1000);
        this.buyer.userName=this.buyerForm.value["userName"];
        this.buyer.password=this.buyerForm.value["password"];
        this.buyer.mobileNo=this.buyerForm.value["mobileNo"];
        this.buyer.emailId=this.buyerForm.value["emailId"];
        this.buyer.dateTime=this.buyerForm.value["dateTime"];
        this.list.push(this.buyer);
        console.log(this.buyer)
       this.service.BuyerRegister(this.buyer).subscribe(res=>
        {
            this.route.navigateByUrl('/home/login')
        },err=>{
          console.log(err)
        })
        }
      }
      get f(){return this.buyerForm.controls;}
      onReset()
      {
        this.submitted=false;
        this.buyerForm.reset();
      }
}
