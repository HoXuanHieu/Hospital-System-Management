import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Staff } from 'src/app/model/staff.model';
import { StaffService } from 'src/app/service/staff.service';
import { matchpassword } from 'src/app/Validator/match-password.validator';

@Component({
  selector: 'app-doctor-form',
  templateUrl: './doctor-form.component.html',
  styleUrls: ['./doctor-form.component.css']
})
export class DoctorFormComponent implements OnInit {

  formRegister: Staff = new Staff();
  constructor(public doctorService: StaffService, private toastr: ToastrService, private router: Router) {
  }

  ngOnInit(): void {
  }

  doctorForm = new FormGroup(
    {
      staffId: new FormControl(''),
      staffName: new FormControl('', [Validators.required]),
      userName: new FormControl('', [Validators.required, Validators.minLength(5)]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)]),
      conPassword: new FormControl('', [Validators.required, Validators.minLength(8)]),
      age: new FormControl('', [Validators.required, Validators.min(18), Validators.max(65)]),
      gender: new FormControl('', [Validators.required]),
      department: new FormControl('', [Validators.required]), 
      specialization: new FormControl(''),
      phoneNumber: new FormControl('', [Validators.required, Validators.pattern('^(0+[0-9]{9})$')]),
      address: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      role: new FormControl('', [Validators.required]),
    }, {
    validators: matchpassword
  }
  );

  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }

  userNameExist: boolean = false;
  phoneNumberExist: boolean = false;
  EmailExist: boolean = false;

  checkUserNameExist() {
    this.doctorService.getDoctorbyUserName(this.doctorForm.controls['userName'].value).subscribe(res => {
      if (res != null) {
        this.userNameExist = true;
      } else {
        this.userNameExist = false;
      }
    });
  }
  checkPhoneExist() {
    this.doctorService.getDoctorbyPhoneNumber(this.doctorForm.controls['phoneNumber'].value).subscribe(res => {
      if (res != null) {
        this.phoneNumberExist = true;
      } else {
        this.phoneNumberExist = false;
      }
    });
  } checkEmail() {
    this.doctorService.getDoctorbyEmail(this.doctorForm.controls['email'].value).subscribe(res => {
      if (res != null) {
        this.EmailExist = true;
      } else {
        this.EmailExist = false;
      }
    });
  }

  onSubmit() {
    console.log(this.doctorForm.value);
    this.doctorService.create(this.doctorForm.value).subscribe(result => {
      this.toastr.success("Succefull", "Add a new Employee");
      this.doctorForm.reset();
      this.router.navigate(['/list-doctor'])
    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
      this.doctorForm.reset();
    });
  }
  get userName() {
    return this.doctorForm.get('userName');
  } get staffName() {
    return this.doctorForm.get('staffName');
  } get password() {
    return this.doctorForm.get('password');
  } get conPassword() {
    return this.doctorForm.get('conPassword');
  } get age() {
    return this.doctorForm.get('age');
  } get gender() {
    return this.doctorForm.get('gender');
  } get department() {
    return this.doctorForm.get('department');
  } get specialization() {
    return this.doctorForm.get('specialization');
  } get phoneNumber() {
    return this.doctorForm.get('phoneNumber');
  } get address() {
    return this.doctorForm.get('address');
  } get email() {
    return this.doctorForm.get('email');
  } get role() {
    return this.doctorForm.get('role');
  }
}



  // createStaff() {
  //   this.doctorService.create(this.formRegister).subscribe(
  //     reset => {
  //       this.resetInput();
  //       this.toastr.success("Succefull", "Add a new Employee");
  //     },
  //     err => {
  //       console.log(err)
  //       this.toastr.error("Something Wrong", "please try again");
  //       form.form.reset();
  //       this.formRegister = new Staff();
  //     }
  //   )
  // }
  // resetInput(form: NgForm) {
  //   form.form.reset();
  //   this.formRegister = new Staff();
  //   this.router.navigate(['/list-doctor'])
  // }
