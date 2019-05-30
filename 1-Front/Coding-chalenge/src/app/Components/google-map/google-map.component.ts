import { Component, EventEmitter, Output } from "@angular/core";
import { Position } from 'src/app/Model/Position';

@Component({
  selector: "app-google-map",
  templateUrl: "./google-map.component.html",
  styleUrls: ["./google-map.component.css"]
})
export class GoogleMapComponent {
  @Output()
  onChangePosition: EventEmitter<Position>;
  position:Position;
  lat: number = 34.65323;
  lng: number = -1.8957377000000002;
  constructor() {
    this.position=new Position();
    this.position.latitude=34.65323;
    this.position.longitude=-1.8957377000000002;
    this.onChangePosition = new EventEmitter<Position>();
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(data => {
        this.position.latitude = data.coords.latitude;
        this.position.longitude = data.coords.longitude;
        this.onChangePosition.emit(this.position);
      });
    }
  }

  /**
   * handle map position changed
   * @param {any}event current map position
   */
  handleChangePosition(event: any) {
    this.position.latitude = event.coords.latitude;
    this.position.longitude = event.coords.longitude;
    this.onChangePosition.emit(this.position);
  }
}
