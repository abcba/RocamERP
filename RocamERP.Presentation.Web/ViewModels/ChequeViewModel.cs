﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class ChequeViewModel
    {
        [Key]
        [DisplayName("Chave")]
        public int ChequeId { get; set; }

        [DisplayName("Banco")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public string BancoId { get; set; }
        public virtual BancoViewModel Banco { get; set; }

        [DisplayName("Agência")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo para o campo é 10 caracteres.")]
        public string Agencia { get; set; }

        [DisplayName("Conta Corrente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo para o campo é 10 caracteres.")]
        public string ContaCorrente { get; set; }

        [DisplayName("Número do Cheque")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(7, ErrorMessage = "O tamanho máximo para o campo é 7 caracteres.")]
        public string NumeroCheque { get; set; }

        [DisplayName("Proprietário")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int PessoaId { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }

        [DisplayName("Observações")]
        [MaxLength(1000, ErrorMessage = "O tamanho máximo para o campo é 1000 caracteres.")]
        public string Observacao { get; set; }

        [DisplayName("Situação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public SituacaoCheque SituacaoCheque { get; set; }

        [DisplayName("Data de Recebimento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public DateTime DataRecebimento { get; set; }

        [DisplayName("Data de Vencimento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public DateTime DataVencimento { get; set; }

        [DisplayName("Data de Pagamento")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", NullDisplayText = "Não registrado.")]
        public DateTime? DataPagamento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [Range(0, 100000, ErrorMessage = "O valor deve ser entre 0 e 100.000.")]
        public decimal Valor { get; set; }
    }

    public enum SituacaoCheque 
    {
        Bloqueado,
        Negociado, 
        Compensado, 
        Devolvido,
        Sustado,
        Repassado,
        SemFundos,
    }
}