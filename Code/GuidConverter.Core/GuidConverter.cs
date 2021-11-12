using System;
using System.Text.RegularExpressions;

namespace GuidConverter.Core
{
    public class GuidConverter
    {
        public static string ToRaw(Guid source)
        {
            return StringifyByteArray(source.ToByteArray());
        }

        public static Guid FromRaw(string source)
        {
            var regEx = new Regex("^[a-fA-F0-9]{32}$");
            if (!regEx.IsMatch(source))
            {
                throw new ArgumentException("Input must be a 32 char hex string. Input was this: " + source);
            }

            var bytes = ParseHex(source);
            return new Guid(bytes);
        }

        private static string StringifyByteArray(byte[] bytes)
        {
            string str = null;
            if (bytes != null)
            {
                str = BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
            return str;
        }

        private static byte[] ParseHex(string hex)
        {
            int offset = 0;
            byte[] bytes = new byte[hex.Length / 2];

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
}
