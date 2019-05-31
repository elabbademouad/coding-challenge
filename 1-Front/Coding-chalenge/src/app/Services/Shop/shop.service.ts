import { Injectable } from "@angular/core";
import { BaseService } from "../BaseService/base.service";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Shop } from "src/app/Model/shop";
import { ShopStatusEnum } from "src/app/Enums/shop-status-enum";

@Injectable({
  providedIn: "root"
})
export class ShopService extends BaseService {
  constructor(_http: HttpClient) {
    super(_http);
  }

  private getNearbyShopsApi: string = "api/shop/nearbyShops";
  /**
   * Get : get nearby shops
   * @returns Observable<Shop>
   */
  public getNearbyShops(): Observable<Array<Shop>> {
    return this.httpGet(this.getNearbyShopsApi);
  }

  private getPreferredShopsApi: string = "api/shop/preferredShops";
  /**
   * Get : get nearby shops
   * @returns Observable<Shop>
   */
  public getPreferredShops(): Observable<Array<Shop>> {
    return this.httpGet(this.getPreferredShopsApi);
  }

  private likeOrDislikeShopApi: string = "api/shop/LikeOrDislike";
  /**
   * Post : like or dislike shop
   * @returns Observable<boolean>
   */
  public likeOrDislike(
    shopId: number,
    status: ShopStatusEnum
  ): Observable<boolean> {
    return this.httpPost(this.likeOrDislikeShopApi, {
      shopId: shopId,
      status: status
    });
  }

  private removeShopFromPreferredApi: string =
    "api/shop/RemoveShopfromPreferred";

  /**
   * Post : remove shop from preferred shops
   * @returns Observable<boolean>
   */
  public removeShopfromPreferred(shopId: number): Observable<boolean> {
    return this.httpPost(this.removeShopFromPreferredApi, shopId);
  }
}
