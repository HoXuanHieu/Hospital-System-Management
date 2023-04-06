import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Staff } from 'src/app/model/staff.model';
import { StaffService } from 'src/app/service/staff.service';
import { MatTableDataSource } from '@angular/material/table'
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDoctorComponent } from '../delete-doctor/delete-doctor.component';
import { DoctorImportExcelComponent } from '../doctor-import-excel/doctor-import-excel.component';
import * as XLSX from 'xlsx';


@Component({
  selector: 'app-doctor-list',
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {

  displayedColumns: string[] = ['staffName', 'age', 'gender', 'department', 'specialization', 'phoneNumber', 'address', 'email', 'action'];
  doctorList: any;
  dataSourse: any;

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  constructor(public doctorService: StaffService, private toastr: ToastrService, private router: Router, private matDiaLog: MatDialog) { }

  ngOnInit(): void {
    this.getAll();
  }
  getAll() {
    this.doctorService.getDoctor().subscribe(res => {
      this.doctorList = res
      this.dataSourse = new MatTableDataSource<Staff>(this.doctorList);
      this.dataSourse.paginator = this.paginator;
      this.dataSourse.sort = this.sort;
      console.log(this.dataSourse);

    })
  }
  Search(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourse.filter = filvalue;
  }
  selectRecord(selectRecord: Staff) {
    this.doctorService.formData = selectRecord;
    this.router.navigate(['/update-doctor']);
  }
  delete(id: number) {
    if (confirm("Are you sure to delete Employee id " + id + " ?")) {
      this.doctorService.delete(id).subscribe(
        reset => {
          this.getAll();
          this.toastr.error("Successfull", "Delete a Employee " + id);
        }, err => { console.log(err) }
      )
    }
  }

  OpenDiaLog(doctorId: number, name: string) {
    const diaLog = this.matDiaLog.open(DeleteDoctorComponent, { data: { id: doctorId, name: name } });
    diaLog.afterClosed().subscribe(
      result => {
        this.getAll();
      }
    )
  }
  dataGenerator() {
    for (let index = 1000; index < 2000; index++) {
      let doctor = {
        staffId: 0,
        staffName: "Doctor" + index,
        userName: 'Doctor' + index,
        password: '123',
        conPassword: '123',
        age: 20,
        gender: 'male',
        department: 'asvjn',
        specialization: '123123vda',
        phoneNumber: '0123659488',
        address: 'avndf',
        email: 'abc@avc.com',
        role: 'Doctor',
      }
      this.doctorService.create(doctor).subscribe(res => {
        console.log(doctor);
      });
    }
  }
  openImportExcelDiaLog() {
    const importDiaLog = this.matDiaLog.open(DoctorImportExcelComponent);
    importDiaLog.afterClosed().subscribe(result => {
      this.getAll();
    });
  }
  exportExcel() {

    let element = this.dataSourse.filteredData
    element.forEach((element: any) => {
      delete element.staffId
      delete element.userName
      delete element.password
      delete element.role
    });
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(element);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, 'doctorListExcel.xlsx');
  }
}
