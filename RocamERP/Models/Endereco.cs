﻿namespace RocamERP.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public override string ToString()
        {
            return $"{Rua}, {Numero}, {Bairro} em {Cidade}";
        }
    }
}