import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { time } from 'console';
import { Staff } from 'src/app/model/staff.model';
import { StaffService } from 'src/app/service/staff.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})

export class TestComponent implements OnInit {

  displayedColumns: string[] = ['staffName', 'age', 'gender', 'department', 'specialization', 'phoneNumber', 'address', 'email', 'action'];
  dataSourse: any
  doctorListOnPage: any;
  pageSize: number = 5;
  pageNumber: number = 1;
  maxPage: any;
  searchText: string = '';


  isSort: boolean = false;
  status: string = 'none';
  column: string = 'none';
  constructor(public doctorService: StaffService) { }

  ngOnInit(): void {
    this.getAll();
    this.doctorService.getDoctorPerPage(this.pageNumber, this.pageSize, 'none', 'none', this.searchText).subscribe(res => {
      this.maxPage = res.maxPage;
      // console.log(this.maxPage);
    });
    // console.log(this.status);
    // console.log(this.column);


  }
  getAll() {
    this.doctorService.getDoctorPerPage(this.pageNumber, this.pageSize, 'none', 'none', this.searchText).subscribe(res => {
      this.doctorListOnPage = res.staffListByPage;
      this.maxPage = res.maxPage;
      this.dataSourse = new MatTableDataSource<Staff>(this.doctorListOnPage);
    });
  }
  selectPageSize() {
    this.doctorService.getDoctorPerPage(this.pageNumber, this.pageSize, this.status, this.column, this.searchText).subscribe(res => {
      this.doctorListOnPage = res.staffListByPage;
      this.maxPage = res.maxPage;
      this.dataSourse = new MatTableDataSource<Staff>(this.doctorListOnPage);
    });
  }
  pageNumberChange(change: string) {
    if (change == 'up') {
      this.pageNumber++;
      this.doctorService.getDoctorPerPage(this.pageNumber, this.pageSize, this.status, this.column, this.searchText).subscribe(res => {
        this.doctorListOnPage = res.staffListByPage;
        this.maxPage = res.maxPage;
        this.dataSourse = new MatTableDataSource<Staff>(this.doctorListOnPage);
      });
    }
    if (change == 'down') {
      this.pageNumber--;
      this.doctorService.getDoctorPerPage(this.pageNumber, this.pageSize, this.status, this.column, this.searchText).subscribe(res => {
        this.doctorListOnPage = res.staffListByPage;
        this.maxPage = res.maxPage;
        this.dataSourse = new MatTableDataSource<Staff>(this.doctorListOnPage);
      });
    }
  }
  Search() {
    if (this.searchText == '') {
      this.doctorService.getDoctorPerPage(this.pageNumber, this.pageSize, 'none', 'none', '').subscribe(res => {
        this.doctorListOnPage = res.staffListByPage;
        this.maxPage = res.maxPage;
        this.dataSourse = new MatTableDataSource<Staff>(this.doctorListOnPage);
      });
    } else {
      this.doctorService.getDoctorPerPage(1, this.pageSize, 'none', 'none', this.searchText).subscribe(res => {
        this.doctorListOnPage = res.staffListByPage;
        this.maxPage = res.maxPage;
        this.dataSourse = new MatTableDataSource<Staff>(this.doctorListOnPage);
      });
    }
  }
  ChangeStatusOfColumn(columnChange: string) {
    if (this.column == columnChange) {
      if (this.status == 'asc') {
        this.status = 'desc';
        this.doctorService.getDoctorPerPage(1, this.pageSize, this.status, this.column, '').subscribe(res => {
          this.doctorListOnPage = res.staffListByPage;
          this.maxPage = res.maxPage;

          this.dataSourse = new MatTableDataSource<Staff>(this.doctorListOnPage);
        });
      } else if (this.status == 'desc') {
        this.status = 'none';
        this.column = 'none';
        this.doctorService.getDoctorPerPage(1, this.pageSize, this.status, this.column, '').subscribe(res => {
          this.doctorListOnPage = res.staffListByPage;
          this.maxPage = res.maxPage;
          this.dataSourse = new MatTableDataSource<Staff>(this.doctorListOnPage);
        });
      }
    } else {
      this.column = columnChange;
      this.status = 'asc';
      this.doctorService.getDoctorPerPage(1, this.pageSize, this.status, this.column, '').subscribe(res => {
        this.doctorListOnPage = res.staffListByPage;
        this.maxPage = res.maxPage;
        this.dataSourse = new MatTableDataSource<Staff>(this.doctorListOnPage);
      })
    }
  }
}
