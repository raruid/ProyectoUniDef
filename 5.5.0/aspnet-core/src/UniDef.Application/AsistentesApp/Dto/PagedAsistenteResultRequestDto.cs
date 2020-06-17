using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniDef.AsistentesApp.Dto
{
    public class PagedAsistenteResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
