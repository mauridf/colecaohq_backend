using System;
using System.Linq;
using System.Threading.Tasks;
using colecaohq.Business.Interface;
using colecaohq.Business.Models;
using colecaohq.Business.Models.Validations;

namespace colecaohq.Business.Services
{
    public class EditoraService : BaseService, IEditoraService
    {
        private readonly IEditoraRepository _editoraRepository;

        public EditoraService(IEditoraRepository editoraRepository,
                              INotificador notificador) : base(notificador)
        {
            _editoraRepository = editoraRepository;
        }

        public async Task Adicionar(Editora editora)
        {
            if (!ExecutarValidacao(new EditoraValidation(), editora)) return;

            await _editoraRepository.Adicionar(editora);
        }

        public async Task Atualizar(Editora editora)
        {
            if (!ExecutarValidacao(new EditoraValidation(), editora)) return;

            await _editoraRepository.Atualizar(editora);
        }

        public async Task Remover(Guid id)
        {
            await _editoraRepository.Remover(id);
        }

        public void Dispose()
        {
            _editoraRepository?.Dispose();
        }
    }
}
