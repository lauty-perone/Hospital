import { Component } from '@angular/core';
import {MatChipsModule} from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-index',
    imports: [MatChipsModule, MatIconModule, MatCardModule, RouterModule],
    templateUrl: './index.component.html',
    styleUrl: './index.component.scss'
})
export class IndexComponent {
}
