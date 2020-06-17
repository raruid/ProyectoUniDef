using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using UniDef.Eventos;
using UniDef.Seguidores;

namespace UniDef.Authorization.Users
{
    public class User : AbpUser<User>
    {
        //public string Login { get; set; }
        //public string Contrasenia { get; set; }
        //public string Nombre { get; set; }
        //public string Apellido1 { get; set; }
        public string Surname2 { get; set; }
        public int Age { get; set; }
        public string StudyingAt { get; set; }
        public string  AboutMe { get; set; }

        //LO DE ABAJO ESTABA COMENTADO CUANDO HICE LA PRIMERA MIGRACION
        public ICollection<Evento> EventosCreados { get; set; }
        public ICollection<Seguidor> UsuariosSeguidores { get; set; }
        public ICollection<Seguidor> UsuariosSeguidos { get; set; }

        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
