using System;
using System.IO;

// File Directory Output System
namespace FDOS{
    public class FileDirSystem
    {
        // Выводит файлы и подкаталоги из текущего каталога.
        public void PrintFilesDirs(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(path);
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(path);
                foreach (string s in files)
                {
                    Console.Write(s);
                }
                Console.WriteLine();
            }
        }

        public void MakeDir(string dirName, string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path + dirName);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Такой каталог уже существует.\n");
                Console.ResetColor();
            }
            dirInfo.CreateSubdirectory(dirName);
        }
    }
}