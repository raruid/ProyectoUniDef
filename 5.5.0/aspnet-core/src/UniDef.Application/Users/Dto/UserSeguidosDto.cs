using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using UniDef.Seguidores;
using UniDef.SeguidoresApp.Dto;

namespace UniDef.Users.Dto
{
    public class UserSeguidosDto : EntityDto
    {
        public ICollection<SeguidoDatosDto> UsuariosSeguidos { get; set; }
    }
}
