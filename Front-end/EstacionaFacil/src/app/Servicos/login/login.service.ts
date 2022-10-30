import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { LoginModel } from 'src/app/Interfaces/login/login-model';
import { ResponseBaseModel } from 'src/app/Interfaces/response-base/response-base-model';
import { environment } from 'src/environments/environment';
import { BaseService } from '../base/base.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private baseService: BaseService<LoginModel>) { }

  async fazerLogin(email: string, senha: string): Promise<ResponseBaseModel<LoginModel>> {

    const body = {
      Email: email,
      Senha: senha
    }

    const requisicaoLogin = await lastValueFrom(this.baseService.get(`${environment.url}Usuario/Teste`))
      .catch(ex => {
        return ex.message;
      });

    const loginModel: ResponseBaseModel<LoginModel> = {
      Sucesso: requisicaoLogin.Sucesso,
      Mensagem: requisicaoLogin.Mensagem,
      Data: requisicaoLogin.Data
    }

    return loginModel;
  }

}
