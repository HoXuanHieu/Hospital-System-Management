import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UrineTestInfoWithPatientName } from '../model/urine-test-info-with-patient-name.model';
import { UrineTestInfo } from '../model/urine-test-info.model';

@Injectable({
  providedIn: 'root'
})
export class UrineTestService {

  constructor(private http: HttpClient) { }
  readonly  urineUrl = "https://localhost:44392/api/UrineTestInfor";

  urineTest: UrineTestInfo = new UrineTestInfo();

  creatBloodTes(bloodTest: any) {
    return this.http.post(this.urineUrl, bloodTest);
  }
  getBloodTestList(): Observable<UrineTestInfoWithPatientName> {
    return this.http.get<UrineTestInfoWithPatientName>(this.urineUrl + '/getListWithPatientName');
  }
  delete(id: number) {
    return this.http.delete(this.urineUrl + "/" + id);
  }
  update(urineTest: any) {
    return this.http.put(this.urineUrl + "/" + urineTest.urineTestId, urineTest);
  }
}
