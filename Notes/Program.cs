using System;

namespace Notes
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Action[] act = new Action[4] { System.addNote, System.removeNote, System.redactNote, System.findNote };
                int chose;
                do
                {
                    Console.WriteLine("Menu");
                    Console.WriteLine("1 - Добавить заметку");
                    Console.WriteLine("2 - Удалить заметку");
                    Console.WriteLine("3 - Редактировать заметку");
                    Console.WriteLine("4 - Найти заметку");
                    Console.WriteLine("0 - выход");

                    Console.Write("Ваш выбор: ");
                    chose = int.Parse(Console.ReadLine());
                    Console.Clear();
                } while (chose < 1 || chose > 4);
                if (chose == 0)
                {
                    break;
                }
                act[chose - 1]?.Invoke();
            } while (true);
        }
    }
}
