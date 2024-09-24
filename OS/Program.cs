using System;
using System.ComponentModel.Design;
using System.IO;

namespace OSApp
{
    class Program 
    {
        static void Main(string[] args)
        {
            Drives();
            while (true)
            {
                Console.WriteLine("Выберите режим работы [0-1]:\n0. Выход из программы.\nВывод Информации о дисках");
                string mode = Console.ReadLine();


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