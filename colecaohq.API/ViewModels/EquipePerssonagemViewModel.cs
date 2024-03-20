using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace colecaohq.API.ViewModels
{
    public class EquipePerssonagemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomeEquipePerssonagem { get; set; }
        public IEnumerable<TituloHQView> HqPerssonagem { get; set; }
    }
}
