import { CommonModule, isPlatformBrowser } from '@angular/common';
import { ChangeDetectorRef, Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { Evento } from '../../Models/Evento';
import { EventoService } from '../../services/evento.service';
import { DateTimeFormatterPipe } from '../../helpers/DateTimeFormatter.pipe';
import { ToastService } from '../../fragments/toast/ToastService';
import { TituloComponent } from "../../shared/titulo/titulo.component";
import { finalize } from 'rxjs';

@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DateTimeFormatterPipe,
    TituloComponent
  ],
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {

  public eventos: Evento[] = [];

  public eventosFiltrados: Evento[] = [];

  public filtro = new FormControl('');

  public eventoIdSelecionado: number | null = null;

  // Controle do spinner
  public carregando = false;


  constructor(
    private eventoService: EventoService,
    private toast: ToastService,
    private cd: ChangeDetectorRef,
    @Inject(PLATFORM_ID) private platformId: Object
  ) { }


  ngOnInit(): void {

    /**
     * Evita conflito com SSR + Hydration.
     * A API será chamada somente no navegador.
     */
    if (isPlatformBrowser(this.platformId)) {

      this.getEventos();

    }


    this.filtro.valueChanges.subscribe(valor => {

      this.filtrarEventos(valor ?? '');

    });

  }


  /**
   * Inicializa os tooltips do Bootstrap.
   */
  private async inicializarTooltips(): Promise<void> {

    if (!isPlatformBrowser(this.platformId)) {

      return;

    }


    const { Tooltip } = await import('bootstrap');


    const tooltipElements =
      document.querySelectorAll('[title]');


    tooltipElements.forEach(element => {

      new Tooltip(element);

    });

  }


  /**
   * Filtra eventos por tema ou local.
   */
  public filtrarEventos(tema: string): void {

    tema = tema.trim().toLowerCase();


    if (!tema) {

      this.eventosFiltrados = [
        ...this.eventos
      ];

      return;

    }


    this.eventosFiltrados =
      this.eventos.filter(evento =>

        evento.tema.toLowerCase().includes(tema) ||

        evento.local.toLowerCase().includes(tema)

      );

  }


  /**
   * Busca eventos.
   */
  public getEventos(): void {

    console.log('Chamando API');


    this.carregando = true;


    this.eventoService.getEventos()
      .pipe(

        finalize(() => {

          console.log('Finalize executado');


          this.carregando = false;


          // Garante atualização da tela
          this.cd.detectChanges();

        })

      )
      .subscribe({

        next: response => {

          console.log('Resposta:', response);


          this.eventos = response;


          this.eventosFiltrados = [
            ...response
          ];


          // Atualiza o HTML após receber os dados
          this.cd.detectChanges();

        },


        error: erro => {

          console.error('Erro API:', erro);


          this.toast.error(
            'Erro ao carregar os eventos.'
          );


          this.cd.detectChanges();

        }

      });

  }


  /**
   * Seleciona evento para exclusão.
   */
  public selecionarEvento(id: number): void {

    this.eventoIdSelecionado = id;

  }


  /**
   * Exclui evento.
   */
  public deleteEvento(): void {

    if (this.eventoIdSelecionado === null) {

      this.toast.warning(
        'Nenhum evento selecionado.'
      );

      return;

    }


    this.carregando = true;


    this.eventoService
      .deleteEvento(this.eventoIdSelecionado)
      .subscribe({

        next: () => {


          this.carregando = false;


          this.toast.success(
            'Evento excluído com sucesso!'
          );


          this.eventoIdSelecionado = null;


          this.getEventos();


          this.fecharModal();


        },


        error: erro => {

          console.error(erro);


          this.carregando = false;


          this.toast.error(
            'Erro ao excluir o evento.'
          );


          this.cd.detectChanges();

        }

      });

  }


  /**
   * Fecha modal Bootstrap.
   */
  private async fecharModal(): Promise<void> {


    if (!isPlatformBrowser(this.platformId)) {

      return;

    }


    const { Modal } = await import('bootstrap');


    const modalElement =
      document.getElementById('modalExcluir');


    if (modalElement) {


      const modal =
        Modal.getInstance(modalElement);


      modal?.hide();

    }

  }

}
