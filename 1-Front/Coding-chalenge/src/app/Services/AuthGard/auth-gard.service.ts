import { Injectable } from "@angular/core";
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router
} from "@angular/router";
import { Observable } from "rxjs";
import { AuthenticationService } from "../Authentication/authentication.service";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})

/**
 * implementation of CanActive interface for routes authorization handler
 */
export class AuthGardService implements CanActivate {
  constructor(
    private _authService: AuthenticationService,
    private _router: Router
  ) {}
  canActivate(
    _route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    this._authService.getCredentials();
    return this._authService.Login(this._authService.getCredentials()).pipe(
      map(response => {
        if (!response.isSuccess) {
          this._router.navigate(["login"]);
          this._authService.setCurrentUser(null);
          return false;
        }
        this._authService.setCurrentUser({
          email: response.user.email,
          password: response.user.password
        });
        return true;
      })
    );
  }
}
