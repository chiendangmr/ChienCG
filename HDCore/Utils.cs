using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic.Devices;

namespace HDCore
{
    public static class Utils
    {
        public static void SaveObject<T>(this T obj, string FileName)
        {
            var x = new XmlSerializer(typeof(T));
            using (var Writer = new StreamWriter(FileName, false))
            {
                x.Serialize(Writer, obj);
                Writer.Close();
            }
        }

        public static T GetObject<T>(string FileName)
        {
            using (FileStream stream = new FileStream(FileName, FileMode.Open))
            {
                XmlTextReader reader = new XmlTextReader(stream);
                var x = new XmlSerializer(typeof(T));
                var obj = (T)x.Deserialize(reader);
                stream.Close();
                return obj;
            }
        }

        public static string ObjectToXml<T>(this T obj)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stringwriter, obj);

            return stringwriter.ToString();
        }

        public static T ObjectFromXml<T>(string xml)
        {
            var stringReader = new System.IO.StringReader(xml);
            var serializer = new XmlSerializer(typeof(T));
            var obj = (T)serializer.Deserialize(stringReader);
            return obj;
        }

        public static string ObjectToString(this Object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static string ConvertToVietnameseNonSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string DayOfWeekToVietNam(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return "THỨ HAI";
                case DayOfWeek.Tuesday:
                    return "THỨ BA";
                case DayOfWeek.Wednesday:
                    return "THỨ TƯ";
                case DayOfWeek.Thursday:
                    return "THỨ NĂM";
                case DayOfWeek.Friday:
                    return "THỨ SÁU";
                case DayOfWeek.Saturday:
                    return "THỨ BẢY";
                default:
                    return "CHỦ NHẬT";
            }
        }

        public static Type GetListType<T>(List<T> _)
        {
            return typeof(T);
        }

        public static T Copy<T>(this T obj)
        {
            T newObj = Activator.CreateInstance<T>();
            Type objType = typeof(T);

            var props = objType.GetProperties().Where(p => p.CanRead && p.CanWrite).OrderBy(o => o.Name).ToList();

            foreach (PropertyInfo prop in props)
            {
                if (prop.CanRead && prop.CanWrite)
                    prop.SetValue(newObj, prop.GetValue(obj, null), null);
            }

            return newObj;
        }

        public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var itemsWithIndices = items.Select((item, index) => new { Item = item, Index = index });
            var matchingIndices =
                from itemWithIndex in itemsWithIndices
                where predicate(itemWithIndex.Item)
                select (int?)itemWithIndex.Index;

            return matchingIndices.FirstOrDefault() ?? -1;
        }

        public static string FileSizeToString(long fileSize)
        {
            double size = fileSize;
            string currentUnit = "B";
            while (size > 1024)
            {
                size /= 1024;
                if (currentUnit == "B")
                    currentUnit = "kB";
                else if (currentUnit == "kB")
                    currentUnit = "MB";
                else if (currentUnit == "MB")
                    currentUnit = "GB";
                else if (currentUnit == "GB")
                {
                    currentUnit = "TB";
                    break;
                }
            }
            return size.ToString("0.##") + currentUnit;
        }

        public static string GetHex(long x, int length)
        {
            return x.ToString("x").PadLeft(length, '0').Substring(0, length);
        }

        private static char[] _mBase32Alphabet = new char[]{'A','B','C','D','E','F','G','H','I','J',
            'K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','2','3','4','5','6','7'};
        public static string Base32Encode(long num, int length)
        {
            string base32 = "";
            for (int i = length; i > 0; i--)
            {
                base32 = _mBase32Alphabet[(num % 32)].ToString() + base32;
                num /= 32;
            }
            return base32;
        }

        public static long Base32Decode(string base32)
        {
            long num = 0;
            base32 = base32.ToUpper();
            foreach (char c in base32)
            {
                for (int i = 0; i < 32; i++)
                    if (c == _mBase32Alphabet[i])
                    {
                        num = num * 32 + i;
                        break;
                    }
            }
            return num;
        }

        public static string GetCurrentIP()
        {
            string myIP = "";

            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    if (myIP != "") myIP += ";";
                    myIP += ip.ToString();
                }
            }

            return myIP;
        }

        public static ulong GetRamSpace()
        {
            try
            {
                var computerInfo = new ComputerInfo();
                return computerInfo.AvailablePhysicalMemory;
            }
            catch { }
            return 0;
        }

        public const string RegExIP = @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)";

        /// <summary>
        /// Compresses the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// Decompresses the string.
        /// </summary>
        /// <param name="compressedText">The compressed text.</param>
        /// <returns></returns>
        public static string DecompressString(string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        public static string ToJSon<T>(this T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static T FromJSon<T>(this string str)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
            }
            catch { }

            return default(T);
        }
    }
}
