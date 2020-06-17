using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using UniDef.Eventos;
using UniDef.Authorization.Users;

namespace UniDef.Asistentes
{
    public class Asistente : AuditedEntity
    {
        
        public long UsuarioAsistenteId { get; set; }
        public User UsuarioAsistente { get; set; }
        public long EventoId { get; set; }
        public Evento Evento { get; set; }
        
    }
}
