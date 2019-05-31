import { Component } from "@angular/core";
import { AuthenticationService } from "src/app/Services/Authentication/authentication.service";
import { Router } from "@angular/router";
import { LoginRequest } from "src/app/Model/login-request";
import { AuthenticationResponse } from "src/app/Model/authentication-response";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent {
  login: LoginRequest;
  message: string;
  constructor(
    private _authService: AuthenticationService,
    private _router: Router
  ) {
    this.login = new LoginRequest();
  }

  /**
   * handle button login click event
   */
  handleLoginClick() {
    this._authService
      .Login(this.login)
      .subscribe((data: AuthenticationResponse) => {
        if (data.isSuccess) {
          this._router.navigate([""]);
          this.message = "";
        } else {
          this.message = data.message;
        }
      });
  }
}
