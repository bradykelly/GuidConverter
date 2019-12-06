using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace GuidConverter.Cmdlet
{
    [Cmdlet(VerbsData.Convert, "GuidToRaw")]
    public class ConverterGuidToRaw : System.Management.Automation.Cmdlet
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
