import { Injectable } from '@angular/core';
import { BaseService } from '../BaseService/base.service';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from 'src/app/Model/login-request';
import { AuthenticationResponse } from 'src/app/Model/authentication-response';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {

  loginApi:string ="api/authentication/login"
  constructor(private _http:HttpClient) {
    super();
  }

  public Login(loginRequest:LoginRequest){
    this.setCredentials(loginRequest);
    return this._http.post<AuthenticationResponse>(this.BaseUrl+this.loginApi,loginRequest);
  }
}
