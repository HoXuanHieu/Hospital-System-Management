import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Staff } from 'src/app/model/staff.model';
import { LoginService } from 'src/app/service/login.service';

@Component({
  selector: 'app-header-doctor',
  templateUrl: './header-doctor.component.html',
  styleUrls: ['./header-doctor.component.css']
})
export class HeaderDoctorComponent implements OnInit {

  constructor(private router: Router, public loginService: LoginService, private toastr: ToastrService) { }
  user: Staff = new Staff;
  ngOnInit(): void {
    this.loginService.getUser().subscribe(res =>{
      this.user = res!=null? res : new Staff;
    });
  }
  Logout() {
    localStorage.clear();
    this.router.navigate(['']);
  }
}
