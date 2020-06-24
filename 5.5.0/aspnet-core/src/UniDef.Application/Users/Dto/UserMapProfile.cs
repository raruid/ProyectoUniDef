using AutoMapper;
using UniDef.Authorization.Users;

namespace UniDef.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<UserDto, User>()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore());

            CreateMap<UserDatosPerfilDto, User>().ReverseMap();

            CreateMap<User, UserSeguidoresDto>()
                .ForMember(us => us.UsuariosSeguidores, opts => opts.MapFrom(us => us.UsuariosSeguidos))
                .ReverseMap();

            CreateMap<User, UserSeguidosDto>()
                .ForMember(us => us.UsuariosSeguidos, opts => opts.MapFrom(us => us.UsuariosSeguidores))
                .ReverseMap();
                

            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
        }
    }
}
