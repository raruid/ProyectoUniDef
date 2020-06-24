using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniDef.AsistentesApp.Dto
{
    public class AsistenteDatosDto : EntityDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
