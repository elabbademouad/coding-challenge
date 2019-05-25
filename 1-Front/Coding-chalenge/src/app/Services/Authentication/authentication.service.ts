import { Injectable } from '@angular/core';
import { BaseService } from '../BaseService/base.service';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from 'src/app/Model/login-request';
import { AuthenticationResponse } from 'src/app/Model/authentication-response';
import { RegisterRequest } from 'src/app/Model/register-request';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {

  private loginApi:string ="api/authentication/login";
  private registerApi:string ="api/authentication/register";
  constructor(_http:HttpClient) {
    super(_http);
  }

  public Login(loginRequest:LoginRequest){
    this.setCredentials(loginRequest);
    return this.httpPost<AuthenticationResponse>(this.loginApi,loginRequest,false);
  }

  public Register(registerRequest:RegisterRequest){
    return this.httpPost<AuthenticationResponse>(this.registerApi,registerRequest,false);
  }
}
