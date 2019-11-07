import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Produto } from 'src/app/_models/_Administrativos/produtoModels';
import { ToastrService } from 'ngx-toastr';
import { ProdutoService } from 'src/app/_services/_administrativo/produto.service';


@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styles: []
})
export class ProdutosComponent implements OnInit {

  titulo = 'Produtos';
  produtosFiltrados: Produto[];
  produtos: Produto[];
  produto: Produto;
  modoSalvar = 'post';

  registerForm: FormGroup;
  bodyDeletarProduto = '';

  dataAtual: string;
  _filtraPoduto = '';

  constructor(
    private produtoService: ProdutoService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) { }

  //#region Crud - Filtros - Salvar - editar - excluirs
  get filtroProduto(): string {
    return this._filtraPoduto;
  }

  set filtroProduto(value: string) {
    this._filtraPoduto = value;
    this.produtosFiltrados = this.filtroProduto ? this.filtrarProdutos(this.filtroProduto) : this.produtos;
  }

  editarProduto(produto: Produto, templete: any) {
    this.modoSalvar = 'put';
    this.openModal(templete);
    this.produto = Object.assign({}, produto);
    this.registerForm.patchValue(this.produto);
  }

  novoProduto(template: any) {
    this.modoSalvar = 'post';
    this.openModal(template);
  }

  excluirProduto(produto: Produto, template: any) {
    this.openModal(template);
    this.produto = this.produto;
    this.bodyDeletarProduto = `Tem certeza que deseja excluir o Produto: ${produto.descricao}, Código: ${produto.id}`;
  }

  confirmeDelete(template: any) {
    this.produtoService.deleteProduto(this.produto.id).subscribe(
      () => {
        template.hide();
        this.toastr.success('Deletado com Sucesso');
      }, error => {
        this.toastr.error('Erro ao tentar Deletar');
        console.log(error);
      }
    );
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.modoSalvar === 'post') {
        this.produto = Object.assign({}, this.registerForm.value);

        this.produtoService.postProduto(this.produto).subscribe(
          (novoEvento: Produto) => {
            template.hide();
            this.toastr.success('Inserido com Sucesso!');
          }, error => {
            this.toastr.error(`Erro ao Inserir: ${error}`);
          }
        );
      } else {
        this.produto = Object.assign({ id: this.produto.id }, this.registerForm.value);

        this.produtoService.putProduto(this.produto).subscribe(
          () => {
            template.hide();
            this.getProdutos();
            this.toastr.success('Editado com Sucesso!');
          }, error => {
            this.toastr.error(`Erro ao Editar: ${error}`);
          }
        );
      }
    }
  }
  //#endregion

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  ngOnInit() {
   this.validation(); // Valida Formulário
    this.getProdutos();
  }

  filtrarProdutos(filtrorPor: string): Produto[] {
    filtrorPor = filtrorPor.toLocaleLowerCase();
    return this.produtos.filter(
      produto => produto.descricao.toLocaleLowerCase().indexOf(filtrorPor) !== -1
    );
  }

  validation() {
    this.registerForm = this.fb.group({
      descricao: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      fornecedor: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
    });
  }


  // Busca a lista de produtos
  getProdutos() {
    // this.dataAtual = new Date().getMilliseconds().toString();
    this.produtoService.getAllProduto().subscribe(
      (_produto: Produto[]) => {
        this.produtos = _produto;
        this.produtosFiltrados = this.produtos;
        console.log(this.produtos);
      }, error => {
        this.toastr.error(`Erro ao tentar carregar os Produtos: ${error}`);
      });
  }
}


