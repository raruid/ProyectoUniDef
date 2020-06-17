using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using UniDef.Eventos;

namespace UniDef.Users.Dto
{
    public class UserEventosCreadosDto : EntityDto
    {
        public ICollection<Evento> EventosCreados { get; set; }
    }
}
