import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BloodTestFormComponent } from './home-page-admin/blood-test/blood-test-form/blood-test-form.component';
import { BloodTestListComponent } from './home-page-admin/blood-test/blood-test-list/blood-test-list.component';
import { DoctorFormComponent } from './home-page-admin/doctor/doctor-form/doctor-form.component';
import { DoctorListComponent } from './home-page-admin/doctor/doctor-list/doctor-list.component';
import { DoctorUpdateFormComponent } from './home-page-admin/doctor/doctor-update-form/doctor-update-form.component';
import { DoctorComponent } from './home-page-admin/doctor/doctor.component';
import { TestFormComponent } from './home-page-admin/doctor/test-form/test-form.component';
import { TestComponent } from './home-page-admin/doctor/test/test.component';
import { HomePageAdminComponent } from './home-page-admin/home-page-admin.component';
import { MedicineImportExcelComponent } from './home-page-admin/medicine-info/medicine-import-excel/medicine-import-excel.component';
import { MedicineListComponent } from './home-page-admin/medicine-info/medicine-list/medicine-list.component';
import { ListInOutPatientComponent } from './home-page-admin/patient/list-in-out-patient/list-in-out-patient.component';
import { PatientFormComponent } from './home-page-admin/patient/patient-form/patient-form.component';
import { PatientListComponent } from './home-page-admin/patient/patient-list/patient-list.component';
import { PatientUpdateFormComponent } from './home-page-admin/patient/patient-update-form/patient-update-form.component';
import { RegisterInPatientFormComponent } from './home-page-admin/patient/register-in-patient-form/register-in-patient-form.component';
import { SurgeryRequestFormComponent } from './home-page-admin/surgery/surgery-request-form/surgery-request-form.component';
import { SurgeryRequestListComponent } from './home-page-admin/surgery/surgery-request-list/surgery-request-list.component';

import { UrineTestFormComponent } from './home-page-admin/urine-test/urine-test-form/urine-test-form.component';
import { UrineTestListComponent } from './home-page-admin/urine-test/urine-test-list/urine-test-list.component';
import { HomePageDoctorComponent } from './home-page-doctor/home-page-doctor.component';
import { PharmacyListComponent } from './home-page-doctor/pharmacy-infor/pharmacy-list/pharmacy-list.component';
import { RegisterPharmacyComponent } from './home-page-doctor/register-pharmacy/register-pharmacy.component';
import { SurgeryListForDoctorComponent } from './home-page-doctor/surgery-list-for-doctor/surgery-list-for-doctor.component';
import { LoginPageComponent } from './login-page/login-page.component';

const routes: Routes = [
  { path: 'home-page-admin', component: HomePageAdminComponent },
  { path: '', component: LoginPageComponent },
  { path: 'doctor', component: DoctorComponent },
  { path: 'list-doctor', component: DoctorListComponent },
  { path: 'add-doctor', component: DoctorFormComponent },
  { path: 'update-doctor', component: DoctorUpdateFormComponent },
  { path: 'list-patient', component: PatientListComponent },
  { path: 'add-patient', component: PatientFormComponent },
  { path: 'update-patient', component: PatientUpdateFormComponent },
  { path: 'register-in-patient', component: RegisterInPatientFormComponent },
  { path: 'in-out-patient-list', component: ListInOutPatientComponent },
  { path: 'blood-test-form', component: BloodTestFormComponent },
  { path: 'blood-test-list', component: BloodTestListComponent },
  { path: 'urine-test-list', component: UrineTestListComponent },
  { path: 'urine-test-form', component: UrineTestFormComponent },
  { path: 'surgery-request-form', component: SurgeryRequestFormComponent },
  { path: 'surgery-request-list', component: SurgeryRequestListComponent },
  { path: 'home-page-doctor', component: HomePageDoctorComponent },
  { path: 'surgery-request-for-doctor', component: SurgeryListForDoctorComponent },
  { path: 'pharmacy-form', component: RegisterPharmacyComponent },
  { path: 'pharmacy-list', component: PharmacyListComponent },
  { path: 'medicine-list', component: MedicineListComponent },
  { path: 'import-medicine-excel', component: MedicineImportExcelComponent },
  { path: 'test', component: TestComponent },
  { path: 'test-form', component: TestFormComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  hide = true;

}
