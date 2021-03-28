using FluentValidation;

namespace Trafikverket.Application.Features.Camera.Commands.CreateCamera
{
    public class CreateCameraCommandValidator: AbstractValidator<CreateCameraCommand>
    {
        public CreateCameraCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        }
    }
}
