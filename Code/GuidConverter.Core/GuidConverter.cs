using System;

namespace GuidConverter.Core
{
    public class GuidConverter
    {
        public static string ToRaw(Guid source)
        {
            return StringifyByteArray(source.ToByteArray());
        }

        public static Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        public static Guid FromRaw(string source)
        {
            // BKTODO Check string is hex digits only.
            if (source.Length != 32)
            {
                throw new ArgumentException("Input must be a 32 char hex string. Input was this: " + source);
            }
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
            int offset = 0;
            byte[] ret = new byte[hex.Length / 2];

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
