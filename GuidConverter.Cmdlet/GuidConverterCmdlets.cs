using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace GuidConverter.Cmdlet
{
    [Cmdlet(VerbsData.Convert, "Guid")]
    public class GuidConverterCmdlets : System.Management.Automation.Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Input { get; set; }
    }
}
