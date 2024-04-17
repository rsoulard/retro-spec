import { Routes } from '@angular/router';
import { BoardComponent } from './routes/board/board.component';
import { TeamComponent } from './routes/team/team.component';

export const routes: Routes = [
  { path: 'board/:id', component: BoardComponent },
  { path: 'team/:id', component: TeamComponent }
];
