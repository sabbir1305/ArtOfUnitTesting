using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
   public class LogAnalyzer
    {
        private IExtensionManager manager;
        public LogAnalyzer(IExtensionManager mgr)
        {
            manager = mgr;
        }
        public bool IsValidLogFileName(string fileName)
        {
            return manager.IsValid(fileName);
        }
    }

    public interface IExtensionManager
    {
        bool IsValid(string fileName);
    }
}
