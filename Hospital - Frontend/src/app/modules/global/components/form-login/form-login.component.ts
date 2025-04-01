import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialog, MatDialogActions, MatDialogContent, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormField, MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatRadioButton, MatRadioModule } from '@angular/material/radio';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormComponent } from '../../../medico/components/form/form.component';
import { HttpService } from '../../../../services/http.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-form-login',
  imports: [
    MatDialogActions,
        MatDialogContent,
        MatRadioModule,
        MatLabel,
        MatDialogModule,
        MatSlideToggleModule,
        ReactiveFormsModule,
        MatDialogModule,
        MatFormFieldModule,
        MatInputModule,
        MatRadioModule,
        MatSlideToggleModule,
        MatButtonModule,
        FormsModule
  ],
  templateUrl: './form-login.component.html',
  styleUrl: './form-login.component.scss'
})
export class FormLoginComponent {

  formGroup! : FormGroup;

  constructor(
    public dialogRef : MatDialogRef<FormComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private fb : FormBuilder,
        private httpService: HttpService,
        private toastr : ToastrService
  ){}
  
  cancelar(){
    this.dialogRef.close()
  }

  iniciarSesion(){

  }
  /*initForm(){
    this.formGroup = this.fb.group({ //nombres recomendado iguales a los de la DB
        cedula : [{ value: null, disabled : false} , [Validators.required]], //configuraciones del campo, validadores(campo obligatorio)
        nombre : [{ value: null, disabled: false},[Validators.required]],
        apellidoPaterno : [{ value: null, disabled : false},[Validators.required]],
        apellidoMaterno : [{ value: null, disabled : false}],
        esEspecialista: [{ value: false, disabled : false},[Validators.required]],
        habilitado: [{ value: true, disabled : false},[Validators.required]]
    });*/

} 

