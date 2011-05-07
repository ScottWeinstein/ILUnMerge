using System;
using System.Collections.Generic;
using MbUnit.Framework;
using Mono.Cecil;
using ACATool;

namespace MBUnitTests
{


    [TestFixture]
    public class TestACA
    {
  
        DetermineClassDeps dcd;
        [SetUp]
        public void Setup()
        {
            dcd = new ACATool.DetermineClassDeps();
            dcd.AssemblyFile = this.GetType().Assembly.Location;
                //@"C:\dev\N\play\ACATool\TestAssem\bin\Debug\TestAssem.dll";
            dcd.GetAllTypes();
        }

        [Test]
        public void TestInternalClasses()
        {
            Assert.IsNotNull(dcd.TypeList.Find(
                delegate(TypeDefinition decl) { return (decl.Name == "NestedClass2Deep"); }));
        }
        [Test]
        public void TestContains()
        {
            TypeReference tref = dcd.TypeList.Find(
                 delegate(TypeDefinition decl) { return (decl.Name == "NestedClass2Deep"); });
            List<UsedClass> list = new List<UsedClass>();
            UsedClass uc1 = new UsedClass(tref, ClassUse.Calls);
            UsedClass uc2 = new UsedClass(tref, ClassUse.Calls);

            list.Add(uc1);
            Assert.IsTrue(list.Contains(uc1));
            Assert.IsTrue(list.Contains(uc2));
        }

        [RowTest]
        [Row("InheritedClass2", "InheritedClass1",ClassUse.Inherits)]
        [Row("InheritedClass2", "IMyInterface",ClassUse.Implements)]
        [Row("TopLevelClass2", "P1", ClassUse.Parameter)]
        [Row("TopLevelClass1", "AUsedClass2", ClassUse.Contains)] // method field
        [Row("TopLevelClass1", "AUsedClass", ClassUse.Contains)] // class member
        [Row("TopLevelClass1", "P1", ClassUse.Calls)] // new obj
        [Row("TopLevelClass1", "P3", ClassUse.Calls)]// Static ref
        [Row("TopLevelClass1", "P2", ClassUse.Calls)]//chained
        [Row("TLC3","AnAttribute",ClassUse.Attribute)]
        [Row("TLC4","P3",ClassUse.Parameter)]
         public void TestUses(string usesClass,string usedClass,ClassUse useMethod)
        {
            TestClassDeps(usesClass, usedClass, useMethod, false);
        }

        [Row("IC3", "AnAttribute", ClassUse.Attribute)]
        public void TestDoNotUse(string usesClass, string usedClass, ClassUse useMethod)
        {
            TestClassDeps(usesClass,usedClass,useMethod,true);
        }
        private void TestClassDeps(string usesClass, string usedClass, ClassUse useMethod,bool testForNotFound)
        {
            TypeDefinition usesTD = dcd.TypeList.Find(delegate(TypeDefinition decl)
            {
                return (decl.Name == usesClass);
            });
            Assert.IsNotNull(usesTD, "Unable to find usesTD");
            List<UsedClass> usedClassList = dcd.FindClassDeps(usesTD);
            UsedClass usedclass = usedClassList.Find(delegate(UsedClass uc)
            {
                if (uc.Use == useMethod)
                {
                    ITypeReference baseTyperef = uc.Type as ITypeReference;
                    if (baseTyperef != null && baseTyperef.Name == usedClass)
                        return true;
                }
                return false;
            });
            if (testForNotFound)
                Assert.IsNull(usedclass, "Found usedClass");
            else
                Assert.IsNotNull(usedclass, "Unable to find usedClass");

        }


    }
}
//[Test]
//public void TestUsesViaInherits()
//{
//    TypeDefinition usesClass = dcd.TypeList.Find(
//        delegate(TypeDefinition decl) { return (decl.Name == "InheritedClass2"); });

//   IType baseType =  dcd.ClassDependencies[usesClass].Find(
//        delegate(UsedClass uc){ return (uc.Use== ClassUse.Inherits);}).Type;
//    ITypeReference baseTyperef = baseType as ITypeReference;
//    Assert.AreEqual(baseTyperef.Name,"InheritedClass1");

//}

//[Test]
//public void TestUsesViaImplements()
//{
//    TypeDefinition usesClass = dcd.TypeList.Find(
//        delegate(TypeDefinition decl) { return (decl.Name == "InheritedClass2"); });

//    IType baseType = dcd.ClassDependencies[usesClass].Find(
//         delegate(UsedClass uc) { return (uc.Use == ClassUse.Implements); }).Type;
//    ITypeReference baseTyperef = baseType as ITypeReference;
//    Assert.AreEqual(baseTyperef.Name, "IMyInterface");

//}

