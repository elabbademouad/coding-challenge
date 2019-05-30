import { Component, OnInit } from "@angular/core";
import { Shop } from "src/app/Model/shop";
import { ShopActionEnum } from "src/app/Enums/shop-action-enum";
import { ShopAction } from "src/app/Model/shop-action";
import { ShopService } from 'src/app/Services/Shop/shop.service';

@Component({
  selector: "app-nearby-shops",
  templateUrl: "./nearby-shops.component.html",
  styleUrls: ["./nearby-shops.component.css"]
})
export class NearbyShopsComponent implements OnInit {
  loaded:boolean;
  shops: Array<Shop>;
  actions: Array<ShopActionEnum>;
  constructor(private _shopService:ShopService) {
    this.actions = [ShopActionEnum.Like, ShopActionEnum.Dislike];
    this.shops=[];
  }
 ngOnInit(){
   console.log("dddd");
    this._shopService.getNearbyShops()
      .subscribe((data:Array<Shop>)=>{
        console.log(data);
          this.shops=data;
          this.loaded=true;
      })
 }
  handleActionClick(event: ShopAction) {
    switch (event.action) {
      case ShopActionEnum.Like:
        console.log(ShopActionEnum.Like);
        break;
      case ShopActionEnum.Dislike:
        console.log(ShopActionEnum.Dislike);
        break;
    }
  }
}
