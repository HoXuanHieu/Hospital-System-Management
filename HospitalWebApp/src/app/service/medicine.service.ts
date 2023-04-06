import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Medicine } from '../model/medicine.model';

@Injectable({
  providedIn: 'root'
})
export class MedicineService {

  constructor(private http: HttpClient) { }
  medicineUrl = 'https://localhost:44392/api/Medicine';
  medicine: Medicine = new Medicine();
  getAllMedicine(): Observable<Medicine[]> {
    return this.http.get<Medicine[]>(this.medicineUrl);
  }
  public uploadExcelFile(medicine: any) {
    return this.http.post(this.medicineUrl + '/ImportExcel', medicine);
  }
  public deleteMedicine(id: number) {
    return this.http.delete(this.medicineUrl + '/' + id);
  }
  public updateMedicine(id: number) {
    return this.http.delete(this.medicineUrl + '/' + id);
  }
  public createMedicine(medicine: any) {
    return this.http.post(this.medicineUrl, medicine);
  }
  public update(medicine: any) {
    return this.http.put(this.medicineUrl + "/" + medicine.medicineId, medicine);
  }
  public getMedicineByName(name: any): Observable<Medicine> {
    return this.http.get<Medicine>(this.medicineUrl + '/getByName/' + name);
  }
}

