import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { InPaientShowByDepartment } from 'src/app/model/in-paient-show-by-department.model';
import { OutPaientShowByDepartment } from 'src/app/model/out-paient-show-by-department.model';
import { PharmacyByDepartment } from 'src/app/model/pharmacy-by-department';
import { InOutPatientService } from 'src/app/service/in-out-patient.service';
import { PharmacyInfoService } from 'src/app/service/pharmacy-info.service';
import { PharmacyDeleteComponent } from '../pharmacy-delete/pharmacy-delete.component';

@Component({
  selector: 'app-pharmacy-list',
  templateUrl: './pharmacy-list.component.html',
  styleUrls: ['./pharmacy-list.component.css']
})
export class PharmacyListComponent implements OnInit {

  constructor(private inOutPatientService: InOutPatientService,private pharmacyService: PharmacyInfoService, private diaLog: MatDialog) { }
  currentDepartment: any
  ngOnInit(): void {
    this.getPharmacy();
    this.currentDepartment = localStorage.getItem('department');
    
    this.getInpatientByPatientDepartment();
    this.getOutpatientByPatientByDepartment();
  }
  displayedPharmacyColumns: string[] = ['patientName', 'status', 'medicineName', 'quantity', 'description', 'action'];
  pharmacyList: any;
  dataPharmacySourse: any

  @ViewChild('pharmacyPaginator') Pharmacypaginator !: MatPaginator;
  @ViewChild('pharmacySort') Pharmacysort !: MatSort;

  displayedColumnsInPatient: string[] = ['patientName','familyPhone', 'wardNum', 'bedNum', 'symptoms', 'doctorName'];
  displayedColumnsOutPatient: string[] = ['patientName','familyPhone', 'doctorName'];

  @ViewChild('inPatientPaging') inPatientPaging !: MatPaginator;
  @ViewChild('inPatientSort') inpatientSort !: MatSort;
  @ViewChild('outPatientPaging') outPatientPaging !: MatPaginator;
  @ViewChild('outPatientSort') outPatientSort !: MatSort;

  InpatientList: any;
  OutpatientList: any;
  dataSourseInPatient: any;
  dataSourseOutPatient: any;

  getOutpatientByPatientByDepartment() {
    //this.inOutPatientService.getOutatientById(this.patientId)
    this.inOutPatientService.getOutPatientByDepartment(this.currentDepartment).subscribe(res => {
      this.OutpatientList = res;
      this.dataSourseOutPatient = new MatTableDataSource<OutPaientShowByDepartment>(this.OutpatientList);
      this.dataSourseOutPatient.paginator = this.outPatientPaging;
      this.dataSourseOutPatient.sort = this.outPatientSort;
    });
  }

  getInpatientByPatientDepartment() {
    // this.inOutPatientService.getInPatientById
    this.inOutPatientService.getInPatientByDepartment(this.currentDepartment).subscribe(res => {
      this.InpatientList = res;
      this.dataSourseInPatient = new MatTableDataSource<InPaientShowByDepartment>(this.InpatientList);
      this.dataSourseInPatient.paginator = this.inPatientPaging;
      this.dataSourseInPatient.sort = this.inpatientSort;
    });
  }
    
  SearchPatient(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourseInPatient.filter = filvalue;
    this.dataSourseOutPatient.filter = filvalue;
  }
  
  getPharmacy() {
    this.currentDepartment = localStorage.getItem('department');
    this.pharmacyService.getAllPharmacyByDepartment(this.currentDepartment).subscribe(res => {
      this.pharmacyList = res
      this.dataPharmacySourse = new MatTableDataSource<PharmacyByDepartment>(this.pharmacyList);
      this.dataPharmacySourse.paginator = this.Pharmacypaginator;
      this.dataPharmacySourse.sort = this.Pharmacysort;
    })
  }

  openDeletePatient(pharmacyInforId: number, patientName: string) {
    const deletPatient = this.diaLog.open(PharmacyDeleteComponent, { data: { id: pharmacyInforId, name: patientName } });
    deletPatient.afterClosed().subscribe(result => {
      this.getPharmacy();
    })
  }
  Search(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataPharmacySourse.filter = filvalue;
  }
  selectPatient(patientId: number){
    this.pharmacyService.getAllPharmacyByPatientId(patientId).subscribe(res =>{
      this.pharmacyList = res;
      this.dataPharmacySourse = new MatTableDataSource<PharmacyByDepartment>(this.pharmacyList);
      this.dataPharmacySourse.paginator = this.Pharmacypaginator;
      this.dataPharmacySourse.sort = this.Pharmacysort;
    })
  }
}
