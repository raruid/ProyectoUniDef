using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniDef.EventosApp.Dto
{
    public class PagedEventoResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
