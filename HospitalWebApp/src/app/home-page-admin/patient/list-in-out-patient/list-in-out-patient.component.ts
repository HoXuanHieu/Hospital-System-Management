import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { InPatientWithDoctorName } from 'src/app/model/in-patient-with-doctor-name.model';
import { InPatient } from 'src/app/model/in-patient.model';
import { OutPatientWithDoctorName } from 'src/app/model/out-patient-with-doctor-name.model';
import { OutPatient } from 'src/app/model/out-patient.model';
import { InOutPatientService } from 'src/app/service/in-out-patient.service';
import { PatientService } from 'src/app/service/patient.service';

@Component({
  selector: 'app-list-in-out-patient',
  templateUrl: './list-in-out-patient.component.html',
  styleUrls: ['./list-in-out-patient.component.css']
})
export class ListInOutPatientComponent implements OnInit {

  displayedColumnsInPatient: string[] = ['familyPhone', 'dateIn', 'dateOut', 'wardNum' ,'bedNum', 'department', 'symptoms','doctorName', 'action' ];
  displayedColumnsOutPatient: string[] = ['familyPhone', 'onDate', 'department','doctorName', 'action'];

  InpatientList: any;
  OutpatientList: any;

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;
  patientId : number;
  patientName : any;

  dataSourseInPatient: any;
  dataSourseOutPatient: any;

  constructor(private inOutPatientService: InOutPatientService, public patientService: PatientService, private toastr: ToastrService) { }

  getInpatientByPatientId() {
    // this.inOutPatientService.getInPatientById
    this.inOutPatientService.getInPatientByIdWithDoctorName(this.patientId).subscribe(res => {
      this.InpatientList = res;
      this.dataSourseInPatient = new MatTableDataSource<InPatientWithDoctorName>(this.InpatientList);
      this.dataSourseInPatient.paginator = this.paginator;
      this.dataSourseInPatient.sort = this.sort;
    });
  }
  getOutpatientByPatientId() {
    //this.inOutPatientService.getOutatientById(this.patientId)
    this.inOutPatientService.getOutPatientByIdWithDoctorName(this.patientId).subscribe(res => {
      this.OutpatientList = res;
      this.dataSourseOutPatient = new MatTableDataSource<OutPatientWithDoctorName>(this.OutpatientList);
      this.dataSourseOutPatient.paginator = this.paginator;
      this.dataSourseOutPatient.sort = this.sort;
    });
  }
  ngOnInit(): void {
    if(this.patientService.formData.patientId != 0){
      localStorage.setItem('patientId', this.patientService.formData.patientId.toString())
      localStorage.setItem('patientName', this.patientService.formData.patientName)
    }
    this.patientId = Number(localStorage.getItem('patientId'));
    this.patientName = localStorage.getItem('patientName');
    this.getInpatientByPatientId();
    this.getOutpatientByPatientId();
  }
  
  SearchInpatient(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourseInPatient.filter = filvalue;
    this.dataSourseOutPatient.filter = filvalue;
  }
  deleteInPatient(id: number){
    if (confirm("Are you sure to delete this In-patient id " + id + " ?")) {
      this.inOutPatientService.deleteInPatient(id).subscribe(
        reset => {
          this.getInpatientByPatientId();
          this.toastr.error("Successfull", "Delete this patient " + id)
        }, err => { console.log(err) }
      )
    }
  }
  deleteOutPatient(id: number){
    if (confirm("Are you sure to delete this Out-patient id " + id + " ?")) {
      this.inOutPatientService.deleteOutPatient(id).subscribe(
        reset => {
          this.getOutpatientByPatientId();
          this.toastr.error("Successfull", "Delete this patient " + id)
        }, err => { console.log(err) }
      )
    }
  }
}
