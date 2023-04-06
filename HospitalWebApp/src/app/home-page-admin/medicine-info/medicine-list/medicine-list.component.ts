import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Medicine } from 'src/app/model/medicine.model';
import { MedicineService } from 'src/app/service/medicine.service';
import { MedicineImportExcelComponent } from '../medicine-import-excel/medicine-import-excel.component';
import { MedicineUdpateComponent } from './medicine-udpate/medicine-udpate.component';
import { MedicineDeleteComponent } from './medicine-delete/medicine-delete.component';
import * as XLSX from 'xlsx';
import { MedicineExport } from 'src/app/model/medicine-export.model';
import { MedicineCreateComponent } from '../medicine-create/medicine-create.component';


@Component({
  selector: 'app-medicine-list',
  templateUrl: './medicine-list.component.html',
  styleUrls: ['./medicine-list.component.css']
})
export class MedicineListComponent implements OnInit {

  constructor(private medicineService: MedicineService, private diaLog: MatDialog) { }
  displayedColumns: string[] =
    ['medicineName', 'price', 'company', 'description', 'lastModified', 'action'];
  medicineInfoList: any;
  dataSourse: any


  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  ngOnInit(): void {
    this.getAllMedicineTest();
  }
  Search(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourse.filter = filvalue;
  }
  getAllMedicineTest() {
    this.medicineService.getAllMedicine().subscribe(res => {
      this.medicineInfoList = res
      this.dataSourse = new MatTableDataSource<Medicine>(this.medicineInfoList);
      this.dataSourse.paginator = this.paginator;
      this.dataSourse.sort = this.sort;
    })
  }
  OpenImportDiaLog() {
    const medicineDiaLog = this.diaLog.open(MedicineImportExcelComponent);
    medicineDiaLog.afterClosed().subscribe(result => {
      this.getAllMedicineTest();
    });
  }
  openUpdateDialog(selectRecord: Medicine) {
    this.medicineService.medicine = selectRecord;
    const updatePatient = this.diaLog.open(MedicineUdpateComponent);
    updatePatient.afterClosed().subscribe(result => {
      this.getAllMedicineTest();
    });
  }
  openDeleteDialog(medicineId: number, medicineName: string) {
    const deleteMedicine = this.diaLog.open(MedicineDeleteComponent, { data: { id: medicineId, name: medicineName } });
    deleteMedicine.afterClosed().subscribe(result => {
      this.getAllMedicineTest();
    })
  }
  openCreateMedicine(){
    const updatePatient = this.diaLog.open(MedicineCreateComponent);
    updatePatient.afterClosed().subscribe(result => {
      this.getAllMedicineTest();
    });
  }
  exportExcel() {
    let element: MedicineExport[] = [];
    element = this.dataSourse.filteredData;
    element.forEach(element => {
      delete element.medicineId
    });
    // console.log(element)
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(element);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, 'medicineList.xlsx');
  }
}
