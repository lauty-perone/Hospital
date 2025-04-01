import { NgModule } from "@angular/core";
import { RouterModule  } from "@angular/router";
import { globalRoutes } from "./modules/global/global.routing";
import { medicoRoutes } from "./modules/medico/medico.routing";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
    imports: [RouterModule.forChild([
        ...globalRoutes,
        ...medicoRoutes
    ]),HttpClientModule],
    exports: [RouterModule]
})
export class RutasModule {}