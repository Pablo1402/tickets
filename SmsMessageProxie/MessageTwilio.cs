using Business.Interfaces.Proxies;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace SmsMessageProxie
{
    public class MessageTwilio : ISmsMessageProxie
    {
        public async Task SendMessage(string text, string phoneTo)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            var accountSid = "{id}";
            var authToken = "{pass}";
            TwilioClient.Init(accountSid, authToken);


            var message = MessageResource.Create(
                body: text,
                from: new Twilio.Types.PhoneNumber("+15076045751"),
                to: new Twilio.Types.PhoneNumber(phoneTo)
            );
        }
    }
}
