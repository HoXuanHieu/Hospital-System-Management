import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { UrineTestService } from 'src/app/service/urine-test.service';

@Component({
  selector: 'app-update-urine-test-info',
  templateUrl: './update-urine-test-info.component.html',
  styleUrls: ['./update-urine-test-info.component.css']
})
export class UpdateUrineTestInfoComponent implements OnInit {

  constructor(private urineTestService : UrineTestService, private toastr: ToastrService, private diaLog: MatDialog) { }

  ngOnInit(): void {
  }
  urineTestForm = new FormGroup({
    urineTestId : new FormControl(this.urineTestService.urineTest.urineTestId),
    mediclatestype: new FormControl(this.urineTestService.urineTest.mediclatestype, [Validators.required]), //cac loai test
    color: new FormControl(this.urineTestService.urineTest.color, [Validators.required]),
    calrity: new FormControl(this.urineTestService.urineTest.calrity, [Validators.required]),
    odor: new FormControl(this.urineTestService.urineTest.odor, [Validators.required]),
    specificgravity: new FormControl(this.urineTestService.urineTest.specificgravity, [Validators.required]),
    glucose: new FormControl(this.urineTestService.urineTest.glucose, [Validators.required, Validators.min(0), Validators.max(10)]),
    description: new FormControl(this.urineTestService.urineTest.description),
    patientId: new FormControl(this.urineTestService.urineTest.patientId, [Validators.required]),
  })
  get urineTestId() {
    return this.urineTestForm.get('urineTestId'); 
  } get mediclatestype() {
    return this.urineTestForm.get('mediclatestype');
  } get color() {
    return this.urineTestForm.get('color');
  } get calrity() {
    return this.urineTestForm.get('calrity');
  } get odor() {
    return this.urineTestForm.get('odor');
  } get specificgravity() {
    return this.urineTestForm.get('specificgravity');
  } get glucose() {
    return this.urineTestForm.get('glucose');
  } get description() {
    return this.urineTestForm.get('description');
  } get patientId() {
    return this.urineTestForm.get('patientId');
  }

  onSubmit(){
    // console.log(this.bloodTestForm.value);
    
    this.urineTestService.update(this.urineTestForm.value).subscribe(
      reset => {
        this.urineTestForm.reset();
        this.toastr.info("Succefull", "Update a UrineTest");
        this.diaLog.closeAll();
      },
      err => {
        console.log(err)
        this.toastr.error("Something Wrong", "please try again");
      }
    )
  }
}
