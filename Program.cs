using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandlotXMLDecryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: SandlotXMLDecryptor (file) (password)");
                return;
            }
            string filename = args[0];
            string password = args[1];
            byte[] key = Encoding.ASCII.GetBytes(password);
            byte[] file = System.IO.File.ReadAllBytes(filename);
            for (int i = 0; i < file.Length; i++)
            {
                file[i] -= key[i % key.Length];
            }
            System.IO.File.WriteAllBytes(filename + "_decrypted.txt", file);
        }
    }
}
