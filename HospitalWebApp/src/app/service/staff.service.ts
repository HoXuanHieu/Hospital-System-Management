import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Staff } from '../model/staff.model';

@Injectable({
  providedIn: 'root'
})
export class StaffService {

  constructor(private http: HttpClient) { }
  readonly baseUrl = "https://localhost:44392/api/Staff";
  listStaff: Staff[];
  staff: Staff;
  formData: Staff = new Staff();
  formRegister: Staff = new Staff();

  getDoctor(): Observable<Staff> {
    return this.http.get<Staff>(this.baseUrl + '/Doctor');
  }
  getDoctor2() {
    this.http.get(this.baseUrl + '/Doctor').toPromise().then(res => this.listStaff = res as Staff[]);
  }
  getSurgeryDoctor(): Observable<Staff> {
    return this.http.get<Staff>(this.baseUrl + '/getSurgeryDoctor');
  }
  create(user: any) {
    return this.http.post(this.baseUrl, user);
  }
  update(user: any) {
    return this.http.put(`${this.baseUrl}/${user.staffId}`, user);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  getById(id: number) {
    this.http.get(`${this.baseUrl}/${id}`).toPromise().then(res => this.staff = res as Staff);
  }

  getDoctorPerPage(pageNumber: number, pageSize: number, status: string, sortColunm: string, searchText: string): Observable<any> {
    // getStaffpage
    // /api/Staff/GetStaffPagebySqlDapper/{pageNumber}/{pageSize}/{sortWith}/{search}/{status}
    if (searchText == '') {
      if (pageNumber == null) {
        return this.http.get<any>(this.baseUrl + '/GetStaffPagebySqlDapper/' + 1 + '/' + pageSize + '/' + sortColunm + '/none/' + status)
      } else {
        return this.http.get<any>(this.baseUrl + '/GetStaffPagebySqlDapper/' + pageNumber + '/' + pageSize + '/' + sortColunm + '/none/' + status)
      }
    } else {
      if (pageNumber == null) {
        return this.http.get<any>(this.baseUrl + '/GetStaffPagebySqlDapper/' + 1 + '/' + pageSize + '/' + sortColunm + '/' + searchText + '/' + status)
      } else {
        return this.http.get<any>(this.baseUrl + '/GetStaffPagebySqlDapper/' + pageNumber + '/' + pageSize + '/' + sortColunm + '/' + searchText + '/' + status)
      }
    }
  }

  getTotalPage(pageSize: number): Observable<number> {
    return this.http.get<number>(this.baseUrl + '/getMaxPage/' + pageSize);
  }
  ImportExcelFile(staff: any) {
    return this.http.post('https://localhost:44392/api/Staff/ImportExcel', staff);
  }
  // https://localhost:44392/api/Staff/ImportExcel
  getDoctorbyUserName(userName: any): Observable<Staff> {
    return this.http.get<Staff>(this.baseUrl + '/getDoctorByUserName/' + userName);
  }
  getDoctorbyEmail(email: any): Observable<Staff> {
    return this.http.get<Staff>(this.baseUrl + '/getDoctorByEmail/' + email);
  }
  getDoctorbyPhoneNumber(phoneNumber: any): Observable<Staff> {
    return this.http.get<Staff>(this.baseUrl + '/getDoctorByPhoneNumber/' + phoneNumber);

  }
}
