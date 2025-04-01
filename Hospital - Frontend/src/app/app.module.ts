import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app.routes";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { GlobalModule } from "./modules/global/global.module";
import { HttpClientModule } from "@angular/common/http";
import { ToastrModule, ToastrService } from "ngx-toastr";


@NgModule({
    declarations : [
        AppComponent
    ],
    imports : [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        GlobalModule,
        HttpClientModule
    ],
    providers: [],
    bootstrap : [AppComponent]
})

export class AppModule {}