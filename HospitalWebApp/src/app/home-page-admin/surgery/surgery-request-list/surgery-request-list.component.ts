import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { SurgeryRequestWithName } from 'src/app/model/surgery-request-with-name.model';
import { SurgeryRequest } from 'src/app/model/surgery-request.model';
import { SurgeryService } from 'src/app/service/surgery.service';
import { DeleteSurgeryRequestComponent } from '../delete-surgery-request/delete-surgery-request.component';

@Component({
  selector: 'app-surgery-request-list',
  templateUrl: './surgery-request-list.component.html',
  styleUrls: ['./surgery-request-list.component.css']
})
export class SurgeryRequestListComponent implements OnInit {


  constructor(private surgeryService: SurgeryService, private toastr: ToastrService, private diaLog: MatDialog) { }

  ngOnInit(): void {
    this.getAllSurgeryRequest();
  }
  displayedColumns: string[] = ['patientName', 'surgeryTpye', 'surgeryDate', 'staffName', 'status', 'description', 'change', 'action'];
  patientList: any;
  dataSourse: any

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  getAllSurgeryRequest() {
    this.surgeryService.getAllSurgerywithName().subscribe(res => {
      this.patientList = res
      this.dataSourse = new MatTableDataSource<SurgeryRequestWithName>(this.patientList);
      this.dataSourse.paginator = this.paginator;
      this.dataSourse.sort = this.sort;
    })
  }
  changeStatus(surgeryRequest: SurgeryRequest) {
    if (surgeryRequest.status == 'Complete') {
      surgeryRequest.status = 'In-Queue'
      this.surgeryService.updateSurgery(surgeryRequest).subscribe(
        reset => {
          this.getAllSurgeryRequest();
          this.toastr.info("Succefull", "Change Status have Id: " + surgeryRequest.surgeryRequestId);
        },
        err => { console.log(err) }
      );
    }
    if (surgeryRequest.status == 'In-Queue') {
      surgeryRequest.status = 'Complete'
      this.surgeryService.updateSurgery(surgeryRequest).subscribe(
        reset => {
          this.getAllSurgeryRequest();
          this.toastr.info("Succefull", "Change Status have Id: " + surgeryRequest.surgeryRequestId);
        },
        err => { console.log(err) }
      );
    }
  }
  Search(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourse.filter = filvalue;
  }
  openDeleteSurgery(surgeryRequestId: number, patientName: string) {
    const deletPatient = this.diaLog.open(DeleteSurgeryRequestComponent, { data: { id: surgeryRequestId, name: patientName } });
    deletPatient.afterClosed().subscribe(result => {
      this.getAllSurgeryRequest();
    })
  }
}
