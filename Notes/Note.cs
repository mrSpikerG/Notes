using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    class Note
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Text { get; private set; }
        public DateTime TimeOfCreation { get; set; }


        public Note(string title, string category):this(title,category," ")
        {
        }
        public Note(string title, string category,string text)
        {
            Title = title;
            Category = category;
            TimeOfCreation = DateTime.Now;
            Text = text;

            if (!Directory.Exists("Notes"))
            {
                Directory.CreateDirectory("Notes");
            }

            //для удобного поиска
            File.AppendAllText("Notes/!database.txt", String.Format("{0}|{1}|{2}", title, category, TimeOfCreation.ToShortDateString()));
            File.AppendAllText($"Notes/{Title}.txt", String.Format("{0}", Text));

        }

        //for verify
        public Note(string title, string category, string text, DateTime timeOfCreation)
        {
            Title = title;
            Category = category;
            TimeOfCreation = timeOfCreation;
            Text = text;
        }


        public string getText() => File.ReadAllText($"Notes/{Title}.txt");
        public void addText(string text) => Text += text;
        public void setText(string text) => Text = text;

        public override string ToString()
        {
            return String.Format("{0} \nКатегория: {1}\t\tДата создания: {2}\n\n{3}",Title,Category,TimeOfCreation.ToShortDateString(),Text);
        }
    }
}
