import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Staff } from 'src/app/model/staff.model';
import { LoginService } from 'src/app/service/login.service';

@Component({
  selector: 'app-header-admin',
  templateUrl: './header-admin.component.html',
  styleUrls: ['./header-admin.component.css']
})
export class HeaderAdminComponent implements OnInit {

  constructor(private router: Router, public loginService: LoginService, private toastr: ToastrService) { }
  user: Staff = new Staff;

  ngOnInit(): void {
    this.loginService.getUser().subscribe(res =>{
      this.user = res!=null? res : new Staff;
    });
    // console.log("For Log " + this.user.staffName)
  }
  Logout() {
    localStorage.clear();
    this.router.navigate(['']);
  }
}
