import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Shop } from "src/app/Model/shop";
import { ShopAction } from "src/app/Model/shop-action";
import { ShopActionEnum } from "src/app/Enums/shop-action-enum";

@Component({
  selector: "app-shop-item",
  templateUrl: "./shop-item.component.html",
  styleUrls: ["./shop-item.component.css"]
})
export class ShopItemComponent implements OnInit {
  constructor() {
    this.onClickAction=new  EventEmitter<ShopAction>();
  }
  @Input()
  shop: Shop;
  @Input()
  actions: Array<ShopActionEnum>;
  @Output()
  onClickAction: EventEmitter<ShopAction>;
  ngOnInit() {
    this.actions = [ShopActionEnum.Like, ShopActionEnum.Dislike];
  }
  handleActionClick(action: ShopActionEnum) {
    let data = new ShopAction();
    data.action = action;
    data.item = this.shop;
    this.onClickAction.emit(data);
  }
}
