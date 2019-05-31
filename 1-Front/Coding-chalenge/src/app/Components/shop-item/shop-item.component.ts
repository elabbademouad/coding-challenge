import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Shop } from "src/app/Model/shop";
import { ShopAction } from "src/app/Model/shop-action";
import { ShopActionEnum } from "src/app/Enums/shop-action-enum";
import { BaseService } from "src/app/Services/BaseService/base.service";

@Component({
  selector: "app-shop-item",
  templateUrl: "./shop-item.component.html",
  styleUrls: ["./shop-item.component.css"]
})
export class ShopItemComponent {
  constructor() {
    this.onClickAction = new EventEmitter<ShopAction>();
    this.baseUrl = BaseService.BaseUrl;
  }
  @Input()
  shop: Shop;
  @Input()
  actions: Array<ShopActionEnum>;
  @Output()
  onClickAction: EventEmitter<ShopAction>;
  baseUrl: string;

  /**
   * handle action click event
   * @param  action ShopActionEnum
   */
  handleActionClick(action: ShopActionEnum) {
    let data = new ShopAction();
    data.action = action;
    data.item = this.shop;
    this.onClickAction.emit(data);
  }
}
