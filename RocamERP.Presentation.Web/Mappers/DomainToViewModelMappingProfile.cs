﻿using AutoMapper;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;

namespace RocamERP.Presentation.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Banco, BancoViewModel>();
            CreateMap<Cheque, ChequeViewModel>();
            CreateMap<Endereco, EnderecoViewModel>().ForMember(m => m.TipoEnderecoList, opt => opt.Ignore()); ;

            CreateMap<Contato, ContatoViewModel>().ForMember(m => m.TipoContatoList, opt => opt.Ignore());
            CreateMap<Cidade, CidadeViewModel>().PreserveReferences();
            CreateMap<Pessoa, PessoaViewModel>().PreserveReferences();

            CreateMap<CadastroNacional, CadastroNacionalViewModel>();
            CreateMap<CadastroEstadual, CadastroEstadualViewModel>();
        }
    }
}