import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';

import { MatTabsModule } from '@angular/material/tabs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSortModule } from '@angular/material/sort';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { ScrollingModule } from '@angular/cdk/scrolling';


import { ReactiveFormsModule } from '@angular/forms';
import { AuthorInterceptor } from './service/author.interceptor';


import { LoginPageComponent } from './login-page/login-page.component';
import { HomePageAdminComponent } from './home-page-admin/home-page-admin.component';
import { HeaderAdminComponent } from './home-page-admin/header-admin/header-admin.component';
import { DoctorListComponent } from './home-page-admin/doctor/doctor-list/doctor-list.component';
import { DoctorComponent } from './home-page-admin/doctor/doctor.component';
import { DoctorFormComponent } from './home-page-admin/doctor/doctor-form/doctor-form.component';
import { DoctorUpdateFormComponent } from './home-page-admin/doctor/doctor-update-form/doctor-update-form.component';
import { TestComponent } from './home-page-admin/doctor/test/test.component';
import { PatientListComponent } from './home-page-admin/patient/patient-list/patient-list.component';
import { PatientFormComponent } from './home-page-admin/patient/patient-form/patient-form.component';
import { PatientUpdateFormComponent } from './home-page-admin/patient/patient-update-form/patient-update-form.component';
import { RegisterInPatientFormComponent } from './home-page-admin/patient/register-in-patient-form/register-in-patient-form.component';
import { DeleteDoctorComponent } from './home-page-admin/doctor/delete-doctor/delete-doctor.component';
import { DeletePatientComponent } from './home-page-admin/patient/delete-patient/delete-patient.component';
import { RegisterOutPatientComponent } from './home-page-admin/patient/register-out-patient/register-out-patient.component';
import { ListInOutPatientComponent } from './home-page-admin/patient/list-in-out-patient/list-in-out-patient.component';
import { BloodTestFormComponent } from './home-page-admin/blood-test/blood-test-form/blood-test-form.component';
import { BloodTestListComponent } from './home-page-admin/blood-test/blood-test-list/blood-test-list.component';
import { DeleteBloodTestInfoComponent } from './home-page-admin/blood-test/blood-test-list/delete-blood-test-info/delete-blood-test-info.component';
import { UpdateBloodTestInfoComponent } from './home-page-admin/blood-test/blood-test-list/update-blood-test-info/update-blood-test-info.component';
import { UrineTestListComponent } from './home-page-admin/urine-test/urine-test-list/urine-test-list.component';
import { UrineTestFormComponent } from './home-page-admin/urine-test/urine-test-form/urine-test-form.component';
import { UpdateUrineTestInfoComponent } from './home-page-admin/urine-test/urine-test-list/update-urine-test-info/update-urine-test-info.component';
import { DeleteUrineTestInfoComponent } from './home-page-admin/urine-test/urine-test-list/delete-urine-test-info/delete-urine-test-info.component';
import { SurgeryRequestFormComponent } from './home-page-admin/surgery/surgery-request-form/surgery-request-form.component';
import { SurgeryRequestListComponent } from './home-page-admin/surgery/surgery-request-list/surgery-request-list.component';
import { UpdateSurgeryRequestComponent } from './home-page-admin/surgery/update-surgery-request/update-surgery-request.component';
import { DeleteSurgeryRequestComponent } from './home-page-admin/surgery/delete-surgery-request/delete-surgery-request.component';
import { HomePageDoctorComponent } from './home-page-doctor/home-page-doctor.component';
import { HeaderDoctorComponent } from './home-page-doctor/header-doctor/header-doctor.component';
import { SurgeryListForDoctorComponent } from './home-page-doctor/surgery-list-for-doctor/surgery-list-for-doctor.component';
import { RegisterPharmacyComponent } from './home-page-doctor/register-pharmacy/register-pharmacy.component';
import { PharmacyListComponent } from './home-page-doctor/pharmacy-infor/pharmacy-list/pharmacy-list.component';
import { PharmacyDeleteComponent } from './home-page-doctor/pharmacy-infor/pharmacy-delete/pharmacy-delete.component';
import { MedicineListComponent } from './home-page-admin/medicine-info/medicine-list/medicine-list.component';
import { MedicineImportExcelComponent } from './home-page-admin/medicine-info/medicine-import-excel/medicine-import-excel.component';
import { MedicineUdpateComponent } from './home-page-admin/medicine-info/medicine-list/medicine-udpate/medicine-udpate.component';
import { MedicineDeleteComponent } from './home-page-admin/medicine-info/medicine-list/medicine-delete/medicine-delete.component';
import { DoctorImportExcelComponent } from './home-page-admin/doctor/doctor-import-excel/doctor-import-excel.component';
import { MedicineCreateComponent } from './home-page-admin/medicine-info/medicine-create/medicine-create.component';
import { TestFormComponent } from './home-page-admin/doctor/test-form/test-form.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    HomePageAdminComponent,
    HeaderAdminComponent,
    DoctorListComponent,
    DoctorComponent,
    DoctorFormComponent,
    DoctorUpdateFormComponent,
    TestComponent,
    PatientListComponent,
    PatientFormComponent,
    PatientUpdateFormComponent,
    RegisterInPatientFormComponent,
    DeleteDoctorComponent,
    DeletePatientComponent,
    RegisterOutPatientComponent,
    ListInOutPatientComponent,
    BloodTestFormComponent,
    BloodTestListComponent,
    DeleteBloodTestInfoComponent,
    UpdateBloodTestInfoComponent,
    UrineTestListComponent,
    UrineTestFormComponent,
    UpdateUrineTestInfoComponent,
    DeleteUrineTestInfoComponent,
    SurgeryRequestFormComponent,
    SurgeryRequestListComponent,
    UpdateSurgeryRequestComponent,
    DeleteSurgeryRequestComponent,
    HomePageDoctorComponent,
    HeaderDoctorComponent,
    SurgeryListForDoctorComponent,
    RegisterPharmacyComponent,
    PharmacyListComponent,
    PharmacyDeleteComponent,
    MedicineListComponent,
    MedicineImportExcelComponent,
    MedicineUdpateComponent,
    MedicineDeleteComponent,
    DoctorImportExcelComponent,
    MedicineCreateComponent,
    TestFormComponent,

  ], entryComponents: [
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTabsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatRadioModule,
    MatCardModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    MatPaginatorModule,
    MatMenuModule,
    MatIconModule,
    MatTableModule,
    MatTooltipModule,
    MatSortModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatAutocompleteModule,
    ScrollingModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorInterceptor,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
