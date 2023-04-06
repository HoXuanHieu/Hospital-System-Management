import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { SurgeryService } from 'src/app/service/surgery.service';

@Component({
  selector: 'app-delete-surgery-request',
  templateUrl: './delete-surgery-request.component.html',
  styleUrls: ['./delete-surgery-request.component.css']
})
export class DeleteSurgeryRequestComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: number, name: string },private surgeryRequest: SurgeryService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  delete() {
    this.surgeryRequest.delete(this.data.id).subscribe(
      reset => {
        this.toastr.error("Successfull", "Delete a Blood Test of " + this.data.name);
      }, err => { console.log(err) });
  }
}
