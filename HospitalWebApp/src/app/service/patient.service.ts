import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Patient } from '../model/patient.model';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  readonly patientUrl = "https://localhost:44392/api/Patient";

  formData : Patient = new Patient();
  constructor(private http: HttpClient) { }

  getAllPatient() : Observable<Patient>{
    return this.http.get<Patient>(this.patientUrl)
  }
  create(user: any){
    return this.http.post(this.patientUrl, user);
  }
  delete(id: number) {
    return this.http.delete(`${this.patientUrl}/${id}`);
  }
  update(patient: any){
    return this.http.put(`${this.patientUrl}/${patient.patientId}`, patient);
  }
}
