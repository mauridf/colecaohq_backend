using System;
using System.Collections.Generic;
using System.Text;

namespace colecaohq.Business.Models
{
    public class EquipePerssonagem : Entity
    {
        public string NomeEquipePerssonagem { get; set; }
        public string DescricaoEquipePerssonagem { get; set; }

        /* EF Relations */
        public IEnumerable<HqPerssonagem> HqPerssonagens { get; set; }
    }
}
