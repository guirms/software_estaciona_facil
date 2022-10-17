import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TelaCadastroComponent } from './Paginas/tela-cadastro/tela-cadastro.component';
import { TelaLoginComponent } from './Paginas/tela-login/tela-login.component';

const routes: Routes = [{
  path: '', component: TelaLoginComponent,
},
{
  path: 'cadastro', component: TelaCadastroComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
