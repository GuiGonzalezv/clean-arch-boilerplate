using FluentValidation;

namespace AgrotoolsMaps.Application.UseCases.Shared.Validations
{
    public class PageRequestValidator : AbstractValidator<PageRequest>
    {
        public PageRequestValidator()
        {
            ValidatePage();
            ValidateSize();
        }

        private void ValidatePage()
        {
            RuleFor(r => r.Page)
                .GreaterThan(0)
                .WithMessage("Informação da página requisitada é obrigatória.");
        }

        private void ValidateSize()
        {
            RuleFor(r => r.Size)
                .GreaterThan(0)
                .WithMessage("Informação do tamanho da página é obrigatória.");
        }
    }
}