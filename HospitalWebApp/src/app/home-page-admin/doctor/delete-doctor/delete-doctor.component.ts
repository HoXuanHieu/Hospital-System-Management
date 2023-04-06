import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { StaffService } from 'src/app/service/staff.service';


@Component({
  selector: 'app-delete-doctor',
  templateUrl: './delete-doctor.component.html',
  styleUrls: ['./delete-doctor.component.css']
})
export class DeleteDoctorComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: number, name: string }, public doctorService: StaffService, private toastr: ToastrService) { }

  ngOnInit(): void {

  }
  delete() {
    this.doctorService.delete(this.data.id).subscribe(
      reset => {
        this.toastr.error("Successfull", "Delete a Employee " + this.data.name);
      }, err => { console.log(err) });
  }
}
