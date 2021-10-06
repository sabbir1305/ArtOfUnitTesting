using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{

    [TestFixture]
   public class LogAnaluzer2Tests
    {
        [Test]
        public void Analyze_WebserviceThrows_SendEmail()
        {
            FakeWebServie stubWebService = new FakeWebServie();
            stubWebService.ToThrow = new Exception("fake exception");

            FakeEmailService mockEmail = new FakeEmailService();
            LogAnalyzer2 log = new LogAnalyzer2(stubWebService, mockEmail);

            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);

            StringAssert.Contains("someone@somewhere.com", mockEmail.To);
            StringAssert.Contains("fake exception", mockEmail.Body);
            StringAssert.Contains("can't log", mockEmail.Subject);
        }
    }

    public class FakeWebServie : IWebService
    {
        public Exception ToThrow;
        public void LogError(string error)
        {
            if (ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }

    public class FakeEmailService : IEmailService
    {
        public string To;
        public string Subject;
        public string Body;

        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
