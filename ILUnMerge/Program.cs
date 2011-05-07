using System;
using ACATool.Tasks;
using Microsoft.Build.Utilities;

namespace ACATool
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string assemFile = @"..\..\..\ILUnMergeTest\bin\Debug\MBUnitTests.exe";
            RenderProjectFiles rpf = new RenderProjectFiles();
            rpf.AssemblyFileName = assemFile;
            rpf.SourceDirectory = @"..\..\..\ILUnMergeTest";
            rpf.OutputDirectory = "Projects";
            rpf.NameHint = "mbuTests";
            rpf.Execute();

        }
    }
}