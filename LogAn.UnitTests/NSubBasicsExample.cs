using LogAn.Contracts;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LogAn.LogAnalyzer3;

namespace LogAn.UnitTests
{
    
    [TestFixture]
    class NSubBasicsExample
    {
        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFilenameRules fakeRules = Substitute.For<IFilenameRules>();
            fakeRules.IsValidLogFileName("strict.txt").Returns(true);
            Assert.IsTrue(fakeRules.IsValidLogFileName("strict.txt"));
        }

        [Test]
        public void Returns_ByDefault_WorksForHardCodedAnyArgument()
        {
            IFilenameRules fakeRules = Substitute.For<IFilenameRules>();
            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);
            Assert.IsTrue(fakeRules.IsValidLogFileName("strict.txt"));
        }


        [Test]

        public void Returns_ArgAny_Throws()
        {
            IFilenameRules fakeRules = Substitute.For<IFilenameRules>();
            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>())).Do(context =>
            {
                throw new Exception("fake exeption");

            });
            Assert.Throws<Exception>(() => fakeRules.IsValidLogFileName("anything"));
        }


        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockWebService = Substitute.For<LogAn.LogAnalyzer3.IWebService>();
            var stubLogger = Substitute.For<ILogger>();

            stubLogger.When(logger => logger.LogError(Arg.Any<string>())).Do(info => { throw new Exception("fake exception"); });

            var analyzer = new LogAnalyzer3(stubLogger, mockWebService);

            analyzer.MinNameLength = 10;
            analyzer.Analyze("Short.txt");

            mockWebService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));

        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObject()
        {
            var mockWebService = Substitute.For<LogAnalyzer3.IWebService>();

            var stubLogger = Substitute.For<ILogger>();

            stubLogger.When(logger => logger.LogError(Arg.Any<string>())).Do(info =>
             {
                 throw new Exception("fake exception");
             });

            var analyzer = new LogAnalyzer3(stubLogger, mockWebService);

            analyzer.MinNameLength = 10;
            analyzer.Analyze("short.txt");
            mockWebService.Received().Write(Arg.Is<ErrorInfo>(info => info.Severity == 1000 && info.Message.Contains("fake exception")));
        }
    }
}
