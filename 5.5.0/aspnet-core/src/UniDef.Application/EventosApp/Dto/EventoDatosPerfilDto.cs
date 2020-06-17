using System;
using System.Collections.Generic;
using System.Text;

namespace UniDef.EventosApp.Dto
{
    public class EventoDatosPerfilDto
    {
        public string NombreEvento { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Requisitos { get; set; }
        public int AforoMaximo { get; set; }
        public string Descripcion_Evento { get; set; }

        public int CreatorUserId { get; set; }
    }
}
