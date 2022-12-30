using System;

namespace Lab5Games
{
    public static class BinaryExtensions
    {
        public static string ToBinaryString(this int inValue)
        {
            char[] buff = new char[32];

            for (int indx = 0; indx < buff.Length; indx++)
                buff[indx] = GetBit(inValue, indx) > 0 ? '1' : '0';

            Array.Reverse(buff);
            int cut_point = 8;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            foreach (var b in buff)
            {
                if (cut_point == 0)
                {
                    cut_point = 8;
                    sb.Append(" ");
                }

                sb.Append(b);
                --cut_point;
            }

            return sb.ToString();
        }

        public static int Reverse(this int inValue)
        {
            return ~inValue;
        }

        public static int SetBit(this int inValue, int index, int flag)
        {
            if (index < 0 || index > 31)
            {
                throw new IndexOutOfRangeException("index");
            }

            return ((inValue & ~(1 << index)) | ((flag > 0 ? 1 : 0) << index));
        }

        public static int GetBit(this int inValue, int index)
        {
            if (index < 0 || index > 31)
            {
                throw new IndexOutOfRangeException("index");
            }

            return (inValue & (1 << index)) != 0 ? 1 : 0;
        }
    }
}