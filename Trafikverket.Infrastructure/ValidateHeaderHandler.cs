using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Trafikverket.Infrastructure
{
   public  class ValidateHeaderHandler: DelegatingHandler
    {
      protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                      CancellationToken cancellationToken)
        {
           if(request.Headers.Accept.ToString() !="application/xml")           
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(
                        "You must supply an API key header called X-API-KEY")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
