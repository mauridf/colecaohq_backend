using System;
using System.Linq;
using System.Threading.Tasks;
using colecaohq.Business.Interface;
using colecaohq.Business.Models;
using colecaohq.Business.Models.Validations;

namespace colecaohq.Business.Services
{
    public class HqPerssonagemService : BaseService, IHqPerssonagemService
    {
        private readonly IHqPerssonagem _hqPerssonagem;

        public HqPerssonagemService(IHqPerssonagem hqPerssonagem,
                              INotificador notificador) : base(notificador)
        {
            _hqPerssonagem = hqPerssonagem;
        }

        public async Task Adicionar(HqPerssonagem hqPerssonagem)
        {
            await _hqPerssonagem.Adicionar(hqPerssonagem);
        }

        public async Task Atualizar(HqPerssonagem hqPerssonagem)
        {
            await _hqPerssonagem.Atualizar(hqPerssonagem);
        }

        public async Task Remover(Guid id)
        {
            await _hqPerssonagem.Remover(id);
        }

        public void Dispose()
        {
            _hqPerssonagem?.Dispose();
        }
    }
}
