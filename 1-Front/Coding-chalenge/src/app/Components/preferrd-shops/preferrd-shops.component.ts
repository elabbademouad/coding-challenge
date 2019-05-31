import { Component, OnInit } from "@angular/core";
import { Shop } from "src/app/Model/shop";
import { ShopActionEnum } from "src/app/Enums/shop-action-enum";
import { ShopService } from "src/app/Services/Shop/shop.service";
import { ShopAction } from "src/app/Model/shop-action";

@Component({
  selector: "app-preferrd-shops",
  templateUrl: "./preferrd-shops.component.html",
  styleUrls: ["./preferrd-shops.component.css"]
})
export class PreferrdShopsComponent implements OnInit {
  loaded: boolean;
  shops: Array<Shop>;
  actions: Array<ShopActionEnum>;
  constructor(private _shopService: ShopService) {
    this.actions = [ShopActionEnum.Remove];
    this.shops = [];
  }
  ngOnInit() {
    this._shopService.getPreferredShops().subscribe((data: Array<Shop>) => {
      this.shops = data;
      this.loaded = true;
    });
  }

  /**
   * handle action click event
   * @param  event ShopAction
   */
  handleActionClick(event: ShopAction) {
    if (event.action == ShopActionEnum.Remove) {
      this._shopService
        .removeShopfromPreferred(event.item.id)
        .subscribe((response: boolean) => {
          if (response) {
            this.shops = this.shops.filter(s => {
              return s.id !== event.item.id;
            });
          }
        });
    }
  }
}
