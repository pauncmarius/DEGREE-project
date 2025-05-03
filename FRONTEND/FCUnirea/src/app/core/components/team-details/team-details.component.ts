import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TeamService } from '../../services/teams.service';
import { Team } from '../../models/teams-model';
import { GamesService } from '../../services/games.service';
import { Game } from '../../models/games-model';
import { Player } from '../../models/players-model';
import { PlayersService } from '../../services/players.service';


@Component({
  selector: 'app-team-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './team-details.component.html',
  styleUrl: './team-details.component.scss'
})
export class TeamDetailsComponent implements OnInit {
  team!: Team;
  teamId!: number;
  games: Game[] = [];
  players: Player[] = [];



  constructor(private route: ActivatedRoute, private teamService: TeamService, private gamesService: GamesService, private playersService: PlayersService
  ) {}

  ngOnInit(): void {
    this.teamId = Number(this.route.snapshot.paramMap.get('id'));
    this.teamService.getTeamById(this.teamId).subscribe((team) => {
      this.team = team;
    });
    this.gamesService.getGamesByTeam(this.teamId).subscribe((games) => {
      this.games = games;
    });
    this.playersService.getPlayersByTeam(this.teamId).subscribe((players) => {
      this.players = players;
    });
  }

  calculateAge(birthDateStr: string): number {
    const birthDate = new Date(birthDateStr);
    const today = new Date();
    let age = today.getFullYear() - birthDate.getFullYear();
    const hasBirthdayPassedThisYear =
      today.getMonth() > birthDate.getMonth() ||
      (today.getMonth() === birthDate.getMonth() && today.getDate() >= birthDate.getDate());
  
    if (!hasBirthdayPassedThisYear) {
      age--;
    }
  
    return age;
  }
}
