import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TelaLoginComponent } from './Paginas/tela-login/tela-login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TelaCadastroComponent } from './Paginas/tela-cadastro/tela-cadastro.component';
import { HttpClientModule } from '@angular/common/http';
import { TelaPrincipalComponent } from './Paginas/tela-principal/tela-principal.component';

@NgModule({
  declarations: [
    AppComponent,
    TelaLoginComponent,
    TelaCadastroComponent,
    TelaPrincipalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
