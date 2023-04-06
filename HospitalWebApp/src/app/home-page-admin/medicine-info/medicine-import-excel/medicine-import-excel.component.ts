import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ErrorMessage } from 'src/app/model/error-message';
import { Medicine } from 'src/app/model/medicine.model';
import { MedicineService } from 'src/app/service/medicine.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-medicine-import-excel',
  templateUrl: './medicine-import-excel.component.html',
  styleUrls: ['./medicine-import-excel.component.css']
})

export class MedicineImportExcelComponent implements OnInit {

  constructor(private medicineService: MedicineService, private toastr: ToastrService, private diaLog: MatDialog, private spinner: NgxSpinnerService) { }
  displayedColumns: string[] =
    ['index', 'medicineName', 'price', 'company', 'description'];
  medicineInfoList: any;
  dataSourse: any;
  displayData: any = [];
  invalidFile: boolean = false;

  ngOnInit(): void {
  }
  @ViewChild(MatPaginator) set paginator(value: MatPaginator) {
    this.displayData.paginator = value;
  }

  UpdateFile(event: any) {
    // console.log(event)
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
      this.displayData = new MatTableDataSource(this.dataSourse);
      // console.log(this.displayData);

      this.checkImportData();
    }
  }

  UploadFile() {
    this.medicineService.uploadExcelFile(this.dataSourse).subscribe((data: any) => {
      this.toastr.success("Succefull", "Upload File");
      this.diaLog.closeAll();
      this.dataSourse = null;
    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
    });
  }
  errorMess: ErrorMessage[] = [];
  checkImportData() {
    let error = new ErrorMessage();
    this.dataSourse.forEach((element: any, index: number) => {
      if (element.medicineName == null) {
        this.invalidFile = true;
        error.index = index + 1;
        error.mess = 'medicineName must be required'
        this.errorMess.push({index : error.index,mess: error.mess});
      }
      if (element.price == null) {
        error.index = index + 1;
        error.mess = 'price must be required'
        this.errorMess.push({index : error.index,mess: error.mess});
        this.invalidFile = true;

      } else {
        if (isNaN(element.price)) {
          error.index = index + 1;
          error.mess = 'price must be a number'
          this.errorMess.push({index : error.index,mess: error.mess});
          this.invalidFile = true;
        }
      }
      if (element.company == null) {
        this.invalidFile = true;
        error.index = index + 1;
        error.mess = 'company must be required'
        this.errorMess.push({index : error.index,mess: error.mess});
      }
    });
    if (this.invalidFile) {
      this.toastr.error("Something Wrong", "Have some Error Data Please check again!!");
    }
    console.log(this.dataSourse);
  }
}
