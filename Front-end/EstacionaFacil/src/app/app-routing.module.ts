import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TelaCadastroComponent } from './Paginas/tela-cadastro/tela-cadastro.component';
import { TelaLoginComponent } from './Paginas/tela-login/tela-login.component';
import { TelaPrincipalComponent } from './Paginas/tela-principal/tela-principal.component';

const routes: Routes = [
  {
    // path: '', component: TelaLoginComponent,
    path: '', component: TelaPrincipalComponent,
  },
  {
    path: 'cadastro', component: TelaCadastroComponent
  },
  {
    path: 'principal', component: TelaPrincipalComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
