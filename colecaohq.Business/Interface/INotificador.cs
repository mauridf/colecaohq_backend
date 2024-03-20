using System.Collections.Generic;
using colecaohq.Business.Notificacoes;

namespace colecaohq.Business.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
