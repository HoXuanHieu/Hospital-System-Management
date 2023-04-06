import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from 'src/app/service/patient.service';

@Component({
  selector: 'app-delete-patient',
  templateUrl: './delete-patient.component.html',
  styleUrls: ['./delete-patient.component.css']
})
export class DeletePatientComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: number, name: string }, public patientService: PatientService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  delete() {
    this.patientService.delete(this.data.id).subscribe(
      reset => {
        this.toastr.error("Successfull", "Delete a Patient " + this.data.name);
      }, err => { console.log(err) });
  }
}
