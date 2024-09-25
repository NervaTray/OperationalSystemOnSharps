using System;
using System.ComponentModel.Design;
using System.IO;

using FDOS;

namespace OSApp
{
    class Program 
    {
        static void Main(string[] args)
        {
            FileDirSystem fileDir = new FileDirSystem();
            
            while (true)
            {
                Console.Write("0. Выход из программы.\n1. Вывод Информации о дисках\n\nВыберите режим работы [0-1]: ");
                string mode = Console.ReadLine();

                switch(mode)
                {
                    case "0":
                        Console.WriteLine("Конец программы!");
                        return;
                    case "1":
                        Drives();
                        break;
                    case "2":
                        fileDir.MakeDir("teest", "C://Users/Nerva/");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Такой опции не существует. Повторите попытку.\n");
                        Console.ResetColor();
                        break;
                }
            }
        }

        // Метод для вывода информации о дисках в системе.
        private static void Drives()
        {
            string[] driveTypes = ["Неизвестно", "Не имеет корневой директории", "Съемный", "Несъемный", "Сетевой", "Компакт-диск", "ОЗУ"];
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.WriteLine(drives);

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Название: {0}", drive.Name);
                Console.WriteLine("Тип: {0}", driveTypes[(int)drive.DriveType]);
                if (drive.IsReady)
                {
                    Console.WriteLine("Тип файловой системы: {0}", drive.DriveFormat);
                    Console.WriteLine("Объем диска: {0} ГБ", ToGB(drive.TotalSize));
                    Console.WriteLine("Занятое пространство: {0} ГБ", ToGB(drive.TotalSize - drive.TotalFreeSpace));
                    Console.WriteLine("Свободное пространство: {0} ГБ", ToGB(drive.TotalFreeSpace));
                    Console.WriteLine("Метка: {0}", drive.VolumeLabel);
                }
                Console.WriteLine();
            }
        }

        // Преобразует байты в гигабайты.
        private static long ToGB(long bytes)
        {
            bytes /= 1024*1024*1024;
            return bytes;
        }
    }
}