using System;
using System.Linq;
using System.Threading.Tasks;
using colecaohq.Business.Interface;
using colecaohq.Business.Models;
using colecaohq.Business.Models.Validations;

namespace colecaohq.Business.Services
{
    public class TituloHqService : BaseService, ITituloHqService
    {
        private readonly ITituloHq _tituloHqRepository;

        public TituloHqService(ITituloHq tituloHqService,
                              INotificador notificador) : base(notificador)
        {
            _tituloHqRepository = tituloHqService;
        }

        public async Task Adicionar(TituloHQ tituloHQ)
        {
            if (!ExecutarValidacao(new TituloHqValidation(), tituloHQ)) return;

            await _tituloHqRepository.Adicionar(tituloHQ);
        }

        public async Task Atualizar(TituloHQ tituloHQ)
        {
            if (!ExecutarValidacao(new TituloHqValidation(), tituloHQ)) return;

            await _tituloHqRepository.Atualizar(tituloHQ);
        }

        public async Task Remover(Guid id)
        {
            await _tituloHqRepository.Remover(id);
        }

        public void Dispose()
        {
            _tituloHqRepository?.Dispose();
        }
    }
}
