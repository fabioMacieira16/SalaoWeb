import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from 'src/app/models/_Administrativos/produtoModels';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  baseURL = 'http://localhost:5000/api/produto';

  constructor(private http: HttpClient) {}

  getAllProduto(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.baseURL);
  }

  getProdutoBydescricao(descricao: string): Observable<Produto[]> {
    return this.http.get<Produto[]>(`${this.baseURL}/getByDescricao/${descricao}`);
  }

  getProdutoById(id: number): Observable<Produto> {
    return this.http.get<Produto>(`${this.baseURL}/${id}`);
  }

  postProduto(produto: Produto) {
    return this.http.post(this.baseURL, produto);
  }

  putProduto(produto: Produto) {
    return this.http.put(`${this.baseURL}/${produto.id}`, produto);
  }

  deleteProduto(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
