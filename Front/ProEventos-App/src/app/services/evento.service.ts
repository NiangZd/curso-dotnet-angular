import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../Models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  private baseURL = 'http://localhost:5130/api/Eventos';


  constructor(
    private http: HttpClient
  ) { }


  /**
   * Busca todos os eventos.
   */
  public getEventos(): Observable<Evento[]> {

    return this.http.get<Evento[]>(
      this.baseURL
    );

  }


  /**
   * Busca eventos por tema.
   */
  public getEventosByTema(tema: string): Observable<Evento[]> {

    return this.http.get<Evento[]>(
      `${this.baseURL}/tema/${tema}`
    );

  }


  /**
   * Busca evento pelo ID.
   */
  public getEventoById(id: number): Observable<Evento> {

    return this.http.get<Evento>(
      `${this.baseURL}/${id}`
    );

  }


  /**
   * Exclui evento pelo ID.
   */
  public deleteEvento(id: number): Observable<void> {

    return this.http.delete<void>(
      `${this.baseURL}/${id}`
    );

  }

}
