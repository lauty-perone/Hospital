import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export class HttpService{
    
    constructor(
        private httpCliente: HttpClient
    ){}
        
    LeerTodo(cantidad: number, pagina:number, textoBusqueda: string){
        let parametros = new HttpParams();

        parametros = parametros.append('cantidad',cantidad);
        parametros = parametros.append('pagina',pagina);
        parametros = parametros.append('textoBusqueda',textoBusqueda);

        
        return this.httpCliente.get('http://localhost:58767/api/medico', { params : parametros});

    }

    Eliminar(ids :number[]){
        const option = {
            headers : new HttpHeaders({
                'Content-Type': 'application/json'
            }),
            body : ids
        };

        return this.httpCliente.delete('http://localhost:58767/api/medico',option);
    }

    post(medico: any) {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json'
        });
    
        return this.httpCliente.post('http://localhost:58767/api/medico', medico, { headers });
    }
    
}