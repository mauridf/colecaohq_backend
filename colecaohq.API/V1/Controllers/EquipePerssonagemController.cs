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
    [Route("api/v{version:apiVersion}/equipePerssonagem")]
    public class EquipePerssonagemController : MainController
    {
        private readonly IEquipePerssonagem _equipeperssonagemRepository;
        private readonly IEquipePerssonagemService _equipeperssonagemService;
        private readonly IMapper _mapper;

        public EquipePerssonagemController(IEquipePerssonagem equipeperssonagemRepository,
                                      IMapper mapper,
                                      IEquipePerssonagemService equipeperssonagemService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _equipeperssonagemRepository = equipeperssonagemRepository;
            _mapper = mapper;
            _equipeperssonagemService = equipeperssonagemService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EquipePerssonagemViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EquipePerssonagemViewModel>>(await _equipeperssonagemRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EquipePerssonagemViewModel>> ObterPorId(Guid id)
        {
            var equipePerssonagem = await ObterEquipePerssonagemPorId(id);

            if (equipePerssonagem == null) return NotFound();

            return equipePerssonagem;
        }

        [ClaimsAuthorize("EquipePerssonagem", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<EquipePerssonagemViewModel>> Adicionar(EquipePerssonagemViewModel equipePerssonagemViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _equipeperssonagemService.Adicionar(_mapper.Map<EquipePerssonagem>(equipePerssonagemViewModel));

            return CustomResponse(equipePerssonagemViewModel);
        }

        [ClaimsAuthorize("EquipePerssonagem", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EquipePerssonagemViewModel>> Atualizar(Guid id, [FromBody] EquipePerssonagemViewModel equipePerssonagemViewModel)
        {
            if (id != equipePerssonagemViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(equipePerssonagemViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _equipeperssonagemService.Atualizar(_mapper.Map<EquipePerssonagem>(equipePerssonagemViewModel));

            return CustomResponse(equipePerssonagemViewModel);
        }

        [ClaimsAuthorize("EquipePerssonagem", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EquipePerssonagemViewModel>> Excluir(Guid id)
        {
            var equipePerssonagemViewModel = await ObterEquipePerssonagemPorId(id);

            if (equipePerssonagemViewModel == null) return NotFound();

            await _equipeperssonagemService.Remover(id);

            return CustomResponse(equipePerssonagemViewModel);
        }

        private async Task<EquipePerssonagemViewModel> ObterEquipePerssonagemPorId(Guid id)
        {
            return _mapper.Map<EquipePerssonagemViewModel>(await _equipeperssonagemRepository.ObterPorId(id));
        }
    }
}
