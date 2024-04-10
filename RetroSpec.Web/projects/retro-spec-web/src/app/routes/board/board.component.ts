import { Component } from '@angular/core';
import { CardComponent, ColumnComponent, ButtonComponent, IconComponent } from 'retro-spec-components';

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [
    CardComponent,
    ColumnComponent,
    ButtonComponent,
    IconComponent
  ],
  templateUrl: './board.component.html',
  styleUrl: './board.component.css'
})
export class BoardComponent {

}
