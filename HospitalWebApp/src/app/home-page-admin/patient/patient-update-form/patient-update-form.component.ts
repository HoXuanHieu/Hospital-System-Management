import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from 'src/app/service/patient.service';

@Component({
  selector: 'app-patient-update-form',
  templateUrl: './patient-update-form.component.html',
  styleUrls: ['./patient-update-form.component.css']
})
export class PatientUpdateFormComponent implements OnInit {

  patientForm = new FormGroup(
    {
      patientId: new FormControl(this.patientService.formData.patientId),
      patientName: new FormControl(this.patientService.formData.patientName, [Validators.required]),
      age: new FormControl(this.patientService.formData.age, [Validators.required, Validators.min(0), Validators.max(100)]),
      gender: new FormControl(this.patientService.formData.gender, [Validators.required]),
      phoneNumber: new FormControl(this.patientService.formData.phoneNumber, [Validators.required, Validators.pattern('^(0+[0-9]{9})$')]),
      address: new FormControl(this.patientService.formData.address),
      occupation: new FormControl(this.patientService.formData.occupation),
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
  constructor(private patientService: PatientService, private toastr: ToastrService,  private diaLog: MatDialog) { }

  ngOnInit(): void {
  }
  onSubmit(){
    this.patientService.update(this.patientForm.value).subscribe(
      reset => {
        this.patientForm.reset();
        this.toastr.info("Succefull", "Update a Employee");
        this.diaLog.closeAll();
      },
      err => {
        console.log(err)
        this.toastr.error("Something Wrong", "please try again");
      }
    )
  }
  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }
}
