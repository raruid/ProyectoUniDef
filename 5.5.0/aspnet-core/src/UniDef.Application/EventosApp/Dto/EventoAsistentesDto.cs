using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using UniDef.AsistentesApp.Dto;

namespace UniDef.EventosApp.Dto
{
    public class EventoAsistentesDto : EntityDto
    {
        public ICollection<AsistenteDatosDto> UsuariosAsistentes { get; set; }
    }
}
