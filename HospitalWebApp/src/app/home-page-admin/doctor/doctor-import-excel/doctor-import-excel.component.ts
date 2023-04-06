import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { ErrorMessage } from 'src/app/model/error-message';
import { Staff } from 'src/app/model/staff.model';
import { StaffService } from 'src/app/service/staff.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-doctor-import-excel',
  templateUrl: './doctor-import-excel.component.html',
  styleUrls: ['./doctor-import-excel.component.css']
})
export class DoctorImportExcelComponent implements OnInit {

  constructor(private staffService: StaffService, private toastr: ToastrService, private diaLog: MatDialog) { }
  ngOnInit(): void {

  }
  displayedColumns: string[] =
    ['index', 'staffName', 'userName', 'age', 'gender', 'department', 'specialization', 'phoneNumber', 'address', 'email'];
  doctorList: any;
  dataSourse: any;
  displayData: any = [];
  pageEvent = { pageSize: 10, pageIndex: 0 }
  @ViewChild(MatPaginator) set paginator(value: MatPaginator) {
    this.displayData.paginator = value;
  }
  UpdateFile(event: any) {
    if (event.target.files.length != 1) {
      throw new Error("Cannot use multiple files");
    }
    const reader: FileReader = new FileReader();
    reader.readAsBinaryString(event.target.files[0]);
    reader.onload = (event: any) => {
      const binaryString: string = event.target.result;
      const workbook: XLSX.WorkBook = XLSX.read(binaryString, { type: 'binary' });
      const worksheetname: string = workbook.SheetNames[0];
      const worksheet: XLSX.WorkSheet = workbook.Sheets[worksheetname];
      this.dataSourse = XLSX.utils.sheet_to_json(worksheet);
      this.checkImportData();
      this.displayData = new MatTableDataSource(this.dataSourse);
      console.log(this.displayData);
    }

  }
  UploadFile() {
    this.staffService.ImportExcelFile(this.dataSourse).subscribe((data: any) => {
      this.toastr.success("Succefull", "Upload File");
      this.diaLog.closeAll();
      this.dataSourse = null;

    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
    });
  }
  invalidFile: boolean = false;
  errorMess: ErrorMessage[] = [];
  checkImportData() {
    let error = new ErrorMessage();
    if (this.dataSourse.length > 0) {
      this.dataSourse.forEach((element: any, index: number) => {
        //check staffName
        // element.Add({ password: '', role: '' });
        element['password'] = '';
        element['role'] = '';
        if (element.staffName == null) {
          this.invalidFile = true;
          error.index = index + 1;
          error.mess = 'Staff Name must be required.'
          this.errorMess.push({ index: error.index, mess: error.mess });
        }
        //check gender
        if (element.gender == null) {
          this.invalidFile = true;
          error.index = index + 1;
          error.mess = 'Gender must be required.'
          this.errorMess.push({ index: error.index, mess: error.mess });
        } else {
          if (element.gender != 'male' && element.gender != 'female') {
            this.invalidFile = true;
            error.index = index + 1;
            error.mess = 'Gender is Invalid (male/ female).'
            this.errorMess.push({ index: error.index, mess: error.mess });
          }
        }
        //check userName
        if (element.userName == null) {
          this.invalidFile = true;
          error.index = index + 1;
          error.mess = 'User Name must be required'
          this.errorMess.push({ index: error.index, mess: error.mess });
        } else {
          this.staffService.getDoctorbyUserName(element.userName).subscribe(res => {
            if (res != null) {

              this.invalidFile = true;
              this.errorMess.push({ index: index + 1, mess: 'User Name have already exist.' });
            }
          });
        }
        //check age
        if (element.age == null) {
          error.index = index + 1;
          error.mess = 'Age must be required'
          this.errorMess.push({ index: error.index, mess: error.mess });
          this.invalidFile = true;

        } else {
          if (isNaN(element.age)) {
            error.index = index + 1;
            error.mess = 'Age must be a number'
            this.errorMess.push({ index: error.index, mess: error.mess });
            this.invalidFile = true;
          }
        }
        //check department
        if (element.department == null) {
          this.invalidFile = true;
          error.index = index + 1;
          error.mess = 'department must be required'
          this.errorMess.push({ index: error.index, mess: error.mess });
        }
        //check phone number
        if (element.phoneNumber == null) {
          error.index = index + 1;
          error.mess = 'PhoneNumber must be required'
          this.errorMess.push({ index: error.index, mess: error.mess });
          this.invalidFile = true;
        } else {
          if (isNaN(element.phoneNumber)) {
            error.index = index + 1;
            error.mess = 'Phone Number must be a number'
            this.errorMess.push({ index: error.index, mess: error.mess });
            this.invalidFile = true;
          }
          let myRegex: RegExp = /^(0+[0-9]{9})$/;
          if (!myRegex.test(element.phoneNumber)) {
            this.errorMess.push({ index: index + 1, mess: 'Phone Number must be start with 0 and have 10 number.' });
          }
          this.staffService.getDoctorbyPhoneNumber(element.phoneNumber).subscribe(res => {
            if (res != null) {
              this.invalidFile = true;
              this.errorMess.push({ index: index + 1, mess: 'Phone Number have already exist.' });
            }
          });
        }
        //check email 
        if (element.email == null) {
          this.invalidFile = true;
          error.index = index + 1;
          error.mess = 'Email must be required'
          this.errorMess.push({ index: error.index, mess: error.mess });
        } else {
          let myRegex: RegExp = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/;
          if (!myRegex.test(element.email)) {
            this.errorMess.push({ index: index + 1, mess: 'Email is invalid.' });
          }
          this.staffService.getDoctorbyEmail(element.email).subscribe(res => {
            if (res != null) {
              this.invalidFile = true;
              this.errorMess.push({ index: index + 1, mess: 'Email have already exist.' });
            }
          });
        }
      });
    } else {
      this.invalidFile = true;
      this.errorMess.push({ index: 0, mess: 'No data for import.' });

    }
    if (this.invalidFile) {
      this.toastr.error("Something Wrong", "Have some Error Data Please check again!!");
    }

  }
}
