### PowerShell Cmdlets to convert between Oracle RAW and GUID

I often have to convert between a RAW hex string returned in Oracle query results (at least in SQL Developer queries) and a GUID, or vice versa, but I have created 2 PowerShell cmdlets to help with these conversions and they have really saved me so much time.

#### The CmdLets

**Convert-GuidToRaw <guid-string>**: Convert a string representation of a standard GUID to an Oracle RAW string

_Example_:
> Convert-GuidToRaw 760fb5c1-a117-4fda-a29c-a7aa80a9655b [Enter]
***C1B50F7617A1DA4FA29CA7AA80A9655B***

**Convert-RawToGuid <raw-string>**: Convert an Oracle RAW representation of a GUID to a standard GUID

_Example_:
> Convert-RawToGuid C1B50F7617A1DA4FA29CA7AA80A9655B [Enter]
> ***Guid***  
> ***760fb5c1-a117-4fda-a29c-a7aa80a9655b***


#### Installation Instructions

1.	Find your main PowerShell modules folder. It is normally _C:\Program Files\WindowsPowerShell\Modules_, with _C:_ being dependent on how your drives are named, e.g. it could also be, say, _D:\Program Files\WindowsPowerShell\Modules_.
2.	Create a new folder under the modules folder to give _C:\Program Files\WindowsPowerShell\Modules\GuidConverter.Cmdlets\1.0.0_
3.  Copy the following build output files to the new folder:  
4.  i)    GuidConverter.CmdLets.dll
    2)    GuidConverter.CmdLets.psd1
    3)    GuidConverter.Core.dll
5.  The 2 new cmdlets should now be ready to use. To check this, 
from any folder in PowerShell, type *Convert-* and then press *CTRL-Space*. 
This should bring up a list of all cmdlets that start with *Convert*, and if 
*Convert-GuidToRaw* and *Convert-RawToGuid* are present in this list, then the GuidConverter cmdlets are properly installed and you can start using them as documented above   