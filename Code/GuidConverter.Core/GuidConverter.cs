using System.Text.RegularExpressions;

namespace GuidConverter.Core;

public static class GuidConverter
{
    /// <summary>
    /// Derives a string representation of a GUID that is suitable for use e.g. in an Oracle RAW(16) type column.
    /// </summary>
    /// <param name="source">A normally formatted GUID e.g. "085ef253-541d-4749-9c13-42d82027e12b" from which to determine raw string.</param>
    /// <returns>A raw string representation of <paramref name="source"/> e.g. "53F25E081D5449479C1342D82027E12B"</returns>
    public static string? ToRaw(Guid source)
    {
        return StringifyByteArray(source.ToByteArray());
    }

    /// <summary>
    /// Derives a normal, grouped string representation of a GUID that as is stored as raw bytes e.g. in an Oracle RAW(16) type column.
    /// </summary>
    /// <param name="source">A raw byte string representation of a GUID e.g. from an Oracle RAW(16) column "53F25E081D5449479C1342D82027E12B"</param>
    /// <returns>A normal, grouped string representation of a GUID, e.g. "085ef253-541d-4749-9c13-42d82027e12b" based on <paramref name="source"/></returns>
    public static Guid FromRaw(string? source)
    {
        var regEx = new Regex("^[a-fA-F0-9]{32}$");
        if (string.IsNullOrWhiteSpace(source) || !regEx.IsMatch(source))
        {
            throw new ArgumentException("Input must be a 32 char hex string. Input was this: " + (source ?? "'empty'"));
        }

        var bytes = ParseHex(source);
        return new Guid(bytes);
    }

    private static string? StringifyByteArray(byte[]? bytes)
    {
        // BKTODO Test null cases
        string? str = null;
        if (bytes != null)
        {
            str = BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
        return str;
    }

    private static byte[] ParseHex(string hex)
    {
        var offset = 0;
        var bytes = new byte[hex.Length / 2];

        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = (byte)((ParseDigit(hex[offset]) << 4)
                              | ParseDigit(hex[offset + 1]));
            offset += 2;
        }
        return bytes; 
    }

    private static int ParseDigit(char c)
    {
        return c switch
        {
            >= '0' and <= '9' => c - '0',
            >= 'A' and <= 'F' => c - 'A' + 10,
            >= 'a' and <= 'f' => c - 'a' + 10,
            _ => throw new ArgumentException("Invalid hex digit: " + c)
        };
    }
}