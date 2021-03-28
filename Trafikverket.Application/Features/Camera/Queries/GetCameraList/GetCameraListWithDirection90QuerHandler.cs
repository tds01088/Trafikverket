using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trafikverket.Application.Contracts.Persistence;

namespace Trafikverket.Application.Features.Camera.Queries.GetCameraList
{
   public  class GetCameraListWithDirection90QuerHandler : IRequestHandler<GetCameraListWithDirection90Query , List<CameraList>>
    {
        private readonly ITrafikverketCameraRepository _cameraRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCameraListWithDirection90QuerHandler> _logger;

        public GetCameraListWithDirection90QuerHandler(ITrafikverketCameraRepository cameraRepository, IMapper mapper, ILogger<GetCameraListWithDirection90QuerHandler> logger)
        {
            _cameraRepository = cameraRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<CameraList>> Handle(GetCameraListWithDirection90Query  request, CancellationToken cancellationToken)
        {
            var allCameras = (await _cameraRepository.ListAllAsync()).Where(c => c.Direction == 90).OrderBy(x => x.Name);           
            return await Task.FromResult(_mapper.Map<List<CameraList>>(allCameras));
        }
    }
}
