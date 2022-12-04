import { Injectable } from '@angular/core';
import {JwtHelperService} from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoService {

  constructor(private jwtHelper: JwtHelperService) { }

  tokenValido(): boolean {
    const token = localStorage.getItem('tokenSessao') ?? '';

    return !this.jwtHelper.isTokenExpired(token);
  } 

}
