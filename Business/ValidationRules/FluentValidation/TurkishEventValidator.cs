using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TurkishEventValidator : AbstractValidator<TurkishEvent>
    {
        public TurkishEventValidator()
        {
            RuleFor(e => e.dc_Olay).MinimumLength(5);
            RuleFor(e => e.dc_Kategori).MaximumLength(49);
            RuleFor(e => e.dc_Zaman).MaximumLength(49);
            RuleFor(e => e.ID).NotEmpty();
        }
    }
}
