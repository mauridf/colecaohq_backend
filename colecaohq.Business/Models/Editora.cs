using System;
using System.Collections.Generic;

namespace colecaohq.Business.Models
{
    public class Editora : Entity
    {
        public string NomeEditora { get; set; }

        /* EF Relations */
        public IEnumerable<TituloHQ> TituloHQs { get; set; }
    }
}
