import { Component, OnInit, signal } from '@angular/core';
import { TeamService } from '../../shared/domain/services/team.service';
import { ActivatedRoute } from '@angular/router';
import { TeamDto } from '../../shared/domain/dtos/team.dto';

@Component({
  selector: 'app-team',
  standalone: true,
  imports: [],
  templateUrl: './team.component.html',
  styleUrl: './team.component.css'
})
export class TeamComponent implements OnInit {

  protected team = signal<TeamDto | undefined>(undefined);

  constructor(private teamService: TeamService, private route: ActivatedRoute) { }

  public ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')!;

    this.fetchTeam(id);
  }

  private fetchTeam(id: string) {
    this.teamService.retrieve(id)
      .subscribe(response => {
        this.team.set(response);
      })
  }
}
