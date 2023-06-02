import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-jogadores',
  templateUrl: './jogadores.component.html',
  styleUrls: ['./jogadores.component.scss']
})
export class JogadoresComponent {

  public jogadores: any;

  constructor(private http: HttpClient){ }

  ngOnInit(): void {
    this.getJogadores();
  }

  public getJogadores(): void {
    this.http.get('https://localhost:7249/api/Jogador').subscribe(
      response => this.jogadores = response,
      error => console.log(error),
    );
  }

}
