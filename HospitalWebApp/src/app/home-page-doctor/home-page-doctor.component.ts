import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { InPaientShowByDepartment } from '../model/in-paient-show-by-department.model';
import { OutPaientShowByDepartment } from '../model/out-paient-show-by-department.model';
import { Staff } from '../model/staff.model';
import { InOutPatientService } from '../service/in-out-patient.service';
import { LoginService } from '../service/login.service';
import { RegisterPharmacyComponent } from './register-pharmacy/register-pharmacy.component';

@Component({
  selector: 'app-home-page-doctor',
  templateUrl: './home-page-doctor.component.html',
  styleUrls: ['./home-page-doctor.component.css']
})
export class HomePageDoctorComponent implements OnInit {

  constructor(private inOutPatientService: InOutPatientService, public loginService: LoginService, private diaLog: MatDialog) { }
   departmentCurrent : any;
  ngOnInit(): void {
    this.departmentCurrent = localStorage.getItem('department');
    
    this.getInpatientByPatientDepartment();
    this.getOutpatientByPatientByDepartment();
  }
  displayedColumnsInPatient: string[] = ['patientName','familyPhone', 'dateIn', 'dateOut', 'wardNum', 'bedNum', 'department', 'symptoms', 'doctorName','action'];
  displayedColumnsOutPatient: string[] = ['patientName','familyPhone', 'onDate', 'department', 'doctorName','action'];

  @ViewChild('inPatientPaging') inPatientPaging !: MatPaginator;
  @ViewChild('inPatientSort') sort !: MatSort;
  @ViewChild('outPatientPaging') outPatientPaging !: MatPaginator;
  @ViewChild('outPatientSort') outPatientSort !: MatSort;

  InpatientList: any;
  OutpatientList: any;
  dataSourseInPatient: any;
  dataSourseOutPatient: any;

  getOutpatientByPatientByDepartment() {
    //this.inOutPatientService.getOutatientById(this.patientId)
    this.inOutPatientService.getOutPatientByDepartment(this.departmentCurrent).subscribe(res => {
      this.OutpatientList = res;
      this.dataSourseOutPatient = new MatTableDataSource<OutPaientShowByDepartment>(this.OutpatientList);
      this.dataSourseOutPatient.paginator = this.outPatientPaging;
      this.dataSourseOutPatient.sort = this.sort;
    });
  }

  getInpatientByPatientDepartment() {
    // this.inOutPatientService.getInPatientById
    this.inOutPatientService.getInPatientByDepartment(this.departmentCurrent).subscribe(res => {
      this.InpatientList = res;
      this.dataSourseInPatient = new MatTableDataSource<InPaientShowByDepartment>(this.InpatientList);
      this.dataSourseInPatient.paginator = this.inPatientPaging;
      this.dataSourseInPatient.sort = this.sort;
    });
  }
    
  SearchPatient(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourseInPatient.filter = filvalue;
    this.dataSourseOutPatient.filter = filvalue;
  }
  registerPharmacy(patientId: any, patientName: any){
    const deletPatient = this.diaLog.open(RegisterPharmacyComponent, { data: { id: patientId, name: patientName} });
  }
}
