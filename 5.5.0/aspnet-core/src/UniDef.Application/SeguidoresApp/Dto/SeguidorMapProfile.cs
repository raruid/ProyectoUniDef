using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniDef.Seguidores;

namespace UniDef.SeguidoresApp.Dto
{
    public class SeguidorMapProfile : Profile
    {
        public SeguidorMapProfile()
        {
            CreateMap<Seguidor, SeguidorDto>().ReverseMap();
            CreateMap<Seguidor, SeguidorDatosDto>()
                .ForMember(se => se.Name, opts => opts.MapFrom(se => se.UsuarioSeguidor.Name))
                .ForMember(se => se.Age, opts => opts.MapFrom(se => se.UsuarioSeguidor.Age))
                .ReverseMap();

            CreateMap<Seguidor, SeguidoDatosDto>()
                .ForMember(se => se.Name, opts => opts.MapFrom(se => se.UsuarioSeguido.Name))
                .ForMember(se => se.Age, opts => opts.MapFrom(se => se.UsuarioSeguido.Age))
                .ReverseMap();
        }
    }
}
