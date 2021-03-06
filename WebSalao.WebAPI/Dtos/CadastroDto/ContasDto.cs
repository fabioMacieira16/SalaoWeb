﻿using System;
using System.Collections.Generic;

namespace WebSalao.WebAPI.Dtos.CadastroDto
{
    public class ContasDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDoVencimento { get; set; }
        public string Cliente { get; set; }
        public string Observacao { get; set; }
        public string Banco { get; set; }
        public string Cheque { get; set; }
        public string Categoria { get; set; } //o Mesmo que TipoDeLancaento
        public string SubCateria { get; set; }
        public string ContasCorrente { get; set; }

        public List<ClienteDto> Clientes { get; set; }
    }
}
