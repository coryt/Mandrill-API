using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mandrill.API.Tests
{
    [TestFixture]
    public class UserTests
    {
        private const string ApiKey = "e5654266-29f7-4c4e-92bd-3153ecc71c19";

        [Test]
        public void WithAPIKey_GetInfo_Should_ReturnInformation()
        {
            var response = MandrillRequest.With(ApiKey).In<Endpoints.Users>().GetInfo();
            Assert.IsNotNull(response);
        }

        [Test]
        public void WithInvalidAPIKey_GetInfo_ShouldNot_ReturnInformation()
        {
            var response = MandrillRequest.With("_invalidkey_").In<Endpoints.Users>().GetInfo();
            Assert.IsNotNull(response);
        }

        [Test]
        public void WithInvalidAPIKey_GetInfo_ShouldNot_ReturnInformation()
        {
            var response = MandrillRequest.With("_invalidkey_").In<Endpoints.Users>().GetInfo();
            Assert.IsNotNull(response);
        }

        [Test]
        public void WithInvalidAPIKey_GetInfo_ShouldNot_ReturnInformation()
        {
            var response = MandrillRequest.With("_invalidkey_").In<Endpoints.Users>().GetInfo();
            Assert.IsNotNull(response);
        }

    }
}
