import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { LoginService } from 'src/app/Servicos/login/login.service';

@Component({
  selector: 'app-tela-login',
  templateUrl: './tela-login.component.html',
  styleUrls: ['./tela-login.component.scss']
})
export class TelaLoginComponent implements OnInit {

  loginForm!: FormGroup;
  email!: string;
  senha!: string;
  lembrarSenha!: boolean;

  constructor(private formBuilder: FormBuilder,
    private loginService: LoginService) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      id: [''],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required]],
      lembrarSenha: ['', []]
    });
  }

  async loginSubmit(): Promise<void> {
    if (this.email && this.senha) {
      var requisicaoLogin = await this.loginService.fazerLogin(this.email, this.senha);
      if (requisicaoLogin.sucesso) {
        alert('sucesso');
      } 
      else {
        alert('erro');
      }
    }
    else {
      alert('erro');
    }
  }

}
