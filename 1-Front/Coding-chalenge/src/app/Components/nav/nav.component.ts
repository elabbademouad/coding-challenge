import { Component } from "@angular/core";
import { AuthenticationService } from "src/app/Services/Authentication/authentication.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"]
})
export class NavComponent {
  display: boolean = false;
  constructor(
    private _authService: AuthenticationService,
    private _router: Router
  ) {
    _authService.getCurrentUser().subscribe(data => {
      this.display = data!=null;
    });
  }

  /**
   *  handle log out button click event
   */
  handleLogOutClick() {
    this._authService.clearCredentials();
    this.display = false;
    this._router.navigate(["login"]);
  }
}
