import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PharmacyByDepartment } from '../model/pharmacy-by-department';

@Injectable({
  providedIn: 'root'
})
export class PharmacyInfoService {

  constructor(private http: HttpClient) { }
  readonly pharmacyUrl = 'https://localhost:44392/api/PharmacyInfor';
  createPharmacy(pharmacyInfo: any) {
    return this.http.post(this.pharmacyUrl, pharmacyInfo);
  }
  getAllPharmacyByDepartment(department: string): Observable<PharmacyByDepartment> {
    return this.http.get<PharmacyByDepartment>(this.pharmacyUrl + '/getAllByDepartment/' + department);
  }
  delete(id: number) {
    return this.http.delete(`${this.pharmacyUrl}/${id}`);
  }
  getAllPharmacyByPatientId(patientId: number): Observable<PharmacyByDepartment> {
    return this.http.get<PharmacyByDepartment>(this.pharmacyUrl + '/getAllByPatientId/' + patientId);
  }
}
