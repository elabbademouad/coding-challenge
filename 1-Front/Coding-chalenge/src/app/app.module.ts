import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { FormsModule} from '@angular/forms'
import { Routes,RouterModule } from '@angular/router';
import { RegisterComponent } from './Components/register/register.component';
import { AgmCoreModule } from '@agm/core';
import { GoogleMapComponent } from './Components/google-map/google-map.component';
import { NavComponent } from './Components/nav/nav.component';
import { ShopItemComponent } from './Components/shop-item/shop-item.component';
import { NearbyShopsComponent } from './Components/nearby-shops/nearby-shops.component';
import { AuthGardService} from './Services/AuthGard/auth-gard.service'
const appRoute:Routes=[
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"nearbyshops",component:NearbyShopsComponent,canActivate:[AuthGardService]},
  {path:"",component:NearbyShopsComponent,canActivate:[AuthGardService]},
]
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    GoogleMapComponent,
    NavComponent,
    ShopItemComponent,
    NearbyShopsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoute,{enableTracing:false}),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCF4CyjdmY3Ft7SsZFh2JvvHLrOMMQ54Q8'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
