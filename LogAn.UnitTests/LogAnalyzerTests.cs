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
        [TestCase("Filename.sds",false)]
        public void IsalidLogFileName_ValidExtensions_ReturnsTrue(string file, bool expected)
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager();
            fakeExtensionManager.WillBeValid = true;
            LogAnalyzer analyzer = new LogAnalyzer(fakeExtensionManager);
            bool result = analyzer.IsValidLogFileName(file); 

            Assert.AreEqual(result,expected);
        }

       
    }

    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public bool IsValid(string fileName)
        {
            return WillBeValid;
        }
    }
}
