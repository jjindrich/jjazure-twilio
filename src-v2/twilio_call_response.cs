using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;

namespace jjfunction
{
    public static class twilio_call_response
    {
        [FunctionName("twilio_call_response")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Calling Twilio Call Response XML");

            string xmlResponse = @"<?xml version='1.0' encoding='UTF-8'?><Response><Say>Welcome in Azure !</Say></Response>";

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(xmlResponse);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");

            return response;

        }
    }
}
