using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace GuidConverter.Commands
{
    /// <summary>
    /// A PowerShell cmdlet that derives a Guid from the hex string representation of an Oracle RAW type column.
    /// </summary>
    [Cmdlet(VerbsData.Convert, "RawToGuid")]
    public class ConvertRawToGuid : System.Management.Automation.Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
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
