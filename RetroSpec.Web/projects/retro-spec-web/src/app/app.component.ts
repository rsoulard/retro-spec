import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CardComponent, ColumnComponent, ButtonComponent} from 'retro-spec-components';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CardComponent,
    ColumnComponent,
    ButtonComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'retro-spec-web';

  protected handleClick() {
    console.log("Mean");
  }
}
