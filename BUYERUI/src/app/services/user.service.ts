import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Buyer } from '../Models/buyer';
const Requestheaders={headers:new HttpHeaders({
  'Content-Type':'application/json',
  'Authorization':'Bearer'+localStorage.getItem('token')
})}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }
  url:string='http://localhost:49190/User/'
  public BuyerRegister(buyer:Buyer):Observable<any>
  {
     
     return this.http.post<any>(this.url+'Register',JSON.stringify(buyer),Requestheaders)
  }
  public BuyerLogin(username:string,password:string):Observable<any>
  {
    return this.http.get<any>(this.url+'Login/'+username+'/'+password,Requestheaders)
  }
}
