import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { InOutPatientService } from 'src/app/service/in-out-patient.service';
import { PatientService } from 'src/app/service/patient.service';
import { StaffService } from 'src/app/service/staff.service';

@Component({
  selector: 'app-register-in-patient-form',
  templateUrl: './register-in-patient-form.component.html',
  styleUrls: ['./register-in-patient-form.component.css']
})

export class RegisterInPatientFormComponent implements OnInit {

  currentDate: any = new Date();
  startDate: any = new Date();
  ngOnInit(): void {
    this.staffService.getDoctor().subscribe(result => {
      this.doctorList = result;
    });
  }
  dateChange(value: any){
    this.startDate = new Date(value.value)
  }
  doctorList: any;
  InpatientForm = new FormGroup({
    familyPhone: new FormControl('', [Validators.required, Validators.pattern('^(0+[0-9]{9})$')]),
    dateIn: new FormControl('', [Validators.required,]),
    dateOut: new FormControl('', [Validators.required]),
    symptoms: new FormControl(''),
    department: new FormControl('', [Validators.required]),
    wardNum: new FormControl('', [Validators.required, Validators.min(1), Validators.max(20)]),
    bedNum: new FormControl('', [Validators.required, Validators.min(1), Validators.max(6)]),
    staffId: new FormControl('', [Validators.required]),
    patientId: new FormControl(this.patientService.formData.patientId, [Validators.required])
  });

  get familyPhone() {
    return this.InpatientForm.get('familyPhone');
  } get dateIn() {
    return this.InpatientForm.get('dateIn');
  } get dateOut() {
    return this.InpatientForm.get('dateOut');
  } get symptoms() {
    return this.InpatientForm.get('symptoms');
  } get wardNum() {
    return this.InpatientForm.get('wardNum');
  } get bedNum() {
    return this.InpatientForm.get('bedNum');
  } get staffId() {
    return this.InpatientForm.get('staffId');
  } get patientId() {
    return this.InpatientForm.get('patientId');
  } get department() {
    return this.InpatientForm.get('department');
  }
  constructor(public patientService: PatientService, private staffService: StaffService, private inPatientService: InOutPatientService, private toastr: ToastrService, private dialog: MatDialog) { }

  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }
  onSubmitInPatient() {
    this.inPatientService.createInPatient(this.InpatientForm.value).subscribe(result => {
      this.toastr.success("Succefull", "Register In-Patient");
      this.InpatientForm.reset();
      this.dialog.closeAll();
    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
      this.InpatientForm.reset();
    });
  }
  showLog(value: any){
    console.log(value.value);
  }

}
