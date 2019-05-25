import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/Login/login/login.component';
import { FormsModule} from '@angular/forms'
import { Routes,RouterModule } from '@angular/router';
import { RegisterComponent } from './Components/register/register/register.component';
import { AgmCoreModule } from '@agm/core';
import { GoogleMapComponent } from './Components/googleMap/google-map/google-map.component';
const appRoute:Routes=[
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
]
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    GoogleMapComponent
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
