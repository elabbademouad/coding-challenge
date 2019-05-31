import { Component } from "@angular/core";
import { AuthenticationService } from "src/app/Services/Authentication/authentication.service";
import { RegisterRequest } from "src/app/Model/register-request";
import { AuthenticationResponse } from "src/app/Model/authentication-response";
import { Router } from "@angular/router";
import { Position } from "src/app/Model/Position";
@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent {
  register: RegisterRequest;
  confirmPass: string;
  regiterErrorMessage: String;
  constructor(
    private _authService: AuthenticationService,
    private router: Router
  ) {
    this.register = new RegisterRequest();
  }

  /**
   * handle button register click event
   */
  handleClickRegister() {
    this._authService
      .Register(this.register)
      .subscribe((response: AuthenticationResponse) => {
        if (response.isSuccess) {
          this.regiterErrorMessage = "";
          this.router.navigate(["login"]);
        } else {
          this.regiterErrorMessage = response.message;
        }
      });
  }

  /**
   * handle change map position event
   */
  handleChangePosition(event: Position) {
    this.register.position = event;
  }
}
