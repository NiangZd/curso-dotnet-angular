import { CommonModule, isPlatformBrowser } from '@angular/common';

import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  ElementRef,
  Inject,
  PLATFORM_ID,
  ViewChild
} from '@angular/core';

import { ToastService } from './ToastService';


@Component({
  selector: 'app-toast',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './toast.component.html'
})
export class ToastComponent implements AfterViewInit {


  @ViewChild('toast')
  toastElement!: ElementRef;



  titulo = '';

  mensagem = '';

  tipo:
    'success' |
    'danger' |
    'warning' |
    'info' = 'success';



  private toastBootstrap: any;



  constructor(
    private toastService: ToastService,
    private cd: ChangeDetectorRef,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}



  async ngAfterViewInit(): Promise<void> {


    if (!isPlatformBrowser(this.platformId)) {

      return;

    }



    const { Toast } = await import('bootstrap');



    this.toastBootstrap =
      new Toast(
        this.toastElement.nativeElement,
        {
          delay: 4000
        }
      );



    this.toastService.toast$
      .subscribe(toast => {


        if (!toast) {

          return;

        }



        this.titulo =
          toast.titulo;


        this.mensagem =
          toast.mensagem;


        this.tipo =
          toast.tipo;



        this.cd.detectChanges();



        this.toastBootstrap.show();


      });


  }


}
