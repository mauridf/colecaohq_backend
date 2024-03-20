using FluentValidation;

namespace colecaohq.Business.Models.Validations
{
    public class EquipePerssonagemValidation : AbstractValidator<EquipePerssonagem>
    {
        public EquipePerssonagemValidation()
        {
            RuleFor(f => f.NomeEquipePerssonagem)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
