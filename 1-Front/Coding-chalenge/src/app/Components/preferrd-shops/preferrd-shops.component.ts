import { Component, OnInit } from '@angular/core';
import { Shop } from 'src/app/Model/shop';
import { ShopActionEnum } from 'src/app/Enums/shop-action-enum';
import { ShopService } from 'src/app/Services/Shop/shop.service';
import { ShopAction } from 'src/app/Model/shop-action';

@Component({
  selector: 'app-preferrd-shops',
  templateUrl: './preferrd-shops.component.html',
  styleUrls: ['./preferrd-shops.component.css']
})
export class PreferrdShopsComponent implements OnInit {

  loaded:boolean;
  shops: Array<Shop>;
  actions: Array<ShopActionEnum>;
  constructor(private _shopService:ShopService) {
    this.actions = [ShopActionEnum.Remove];
    this.shops=[];
  }
 ngOnInit(){
   console.log("dddd");
    this._shopService.getPreferredShops()
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
