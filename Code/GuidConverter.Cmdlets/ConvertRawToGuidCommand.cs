using System;
using System.Management.Automation;

namespace GuidConverter.Cmdlets
{
    /// <summary>
    /// A PowerShell cmdlet that derives a Guid from the hex string representation of an Oracle RAW type column value.
    /// </summary>
    [Cmdlet(VerbsData.Convert, "RawToGuid")]
    public class ConvertRawToGuidCommand : System.Management.Automation.Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string Input { get; set; }

        protected override void ProcessRecord()
        {
            if (string.IsNullOrEmpty(Input) || Input.Length != 32)
            {
                throw new ArgumentException("Input must be a 32 character hex string");
            }
            var guid = GuidConverter.Core.GuidConverter.FromRaw(Input);
            WriteObject(guid);
        }
    }
}
