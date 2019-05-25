import { HttpHeaders } from '@angular/common/http'
import { LoginRequest } from 'src/app/Model/login-request';

export class BaseService {

  constructor() { }

  BaseUrl:string="http://localhost:5000/";

  protected getHttpHeader():HttpHeaders{
    let credentials:LoginRequest=JSON.parse(localStorage.getItem("Credentials"));
    let headers = new HttpHeaders();
    headers = headers.append("Authorization", "Basic " + btoa(credentials.email+":"+credentials.password));
    headers = headers.append("Content-Type", "application/x-www-form-urlencoded");
    return headers;
  }

  protected setCredentials(loginRequest:LoginRequest){
    localStorage.setItem("Credentials",JSON.stringify(loginRequest));
  }

  protected clearCredentials(){
    localStorage.removeItem("Credentials");
  }

}
