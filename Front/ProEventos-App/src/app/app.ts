import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from './shared/nav/nav.component';
import { EventoService } from './services/evento.service';
import { ToastComponent } from './fragments/toast/toast.component';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavComponent, ToastComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss',
  providers: [EventoService]
})
export class App {
  protected readonly title = signal('ProEventos-App');
}
