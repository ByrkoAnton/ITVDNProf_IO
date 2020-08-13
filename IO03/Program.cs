using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace IO03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FileInfo> files = new List<FileInfo>();
            SerchFile(new DirectoryInfo(@"d:\test\"), "test.txt", files);
            Console.WriteLine(files.Count);
            foreach (var i in files)
            {
                Console.WriteLine(i.FullName);
            }

            Read(files[0]);

            Compress(files[0]);
        }

        public static void Read(FileInfo file)
        {
            StreamReader reader = file.OpenText();
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();

            ////по условию нужно так, вроде как

            //FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            //StreamReader reader2 = new StreamReader(stream);
            //Console.WriteLine(reader2.ReadToEnd());
            //reader2.Close();
        }

        public static void Compress(FileInfo file)
        {
            FileStream src = file.OpenRead();
            FileStream dst = File.Create(file.FullName.Remove(file.FullName.LastIndexOf('.')) + ".zip");

            GZipStream compressor = new GZipStream(dst,CompressionMode.Compress);
            int t = src.ReadByte();
            while (t!=-1)
            {
               compressor.WriteByte((byte)t);
               t = src.ReadByte();
            }

            compressor.Close();
            src.Close();
            dst.Close();
        }

        public static void SerchFile(DirectoryInfo dr, string fileName, List<FileInfo> files)
        {
            FileInfo[] fi = dr.GetFiles();
            foreach (FileInfo info in fi)
            {
                if (fileName.Contains(info.Name))
                {
                    files.Add(info);
                }
            }
            DirectoryInfo[] dirs = dr.GetDirectories();
            foreach (DirectoryInfo directoryInfo in dirs)
            {
                SerchFile(directoryInfo, fileName, files);
            }
        }
    }
}
