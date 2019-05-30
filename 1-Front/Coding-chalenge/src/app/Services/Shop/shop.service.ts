import { Injectable } from "@angular/core";
import { BaseService } from "../BaseService/base.service";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Shop } from "src/app/Model/shop";

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
}
