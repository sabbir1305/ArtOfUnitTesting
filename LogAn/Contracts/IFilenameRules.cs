using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.Contracts
{
  public  interface IFilenameRules
    {
        public bool IsValidLogFileName(string fileName);
    }
}
