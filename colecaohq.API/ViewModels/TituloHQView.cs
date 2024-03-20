using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace colecaohq.API.ViewModels
{
    public class TituloHQView
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public Guid EditoraId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string TituloOriginal { get; set; }
        public int TipoPublicacao { get; set; }
        public int Status { get; set; }
        public string TotalEdicoes { get; set; }
        public string EdicoesPossuidas { get; set; }
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Sinopse { get; set; }
        public string AnoLancamento { get; set; }
        [ScaffoldColumn(false)]
        public string NomeEditora { get; set; }
        public IEnumerable<TituloHQView> HqPerssonagem { get; set; }
    }
}
