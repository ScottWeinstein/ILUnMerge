using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using IO = System.IO;
using Reflector.CodeModel;

namespace ACATool.Tasks
{
    public class AssembliesEquivTask : Task
    {
        [Output]
        public string ReasonCode { get; private set; }
        [Required]
        public ITaskItem OriginalAssembly { get; set; }
        [Required]
        public ITaskItem NewAssembly { get; set; }
        [Output]
        public bool AreEquivalent { get; private set; }

        public override bool Execute()
        {
            AssemComp acomp = new AssemComp(OriginalAssembly.ItemSpec, NewAssembly.ItemSpec);
            AreEquivalent = acomp.AreEquivalent;
            ReasonCode = acomp.Reason;
            return true;
        }
    }

}
