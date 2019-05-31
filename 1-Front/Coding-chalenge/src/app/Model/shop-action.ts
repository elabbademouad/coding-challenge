import { ShopActionEnum } from "../Enums/shop-action-enum";
import { Shop } from "./shop";

/**
 * shop action
 *
 */
export class ShopAction {
  action: ShopActionEnum;
  item: Shop;
}
