using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Trafikverket.Application.Contracts.Infrastructure;
using Trafikverket.Application.Features.Camera.CameraService;

namespace Trafikverket.Infrastructure.Services
{
    public class RelayCameraService : IRelayCameraService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ILogger<RelayCameraService> _logger { get; }
   
        public RelayCameraService(IHttpClientFactory clientFactory, ILogger<RelayCameraService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
         
        }



        public async Task<RootCameraResponse> GetListCameraDetailAsync(string payload)
        {

            _logger.LogInformation("Trafikverket API Service  Starting");

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post,"");
            var client = _clientFactory.CreateClient("trafikverket");         
            httpRequest.Content = new StringContent(payload, System.Text.Encoding.UTF8, "application/xml");
            var response = await client.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();
           
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync
                             <RootCameraResponse>(responseStream);
            }
            else
            {
                _logger.LogError("API SendAsync failed");
                return Array.Empty<RootCameraResponse>().First();
            }

        }
    }
}
