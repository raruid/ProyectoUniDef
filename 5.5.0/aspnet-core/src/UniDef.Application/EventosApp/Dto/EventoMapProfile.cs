using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniDef.Eventos;
using UniDef.EventosApp.Dto;

namespace UniDef.EventosApp.Dto
{
    public class EventoMapProfile : Profile
    {
        public EventoMapProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Evento, CreateEventoDto>().ReverseMap();
            CreateMap<Evento, EventoDatosPerfilDto>().ReverseMap();
        }
    }
}
