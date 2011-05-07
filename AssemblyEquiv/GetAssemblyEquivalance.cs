using System;
using System.Management.Automation;

namespace ACATool.Tasks
{
    [Cmdlet(VerbsCommon.Get,"AssemblyEquivalance")]
    public class GetAssemblyEquivalance : PSCmdlet
    {
        [Parameter(Mandatory=true)]
        public string AssemblyA { get; set; }
        [Parameter(Mandatory = true,Position=2)]
        public string AssemblyB { get; set; }

        protected override void BeginProcessing()
        {
            try
            {
                var acomp = new AssemComp(AssemblyA, AssemblyB);
                WriteObject(acomp);
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        ex,
                        "OpenIsolatedStorage",
                        ErrorCategory.NotSpecified,this
                        )
                    );

            }
        }
    }
}
