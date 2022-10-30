import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService<T> {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type'
    })
  }

  constructor(private httpClient: HttpClient) { }

  get(url: string): Observable<T> {
    try {
      return this.httpClient.get<T>(url, this.httpOptions).pipe(
        retry(2)
      );
    }
    catch (e) {
      throw new Error('Erro durante requisição HTTP');
    }
  }

  post(url: string, body: string): Observable<T> {
    try {
      return this.httpClient.post<T>(url, body,this.httpOptions).pipe(
        retry(2)
      );
    }
    catch (e) {
      throw new Error('Erro durante requisição HTTP');
    }
  }

}
