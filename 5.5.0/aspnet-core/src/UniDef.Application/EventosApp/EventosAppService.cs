using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniDef.Authorization;
using UniDef.Eventos;
using UniDef.EventosApp.Dto;
using Microsoft.AspNetCore.Identity;
using UniDef.Authorization.Users;
using Abp.Runtime.Session;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace UniDef.EventosApp
{
    public class EventosAppService : AsyncCrudAppService<Evento, EventoDto, int, PagedEventoResultRequestDto, CreateEventoDto, EventoDto>
    {
        private readonly IRepository<Evento> _eventoRepository;
        private readonly UserManager _userManager;

        public EventosAppService(
            UserManager userManager,
            IRepository<Evento> repository)
            : base(repository)
        {
            _eventoRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<EventoDto>> GetNombreEvento()
        {
            var evento = await _eventoRepository.GetAllListAsync();
            return new ListResultDto<EventoDto>(ObjectMapper.Map<List<EventoDto>>(evento));
        }

        /*
        public async Task<ListResultDto<EventoDto>> GetDatosEventos()
        {
            var eventos = await _eventoRepository.GetAll()
                .Include(e => e.UsuarioOrganizador.Name)
                .ToListAsync();

            return new ListResultDto<EventoDto>(ObjectMapper.Map<List<EventoDto>>(eventos));
        }
        */


        public async Task<CreateEventoDto> CreateEventoAsync(CreateEventoDto input)
        {
            CheckCreatePermission();

            var userLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
            var evento = ObjectMapper.Map<Evento>(input);

            evento.CreatorUserId = userLogado.Id;
            //userLogado.EventosCreados.Add(evento);

            await _eventoRepository.InsertAsync(evento);
            await CurrentUnitOfWork.SaveChangesAsync();


            return ObjectMapper.Map<CreateEventoDto>(evento);
        }

        public async Task<EventoDatosPerfilDto> ModificarDatosEvento(EventoDatosPerfilDto input)
        {
            CheckUpdatePermission();

            var evento = await this.GetEventoPorId(input.Id);

            evento.NombreEvento = input.NombreEvento;
            evento.Fecha = input.Fecha;
            evento.Hora = input.Hora;
            evento.Requisitos = input.Requisitos;
            evento.AforoMaximo = input.AforoMaximo;
            evento.Descripcion_Evento = input.Descripcion_Evento;

            return ObjectMapper.Map<EventoDatosPerfilDto>(evento);
        }

        public async Task<Evento> GetEventoPorId(long id) 
        {
            var evento = await _eventoRepository.GetAll()
                .FirstOrDefaultAsync(even => even.Id == id);

            return evento;
        }

        public async Task<ListResultDto<EventoDatosPerfilDto>> GetEventosUserLogado()
        {
            var userLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var eventos = _eventoRepository.GetAll()
                .Where(ev => ev.CreatorUserId == userLogado.Id);

            return new ListResultDto<EventoDatosPerfilDto>(ObjectMapper.Map<List<EventoDatosPerfilDto>>(eventos));
        }

        public async Task<ListResultDto<EventoDatosPerfilDto>> GetEventosUser(long id)
        {
            var userLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var eventos = _eventoRepository.GetAll()
                .Where(ev => ev.CreatorUserId == id);

            return new ListResultDto<EventoDatosPerfilDto>(ObjectMapper.Map<List<EventoDatosPerfilDto>>(eventos));
        }

        public async Task<EventoAsistentesDto> GetAsistentesEvento(long id)
        {
            var userLogado = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var asistentes = _eventoRepository.GetAll()
                .Include(us => us.UsuariosAsistentes)
                .ThenInclude(us => us.UsuarioAsistente)
                .Where(us => us.Id == id)
                .FirstOrDefault();

            return ObjectMapper.Map<EventoAsistentesDto>(asistentes);
        }

        public async Task EliminarEvento(long id)
        {
            var evento = await this.GetEventoPorId(id);

            await _eventoRepository.DeleteAsync(evento);
            CurrentUnitOfWork.SaveChanges();
        }

        /*
        protected override EventoDto MapToEntityDto(Evento evento)
        {
            //var eventoDto = base.MapToEntityDto(evento);

            return ObjectMapper.Map<EventoDto>(evento);
        }
        */
    }
}