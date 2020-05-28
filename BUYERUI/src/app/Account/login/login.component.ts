import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Buyer } from 'src/app/Models/buyer';
import { Token } from 'src/app/Models/token';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  submitted=false;
  userForm:FormGroup;
  buyer:Buyer;
  token:Token;
  constructor(private frombuilder:FormBuilder,private service:UserService,private route:Router) { }

  ngOnInit() {
    this.userForm=this.frombuilder.group({
      username:['',[Validators.required,Validators.pattern("^[A-Za-z]{0,}$")]],
      password:['',[Validators.required,Validators.pattern("^[A-Za-z]{7,}[!@#$%^&*]")]]
    });
  }
  onSubmitLogin(){
    this.submitted=true;
      
    if(this.userForm.invalid){
     return;
    }
      else {
        this.token=new Token();
        this.buyer=new Buyer();
        let username=this.userForm.value['username']
        let password=this.userForm.value['password']
      this.service.BuyerLogin(username,password).subscribe(res=>{this.token=res,console.log(this.token)
        if(this.token.message=="Success")
            {
              alert("welcome")
       console.log(this.token)
          localStorage.setItem("token",this.token.token);
          localStorage.setItem("Buyerid",this.token.buyerid.toString());
          this.route.navigateByUrl('/buyer')
            }
            else{
              alert("invalid username or password")
              this.onReset();
            }
      });
    }
   }
    
    get f(){return this.userForm.controls;}
    onReset()
    {
      this.submitted=false;
      this.userForm.reset();
    }
}
