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
    [Route("api/v{version:apiVersion}/editora")]
    public class EditoraController : MainController
    {
        private readonly IEditoraRepository _editoraRepository;
        private readonly IEditoraService _editoraService;
        private readonly IMapper _mapper;

        public EditoraController(IEditoraRepository editoraRepository,
                                      IMapper mapper,
                                      IEditoraService editoraService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _editoraRepository = editoraRepository;
            _mapper = mapper;
            _editoraService = editoraService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EditoraViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EditoraViewModel>>(await _editoraRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EditoraViewModel>> ObterPorId(Guid id)
        {
            var editora = await ObterEditoraPorId(id);

            if (editora == null) return NotFound();

            return editora;
        }

        [ClaimsAuthorize("Editora", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<EditoraViewModel>> Adicionar(EditoraViewModel editoraViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _editoraService.Adicionar(_mapper.Map<Editora>(editoraViewModel));

            return CustomResponse(editoraViewModel);
        }

        [ClaimsAuthorize("Editora", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EditoraViewModel>> Atualizar(Guid id, [FromBody] EditoraViewModel editoraViewModel)
        {
            if (id != editoraViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(editoraViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _editoraService.Atualizar(_mapper.Map<Editora>(editoraViewModel));

            return CustomResponse(editoraViewModel);
        }

        [ClaimsAuthorize("Editora", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EditoraViewModel>> Excluir(Guid id)
        {
            var editoraViewModel = await ObterEditoraPorId(id);

            if (editoraViewModel == null) return NotFound();

            await _editoraService.Remover(id);

            return CustomResponse(editoraViewModel);
        }

        private async Task<EditoraViewModel> ObterEditoraPorId(Guid id)
        {
            return _mapper.Map<EditoraViewModel>(await _editoraRepository.ObterPorId(id));
        }
    }
}
