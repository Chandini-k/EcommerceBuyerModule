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
export class BuyerService {

  constructor(private http:HttpClient) { }
  url1:string='http://localhost:49190/Buyer/'
  public GetBuyerProfile(bid:number):Observable<any>
  {
    return this.http.get<any>(this.url1+'Profile/'+bid,Requestheaders)
  }
  public EditBuyerProfile(buyer:Buyer):Observable<any>
  {
    return this.http.put<any>(this.url1+'EditProfile',buyer,Requestheaders)
  }
}
