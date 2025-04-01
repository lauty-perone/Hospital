import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbar } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { FormLoginComponent } from '../form-login/form-login.component';

@Component({
    selector: 'app-menu-global',
    imports: [MatIconModule, 
        MatToolbar, 
        RouterModule    
    ],
    templateUrl: './menu-global.component.html',
    styleUrl: './menu-global.component.scss'
})
export class MenuGlobalComponent {

    constructor(
        public dialog :  MatDialog
    ){
        
    }

    login(){
          const dialogRef = this.dialog.open(FormLoginComponent,{
            disableClose : true, //click fuera del formulario no se cierra
            autoFocus : true,
            closeOnNavigation : false, //al dar click en otra ventana ,no se cierra
            position : {top : '30px'},
            width : '700px',
            data : {
              tipo : 'LOGIN' //comportamiento de la ventana
            }
          });
      
          dialogRef.afterClosed().subscribe(result => {
            console.log(`Dialog result: ${result}`);
          });
        }
}
