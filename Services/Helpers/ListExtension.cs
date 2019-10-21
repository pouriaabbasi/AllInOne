using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AllInOne.Services.Helpers
{
    public static class ListExtension
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            var provider = new RNGCryptoServiceProvider();
            var n = list.Count;
            while (n > 1)
            {
                var box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                var k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}