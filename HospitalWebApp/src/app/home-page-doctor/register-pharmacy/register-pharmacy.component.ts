import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { MedicineService } from 'src/app/service/medicine.service';
import { PharmacyInfoService } from 'src/app/service/pharmacy-info.service';

@Component({
  selector: 'app-register-pharmacy',
  templateUrl: './register-pharmacy.component.html',
  styleUrls: ['./register-pharmacy.component.css']
})
export class RegisterPharmacyComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: number, name: string }, private pharmacyService: PharmacyInfoService, private toastr: ToastrService, private diaLog: MatDialog, private medicineService: MedicineService) { }
  medicineList: any;
  PharmacyInfoForm = new FormGroup({
    pharmacyInforId: new FormControl(0),
    department: new FormControl(localStorage.getItem('department')),
    status: new FormControl('Ordered'),
    quantity: new FormControl('', [Validators.required, Validators.min(0), Validators.max(20)]),
    medicineId: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.maxLength(500)]),
    patientId: new FormControl(this.data.id),
    // this.data.id
  });
  get pharmacyInforId() {
    return this.PharmacyInfoForm.get('pharmacyInforId')
  } get department() {
    return this.PharmacyInfoForm.get('department')
  } get status() {
    return this.PharmacyInfoForm.get('status')
  } get medicineId() {
    return this.PharmacyInfoForm.get('medicineId')
  } get description() {
    return this.PharmacyInfoForm.get('description')
  } get patientId() {
    return this.PharmacyInfoForm.get('patientId')
  } get quantity() {
    return this.PharmacyInfoForm.get('quantity')
  }
  ngOnInit(): void {
    this.medicineService.getAllMedicine().subscribe(res => {
      this.medicineList = res;
    })
  }

  onSubmit() {
    console.log(this.PharmacyInfoForm.value);
    this.pharmacyService.createPharmacy(this.PharmacyInfoForm.value).subscribe(
      reset => {
        this.PharmacyInfoForm.reset(); 
        this.toastr.success("Succefull", "Register Pharmacy for patient");
        this.diaLog.closeAll();
      },
      err => {
        console.log(err)
        this.toastr.error("Something Wrong", "please try again");
      }
    )
  }
}
