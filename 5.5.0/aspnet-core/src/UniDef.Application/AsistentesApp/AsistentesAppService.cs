using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniDef.Asistentes;
using UniDef.AsistentesApp.Dto;
using UniDef.Authorization;
using UniDef.Authorization.Users;

namespace UniDef.AsistentesApp
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class AsistentesAppService : ApplicationService
    {
        private readonly IRepository<Asistente> _asistenteRepository;
        private readonly UserManager _userManager;

        public AsistentesAppService(
            UserManager userManager,
            IRepository<Asistente> repository)
        {
            _asistenteRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<AsistenteDto>> GetAll()
        {
            var asistentes = await _asistenteRepository.GetAllListAsync();

            return new ListResultDto<AsistenteDto>(ObjectMapper.Map<List<AsistenteDto>>(asistentes));
        }

        public async Task<AsistenteDto> EsAsistente(long id)
        {
            var usuarioLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var seguidor = await _asistenteRepository.GetAll()
                .FirstOrDefaultAsync(seg => seg.UsuarioAsistenteId == usuarioLogado.Id && seg.EventoId == id);

            return ObjectMapper.Map<AsistenteDto>(seguidor);
        }

        public async Task AsistirEvento(long id)
        {
            var usuarioLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            Asistente asistente = new Asistente();

            asistente.EventoId = id;
            asistente.UsuarioAsistenteId = usuarioLogado.Id;

            await _asistenteRepository.InsertAsync(asistente);
            CurrentUnitOfWork.SaveChanges();
        }

        public async Task DejarDeAsistir(long id)
        {
            var usuarioLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var asistente = await _asistenteRepository.GetAll()
                .FirstOrDefaultAsync(seg => seg.UsuarioAsistenteId == usuarioLogado.Id && seg.EventoId == id);

            await _asistenteRepository.DeleteAsync(asistente);
            CurrentUnitOfWork.SaveChanges();
        }

        public async Task<ListResultDto<AsistenteDto>> GetAsistentesEvento(long id)
        {
            var userLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var asistentes = _asistenteRepository.GetAllList()
                .Where(se => se.EventoId == id);

            return new ListResultDto<AsistenteDto>(ObjectMapper.Map<List<AsistenteDto>>(asistentes));
        }
    }
}
