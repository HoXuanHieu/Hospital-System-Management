import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { MedicineService } from 'src/app/service/medicine.service';

@Component({
  selector: 'app-medicine-delete',
  templateUrl: './medicine-delete.component.html',
  styleUrls: ['./medicine-delete.component.css']
})
export class MedicineDeleteComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: number, name: string },private medicineService: MedicineService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  delete(){
    this.medicineService.deleteMedicine(this.data.id).subscribe(
      reset => {
        this.toastr.error("Successfull", "Delete a Blood Test of " + this.data.name);
      }, err => { console.log(err);
        this.toastr.error("Something wrong", "Please try again!");
       });
  }
}
