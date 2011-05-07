using System;
using System.Management.Automation;
using System.ComponentModel;

namespace ACATool.Tasks
{
    [RunInstaller(true)]
    public class Snapin : PSSnapIn
    {

        public Snapin():base()
        {

        }

        public override string Description
        {
            get { return Name +  " " + Vendor; }
        }

        public override string Name
        {
            get { return "AEq"; }
        }

        public override string Vendor
        {
            get { return "Scott Weinstein"; }
        }
    }
}
