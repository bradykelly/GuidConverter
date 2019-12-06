using System;
using System.Collections.Generic;
using System.Text;

namespace GuidConverter.Cli
{
    public class GuidConverter
    {
        public static string ToRaw(Guid target)
        {
            return StringifyByteArray(target.ToByteArray());
        }

        public static Guid FromRaw(string source)
        {
            var bytes = ParseHex(source);
            return new Guid(bytes);
        }

        public static string StringifyByteArray(byte[] array)
        {
            string str = null;
            if (array != null)
            {
                str = BitConverter.ToString(array).Replace("-", string.Empty);
            }
            return str;
        }

        private static byte[] ParseHex(string hex)
        {
            int offset = hex.StartsWith("0x") ? 2 : 0;
            if ((hex.Length % 2) != 0)
            {
                throw new ArgumentException("Invalid length: " + hex.Length);
            }
            byte[] ret = new byte[(hex.Length - offset) / 2];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = (byte)((ParseDigit(hex[offset]) << 4)
                                | ParseDigit(hex[offset + 1]));
                offset += 2;
            }
            return ret;
        }

        private static int ParseDigit(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return c - '0';
            }
            if (c >= 'A' && c <= 'F')
            {
                return c - 'A' + 10;
            }
            if (c >= 'a' && c <= 'f')
            {
                return c - 'a' + 10;
            }
            throw new ArgumentException("Invalid hex digit: " + c);
        }
    }
}
