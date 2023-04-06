import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { BloodTestService } from 'src/app/service/blood-test.service';

@Component({
  selector: 'app-update-blood-test-info',
  templateUrl: './update-blood-test-info.component.html',
  styleUrls: ['./update-blood-test-info.component.css']
})
export class UpdateBloodTestInfoComponent implements OnInit {

  constructor(private toastr: ToastrService,  private diaLog: MatDialog, private bloodTestService : BloodTestService) { }

  ngOnInit(): void {
  }
  bloodTestForm = new FormGroup({
    bloodTestId: new FormControl(this.bloodTestService.bloodTest.bloodTestId),
    mediclatestype: new FormControl(this.bloodTestService.bloodTest.mediclatestype,[Validators.required]),
    bloodGroup: new FormControl(this.bloodTestService.bloodTest.bloodGroup,[Validators.required]), 
    haemoglobin: new FormControl(this.bloodTestService.bloodTest.haemoglobin,[Validators.required, Validators.min(5), Validators.max(20)]), 
    bloodsugar: new FormControl(this.bloodTestService.bloodTest.bloodsugar,[Validators.required, Validators.min(3), Validators.max(10)]), 
    sacid: new FormControl(this.bloodTestService.bloodTest.sacid,[Validators.required, Validators.min(3), Validators.max(10)]), 
    description: new FormControl(this.bloodTestService.bloodTest.description),
    patientId: new FormControl(this.bloodTestService.bloodTest.patientId)
  })
  get bloodTestId() {
    return this.bloodTestForm.get('bloodTestId');
  } get mediclatestype() {
    return this.bloodTestForm.get('mediclatestype');
  } get bloodGroup() {
    return this.bloodTestForm.get('bloodGroup');
  } get haemoglobin() {
    return this.bloodTestForm.get('haemoglobin');
  } get bloodsugar() {
    return this.bloodTestForm.get('bloodsugar');
  } get sacid() {
    return this.bloodTestForm.get('sacid');
  } get description() {
    return this.bloodTestForm.get('description');
  }

  onSubmit(){
    // console.log(this.bloodTestForm.value);
    
    this.bloodTestService.update(this.bloodTestForm.value).subscribe(
      reset => {
        this.bloodTestForm.reset();
        this.toastr.info("Succefull", "Update a Employee");
        this.diaLog.closeAll();
      },
      err => {
        console.log(err)
        this.toastr.error("Something Wrong", "please try again");
      }
    )
  }
}
