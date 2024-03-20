using System;
using System.Linq;
using System.Threading.Tasks;
using colecaohq.Business.Interface;
using colecaohq.Business.Models;
using colecaohq.Business.Models.Validations;

namespace colecaohq.Business.Services
{
    public class EquipePerssonagemService : BaseService, IEquipePerssonagemService
    {
        private readonly IEquipePerssonagem _equipePerssonagem;

        public EquipePerssonagemService(IEquipePerssonagem equipePerssonagem,
                              INotificador notificador) : base(notificador)
        {
            _equipePerssonagem = equipePerssonagem;
        }

        public async Task Adicionar(EquipePerssonagem equipePerssonagem)
        {
            if (!ExecutarValidacao(new EquipePerssonagemValidation(), equipePerssonagem)) return;

            await _equipePerssonagem.Adicionar(equipePerssonagem);
        }

        public async Task Atualizar(EquipePerssonagem equipePerssonagem)
        {
            if (!ExecutarValidacao(new EquipePerssonagemValidation(), equipePerssonagem)) return;

            await _equipePerssonagem.Atualizar(equipePerssonagem);
        }

        public async Task Remover(Guid id)
        {
            await _equipePerssonagem.Remover(id);
        }

        public void Dispose()
        {
            _equipePerssonagem?.Dispose();
        }
    }
}
