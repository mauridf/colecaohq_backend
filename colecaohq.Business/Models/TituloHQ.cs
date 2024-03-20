using System;
using System.Collections.Generic;
using System.Text;

namespace colecaohq.Business.Models
{
    public class TituloHQ : Entity
    {
        public Guid EditoraId { get; set; }
        public string Titulo { get; set; }
        public string TituloOriginal { get; set; }
        public TipoPublicacao TipoPublicacao { get; set; }
        public Status Status { get; set; }
        public string TotalEdicoes { get; set; }
        public string EdicoesPossuidas { get; set; }
        public string Sinopse { get; set; }
        public string AnoLancamento { get; set; }

        /* EF Relations */
        public Editora Editora { get; set; }
        public IEnumerable<HqPerssonagem> HqPerssonagems { get; set; }
    }
}
