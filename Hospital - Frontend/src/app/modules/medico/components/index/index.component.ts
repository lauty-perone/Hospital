import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../../services/http.service';
import { HttpClientModule } from '@angular/common/http';
import {MatButtonModule} from '@angular/material/button';
import { MatIconModule } from "@angular/material/icon";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import { FormsModule } from '@angular/forms';
import {MatTooltipModule} from '@angular/material/tooltip';
import { ToastrService } from 'ngx-toastr';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { FormComponent } from '../form/form.component';

@Component({
  imports: [HttpClientModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    FormsModule,
    MatTooltipModule,
    MatDialogModule
  ],
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent implements OnInit {
  displayedColumns: string[] = ['cedula', 'nombre', 'esEspecialista', 'acciones'];
  dataSource = new MatTableDataSource<any>([]);

  cantidadTotal = 0;
  cantidadPorPagina = 10;
  numeroDePagina = 0;
  opcionesDePaginado: number[] = [1,5,10,25,100];

  textoBusqueda = '';

  constructor(
    private httpService: HttpService,
    private toastr : ToastrService,
    public dialog :  MatDialog          
  ){}

  ngOnInit(): void {
    this.LeerTodo();
  }

  LeerTodo(){
    this.httpService.LeerTodo(this.cantidadPorPagina, this.numeroDePagina, this.textoBusqueda )
      .subscribe((respuesta: any) => { 
         this.dataSource.data = respuesta.datos.elemento;
         this.cantidadTotal = respuesta.datos.cantidadTotal;       
      });
  }
  cambiarPagina(event : any){
    this.cantidadPorPagina = event.pageSize;
    this.numeroDePagina = event.pageIndex;

    this.LeerTodo();
  }

  Eliminar(medicoId: number){
    let confirmacion = confirm('¿Está seguro/a que desea eliminar el elemento?');
    
    if(confirmacion){
      let ids = [medicoId];
      
      this.httpService.Eliminar(ids).subscribe((respuesta: any) => { 
          this.toastr.success("Elemento <b> eliminado </b> satisfactoriamente","Confirmación")
          this.LeerTodo();      
        });
    }
  }

  crearMedico(){
      const dialogRef = this.dialog.open(FormComponent,{
        disableClose : true, //click fuera del formulario no se cierra
        autoFocus : true,
        closeOnNavigation : false, //al dar click en otra ventana ,no se cierra
        position : {top : '30px'},
        width : '700px',
        data : {
          tipo : 'CREAR' //comportamiento de la ventana
        }
      });
  
      dialogRef.afterClosed().subscribe(result => {
        console.log(`Dialog result: ${result}`);
      });
    }
}

