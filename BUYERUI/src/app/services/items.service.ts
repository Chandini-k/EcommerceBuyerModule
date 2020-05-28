import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Purchasehistory } from '../Models/purchasehistory';
import { Cart } from '../Models/cart';
import { Items } from '../Models/items';
const Requestheaders={headers:new HttpHeaders({
  'Content-Type':'application/json',
  'Authorization':'Bearer'+localStorage.getItem('token')
})}

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  constructor(private http:HttpClient) { }
  url2:string='http://localhost:49190/Items/'
  public SearchItems(name:string):Observable<any>
  {
    return this.http.get<any>(this.url2+'SearchItems/'+name,Requestheaders)
  }
  public BuyItem(purchase:Purchasehistory):Observable<any>{
    return this.http.post<any>(this.url2+'BuyItem',JSON.stringify(purchase),Requestheaders)
  }
  public GetCategory():Observable<any>{
    return this.http.get<any>(this.url2+'GetCategory',Requestheaders);
  }
  public PurchaseHistory(buyerid:number):Observable<any>{
    return this.http.get<any>(this.url2+'PurchaseHistory/'+buyerid,Requestheaders);
  }
  public AddToCart(cart:Cart):Observable<any>{
    return this.http.post<any>(this.url2+'AddtoCart',JSON.stringify(cart),Requestheaders);
  }
  public DeleteCart(id:number):Observable<any>{
    return this.http.delete<any>(this.url2+'DeleteCart/'+id,Requestheaders);
  }
  public GetCarts(id:number):Observable<any>{
    return this.http.get<any>(this.url2+'GetCart/'+id,Requestheaders);
  }
  public GetCount(buyerId:number):Observable<any>{
    return this.http.get<any>(this.url2+'GetCount/'+buyerId,Requestheaders);
  }
  public GetCartItem(id:number):Observable<any>{
    return this.http.get<any>(this.url2+'GetCartItem/'+id,Requestheaders);
  }
}
