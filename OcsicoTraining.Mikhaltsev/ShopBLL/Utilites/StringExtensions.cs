using System;
using System.IO;

namespace ShopBLL.Utilites
{
    public static class StringExtensions
    {
        public static string ToBase64(this string path)
        {
            var bytes = File.ReadAllBytes(path);

            return Convert.ToBase64String(bytes);
        }
    }
}
