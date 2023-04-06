import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { map, Observable, startWith } from 'rxjs';
import { Medicine } from 'src/app/model/medicine.model';
import { MedicineService } from 'src/app/service/medicine.service';

@Component({
  selector: 'app-medicine-udpate',
  templateUrl: './medicine-udpate.component.html',
  styleUrls: ['./medicine-udpate.component.css']
})
export class MedicineUdpateComponent implements OnInit {

  constructor(private medicineService: MedicineService, private toastr: ToastrService, private diaLog: MatDialog) { }
  ngOnInit(): void {
    this.getAllMedicineTest();
    this.filterOptions = this.medicineForm.controls['medicineName'].valueChanges.pipe(startWith('abc'),
      map((term) => {
        return this.medicineInfoList.filter((option: any) => option.medicineName.toLowerCase().includes(term));
      })
    );
  }
  medicineForm = new FormGroup({
    medicineId: new FormControl(this.medicineService.medicine.medicineId),
    medicineName: new FormControl(this.medicineService.medicine.medicineName, [Validators.required]),
    price: new FormControl(this.medicineService.medicine.price, [Validators.required]),
    company: new FormControl(this.medicineService.medicine.company, [Validators.required]),
    description: new FormControl(this.medicineService.medicine.description)
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

  medicineInfoList: Medicine[] = [];
  filterOptions: Observable<Medicine[]>;

  getAllMedicineTest() {
    this.medicineService.getAllMedicine().subscribe(res => {
      this.medicineInfoList = res;
    })
  }

  setMedicine() {
    // console.log(this.medicineForm.controls['medicineName'].value);

    this.medicineService.getMedicineByName(this.medicineForm.controls['medicineName'].value).subscribe(res => {
      if (res == null) {
        console.log('not found');
      } else {
        // console.log(res);
        this.medicineService.medicine = res;
        // console.log(this.medicineService.medicine);
        this.medicineForm.controls['medicineName'].setValue( this.medicineService.medicine.medicineName);
        this.medicineForm.controls['medicineId'].setValue( this.medicineService.medicine.medicineId);
        this.medicineForm.controls['price'].setValue( this.medicineService.medicine.price);
        this.medicineForm.controls['company'].setValue( this.medicineService.medicine.company);
        this.medicineForm.controls['description'].setValue( this.medicineService.medicine.description);
      }
    }, err => {
      console.error(err);
    })
  }

  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode == 46) {
      return true;
    }
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }
  onSubmit() {
    this.medicineService.update(this.medicineForm.value).subscribe(
      reset => {
        this.medicineForm.reset();
        this.toastr.info("Succefull", "Update a Medicine");
        this.diaLog.closeAll();
      },
      err => {
        console.log(err)
        this.toastr.error("Something Wrong", "please try again");
      }
    )
  }
}
