using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {


        [TestCase("Filename.slf",true)]
        [TestCase("Filename.SLF",true)]
        [TestCase("Filename.SLF",false)]
        public void IsalidLogFileName_ValidExtensions_ReturnsTrue(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(file);

            Assert.AreEqual(result,expected);
        }
    }
}
