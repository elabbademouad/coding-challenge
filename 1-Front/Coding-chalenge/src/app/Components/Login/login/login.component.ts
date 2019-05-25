import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/Authentication/authentication.service';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/Model/login-request';
import { AuthenticationResponse } from 'src/app/Model/authentication-response';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  login:LoginRequest
  constructor(private _authService:AuthenticationService,
              public route:Router,) { 
        this.login=new LoginRequest();
  }
  handleLoginClick(){
    this._authService.Login(this.login)
      .subscribe((data:AuthenticationResponse)=>{
          if(data.isSuccess){
            alert(data.message);
          }
          else{
            alert(data.message);
          }
      });
  }
}
