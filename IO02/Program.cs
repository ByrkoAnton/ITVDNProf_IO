using System;
using System.IO;

namespace IO02
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new FileInfo(@"D:\text.txt");

            FileStream stream = file.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

            byte b = 110;
            byte c = 111;
            byte d = 112;
            stream.WriteByte(b);
            stream.WriteByte(c);
            stream.WriteByte(d);
            
            stream.Close();

            stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);

            for (int i = 0; i < file.Length; i++)
            {
                Console.WriteLine(stream.ReadByte());
            }

            stream.Position = 0;

            for (int i = 0; i < file.Length; i++)
            {
                Console.WriteLine(stream.ReadByte());
            }
            stream.Close();

            Console.ReadKey();

            file.Delete();
        }
    }
}
