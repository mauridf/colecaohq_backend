using FluentValidation;

namespace colecaohq.Business.Models.Validations
{
    public class TituloHqValidation : AbstractValidator<TituloHQ>
    {
        public TituloHqValidation()
        {
            RuleFor(f => f.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.TituloOriginal)
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.AnoLancamento)
                .Length(2, 4)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
