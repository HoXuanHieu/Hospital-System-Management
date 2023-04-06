import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { catchError, throwError } from 'rxjs';
import { StaffLogin } from '../model/staff-login.model';
import { Staff } from '../model/staff.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient, private toastr :ToastrService) { }
  
  readonly loginUrl = "https://localhost:44392/api/Login";
  readonly getUserUrl = "https://localhost:44392/api/GetUser/user";
  Login(user: StaffLogin) {
    return this.http.post(this.loginUrl, user, { responseType: 'text' }).pipe(catchError(
      (err: HttpErrorResponse) => {
        this.toastr.error("Login Failed", "Please login again");
        return throwError(err.status)
      }
    ));
  }
  getUser() {
    return this.http.get<Staff>(this.getUserUrl);
    //  this.http.get<Staff>(this.getUserUrl).toPromise().then(res => this.staffData = res as Staff);
  }
}