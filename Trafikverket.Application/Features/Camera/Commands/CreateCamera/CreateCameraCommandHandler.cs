using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trafikverket.Application.Contracts.Persistence;
using Trafikverket.Domain.Entities;

namespace Trafikverket.Application.Features.Camera.Commands.CreateCamera
{
    public class CreateCameraCommandHandler: IRequestHandler<CreateCameraCommand, Guid>
    {
        private readonly ITrafikverketCameraRepository _cameraRepository;
        private readonly IMapper _mapper;      
        private readonly ILogger<CreateCameraCommandHandler> _logger;
   

        public CreateCameraCommandHandler(ITrafikverketCameraRepository cameraRepository, IMapper mapper, 
                                          ILogger<CreateCameraCommandHandler> logger)
        {
            _cameraRepository = cameraRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateCameraCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCameraCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                  throw new Exceptions.ValidationException(validationResult);

            var @camera = _mapper.Map<CameraEntity>(request);
            await _cameraRepository.AddAsync(@camera);          
            return  @camera.Id;
        }
    }
}
