using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace colecaohq.API.ViewModels
{
    public class HqPerssonagemViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public Guid EquipePerssonagemId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public Guid TituloHqId { get; set; }
        [ScaffoldColumn(false)]
        public string NomeEquipePerssonagem { get; set; }
        [ScaffoldColumn(false)]
        public string Titulo { get; set; }
    }
}
