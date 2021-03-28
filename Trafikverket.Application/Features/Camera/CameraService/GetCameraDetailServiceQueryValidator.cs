using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trafikverket.Application.Features.Camera.CameraService
{
    public class GetCameraDetailServiceQueryValidator : AbstractValidator<GetCameraDetailServiceQuery>
    {
        public GetCameraDetailServiceQueryValidator()
        {
            RuleFor(p => p.PayloadName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .Equal("GetAllCamera").WithMessage("{PropertyName} is not Camera.");
        }
    }
    
}
