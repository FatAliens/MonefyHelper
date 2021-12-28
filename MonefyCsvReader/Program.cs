using System;
using System.Linq;
using System.Collections.Generic;
using CsvHelper;
using System.Globalization;
using MonefyCsvReader.Models;

class Program
{
    static void Main()
    {
        string path;
        try
        {
            path = GetCsvFilePath();
        }
        catch (Exception ex)
        {
            WriteExceptionToConsole(ex);
            return;
        }

        var records = new List<MonefyRecord>();

        using (var sr = new StreamReader(path))
        {
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                
                records = csv.GetRecords<MonefyRecord>().ToList();
            }
        }

        foreach (var record in records)
        {
            Console.WriteLine(record.ToString());
            Console.WriteLine("--------");
        }

    }

    private static string GetCsvFilePath()
    {
        Console.WriteLine("Введите путь к файлу:");
        Console.WriteLine("[Enter для поиска на рабочем столе]");
        string path = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(path))
        {
            string desctopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] csvFiles = Directory.GetFiles(desctopPath, "*.csv");
            if (csvFiles.Length == 0)
            {
                throw new FileNotFoundException("Файл на рабочем столе не найден!");
            }
            else
            {
                path = csvFiles[0];
            }
        }

        return path;
    }

    private static void WriteExceptionToConsole(Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }
}