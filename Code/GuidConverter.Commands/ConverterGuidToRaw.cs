using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace GuidConverter.Commands
{
    /// <summary>
    /// A PowerShell cmdlet that derives a string representation, for an Oracle RAW type column, of a Guid.
    /// </summary>
    [Cmdlet(VerbsData.Convert, "GuidToRaw")]
    public class ConverterGuidToRaw : System.Management.Automation.Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string Input { get; set; }

        protected override void ProcessRecord()
        {
            if (!Guid.TryParse(Input, out var inputGuid))
            {
                throw new ArgumentException("Input must be a valid Guid string");
            }
            var raw = GuidConverter.Core.GuidConverter.ToRaw(inputGuid);
            WriteObject(raw);
        }
    }
}
