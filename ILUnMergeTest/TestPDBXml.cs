using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;
using MbUnit.Framework;

namespace MBUnitTests
{
    [TestFixture]
    public class TestPDBXml
    {
       	XPathDocument pdbXPathDoc;
		XPathNavigator pdbNav;

        [SetUp]
        public void Setup()
        {
            string p = Path.GetDirectoryName(this.GetType().Assembly.CodeBase);
            pdbXPathDoc = new XPathDocument(Path.Combine(p, "MBUnitTests.pdb.xml"));
            pdbNav = pdbXPathDoc.CreateNavigator();
        }

 
        [Row("ClassesAsData.P2", @"C:\dev\Play\ACATool\MBUnitTests\P2.cs")]
        [Row("ClassesAsData.InheritedClass1", @"C:\dev\Play\ACATool\MBUnitTests\InheritedClass1.cs")]
        [RowTest()]
        public void FindClass(string className, string fileName)
        {
            string query = String.Format(@"/Types/Type[@Name=""{0}""]/File/@Name", className);
            XPathNodeIterator res = pdbNav.Select(query);
            List<string> files = new List<string>();
            while (res.MoveNext())
                files.Add(res.Current.Value);

            //Environment.CurrentDirectory

            Assert.AreEqual(files.Count, 1);
            Assert.AreEqual(files[0], fileName);
        }


    }
}
