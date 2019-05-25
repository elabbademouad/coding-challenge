import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-google-map',
  templateUrl: './google-map.component.html',
  styleUrls: ['./google-map.component.css']
})
export class GoogleMapComponent {

  @Output()
  onChangePosition:EventEmitter<string>;
  lat: number = 34.65323;
  lng: number = -1.8957377000000002;
  constructor() {
    this.onChangePosition=new EventEmitter<string>();
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position)=>{
       this.lat= position.coords.latitude ; 
       this.lng=position.coords.longitude; 
       this.onChangePosition.emit(this.lat+","+this.lng)
      });
    }
   }

  handleChangePosition(event:any){
    this.lat=event.coords.lat;
    this.lng=event.coords.lng;
    this.onChangePosition.emit(this.lat+","+this.lng)
 }

}
