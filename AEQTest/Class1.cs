using System;
using Xunit;
using ACATool.Tasks;

namespace AEQTest
{
    
    public class Class1
    {
        [Fact]
        public void T1()
        {
            string asmA = @"D:\dev\ILUnMerge\AssemblyEquiv\bin\Debug\AssemblyEquiv.dll";
            AssemComp acomp = new AssemComp(asmA, asmA);
            Assert.True(acomp.AreEquivalent);
        }
    }
}
