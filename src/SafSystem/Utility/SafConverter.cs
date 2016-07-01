using System.IO;
using System.Text;

namespace Ataoge.Utility
{
    public static class SafConverter
    {
        /// <summary>
        /// StringToBytes
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary>
        /// BytesToStream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Stream ToStream(this byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// StreamToFile
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static void ToFile(this Stream stream, string filePath)
        {
            // 把 Stream 转换成 byte[]
            byte[] bytes = stream.ToBytes();

            //有一种更简捷的方法把 byte[]写入文件：system.io.file.WriteAllBytes(string path,bytes)
            System.IO.File.WriteAllBytes(filePath, bytes);
        }

        /// <summary>
        /// BytesToFile
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static void ToFile(this byte[] bytes, string filePath)
        {
             // 把 byte[] 写入文件
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(bytes);
                    //bw.Close();
                }
                //fs.Close();
            }
        }

        /// <summary>
        /// FileToBytes
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] FileToBytes(string filePath)
        {
            // 打开文件
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                // 读取文件的 byte[]
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                //fileStream.Close();
                return bytes;
            }
        }

        /// <summary>
        /// FileToStream
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Stream FileToStream(string filePath)
        {
            ////****读取文件的 byte[]：用system.io.file.ReadAllBytes(fileName)更为简捷。*******
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            
            // 把 byte[] 转换成 Stream
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// StringToStream
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Stream ToStream(this string value)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(value);
            writer.Flush();
            return stream;
        }

        /// <summary>
        /// StreamToString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(this Stream stream, Encoding encoding = null)
        {
            stream.Position = 0;
            StreamReader reader = new StreamReader( stream );
            string text = reader.ReadToEnd();
            return text;
        }

    }
}