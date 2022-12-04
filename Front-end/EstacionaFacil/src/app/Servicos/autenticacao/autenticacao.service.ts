import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoService {

  constructor() { }

  validarLogin(): boolean {
    // leitura de token de sessão
    return true;
  } 
}
