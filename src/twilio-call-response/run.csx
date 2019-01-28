using System.Net;
using System.Net.Http.Headers;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("Calling Twilio Call Response XML");

    string xmlResponse = @"<?xml version='1.0' encoding='UTF-8'?><Response><Say>We have critical ticket on XXX project !</Say></Response>";

    var response = new HttpResponseMessage(HttpStatusCode.OK);
    response.Content = new StringContent(xmlResponse);
    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
    return response;
}
