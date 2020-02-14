using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuidConverter.Commands
{
    [Cmdlet(VerbsCommon.Get, "Guid")]
    public class GetGuidCommand : System.Management.Automation.Cmdlet
    {
        protected override void ProcessRecord()
        {
            var guid = Guid.NewGuid();
            Clipboard.SetText(guid.ToString()); 
            WriteObject(guid);
        }
    }
}
