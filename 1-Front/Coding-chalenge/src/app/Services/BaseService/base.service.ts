import { HttpHeaders,HttpClient } from '@angular/common/http'
import { LoginRequest } from 'src/app/Model/login-request';
import { Observable } from 'rxjs';
import { environment} from '../../../environments/environment'

export class BaseService {

  private _http:HttpClient;
  protected BaseUrl:string;

  constructor(http:HttpClient) {
    this._http=http;
    this.BaseUrl=environment.baseUrl;
   }

  protected createHttpHeaders():HttpHeaders{
    let credentials:LoginRequest=JSON.parse(localStorage.getItem("Credentials"));
    if(credentials===null){
      credentials=new LoginRequest();
    }
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

  protected getCredentials():LoginRequest{
    return JSON.parse(localStorage.getItem("Credentials"));
  }

  protected httpGet<T>(url:string,needCredentials:boolean=true):Observable<T>{
    if(!needCredentials){
      return this._http.get<T>(this.BaseUrl+url);
    }
    return this._http.get<T>(this.BaseUrl+url,{headers:this.createHttpHeaders()});
  }

  protected httpPost<T>(url:string,body:any,needCredentials:boolean=true):Observable<T>{
    if(!needCredentials){
    return this._http.post<T>(this.BaseUrl+url,body);
    }
    return this._http.post<T>(this.BaseUrl+url,body,{headers:this.createHttpHeaders()});
  }

}
