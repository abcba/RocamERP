﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class BancoViewModel
    {
        [Key]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Nome { get; set; }

        public virtual ICollection<ChequeViewModel> Cheques { get; set; }

        public BancoViewModel()
        {
            Cheques = new List<ChequeViewModel>();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}