using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using colecaohq.API.Controllers;
using colecaohq.API.Extension;
using colecaohq.API.ViewModels;
using colecaohq.Business.Interface;
using colecaohq.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace colecaohq.API.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/tituloHQ")]
    public class TituloHQController : MainController
    {
        private readonly ITituloHq _tituloHqRepository;
        private readonly ITituloHqService _tituloHqService;
        private readonly IMapper _mapper;

        public TituloHQController(ITituloHq tituloHqRepository,
                                      IMapper mapper,
                                      ITituloHqService tituloHqService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _tituloHqRepository = tituloHqRepository;
            _mapper = mapper;
            _tituloHqService = tituloHqService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<TituloHQView>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TituloHQView>>(await _tituloHqRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TituloHQView>> ObterPorId(Guid id)
        {
            var tituloHQ = await ObterTituloHqPorId(id);

            if (tituloHQ == null) return NotFound();

            return tituloHQ;
        }

        [ClaimsAuthorize("TituloHQ", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<TituloHQView>> Adicionar(TituloHQView tituloHQViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _tituloHqService.Adicionar(_mapper.Map<TituloHQ>(tituloHQViewModel));

            return CustomResponse(tituloHQViewModel);
        }

        [ClaimsAuthorize("TituloHQ", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TituloHQView>> Atualizar(Guid id, [FromBody] TituloHQView tituloHQViewModel)
        {
            if (id != tituloHQViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(tituloHQViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _tituloHqService.Atualizar(_mapper.Map<TituloHQ>(tituloHQViewModel));

            return CustomResponse(tituloHQViewModel);
        }

        [ClaimsAuthorize("TituloHQ", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TituloHQView>> Excluir(Guid id)
        {
            var tituloHQViewModel = await ObterTituloHqPorId(id);

            if (tituloHQViewModel == null) return NotFound();

            await _tituloHqService.Remover(id);

            return CustomResponse(tituloHQViewModel);
        }

        private async Task<TituloHQView> ObterTituloHqPorId(Guid id)
        {
            return _mapper.Map<TituloHQView>(await _tituloHqRepository.ObterPorId(id));
        }
    }
}
