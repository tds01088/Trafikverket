using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Trafikverket.Application.Contracts.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Trafikverket.Application.Models;
using Trafikverket.Application.Contracts.Utilities;

namespace Trafikverket.Application.Features.Camera.CameraService
{
    public class GetCameraDetailServiceQueryHandler : IRequestHandler<GetCameraDetailServiceQuery, List<CameraDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRelayCameraService _relayCameraService;
        public GetCameraDetailServiceQueryHandler(IMapper mapper, IRelayCameraService relayCameraService)
        {
            _mapper = mapper;
            _relayCameraService = relayCameraService;
        }

        public async Task<List<CameraDto>> Handle(GetCameraDetailServiceQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCameraDetailServiceQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var palyoad = QueryPayloads.BaseStart + QueryPayloads.Camera.GetAllCamera + QueryPayloads.BaseEnd;
            var rootCameraDto =   await _relayCameraService.GetListCameraDetailAsync(palyoad);           
            List<Camera> cameraList = rootCameraDto.RESPONSE.RESULT[0].Camera;
            return _mapper.Map<List<CameraDto>>(cameraList.ToList());
         
        }
        

    }
}
