import { Component,Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, NgModel, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogActions, MatDialogContent, MatDialogModule} from '@angular/material/dialog';
import {  MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatRadioModule} from '@angular/material/radio';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { HttpService } from '../../../../services/http.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-form',
    imports: [MatDialogActions,
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
    templateUrl: './form.component.html',
    styleUrl: './form.component.scss'
})
export class FormComponent implements OnInit{

    formGroup! : FormGroup;
    constructor (
        @Inject(MAT_DIALOG_DATA) public data: any,
        public dialogRef : MatDialogRef<FormComponent>,
        private fb : FormBuilder,
        private httpService: HttpService,
        private toastr : ToastrService
    ){}

    ngOnInit(): void {
        this.initForm();
    }
    
    cancelar(){
        this.dialogRef.close()
    }

    guardar() {
        const formData = this.formGroup.getRawValue(); // Extrae los valores del formulario
        console.log('Datos a guardar:', formData); // Esto es solo para depurar
    
        // Envía los datos al backend a través del HttpService
        this.httpService.post(formData).subscribe((response : any) => {
            this.toastr.success('Los datos se han guardado correctamente.', 'Éxito');
            console.log('Respuesta del servidor:', response);
        });
        this.dialogRef.close();

        
    }  

    initForm(){
        this.formGroup = this.fb.group({ //nombres recomendado iguales a los de la DB
            cedula : [{ value: null, disabled : false} , [Validators.required]], //configuraciones del campo, validadores(campo obligatorio)
            nombre : [{ value: null, disabled: false},[Validators.required]],
            apellidoPaterno : [{ value: null, disabled : false},[Validators.required]],
            apellidoMaterno : [{ value: null, disabled : false}],
            esEspecialista: [{ value: false, disabled : false},[Validators.required]],
            habilitado: [{ value: true, disabled : false},[Validators.required]]
        });

    } 
}
