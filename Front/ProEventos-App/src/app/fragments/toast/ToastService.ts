import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';


export interface ToastMessage {

  titulo: string;

  mensagem: string;

  tipo:
    'success' |
    'danger' |
    'warning' |
    'info';

}


@Injectable({
  providedIn: 'root'
})
export class ToastService {


  private toastSubject =
    new BehaviorSubject<ToastMessage | null>(null);


  toast$ =
    this.toastSubject.asObservable();



  success(mensagem: string): void {

    this.show(
      'Sucesso',
      mensagem,
      'success'
    );

  }



  error(mensagem: string): void {

    this.show(
      'Erro',
      mensagem,
      'danger'
    );

  }



  warning(mensagem: string): void {

    this.show(
      'Atenção',
      mensagem,
      'warning'
    );

  }



  info(mensagem: string): void {

    this.show(
      'Informação',
      mensagem,
      'info'
    );

  }



  private show(
    titulo: string,
    mensagem: string,
    tipo: ToastMessage['tipo']
  ): void {


    this.toastSubject.next({

      titulo,

      mensagem,

      tipo

    });


  }


}
