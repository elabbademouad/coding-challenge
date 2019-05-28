import { HttpHeaders, HttpClient } from "@angular/common/http";
import { LoginRequest } from "src/app/Model/login-request";
import { Observable, Subject } from "rxjs";
import { environment } from "../../../environments/environment";

export class BaseService {
  protected http: HttpClient;
  protected BaseUrl: string;
  currentUserSubject: Subject<LoginRequest>;

  constructor(http: HttpClient) {
    this.http = http;
    this.BaseUrl = environment.baseUrl;
    this.currentUserSubject = new Subject<LoginRequest>();
  }

  /**
   * create http headers with credentials
   */
  public createHttpHeaders(): HttpHeaders {
    let credentials: LoginRequest = this.getCredentials();
    if (credentials === null) {
      credentials = new LoginRequest();
    }
    let headers = new HttpHeaders();
    headers = headers.append(
      "Authorization",
      "Basic " + btoa(credentials.email + ":" + credentials.password)
    );
    headers = headers.append(
      "Content-Type",
      "application/x-www-form-urlencoded"
    );
    return headers;
  }

  /**
   * save credentials in localstorage
   * @param LoginRequest login infos
   */
  public setCredentials(loginRequest: LoginRequest) {
    localStorage.setItem("Credentials", JSON.stringify(loginRequest));
  }

  /**
   * clear credentials from localstorage
   */
  public clearCredentials() {
    localStorage.removeItem("Credentials");
  }

  /**
   * get credentials from localstorage
   * @returns LoginRequest
   */
  public getCredentials(): LoginRequest {
    let credentials: LoginRequest = JSON.parse(
      localStorage.getItem("Credentials")
    );
    if (credentials === null) {
      credentials = new LoginRequest();
    }
    return credentials;
  }

  /**
   * http Get with header contains credentials
   * @param url string
   * @returns Observable<T>
   */
  protected httpGet<T>(url: string): Observable<T> {
    return this.http.get<T>(this.BaseUrl + url, {
      headers: this.createHttpHeaders()
    });
  }

  /**
   * http Post with header contains credentials
   * @param url string
   * @param body any
   * @returns Observable<T>
   */
  protected httpPost<T>(url: string, body: any): Observable<T> {
    return this.http.post<T>(this.BaseUrl + url, body, {
      headers: this.createHttpHeaders()
    });
  }

  /**
   * get current user as observable
   * @returns Observable<T>
   */
  public getCurrentUser() {
    return this.currentUserSubject.asObservable();
  }

  /**
   * set current and notify subscribers
   * @param login LoginRequest
   * @returns Observable<LoginRequest>
   */
  public setCurrentUser(login: LoginRequest) {
    this.currentUserSubject.next(login);
  }
}
