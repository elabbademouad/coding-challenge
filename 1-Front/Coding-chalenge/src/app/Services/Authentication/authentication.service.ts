import { Injectable } from "@angular/core";
import { BaseService } from "../BaseService/base.service";
import { HttpClient } from "@angular/common/http";
import { LoginRequest } from "src/app/Model/login-request";
import { AuthenticationResponse } from "src/app/Model/authentication-response";
import { RegisterRequest } from "src/app/Model/register-request";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class AuthenticationService extends BaseService {
  constructor(_http: HttpClient) {
    super(_http);
  }

  private loginApi: string = "api/authentication/login";
  /**
   * Post : Login
   * @param loginRequest LoginRequest
   * @returns Observable<AuthenticationResponse>
   */
  public Login(loginRequest: LoginRequest) {
    this.setCredentials(loginRequest);
    return this.http.post<AuthenticationResponse>(
      this.BaseUrl + this.loginApi,
      loginRequest
    );
  }

  private registerApi: string = "api/authentication/register";
  /**
   * Post : registration
   * @param registerRequest RegisterRequest
   * @returns Observable<AuthenticationResponse>
   */
  public Register(registerRequest: RegisterRequest): Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(
      this.BaseUrl + this.registerApi,
      registerRequest
    );
  }
}
