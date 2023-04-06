import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { MedicineService } from 'src/app/service/medicine.service';

@Component({
  selector: 'app-medicine-create',
  templateUrl: './medicine-create.component.html',
  styleUrls: ['./medicine-create.component.css']
})
export class MedicineCreateComponent implements OnInit {

  constructor(private medicineService: MedicineService, private toastr: ToastrService, private dialog: MatDialog) { }
  medicineList: any;
  ngOnInit(): void {
    this.medicineService.getAllMedicine().subscribe(res => {
      this.medicineList = res;
    })
  }
  medicineForm = new FormGroup({
    medicineId: new FormControl(0),
    medicineName: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required]),
    company: new FormControl('', [Validators.required]),
    description: new FormControl('')
  });
  get medicineId() {
    return this.medicineForm.get('medicineId');
  } get medicineName() {
    return this.medicineForm.get('medicineName');
  } get price() {
    return this.medicineForm.get('price');
  } get company() {
    return this.medicineForm.get('company');
  } get description() {
    return this.medicineForm.get('description');
  }
  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode == 46) {
      return true;
    } if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }
  namExist: boolean = false;
  checkMedicineName() {
    this.medicineService.getMedicineByName(this.medicineForm.controls['medicineName'].value).subscribe(res => {
      if (res != null) {
        this.namExist = true;
      } else {
        this.namExist = false;
      }
    });
  }
  
  onSubmit() {
    // console.log(this.medicineForm.value); 
    this.medicineService.createMedicine(this.medicineForm.value).subscribe(result => {
      this.toastr.success("Succefull", "Add a new Medicine");
      this.medicineForm.reset();
      this.dialog.closeAll();
    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
      this.dialog.closeAll();
    });
  }
}
