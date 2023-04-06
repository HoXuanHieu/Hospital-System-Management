import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { SurgeryRequestWithName } from 'src/app/model/surgery-request-with-name.model';
import { SurgeryService } from 'src/app/service/surgery.service';

@Component({
  selector: 'app-surgery-list-for-doctor',
  templateUrl: './surgery-list-for-doctor.component.html',
  styleUrls: ['./surgery-list-for-doctor.component.css']
})
export class SurgeryListForDoctorComponent implements OnInit {

  constructor(private surgeryService: SurgeryService) { }
  staffId: number;
  ngOnInit(): void {
    this.staffId = Number(localStorage.getItem('staffId'));
    console.log(this.staffId);
    this.getAllSurgeryRequest();
  }
  displayedColumns: string[] = ['patientName', 'surgeryTpye', 'surgeryDate', 'staffName', 'status', 'description'];
  patientList: any;
  dataSourse: any

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  getAllSurgeryRequest() {
    this.surgeryService.getAllSurgeryByStaffId(this.staffId).subscribe(res => {
      this.patientList = res
      this.dataSourse = new MatTableDataSource<SurgeryRequestWithName>(this.patientList);
      this.dataSourse.paginator = this.paginator;
      this.dataSourse.sort = this.sort;
    })
  }
  Search(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourse.filter = filvalue;
  }
}
