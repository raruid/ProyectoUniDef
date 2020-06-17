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
        }
    }
}
