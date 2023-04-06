import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Patient } from 'src/app/model/patient.model';
import { BloodTestService } from 'src/app/service/blood-test.service';
import { PatientService } from 'src/app/service/patient.service';

@Component({
  selector: 'app-blood-test-form',
  templateUrl: './blood-test-form.component.html',
  styleUrls: ['./blood-test-form.component.css']
})
export class BloodTestFormComponent implements OnInit {

  constructor(public patientService: PatientService, private bloodTestService: BloodTestService, private toastr: ToastrService, private router: Router) { }
  
  ngOnInit(): void {
    this.getAllPatient();
  }


  bloodTestForm = new FormGroup({
    mediclatestype: new FormControl('',[Validators.required]), //cac loai test
    bloodGroup: new FormControl('',[Validators.required]), //nhom mau
    haemoglobin: new FormControl('',[Validators.required, Validators.min(5), Validators.max(20)]), 
    //Giá trị của chỉ số HgB thay đổi tùy theo giới tính: Nam: 13 - 16g/dl. Nữ: 12.5 - 14.2g/dl.
    bloodsugar: new FormControl('',[Validators.required, Validators.min(3), Validators.max(10)]), 
    // Nồng độ Glucose máu được đánh giá là an toàn như sau (đơn vị sử dụng phổ biến là mmol/l hoặc mg/dL): Lúc đói (trước bữa ăn): 90 - 130 mg/dL (5 - 7,2 mmol/L). 
    //Sau khi ăn: dưới 180 mg/dL (xét nghiệm tiến hành 1 - 2 tiếng sau ăn). Trước khi ngủ: 100 - 150 mg/dL (6 - 8,3 mmol/L).
    sacid: new FormControl('',[Validators.required, Validators.min(3), Validators.max(10)]), 
    //Bình thường lượng acid uric trong máu luôn được giữ ổn định ở nồng độ dưới 7,0 mg/dl (420 micromol/l với nam) và dưới 6.0 mg/dl (360 micromol/l với nữ) 
    //và được giữ ở mức độ hằng định do sự cân bằng giữa quá trình tổng hợp và đào thải chất của cơ thể.
    description: new FormControl(''),
    patientId: new FormControl( this.patientService.formData.patientId,[Validators.required]),
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
  } get patientId() {
    return this.bloodTestForm.get('patientId');
  }

  displayedColumns: string[] = ['patientName', 'age', 'gender', 'phoneNumber','address'];
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
    this.bloodTestForm.patchValue({
      patientId : this.patientService.formData.patientId
    });
  }
  onSubmit(){
    console.log(this.bloodTestForm.value);
    this.bloodTestService.creatBloodTes(this.bloodTestForm.value).subscribe(result => {
      this.toastr.success("Succefull", "Add a new Employee");
      this.bloodTestForm.reset();
      this.router.navigate(['blood-test-list']);
    }, err => {
      console.log(err)
      this.toastr.error("Something Wrong", "please try again");
      this.bloodTestForm.reset();
    });
  }
}
