import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export const matchpassword: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
    let password = control.get('password');
    let confirmPass = control.get('conPassword');
    if (password && confirmPass && password?.value != confirmPass?.value) {
        return {
            passwordMatchError: true
        }
    }
    return null;
}