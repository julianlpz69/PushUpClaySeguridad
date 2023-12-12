using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;


namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
         public MappingProfiles()
         {
                
            CreateMap<CategoriaPersona,CategoriaPersonaDto>().ReverseMap();

            CreateMap<ContactoPersona,ContactoPersonaDto>().ReverseMap();

            CreateMap<Contrato,ContratoDto>().ReverseMap();

            CreateMap<Estado,EstadoDto>().ReverseMap();

            CreateMap<Persona,PersonaDto>().ReverseMap();

            CreateMap<Programacion,ProgramacionDto>().ReverseMap();

            CreateMap<TipoContacto,TipoContactoDto>().ReverseMap();

            CreateMap<TipoPersona,TipoPersonaDto>().ReverseMap();

            CreateMap<Turno,TurnoDto>().ReverseMap();


            CreateMap<Contrato,ContratoActivosDto>()
                        .ForMember(e => e.NumeroContrato, o => o.MapFrom(o=> o.Id ) )
                        .ForMember(e => e.NombreCliente, o => o.MapFrom(o=> o.IdClienteNavigation.Nombre ) )
                        .ForMember(e => e.NombreEmpleado, o => o.MapFrom(o=> o.IdEmpleadoNavigation.Nombre ) );
                

            
         }
    }
}