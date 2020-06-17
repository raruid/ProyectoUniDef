using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniDef.SeguidoresApp.Dto
{
    public class SeguidorDatosDto : EntityDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
