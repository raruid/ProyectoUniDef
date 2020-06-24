using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniDef.Asistentes;

namespace UniDef.AsistentesApp.Dto
{
    public class AsistenteMapProfile : Profile
    {
        public AsistenteMapProfile()
        {
            CreateMap<Asistente, AsistenteDto>().ReverseMap();
            CreateMap<Asistente, AsistenteDatosDto>()
                .ForMember(se => se.Name, opts => opts.MapFrom(se => se.UsuarioAsistente.Name))
                .ForMember(se => se.Age, opts => opts.MapFrom(se => se.UsuarioAsistente.Age))
                .ReverseMap();
        }
    }
}
