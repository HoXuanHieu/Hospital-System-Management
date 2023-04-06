import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PharmacyInfoService } from 'src/app/service/pharmacy-info.service';

@Component({
  selector: 'app-pharmacy-delete',
  templateUrl: './pharmacy-delete.component.html',
  styleUrls: ['./pharmacy-delete.component.css']
})
export class PharmacyDeleteComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: number, name: string }, public pharmacyService: PharmacyInfoService, private toastr: ToastrService) { }

  ngOnInit(): void {
    
  }
  delete() {
    this.pharmacyService.delete(this.data.id).subscribe(
      reset => {
        this.toastr.error("Successfull", "Delete a this pharmacy of patient: " + this.data.name);
      }, err => { console.log(err) });
  }
}
