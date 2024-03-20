using FluentValidation;

namespace colecaohq.Business.Models.Validations
{
    public class EditoraValidation : AbstractValidator<Editora>
    {
        public EditoraValidation()
        {
            RuleFor(f => f.NomeEditora)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
