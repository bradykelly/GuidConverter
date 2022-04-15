using System.Management.Automation;
using System.Net.Http.Headers;

namespace GuidConverter.Cmdlets;

/// <summary>
/// A PowerShell cmdlet that derives a string representation of a GUID that is suitable for use with an Oracle RAW(16) type column.
/// </summary>
[Cmdlet(VerbsData.Convert, "GuidToRaw")]
public class ConvertGuidToRawCommand : Cmdlet
{
    private const string HelpText = "Please enter a GUID to convert to RAW(16) format.";
    
    [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
    public Guid Input { get; set; }

    protected override void ProcessRecord()
    {
        var raw = GuidConverter.Core.GuidConverter.ToRaw(Input);
        WriteObject(raw);
    }
}