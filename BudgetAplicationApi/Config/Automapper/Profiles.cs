using AutoMapper;
using BudgetAplicationApi.Api.Dto;
using BudgetAplicationApi.Api.Models;
using System;

namespace BudgetAplicationApi.Config.Automapper
{
    public class Profiles : Profile
    {
        public Profiles () {
            CreateMap<Usuarios, UsuariosUpdate>();
            CreateMap<UsuariosUpdate, Usuarios>();
            CreateMap<Usuarios, UsuariosCreate>();
            CreateMap<UsuariosCreate, Usuarios>();
            CreateMap<UsuariosDto, Usuarios>();
            CreateMap<Usuarios, UsuariosDto>();

        }
    }
}
