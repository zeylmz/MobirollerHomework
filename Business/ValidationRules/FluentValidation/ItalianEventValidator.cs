using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ItalianEventValidator : AbstractValidator<ItalianEvent>
    {
        public ItalianEventValidator()
        {
            RuleFor(e => e.dc_Evento).MinimumLength(5);
            RuleFor(e => e.dc_Categoria).MaximumLength(49);
            RuleFor(e => e.dc_Orario).MaximumLength(49);
            RuleFor(e => e.ID).NotEmpty();
        }
    }
}
