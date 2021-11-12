using System;
using System.Management.Automation;

namespace GuidConverter.Cmdlets
{
    /// <summary>
    /// A PowerShell cmdlet that derives a string representation, for an Oracle RAW type column, of a Guid.
    /// </summary>
    [Cmdlet(VerbsData.Convert, "GuidToRaw")]
    public class ConvertGuidToRawCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public Guid Input { get; set; }

        protected override void ProcessRecord()
        {
            var raw = GuidConverter.Core.GuidConverter.ToRaw(Input);
            WriteObject(raw);
        }
    }
}
