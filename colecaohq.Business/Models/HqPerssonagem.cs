using System;
using System.Collections.Generic;
using System.Text;

namespace colecaohq.Business.Models
{
    public class HqPerssonagem : Entity
    {
        public Guid TituloHqId { get; set; }
        public Guid EquipePerssonagemId { get; set; }
        public TituloHQ TituloHQ { get; set; }
        public EquipePerssonagem EquipePerssonagem { get; set; }
    }
}
