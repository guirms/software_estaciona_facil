import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FormValidator } from 'src/app/Validators/form-validator';

@Component({
  selector: 'app-tela-cadastro',
  templateUrl: './tela-cadastro.component.html',
  styleUrls: ['./tela-cadastro.component.scss']
})
export class TelaCadastroComponent implements OnInit {

  loginForm!: FormGroup;
  email!: string;
  senha!: string;
  confirmarSenha!: string;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      id: [''],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, FormValidator.confirmarCampo('confirmarSenha')]],
      confirmarSenha: ['', [Validators.required, FormValidator.confirmarCampo('senha')]],
    });
  }

  submitLogin() {
  }

}
