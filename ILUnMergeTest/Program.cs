using System;
using System.Collections.Generic;
using System.Text;
using MbUnit.Core;
using MbUnit.Framework;

namespace MBUnitTests
{
    class Program
    {
        static int Main(string[] args)
        {
            using (AutoRunner runner = new AutoRunner())
            {
                runner.Load();
                runner.Run();
                runner.ReportToHtml();
                int runnerExitCode = runner.ExitCode;
                return runnerExitCode;
            }

        }
    }
}
