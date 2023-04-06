import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Patient } from 'src/app/model/patient.model';
import { PatientService } from 'src/app/service/patient.service';
import { UrineTestService } from 'src/app/service/urine-test.service';

@Component({
  selector: 'app-urine-test-form',
  templateUrl: './urine-test-form.component.html',
  styleUrls: ['./urine-test-form.component.css']
})
export class UrineTestFormComponent implements OnInit {

  constructor(public patientService: PatientService, private toastr: ToastrService, private router: Router, private urineTestService: UrineTestService) { }

  // Red blood cell urine test
  // Glucose urine test
  // Protein urine test
  // Urine pH level test
  // Ketones urine test
  // Bilirubin urine test
  // Urine specific gravity test

  //   Clear: No visible particles or debris are present in the urine.
  // Hazy: The urine appears slightly cloudy or unclear, but there are no visible particles or sediment.
  // Cloudy: The urine appears significantly cloudy or opaque, and there may be visible particles or sediment present.
  // Turbid: The urine is very cloudy or milky in appearance, and there may be a significant amount of visible sediment or particles.
  // Bloody: The urine appears pink, red, or brown in color due to the presence of blood.
  // Brown: The urine appears dark brown in color, which may indicate the presence of bilirubin or other substances.
  // Yellow: The urine appears bright yellow in color, which may be a sign of dehydration or certain medications.
  // Green: The urine appears green in color, which may be a sign of a bacterial infection or other condition.

  //   Ammonia: A strong ammonia-like smell in urine may indicate a urinary tract infection (UTI) or dehydration.
  // Sweet or fruity: A sweet or fruity odor in urine may be a sign of uncontrolled diabetes or high levels of ketones in the body.
  // Fishy: A fishy odor in urine may be a sign of bacterial vaginosis or other bacterial infections.
  // Musty: A musty or moldy odor in urine may be a sign of liver disease or certain metabolic disorders.
  // Rotten: A strong, rotten egg-like odor in urine may be a sign of a bacterial infection or a problem with the digestive system.
  // Chemical: A strong chemical odor in urine may be a sign of exposure to certain chemicals or toxins.

  ngOnInit(): void {
    this.getAllPatient();
  }

  urineTestForm = new FormGroup({
    mediclatestype: new FormControl('Urine Test', [Validators.required]), //cac loai test
    color: new FormControl('', [Validators.required]),
    calrity: new FormControl('', [Validators.required]),
    odor: new FormControl('', [Validators.required]),
    specificgravity: new FormControl('', [Validators.required]),
    glucose: new FormControl('', [Validators.required, Validators.min(0), Validators.max(10)]),
    description: new FormControl(''),
    patientId: new FormControl(this.patientService.formData.patientId, [Validators.required]),
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
  displayedColumns: string[] = ['patientName', 'age', 'gender', 'phoneNumber', 'address'];
  patientList: any;
  dataSourse: any

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  getAllPatient() {
    this.patientService.getAllPatient().subscribe(res => {
      this.patientList = res
      this.dataSourse = new MatTableDataSource<Patient>(this.patientList);
      this.dataSourse.paginator = this.paginator;
      this.dataSourse.sort = this.sort;
    })
  }
  Search(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSourse.filter = filvalue;
  }
  selectRecord(selectRecord: Patient) {
    this.patientService.formData = selectRecord;
    this.urineTestForm.patchValue({
      patientId: this.patientService.formData.patientId
    });
  }
  onSubmit(){
    console.log(this.urineTestForm.value);
    this.urineTestService.creatBloodTes(this.urineTestForm.value).subscribe(result => {
      this.toastr.success("Succefull", "Add a new Urine Test");
      this.urineTestForm.reset();
      this.router.navigate(['urine-test-list']);
    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
      this.urineTestForm.reset();
    });
  }
}
