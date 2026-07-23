import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive
],
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent {

  public menuAberto = false;

  public usuario = {
    nome: 'Victor Gomes'
  };


  public toggleMenu(): void {

    this.menuAberto = !this.menuAberto;

  }

}
