using System;
using System.Threading.Tasks;
using SendGrid;

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Tangsem.Common.Extensions;

namespace Sample.Host.Services
{
  public class AuthMessageSender : IEmailSender
  {
    public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
    {
      this.Options = optionsAccessor.Value;
    }

    public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

    public Task SendSmsAsync(string number, string message)
    {
      // Plug in your SMS service here to send a text message.
      // Your Account SID from twilio.com/console
      var accountSid = this.Options.TwilioAccountId;
      // Your Auth Token from twilio.com/console
      var authToken = this.Options.TwilioKey;

      TwilioClient.Init(accountSid, authToken);

      return MessageResource.CreateAsync(
        to: new PhoneNumber(number),
        from: new PhoneNumber(this.Options.TwilioPhoneNumber),
        body: message);
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
      var response = await this.Execute(this.Options.SendGridKey, subject, message, email);

      if (!response.StatusCode.IsSuccessCode())
      {
        var errMsg = $"Unable to send email! RESPONSE:{response.StatusCode} - {response.StatusCode.ToString()}";
        try
        {
          errMsg += (", Details:" + await response.Body.ReadAsStringAsync());
        }
        catch (Exception ex)
        {
          errMsg += $", Unable to get more details due to error:{ex}";
        }

        throw new Exception(errMsg);
      }
    }

    public async Task<Response> Execute(string apiKey, string subject, string message, string email)
    {
      var client = new SendGridClient(apiKey);
      var msg = new SendGridMessage()
                  {
                    From = new EmailAddress("bobliwang@gmail.com", "Bob Li Wang"),
                    Subject = subject,
                    PlainTextContent = message,
                    HtmlContent = message
                  };
      msg.AddTo(new EmailAddress(email));

      // Disable click tracking.
      // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
      msg.SetClickTracking(true, true);

      return await client.SendEmailAsync(msg);
    }
  }

  public class AuthMessageSenderOptions
  {
    public string SendGridUser { get; set; }
    public string SendGridKey { get; set; }

    public string TwilioAccountId { get; set; }
    public string TwilioKey { get; set; }
    public string TwilioPhoneNumber { get; set; }
  }
}