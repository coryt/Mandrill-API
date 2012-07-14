using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Mandrill.API.Endpoints;
using Mandrill.API.Models;
using NUnit.Framework;

namespace Mandrill.API.Tests
{
    [Subject(typeof(Endpoints.Users), "Info Endpoint")]
    public class when_requesting_info : UserSpecs
    {
        static UserInformation userInfo;
        Because of = () => userInfo = userEndpoint.GetInfo();

        It should_not_be_null = () => userInfo.ShouldNotBeNull();
        It should_have_contain_a_username = () => userInfo.username.ShouldNotBeEmpty();
    }

    [Subject(typeof(Endpoints.Users), "Ping Endpoint")]
    public class when_requesting_ping : UserSpecs
    {
        static string pingResponse;
        Because of = () => pingResponse = userEndpoint.Ping();

        It should_not_be_null = () => pingResponse.ShouldNotBeNull();
        It should_equal_pong = () => pingResponse.ShouldEqual("\"PONG!\"");
    }

    [Subject(typeof(Endpoints.Users), "Ping2 Endpoint")]
    public class when_requesting_ping2 : UserSpecs
    {
        static Ping2 pingResponse;
        Because of = () => pingResponse = userEndpoint.Ping2();
        
        It should_not_be_null = () => pingResponse.ShouldNotBeNull();
        It should_equal_pong = () => pingResponse.PING.ShouldEqual("PONG!");
    }

    [Subject(typeof(Endpoints.Users), "Senders Endpoint")]
    public class when_requesting_senders : UserSpecs
    {
        static List<SenderData> senderResponse;
        Because of = () => senderResponse = userEndpoint.GetSenders();

        It should_not_be_null = () => senderResponse.ShouldNotBeNull();
        It should_not_be_empty = () => senderResponse.ShouldNotBeEmpty();
    }

    public abstract class UserSpecs
    {
        protected static Users userEndpoint;

        Establish context = () =>
        {
            userEndpoint = MandrillRequest.With("e5654266-29f7-4c4e-92bd-3153ecc71c19").In<Endpoints.Users>();
        };
    }
}
