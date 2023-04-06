import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BloodTestInfoWithPatientName } from '../model/blood-test-info-with-patient-name.model';
import { BloodTest } from '../model/blood-test.model';

@Injectable({
  providedIn: 'root'
})
export class BloodTestService {

  constructor(private http: HttpClient) { }
  readonly bloodUrl = "https://localhost:44392/api/BloodTestInfor";
  bloodTest: BloodTest = new BloodTest();

  creatBloodTes(bloodTest: any) {
    return this.http.post(this.bloodUrl, bloodTest);
  }
  getBloodTestList(): Observable<BloodTestInfoWithPatientName> {
    return this.http.get<BloodTestInfoWithPatientName>(this.bloodUrl + '/getListWithPatientName');
  }
  delete(id: number) {
    return this.http.delete(this.bloodUrl + "/" + id);
  }
  update(bloodTest: any) {
    return this.http.put(this.bloodUrl + "/" + bloodTest.bloodTestId, bloodTest);
  }
}
