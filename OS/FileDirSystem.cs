using System;
using System.IO;

// File Directory Output System
namespace FDOS{
    public class FileDirSystem
    {

        // Работа с каталогами.
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

        // Создает директорию по указанному пути.
        // Если директория с таким именем в указанной директории существует, то выдается ошибка.
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

        // Выводит всю информацию о каталоге.
        public void PrintDirInfo(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
 
            Console.WriteLine($"Название каталога: {dirInfo.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}\n");
        }

        // Удаление каталога.
        public void DeleteDir(string path)
        {
            try
            {
                Directory.Delete(path, true);
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Перемещение каталога.
        public void MoveDir(string src, string dst)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(src);
            if (dirInfo.Exists && Directory.Exists(dst) == false)
            {
                dirInfo.MoveTo(dst);
            }
        }

        // Работа с файлами.
        // Получение информации о файле.
        public void PrintFileInfo(string path)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}\n", fileInf.Length);
            }
        }

        // Удаление файла.
        public void DeleteFile(string path)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }

        // Перемещение файла.
        public void MoveFile(string src, string dst)
        {
            FileInfo fileInf = new FileInfo(src);
            if (fileInf.Exists && !File.Exists(dst))
            {
                fileInf.MoveTo(dst);
            }
        }

        // Копирование файла.
        // Параметр rewrite указывает, нужно ли перезаписать файл.
        public void CopyFile(string src, string dst, bool rewrite)
        {
            FileInfo fileInf = new FileInfo(src);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(dst, rewrite);
            }
        }
    }
}