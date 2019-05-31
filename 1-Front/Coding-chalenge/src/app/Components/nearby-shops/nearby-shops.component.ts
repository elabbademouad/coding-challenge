import { Component, OnInit } from "@angular/core";
import { Shop } from "src/app/Model/shop";
import { ShopActionEnum } from "src/app/Enums/shop-action-enum";
import { ShopAction } from "src/app/Model/shop-action";
import { ShopService } from "src/app/Services/Shop/shop.service";
import { ShopStatusEnum } from "src/app/Enums/shop-status-enum";

@Component({
  selector: "app-nearby-shops",
  templateUrl: "./nearby-shops.component.html",
  styleUrls: ["./nearby-shops.component.css"]
})
export class NearbyShopsComponent implements OnInit {
  loaded: boolean;
  shops: Array<Shop>;
  actions: Array<ShopActionEnum>;
  constructor(private _shopService: ShopService) {
    this.actions = [ShopActionEnum.Like, ShopActionEnum.Dislike];
    this.shops = [];
  }
  ngOnInit() {
    this._shopService.getNearbyShops().subscribe((data: Array<Shop>) => {
      this.shops = data;
      this.loaded = true;
    });
  }

  /**
   * handle action click event
   * @param  event ShopAction
   */
  handleActionClick(event: ShopAction) {
    switch (event.action) {
      case ShopActionEnum.Like:
        this._shopService
          .likeOrDislike(event.item.id, ShopStatusEnum.Like)
          .subscribe((response: boolean) => {
            if (response) {
              this.shops = this.shops.filter(s => {
                return s.id !== event.item.id;
              });
            }
          });
        break;
      case ShopActionEnum.Dislike:
        this._shopService
          .likeOrDislike(event.item.id, ShopStatusEnum.Dislike)
          .subscribe((response: boolean) => {
            if (response) {
              this.shops = this.shops.filter(s => {
                return s.id !== event.item.id;
              });
            }
          });
        break;
    }
  }
}
