import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { BloodTestInfoWithPatientName } from 'src/app/model/blood-test-info-with-patient-name.model';
import { BloodTest } from 'src/app/model/blood-test.model';
import { BloodTestService } from 'src/app/service/blood-test.service';
import { DeleteBloodTestInfoComponent } from './delete-blood-test-info/delete-blood-test-info.component';
import { UpdateBloodTestInfoComponent } from './update-blood-test-info/update-blood-test-info.component';

@Component({
  selector: 'app-blood-test-list',
  templateUrl: './blood-test-list.component.html',
  styleUrls: ['./blood-test-list.component.css']
})
export class BloodTestListComponent implements OnInit {

  constructor(private diaLog: MatDialog, private toastr: ToastrService, private bloodTestService: BloodTestService) { }

  ngOnInit(): void {
    this.getAllBloodTest();

  }


  displayedColumns: string[] =
    ['patientName', 'mediclatestype', 'bloodGroup', 'haemoglobin', 'bloodsugar', 'sacid', 'description', 'action'];
  bloodTestInfoList: any;
  dataSourse: any

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  getAllBloodTest() {
    this.bloodTestService.getBloodTestList().subscribe(res => {
      this.bloodTestInfoList = res
      this.dataSourse = new MatTableDataSource<BloodTestInfoWithPatientName>(this.bloodTestInfoList);
      this.dataSourse.paginator = this.paginator;
      this.dataSourse.sort = this.sort;
    })
  }
  Search(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourse.filter = filvalue;
  }
  openDeleteBloodTestInfo(bloodTestId: number, patientName: string) {
    const deletPatient = this.diaLog.open(DeleteBloodTestInfoComponent, { data: { id: bloodTestId, name: patientName } });
    deletPatient.afterClosed().subscribe(result => {
      this.getAllBloodTest();
    })
  }
  openUpdatePatient(selectRecord: BloodTest) {
    this.bloodTestService.bloodTest = selectRecord;
    const updatePatient = this.diaLog.open(UpdateBloodTestInfoComponent);
    updatePatient.afterClosed().subscribe(result => {
      this.getAllBloodTest();
    });
  }
}
