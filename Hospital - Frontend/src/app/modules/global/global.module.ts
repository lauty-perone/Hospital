import { NgModule } from "@angular/core";

import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";

import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from "@angular/material/card";
import { MatToolbarModule } from "@angular/material/toolbar";
import {MatButtonModule} from '@angular/material/button';
import { ToastrModule } from "ngx-toastr";

@NgModule({
    declarations : [],
    imports : [ 
        CommonModule,
        RouterModule,
        HttpClientModule,
        ToastrModule.forRoot({
            closeButton : true,
            progressBar : true,
            enableHtml : true,
          }),

        MatToolbarModule,
        MatButtonModule,
        MatIconModule,
        MatCardModule,
    ],
    exports : [
        ToastrModule,
        MatToolbarModule,
        MatButtonModule,
        MatIconModule,
        MatCardModule
    ]
})

export class GlobalModule {}