import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { BloodTestService } from 'src/app/service/blood-test.service';

@Component({
  selector: 'app-delete-blood-test-info',
  templateUrl: './delete-blood-test-info.component.html',
  styleUrls: ['./delete-blood-test-info.component.css']
})
export class DeleteBloodTestInfoComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: number, name: string },private bloodTestService: BloodTestService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  delete() {
    this.bloodTestService.delete(this.data.id).subscribe(
      reset => {
        this.toastr.error("Successfull", "Delete a Blood Test of " + this.data.name);
      }, err => { console.log(err) });
  }
}
