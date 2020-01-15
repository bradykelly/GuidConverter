﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuidConverter.Commands
{
    [Cmdlet(VerbsCommon.New, "Guid")]
    public class NewGuidCommand : System.Management.Automation.Cmdlet
    {
        protected override void ProcessRecord()
        {
            var guid = Guid.NewGuid();
            Clipboard.SetText(guid.ToString()); 
            WriteObject(guid);
        }
    }
}