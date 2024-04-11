import { Routes } from '@angular/router';
import { BoardComponent } from './routes/board/board.component';

export const routes: Routes = [
  { path: 'board/:id', component: BoardComponent },
  { path: '', redirectTo: '/board', pathMatch: 'full'}
];
