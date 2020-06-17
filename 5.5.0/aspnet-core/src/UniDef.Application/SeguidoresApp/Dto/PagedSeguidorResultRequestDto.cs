using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniDef.SeguidoresApp.Dto
{
    public class PagedSeguidorResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
