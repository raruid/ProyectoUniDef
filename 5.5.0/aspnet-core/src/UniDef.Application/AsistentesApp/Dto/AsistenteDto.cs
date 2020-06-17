using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniDef.AsistentesApp.Dto
{
    public class AsistenteDto : EntityDto
    {
        public long UsuarioAsistenteId { get; set; }
        public long EventoId { get; set; }
    }
}
