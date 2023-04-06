import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SurgeryRequestWithName } from '../model/surgery-request-with-name.model';

@Injectable({
  providedIn: 'root'
})
export class SurgeryService {

  constructor(private http: HttpClient) { }

  surguryReqUrl = 'https://localhost:44392/api/SurgeryRequest';

  createSurgeryRequest(surgeryReq: any) {
    return this.http.post(this.surguryReqUrl, surgeryReq);
  }
  getAllSurgerywithName(): Observable<SurgeryRequestWithName> {
    return this.http.get<SurgeryRequestWithName>(this.surguryReqUrl + '/getListWithName');
  }
  getAllSurgeryByStaffId(id: number): Observable<SurgeryRequestWithName> {
    return this.http.get<SurgeryRequestWithName>(this.surguryReqUrl + '/getSurgeryRequestbyStaffId/' + id);
  }
  updateSurgery(surgery: any) {
    return this.http.put(this.surguryReqUrl + '/' + surgery.surgeryRequestId, surgery);
  }
  delete(id: number) {
    return this.http.delete(this.surguryReqUrl + '/' + id);
  }
}
