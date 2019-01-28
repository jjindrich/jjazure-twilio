using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace jjfunction
{
    public static class twilio_call
    {
        [FunctionName("twilio_call")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Twilio call started");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string toNumber = data?.To;

            if (toNumber != null)
            {
                const string accountSid = "<ACCOUNT>";
                const string authToken = "<TOKEN>";
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber(toNumber);
                var from = new PhoneNumber("+18064549797");
                var call = CallResource.Create(to, from,
                    url: new Uri("https://jjfunctionv2.azurewebsites.net/api/twilio_call_response"));
                //url: new Uri("http://demo.twilio.com/docs/voice.xml"));
            }

            return toNumber == null
                ? new BadRequestObjectResult("Please pass a To in the request body")
                : (ActionResult)new OkObjectResult("Calling...");
        }
    }
}
