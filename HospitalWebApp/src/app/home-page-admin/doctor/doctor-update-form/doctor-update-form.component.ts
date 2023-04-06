import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Staff } from 'src/app/model/staff.model';
import { StaffService } from 'src/app/service/staff.service';

@Component({
  selector: 'app-doctor-update-form',
  templateUrl: './doctor-update-form.component.html',
  styleUrls: ['./doctor-update-form.component.css']
})
export class DoctorUpdateFormComponent implements OnInit {

  constructor(public doctorService: StaffService, private toastr: ToastrService, private router: Router) { }

  doctorForm = new FormGroup(
    {
      staffId: new FormControl(this.doctorService.formData.staffId),
      staffName: new FormControl(this.doctorService.formData.staffName, [Validators.required]),
      userName: new FormControl(this.doctorService.formData.userName, [Validators.required, Validators.minLength(5)]),
      password: new FormControl(this.doctorService.formData.password, [Validators.required, Validators.minLength(8)]),
      age: new FormControl(this.doctorService.formData.age, [Validators.required]),
      gender: new FormControl(this.doctorService.formData.gender, [Validators.required]),
      department: new FormControl(this.doctorService.formData.department, [Validators.required]),
      specialization: new FormControl(this.doctorService.formData.specialization),
      phoneNumber: new FormControl(this.doctorService.formData.phoneNumber, [Validators.required, Validators.pattern('^(0+[0-9]{9})$')]),
      address: new FormControl(this.doctorService.formData.address),
      email: new FormControl(this.doctorService.formData.email, [Validators.required, Validators.email]),
      role: new FormControl(this.doctorService.formData.role, [Validators.required]),
    }
  )
  get userName() {
    return this.doctorForm.get('userName');
  }
  get staffName() {
    return this.doctorForm.get('staffName');
  } get password() {
    return this.doctorForm.get('password');
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
  ngOnInit(): void {

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
  
  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }
  
  onSubmit() {
    this.doctorService.update(this.doctorForm.value).subscribe(
      reset => {
        this.doctorForm.reset();
        this.toastr.info("Succefull", "Update a Employee");
        this.router.navigate(['/list-doctor']);

      },
      err => {
        console.log(err)
        this.toastr.error("Something Wrong", "please try again");
      }
    )
  }
  goBack(){
    this.doctorForm.reset();
    this.router.navigate(['/list-doctor']);
  }
}
