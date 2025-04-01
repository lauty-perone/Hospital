import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbar } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-menu-global',
    imports: [MatIconModule, MatToolbar, RouterModule],
    templateUrl: './menu-global.component.html',
    styleUrl: './menu-global.component.scss'
})
export class MenuGlobalComponent {

}
