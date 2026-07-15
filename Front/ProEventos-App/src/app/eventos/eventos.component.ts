import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];

  public filtro = new FormControl('');

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();

    this.filtro.valueChanges.subscribe(valor => {
      this.filtrarEventos(valor ?? '');
    });
  }

  public filtrarEventos(valor: string): void {

    valor = valor.toLowerCase();

    this.eventosFiltrados = this.eventos.filter((evento: { tema: string; local: string; }) =>
      evento.tema.toLowerCase().includes(valor) ||
      evento.local.toLowerCase().includes(valor)
    );

  }

  public getEventos() : void{
    this.http.get('http://localhost:5130/api/Eventos').subscribe({
      next: (response) => {
        this.eventos = response;
        this.eventosFiltrados = response;
      },
      error: (error) => console.log(error)
    });
  }
}
