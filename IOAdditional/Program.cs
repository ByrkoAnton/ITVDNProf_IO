using System;
using System.IO;

namespace IOAdditional
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Directory.CreateDirectory($"d:\\test\\Folder\\{i}");
            }

            Console.ReadKey();

            for (int i = 0; i < 5; i++)
            {
                Directory.Delete($"d:\\test\\Folder\\{i}",true);
            }
        }
    }
}
