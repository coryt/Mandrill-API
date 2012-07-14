using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Mandrill.API.Endpoints;
using Mandrill.API.Models;

namespace Mandrill.API.Tests
{
    [Subject(typeof(Endpoints.Messages), "Send Endpoint")]
    public class when_sending_email : MessageSpecs
    {
        static List<RecipientReturn> recipients;

        private Because of =
            () =>
            recipients =
            messageEndpoint.send(
                new
                    {
                        html = htmlContent,
                        text = textContent,
                        subject,
                        from_email = fromEmail,
                        from_name = fromName,
                        to = sendTo,
                        headers = new { },
                        track_opens = true,
                        track_clicks = true,
                        auto_text = true,
                        url_strip_qs = true,
                        bcc_address = "",
                        merge = false,
                        global_merge_vars = new object[] { },
                        merge_vars = new object[] { },
                        tags = new object[] { },
                        google_analytics_domains = new object[] { },
                        google_analytics_campaign = new object[] { },
                        metadata = new object[] { },
                        attachments = new object[] { }
                    });

        It should_not_be_null = () => recipients.ShouldNotBeNull();
        It should_not_be_empty = () => recipients.ShouldNotBeEmpty();
        It should_contain_sendTo = () => recipients.Any(r => r.email == ((dynamic)sendTo[0]).email).ShouldBeTrue();
    }

    [Subject(typeof(Endpoints.Users), "Send-Template Endpoint")]
    public class when_sending_with_template : MessageSpecs
    {
        static List<RecipientReturn> recipients;

        private Because of = () => recipients = messageEndpoint.sendtemplate("Mailatale - Basic",
            new List<object> { new { } },
            new
            {
                text = "",
                subject,
                from_email = fromEmail,
                from_name = fromName,
                to = sendTo,
                headers = new { },
                track_opens = true,
                track_clicks = true,
                auto_text = true,
                url_strip_qs = true,
                bcc_address = "",
                merge = false,
                global_merge_vars = new object[] { },
                merge_vars = new object[] { },
                tags = new object[] { },
                google_analytics_domains = new object[] { },
                google_analytics_campaign = new object[] { },
                metadata = new object[] { },
                attachments = new object[] { }
            });

        It should_not_be_null = () => recipients.ShouldNotBeNull();
        It should_not_be_empty = () => recipients.ShouldNotBeEmpty();
        It should_contain_sendTo = () => recipients.Any(r => r.email == ((dynamic)sendTo[0]).email).ShouldBeTrue();
    }

    public abstract class MessageSpecs
    {
        protected static Messages messageEndpoint;
        protected static string htmlContent;
        protected static string textContent;
        protected static string subject;
        protected static string fromEmail;
        protected static string fromName;
        protected static object[] sendTo;
        Establish context = () =>
        {
            messageEndpoint = MandrillRequest.With("e5654266-29f7-4c4e-92bd-3153ecc71c19").In<Endpoints.Messages>();
            sendTo = new object[] { new { email = "cory.c.taylor@gmail.com", name = "Cory Taylor" } };
            htmlContent = "<html><head></head><body>This is a test html email!</body></html>";
            textContent = "This is a test text email!";
            subject = "Mandrill.API Test";
            fromEmail = "noreply@mandrill.api";
            fromName = "Mandrill API";
        };
    }
}