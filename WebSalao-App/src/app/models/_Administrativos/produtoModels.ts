import { CategoriaModels } from './categoriaModels';
import { FornecedorModels } from './fornecedormodels';

export class Produto {
    constructor() {}

    id: number;
    descricao: string;
    fornecedor: FornecedorModels[];
    categoria: CategoriaModels[];
    preco: number;
    ativo: boolean;

}
