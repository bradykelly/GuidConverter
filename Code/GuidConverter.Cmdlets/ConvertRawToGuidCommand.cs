using System;
using System.Management.Automation;

namespace GuidConverter.Cmdlets;

/// <summary>
/// A PowerShell cmdlet that derives a formatted Guid from the hex string representation of an Oracle RAW(16) type column value.
/// </summary>
[Cmdlet(VerbsData.Convert, "RawToGuid")]
public class ConvertRawToGuidCommand : Cmdlet
{
    private const string HelpText = "Please enter a 32 character RAW(16) format string to convert to a GUID.";
    
    [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true, HelpMessage = HelpText)]
    public string? Input { get; set; }

    protected override void ProcessRecord()
    {
        var guid = Core.GuidConverter.FromRaw(Input);
        WriteObject(guid);
    }
}