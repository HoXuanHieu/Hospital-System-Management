import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Patient } from 'src/app/model/patient.model';
import { Staff } from 'src/app/model/staff.model';
import { PatientService } from 'src/app/service/patient.service';
import { StaffService } from 'src/app/service/staff.service';
import { SurgeryService } from 'src/app/service/surgery.service';

@Component({
  selector: 'app-surgery-request-form',
  templateUrl: './surgery-request-form.component.html',
  styleUrls: ['./surgery-request-form.component.css']
})
export class SurgeryRequestFormComponent implements OnInit {

  constructor(public patientService: PatientService, public doctorService: StaffService, private toastr: ToastrService, private router: Router, private surgeryService: SurgeryService) { }

  ngOnInit(): void {
    this.getAllPatient();
    this.getAllDoctor();
  }
  currentDate: any = new Date();
  surgeryRequestForm = new FormGroup({
    surgeryRequestId: new FormControl(''),
    surgeryTpye: new FormControl('', [Validators.required]),
    surgeryDate: new FormControl('', [Validators.required]),
    status: new FormControl('In-Queue', [Validators.required]),
    description: new FormControl(''),
    patientId: new FormControl(0, [Validators.required]),
    staffId: new FormControl(0, [Validators.required])
  })
  get surgeryRequestId(){
    return this.surgeryRequestForm.get('surgeryRequestId');
  }get surgeryTpye(){
    return this.surgeryRequestForm.get('surgeryTpye');
  }get surgeryDate(){
    return this.surgeryRequestForm.get('surgeryDate');
  }get status(){
    return this.surgeryRequestForm.get('status');
  }get description(){
    return this.surgeryRequestForm.get('description');
  }get patientId(){
    return this.surgeryRequestForm.get('patientId');
  }get staffId(){
    return this.surgeryRequestForm.get('staffId');
  }
  

  displayedPatientColumns: string[] = ['patientName', 'age', 'gender', 'phoneNumber',];
  displayedDoctorColumns: string[] = ['staffName', 'age', 'gender', 'department', 'phoneNumber'];
  doctorList: any;
  patientList: any;
  dataSoursePatient: any;
  dataSourseDoctor: any;


  @ViewChild('PatientPaginatior') paginatorPatient !: MatPaginator;
  @ViewChild('DoctorPaginatior') paginatorDoctor !: MatPaginator;

  @ViewChild('patientSort') sortPatient !: MatSort;
  @ViewChild('doctorSort') sortDoctor !: MatSort;


  getAllPatient() {
    this.patientService.getAllPatient().subscribe(res => {
      this.patientList = res
      this.dataSoursePatient = new MatTableDataSource<Patient>(this.patientList);
      this.dataSoursePatient.paginator = this.paginatorPatient;
      this.dataSoursePatient.sort = this.sortPatient;
    })
  }
  getAllDoctor() {
    this.doctorService.getSurgeryDoctor().subscribe(res => {
      this.doctorList = res
      this.dataSourseDoctor = new MatTableDataSource<Staff>(this.doctorList);
      this.dataSourseDoctor.paginator = this.paginatorDoctor;
      this.dataSourseDoctor.sort = this.sortDoctor;
    })
  }
  selectRecordPatient(selectRecord: Patient) {
    this.patientService.formData = selectRecord;
    this.surgeryRequestForm.patchValue({
      patientId: this.patientService.formData.patientId
    });
  }
  selectRecordDoctor(selectRecord: Staff) {
    this.doctorService.formData = selectRecord;
    this.surgeryRequestForm.patchValue({
      staffId: this.doctorService.formData.staffId
    });
  }
  SearchPatient(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSoursePatient.filter = filvalue;
  }
  SearchDoctor(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourseDoctor.filter = filvalue;
  }
  onSubmit(){
    console.log(this.surgeryRequestForm.value);
    this.surgeryService.createSurgeryRequest(this.surgeryRequestForm.value).subscribe(result => {
      this.toastr.success("Succefull", "Add a new Urine Test");
      this.surgeryRequestForm.reset();
      this.router.navigate(['surgery-request-list']);
    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
      this.surgeryRequestForm.reset();
    });

  }
}
