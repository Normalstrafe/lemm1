using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
public class LocalTime
{
    public string Time;
    public static string localTime() {
        DateTime localDate = DateTime.Now;
        DateTime utcDate = DateTime.UtcNow;
        var culture = new CultureInfo("ua-UA");
        Console.WriteLine(utcDate.ToString(culture), utcDate.Kind);
        string Time = Convert.ToString(localDate);
        Console.WriteLine(Time);
        return Time;
    }
    public void setTime()
    {
       
    }
    public void showTime()
    {
        Console.WriteLine(Time);
    }

}
public class TaskManager
{
    public List<string> notes = new List<string>() { };
    public  void AddNote()
    {
        string note = Console.ReadLine();
        notes.Add(note);
    }
    public void showNotes()
    {
        int count = 0;
        foreach (string element in notes)
        {
            count++;
            Console.WriteLine($"Note #{count}: {element}");
            Console.WriteLine("/n");
        }
    }
    public void  deleteNotes()
    {
        string choose = Console.ReadLine();
        int chooseNumber = Convert.ToInt32(choose);
        
        notes.RemoveAt(chooseNumber);
    }
    public void editNote()
    {
        int chooseEdit = Convert.ToInt32(Console.ReadLine());
        notes[chooseEdit] = Console.ReadLine();
    }
    public void saveNotes()
    {
            // создаем каталог для файла
            string path = @"C:\SomeDir2";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();

            // запись в файл
            using (FileStream fstream = new FileStream($"{path}\note.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }

            // чтение из файла
            using (FileStream fstream = File.OpenRead($"{path}\note.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
        }
}
public class Program
{
    public void Main()
    {
        TaskManager tasks;
        tasks.AddNote();

    }
}






