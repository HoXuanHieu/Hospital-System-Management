import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Patient } from 'src/app/model/patient.model';
import { PatientService } from 'src/app/service/patient.service';
import { DeletePatientComponent } from '../delete-patient/delete-patient.component';
import { PatientFormComponent } from '../patient-form/patient-form.component';
import { PatientUpdateFormComponent } from '../patient-update-form/patient-update-form.component';
import { RegisterInPatientFormComponent } from '../register-in-patient-form/register-in-patient-form.component';
import { RegisterOutPatientComponent } from '../register-out-patient/register-out-patient.component';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {

  displayedColumns: string[] = ['patientName', 'age', 'gender', 'phoneNumber', 'address', 'occupation', 'action', 'show', 'register'];
  patientList: any;
  dataSourse: any

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  constructor(private patientSerive: PatientService, private toastr: ToastrService, private router: Router, private diaLog: MatDialog) { }

  ngOnInit(): void {
    this.getAllPatient();
  }

  getAllPatient() {
    this.patientSerive.getAllPatient().subscribe(res => {
      this.patientList = res
      this.dataSourse = new MatTableDataSource<Patient>(this.patientList);
      this.dataSourse.paginator = this.paginator;
      this.dataSourse.sort = this.sort;
    })
  }

  Search(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourse.filter = filvalue;
  }

  openRegisterPatient() {
    const registerPatient = this.diaLog.open(PatientFormComponent);
    registerPatient.afterClosed().subscribe(result => {
      this.getAllPatient();
    })
  }

  openDeletePatient(patientId: number, patientName: string) {
    const deletPatient = this.diaLog.open(DeletePatientComponent, { data: { id: patientId, name: patientName } });
    deletPatient.afterClosed().subscribe(result => {
      this.getAllPatient();
    })
  }

  openUpdatePatient(selectRecord: Patient){
    this.patientSerive.formData = selectRecord;
    const updatePatient = this.diaLog.open(PatientUpdateFormComponent);
    updatePatient.afterClosed().subscribe(result => {
      this.getAllPatient();
    });
  }

  openInpatient(selectRecord: Patient){
    this.patientSerive.formData =selectRecord;
    const inPatient = this.diaLog.open(RegisterInPatientFormComponent);
    inPatient.afterClosed().subscribe(result => {
      this.getAllPatient();
    });
  }
  openOutpatient(selectRecord: Patient){
    this.patientSerive.formData =selectRecord;
    const OutPatient = this.diaLog.open(RegisterOutPatientComponent);
    OutPatient.afterClosed().subscribe(result => {
      this.getAllPatient();
    });
  }
  delete(id: number) {
    console.log(id);
    if (confirm("Are you sure to delete this patient id " + id + " ?")) {
      this.patientSerive.delete(id).subscribe(
        reset => {
          this.getAllPatient();
          this.toastr.error("Successfull", "Delete this patient " + id)
        }, err => { console.log(err) }
      )
    }
  }

  selectRecord(selectRecord: Patient) {
    console.log(selectRecord);
    this.patientSerive.formData = selectRecord;
    this.router.navigate(['/in-out-patient-list']);
  }
}
