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
            CreateMap<Compania, CompaniaDto>();
            CreateMap<CompaniaDto, Compania>();
            CreateMap<Compania, CompaniaUpdate>();
            CreateMap<CompaniaUpdate, Compania>();
            CreateMap<Compania, CompaniaCreate>();
            CreateMap<CompaniaCreate, Compania>();

            //Contabilidad
            CreateMap<Contabilidad, ContabilidadDto>();
            CreateMap<ContabilidadDto, Contabilidad>();
            CreateMap<Contabilidad, ContabilidadUpdateDto>();
            CreateMap<ContabilidadUpdateDto, Contabilidad>();
            CreateMap<Contabilidad, ContabilidadCreateDto>();
            CreateMap<ContabilidadCreateDto, Contabilidad>();

            //Transaccion
            CreateMap<Transaccion, TransaccionDto>();
            CreateMap<TransaccionDto, Transaccion>();
            CreateMap<Transaccion, TransaccionUpdateDto>();
            CreateMap<TransaccionUpdateDto, Transaccion>();
            CreateMap<Transaccion, TransaccionCreateDto>();
            CreateMap<TransaccionCreateDto, Transaccion>();

            //Movimiento
            CreateMap<Movimiento, MovimientoDto>();
            CreateMap<MovimientoDto, Movimiento>();
            CreateMap<Movimiento, MovimientoUpdateDto>();
            CreateMap<MovimientoUpdateDto, Movimiento>();
            CreateMap<Movimiento, MovimientoCreateDto>();
            CreateMap<MovimientoCreateDto, Movimiento>();
        }
    }
}
