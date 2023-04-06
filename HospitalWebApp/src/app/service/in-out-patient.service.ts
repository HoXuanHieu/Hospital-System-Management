import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InPaientShowByDepartment } from '../model/in-paient-show-by-department.model';
import { InPatientWithDoctorName } from '../model/in-patient-with-doctor-name.model';
import { InPatient } from '../model/in-patient.model';
import { OutPaientShowByDepartment } from '../model/out-paient-show-by-department.model';
import { OutPatientWithDoctorName } from '../model/out-patient-with-doctor-name.model';
import { OutPatient } from '../model/out-patient.model';
import { Patient } from '../model/patient.model';

@Injectable({
  providedIn: 'root'
})
export class InOutPatientService {

  constructor(private http: HttpClient) { }

  readonly InPatientUrl = "https://localhost:44392/api/InPatient"
  readonly OutPatientUrl = "https://localhost:44392/api/OutPatient"
  readonly PatientUrl = "https://localhost:44392/api/Patient"
  readonly StaffUrl = "https://localhost:44392/api/Staff"

  patient: Patient = new Patient();
  listInPatient: InPatient[] = [];
  listOutPatient: OutPatient[] = [];
  DoctorName: string;
  // formOutpatient: OutPatient = new OutPatient();

  createInPatient(inPatient: any) {
    return this.http.post(this.InPatientUrl, inPatient);
  }
  createOutPatient(outPatient: any) {
    return this.http.post(this.OutPatientUrl, outPatient);
  }
  getInPatientById(id: number): Observable<InPatient> {
    return this.http.get<InPatient>(this.InPatientUrl + "/getInPatientListById/" + id)
  }
  getInPatientByIdWithDoctorName(id: number): Observable<InPatientWithDoctorName> {
    return this.http.get<InPatientWithDoctorName>(this.InPatientUrl + "/getInPatientListByIdWithDoctorName/" + id)
  }
  getOutatientById(id: number): Observable<OutPatient> {
    return this.http.get<OutPatient>(this.OutPatientUrl + "/getOutPatientListById/" + id)
  }
  getOutPatientByIdWithDoctorName(id: number): Observable<OutPatientWithDoctorName> {
    return this.http.get<OutPatientWithDoctorName>(this.OutPatientUrl + "/getOutPatientListByIdWithDoctorName/" + id);
  }
  getInPatientByDepartment(department: string): Observable<InPaientShowByDepartment>{
    return this.http.get<InPaientShowByDepartment>(this.InPatientUrl+'/getInPatientListByDepartment/' + department);
  }
  getOutPatientByDepartment(department: string): Observable<OutPaientShowByDepartment>{
    return this.http.get<OutPaientShowByDepartment>(this.OutPatientUrl+'/getOutPatientListByDepartment/' + department);
  }
  deleteInPatient(id: number){
    return this.http.delete(`${this.InPatientUrl}/${id}`);
  }
  deleteOutPatient(id: number){
    return this.http.delete(`${this.OutPatientUrl}/${id}`);  
  }
}
