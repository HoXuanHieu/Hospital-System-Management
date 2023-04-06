import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from 'src/app/service/patient.service';

@Component({
  selector: 'app-patient-form',
  templateUrl: './patient-form.component.html',
  styleUrls: ['./patient-form.component.css']
})
export class PatientFormComponent implements OnInit {

  patientForm = new FormGroup(
    {
      patientId: new FormControl(''),
      patientName: new FormControl('', [Validators.required]),
      age: new FormControl('', [Validators.required, Validators.min(0), Validators.max(100)]),
      gender: new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required, Validators.pattern('^(0+[0-9]{9})$')]),
      address: new FormControl(''),
      occupation: new FormControl(''),
    });
  get patientId() {
    return this.patientForm.get('patientId');
  } get patientName() {
    return this.patientForm.get('patientName');
  } get age() {
    return this.patientForm.get('age');
  } get gender() {
    return this.patientForm.get('gender');
  } get phoneNumber() {
    return this.patientForm.get('phoneNumber');
  } get address() {
    return this.patientForm.get('address');
  } get occupation() {
    return this.patientForm.get('occupation');
  }

  constructor(private patientService: PatientService, private toastr: ToastrService, private router: Router, private dialog: MatDialog) { }

  ngOnInit(): void {
  }
  onSubmit() {
    this.patientService.create(this.patientForm.value).subscribe(result => {
      this.toastr.success("Succefull", "Add a new Employee");
      this.patientForm.reset();
      this.dialog.closeAll();
    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
      this.patientForm.reset();
    });
  }

  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }
}
