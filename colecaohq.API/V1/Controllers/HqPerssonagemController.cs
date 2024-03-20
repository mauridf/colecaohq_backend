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
    [Route("api/v{version:apiVersion}/hqPerssonagem")]
    public class HqPerssonagemController : MainController
    {
        private readonly IHqPerssonagem _hqperssonagemRepository;
        private readonly IHqPerssonagemService _hqperssonagemService;
        private readonly IMapper _mapper;

        public HqPerssonagemController(IHqPerssonagem hqperssonagemRepository,
                                      IMapper mapper,
                                      IHqPerssonagemService hqperssonagemService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _hqperssonagemRepository = hqperssonagemRepository;
            _mapper = mapper;
            _hqperssonagemService = hqperssonagemService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<HqPerssonagemViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<HqPerssonagemViewModel>>(await _hqperssonagemRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<HqPerssonagemViewModel>> ObterPorId(Guid id)
        {
            var hqPerssonagem = await ObterHqPerssonagemPorId(id);

            if (hqPerssonagem == null) return NotFound();

            return hqPerssonagem;
        }

        [ClaimsAuthorize("HQPerssonagem", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<HqPerssonagemViewModel>> Adicionar(HqPerssonagemViewModel hqPerssonagemViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _hqperssonagemService.Adicionar(_mapper.Map<HqPerssonagem>(hqPerssonagemViewModel));

            return CustomResponse(hqPerssonagemViewModel);
        }

        [ClaimsAuthorize("HQPerssonagem", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<HqPerssonagemViewModel>> Atualizar(Guid id, [FromBody] HqPerssonagemViewModel hqPerssonagemViewModel)
        {
            if (id != hqPerssonagemViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(hqPerssonagemViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _hqperssonagemService.Atualizar(_mapper.Map<HqPerssonagem>(hqPerssonagemViewModel));

            return CustomResponse(hqPerssonagemViewModel);
        }

        [ClaimsAuthorize("HQPerssonagem", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<HqPerssonagemViewModel>> Excluir(Guid id)
        {
            var hqPerssonagemViewModel = await ObterHqPerssonagemPorId(id);

            if (hqPerssonagemViewModel == null) return NotFound();

            await _hqperssonagemService.Remover(id);

            return CustomResponse(hqPerssonagemViewModel);
        }

        private async Task<HqPerssonagemViewModel> ObterHqPerssonagemPorId(Guid id)
        {
            return _mapper.Map<HqPerssonagemViewModel>(await _hqperssonagemRepository.ObterPorId(id));
        }
    }
}
