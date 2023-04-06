import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { InOutPatientService } from 'src/app/service/in-out-patient.service';
import { PatientService } from 'src/app/service/patient.service';
import { StaffService } from 'src/app/service/staff.service';

@Component({
  selector: 'app-register-out-patient',
  templateUrl: './register-out-patient.component.html',
  styleUrls: ['./register-out-patient.component.css']
})
export class RegisterOutPatientComponent implements OnInit {

  doctorList: any;
  currentDate: any = new Date();
  constructor(public patientService: PatientService, private outPatientService: InOutPatientService, private toastr : ToastrService, private dialog: MatDialog, private staffService: StaffService) { }

  OutpatientForm = new FormGroup({
    familyPhone: new FormControl('', [Validators.required, Validators.pattern('^(0+[0-9]{9})$')]),
    onDate: new FormControl('', [Validators.required,]),
    department: new FormControl('', [Validators.required]),
    staffId: new FormControl('', [Validators.required]),
    patientId: new FormControl(this.patientService.formData.patientId, [Validators.required])
  });
  get familyPhone() {
    return this.OutpatientForm.get('familyPhone');
  } get onDate() {
    return this.OutpatientForm.get('onDate');
  } get staffId() {
    return this.OutpatientForm.get('staffId');
  } get patientId() {
    return this.OutpatientForm.get('patientId');
  } get department() {
    return this.OutpatientForm.get('department');
  }


  ngOnInit(): void {
    this.staffService.getDoctor().subscribe(result => {
      this.doctorList = result;
    });
  }

  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }
  onSubmitOutPatient() {
    this.outPatientService.createOutPatient(this.OutpatientForm.value).subscribe(result => {
      this.toastr.success("Succefull", "Register Out-Patient");
      this.OutpatientForm.reset();
      this.dialog.closeAll();
    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
      this.OutpatientForm.reset();
    });
  }
}
