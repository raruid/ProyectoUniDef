using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniDef.Users.Dto
{
    public class UserDatosPerfilDto : EntityDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Surname2 { get; set; }
        public int Age { get; set; }
        public string StudyingAt { get; set; }
        public string AboutMe { get; set; }
        public string UrlFoto { get; set; }
    }
}
