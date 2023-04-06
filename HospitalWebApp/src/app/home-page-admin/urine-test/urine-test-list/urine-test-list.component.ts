import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { UrineTestInfoWithPatientName } from 'src/app/model/urine-test-info-with-patient-name.model';
import { UrineTestInfo } from 'src/app/model/urine-test-info.model';
import { UrineTestService } from 'src/app/service/urine-test.service';
import { UpdateUrineTestInfoComponent } from './update-urine-test-info/update-urine-test-info.component';

@Component({
  selector: 'app-urine-test-list',
  templateUrl: './urine-test-list.component.html',
  styleUrls: ['./urine-test-list.component.css']
})
export class UrineTestListComponent implements OnInit {

  constructor(private urineTestService: UrineTestService, private diaLog: MatDialog) { }

  ngOnInit(): void {
    this.getAllUrineTest();
  }

  displayedColumns: string[] =
    ['patientName', 'mediclatestype', 'color', 'calrity', 'odor', 'specificgravity', 'glucose', 'description', 'action'];
  urineTestInfoList: any;
  dataSourse: any

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  getAllUrineTest() {
    this.urineTestService.getBloodTestList().subscribe(res => {
      this.urineTestInfoList = res
      this.dataSourse = new MatTableDataSource<UrineTestInfoWithPatientName>(this.urineTestInfoList);
      this.dataSourse.paginator = this.paginator;
      this.dataSourse.sort = this.sort;
    })
  }
  Search(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourse.filter = filvalue;
  }
  openUpdatePatient(selectRecord: UrineTestInfo) {
    this.urineTestService.urineTest = selectRecord;
    const updatePatient = this.diaLog.open(UpdateUrineTestInfoComponent);
    updatePatient.afterClosed().subscribe(result => {
      this.getAllUrineTest();
    });
  }
}
