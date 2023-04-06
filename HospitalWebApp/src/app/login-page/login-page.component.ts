import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { StaffLogin } from '../model/staff-login.model';
import { LoginService } from '../service/login.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  constructor(public loginService: LoginService, public router: Router, private toastr: ToastrService) { }

  user = new StaffLogin();
  checkLogin = localStorage.getItem('authoToken');

  ngOnInit(): void {
    localStorage.clear();
    if (this.checkLogin != null) {
    }
  }

  login(user: StaffLogin) {
    this.loginService.Login(user).subscribe((token: string) => {
      if (token != null) {
        localStorage.setItem('authToken', token);
        this.loginService.getUser().subscribe(res => {
          if (res.role == 'Doctor') {
            localStorage.setItem('department',res.department);
            localStorage.setItem('staffId', res.staffId.toString());
            this.router.navigate(['/home-page-doctor']);
            this.toastr.success("Login Successful", "Wellcome Back!");
          }
          if (res.role == 'Employee') {
            this.router.navigate(['/home-page-admin']);
            this.toastr.success("Login Successful", "Wellcome Back!");
          }
        });
      }
    });
  }
}
