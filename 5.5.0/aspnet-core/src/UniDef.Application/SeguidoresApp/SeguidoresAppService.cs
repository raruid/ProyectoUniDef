using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UniDef.Authorization.Users;
using UniDef.Seguidores;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using UniDef.Authorization;
using System.Threading.Tasks;
using UniDef.SeguidoresApp.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace UniDef.SeguidoresApp
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class SeguidoresAppService : ApplicationService
    {
        private readonly IRepository<Seguidor> _seguidorRepository;
        private readonly UserManager _userManager;

        public SeguidoresAppService(
            UserManager userManager,
            IRepository<Seguidor> repository)
        {
            _seguidorRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<SeguidorDto>> GetAll()
        {
            var seguidores = await _seguidorRepository.GetAllListAsync();

            return new ListResultDto<SeguidorDto>(ObjectMapper.Map<List<SeguidorDto>>(seguidores));
        }

        public async Task<SeguidorDto> EsSeguidor(long id)
        {
            var usuarioLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var seguidor = await _seguidorRepository.GetAll()
                .FirstOrDefaultAsync(seg => seg.UsuarioSeguidorId == usuarioLogado.Id && seg.UsuarioSeguidoId == id);

            return ObjectMapper.Map<SeguidorDto>(seguidor);
        }

        public async Task SeguirUsuario(long id)
        {
            var usuarioLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            Seguidor seguidor = new Seguidor();

            seguidor.UsuarioSeguidoId = id;
            seguidor.UsuarioSeguidorId = usuarioLogado.Id;

            await _seguidorRepository.InsertAsync(seguidor);
            CurrentUnitOfWork.SaveChanges();
        }

        public async Task DejarDeSeguir(long id)
        {
            var usuarioLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var seguidor = await _seguidorRepository.GetAll()
                .FirstOrDefaultAsync(seg => seg.UsuarioSeguidorId == usuarioLogado.Id && seg.UsuarioSeguidoId == id);

            await _seguidorRepository.DeleteAsync(seguidor);
            CurrentUnitOfWork.SaveChanges();
        }
    }
}
