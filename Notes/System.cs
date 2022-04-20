using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public static class System
    {
        public static void addNote()
        {
            Console.Write("Введите название заметки: ");
            string title = Console.ReadLine();

            Console.Write("Введите категорию заметки: ");
            string category = Console.ReadLine();

            Console.Write("Введите текст заметки: ");
            string text = Console.ReadLine();

            Note temp = new Note(title.ToLower(), category.ToLower(), text);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Заметка успешно создана");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static void removeNote()
        {
            Console.Write("Введите название замекти: ");
            string name = Console.ReadLine();


            if (File.Exists($"Notes/{name}.txt"))
            {

                string allNotes = File.ReadAllText("Notes/!database.txt");
                string[] notes = allNotes.Split("\n");
                File.WriteAllText("Notes/!database.txt", "");


                for (int i = 0; i < notes.Length; i++)
                {
                    string[] infoNotes = notes[i].Split("|");
                    if (infoNotes[0] != name)
                    {
                        File.AppendAllText("Notes/!database.txt", $"{infoNotes[0]}|{infoNotes[1]}|{infoNotes[2]}");
                    }
                }
                File.Delete($"Notes/{name}.txt");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Данной заметки не существует");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
        public static void redactNote()
        {
            Console.Write("Введите название замекти: ");
            string name = Console.ReadLine().ToLower();

            int chose;
            string newText;
            if (File.Exists($"Notes/{name}.txt"))
            {
                do
                {
                    Console.WriteLine("Что вы хотите отредактировать?");
                    Console.WriteLine("1 - Название");
                    Console.WriteLine("2 - Категорию");
                    Console.WriteLine("3 - Текст");

                    Console.Write("Ваш выбор: ");
                    chose = int.Parse(Console.ReadLine());
                } while (chose < 1 || chose > 3);

                if (chose == 3)
                {
                    string text = File.ReadAllText($"Notes/{name}.txt");
                    Console.WriteLine("Введите новый текст: ");
                    newText = Console.ReadLine();
                    File.WriteAllText($"Notes/{name}.txt", newText);
                }
                else
                {
                   
                    Console.Write("Введите новое значение: ");
                    newText = Console.ReadLine().ToLower();

                    string allNotes = File.ReadAllText("Notes/!database.txt");
                    string[] notes = allNotes.Split("\n");

                    for (int i = 0; i < notes.Length; i++)
                    {
                        string[] infoNotes = notes[i].Split("|");
                        if (infoNotes[0] == name)
                        {
                            infoNotes[chose - 1] = newText;
                            if (chose == 1)
                            {
                                File.WriteAllText($"Notes/{newText}.txt", File.ReadAllText($"Notes/{name}.txt"));
                            }
                        }
                        notes[i] = String.Join("|", infoNotes);
                    }
                    allNotes = String.Join("\n", notes);

                    File.WriteAllText("Notes/!database.txt", allNotes);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Данной заметки не существует");
                Console.ForegroundColor = ConsoleColor.White;

            }

        }
        public static void findNote()
        {
            string allNotes = File.ReadAllText("Notes/!database.txt");
            string[] notes = allNotes.Split("\n");

            int chose;
            string forFind;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Название");
                Console.WriteLine("2 - Категория");
                Console.WriteLine("3 - Дата создания");
                Console.Write("Введите по какому критерию будете искать:");
                chose = int.Parse(Console.ReadLine());

                Console.Write("Введите искомое значение: ");
                forFind = Console.ReadLine().ToLower();
            } while (chose < 1 || chose > 3);

            for (int i = 0; i < notes.Length; i++)
            {
                string[] infoNotes = notes[i].Split("|");
                if (infoNotes[chose - 1] == forFind)
                {
                    string text = File.ReadAllText($"Notes/{infoNotes[0]}.txt");
                    Console.WriteLine(String.Format("{0} \nКатегория: {1}\t\tДата создания: {2}\n\n{3}", infoNotes[0], infoNotes[1], infoNotes[2], text));
                }
            }
        }
        public static void showAllNotes()
        {
            string allNotes = File.ReadAllText("Notes/!database.txt");
            Console.WriteLine(allNotes);
        }
    }
}
