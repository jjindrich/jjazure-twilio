using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("Twilio call started");

    dynamic data = await req.Content.ReadAsAsync<object>();
    string toNumber = data?.To;

    if (toNumber != null)
    {
        const string accountSid = "<ACCOUNT>";
        const string authToken = "<TOKEN>";
        TwilioClient.Init(accountSid, authToken);
        
        var to = new PhoneNumber(toNumber);
        var from = new PhoneNumber("+18064549797");
        var call = CallResource.Create(to, from,
            url: new Uri("https://jjfunction.azurewebsites.net/api/twilio-call-response"));        
            //url: new Uri("http://demo.twilio.com/docs/voice.xml"));
    }

    return toNumber == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a To in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Calling...");
}
