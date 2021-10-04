using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Article();
            a.Add("Sajad Bagherzadeh Articles");
            a.Add("Solid Article");
            Console.WriteLine(a.ToString());

            var filename = "c:/temp/singleTest.txt";
            var p = new Persistence();
            p.SaveToFile(a,filename,true);

            Process.Start(filename);
        }
    }

    class Article
    {
        private readonly List<string> _list = new List<string>();
        private static int count = 0;

        public int Add(string text)
        {
            _list.Add($"{++count}: {text}");
            return count;
        }

        public void Remove(int index)
        {
            _list.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _list);
        }
    }

    class Persistence
    {
        public void SaveToFile(Article article, string filename, bool overwrite = false)
        {
            SaveToFile(article.ToString(),filename,overwrite);
        }
        public void SaveToFile(string content, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, content);
        }
    }

    class Email
    {
        public void SendEMail(string subject, string to, string body)
        {
            Console.WriteLine("Email Sent ...");
        }

    }
}
