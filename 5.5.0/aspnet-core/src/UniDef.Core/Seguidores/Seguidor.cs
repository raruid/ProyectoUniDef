using Abp.Domain.Entities.Auditing;
using UniDef.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniDef.Seguidores
{
    public class Seguidor : AuditedEntity
    {
        public long UsuarioSeguidoId { get; set; }
        public User UsuarioSeguido { get; set; }
        public long UsuarioSeguidorId { get; set; }
        public User UsuarioSeguidor { get; set; }
        
    }
}
