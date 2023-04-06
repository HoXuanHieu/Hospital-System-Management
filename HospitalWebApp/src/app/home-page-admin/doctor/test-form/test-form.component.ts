import { Component, OnInit } from '@angular/core';
import { FormControl, FormControlName, FormGroup } from '@angular/forms';
import { start } from 'repl';
import { map, Observable, startWith } from 'rxjs';
import { Medicine } from 'src/app/model/medicine.model';
import { MedicineService } from 'src/app/service/medicine.service';

@Component({
  selector: 'app-test-form',
  templateUrl: './test-form.component.html',
  styleUrls: ['./test-form.component.css']
})
export class TestFormComponent implements OnInit {

  constructor(public medicineService: MedicineService) { }
  ngOnInit(): void {
 
  }
  items = Array.from({length: 100000}).map((_, i) => `Item #${i}`);


}
