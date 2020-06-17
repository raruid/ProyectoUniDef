
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using UniDef.Asistentes;
using UniDef.Authorization.Users;

namespace UniDef.Eventos
{
    public class Evento : AuditedEntity
    {
        public string NombreEvento { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string URLFoto { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Requisitos { get; set; }
        public int AforoMaximo { get; set; }
        public string Descripcion_Evento { get; set; }
        
        //Lo de abajo estaba comentado en la primera migracion
        public ICollection<Asistente> UsuariosAsistentes { get; set; }
        
    }
}