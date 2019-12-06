using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace GuidConverter.Cmdlet
{
    [Cmdlet(VerbsData.Convert, "GuidToRaw")]
    public class GuidConverterCmdlets : System.Management.Automation.Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string Input { get; set; }

        protected override void ProcessRecord()
        {
            if(!Guid.TryParse(Input, out var inputGuid))
            {
                throw new ArgumentException("Input must be a valid Guid string");
            }
            var raw = GuidConverter.Core.GuidConverter.ToRaw(inputGuid);
            WriteObject(raw);
        }
    }
}
