﻿namespace RocamERP.Models
{
    public class ClientePessoaFisica : Cliente
    {
        public string CPF { get; set; }
        public string RG { get; set; }
    }
}