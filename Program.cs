using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sortndsearch
{
    internal class Program
    {
        public class Student
        {
            public string nm { get; set; }
            public int Class { get; set; }
        }
        static void Main(string[] args)
        {
            string str = "E:\\Dotnet\\Ph1-PracticeProject2\\Ph1-PracticeProject2\\students.txt";
            FileStream fs = new FileStream(str, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<Student> list = new List<Student>();
            while (!sr.EndOfStream)
            {
                string k = sr.ReadLine();
                char[] c = new char[]
                { ' ', '\t' };
                string[] man = k.Split(c, StringSplitOptions.None);
                Student s = new Student();
                s.nm = man[0];
                s.Class = Convert.ToInt32(man[1]);
                list.Add(s);
            }
            sr.Close();
            fs.Close();
            sr.Dispose();
            fs.Dispose();

            Console.WriteLine("***search and sorting in a text file***");
            Console.WriteLine("***The student details are:***");
            Console.WriteLine("Student\t Class");
            foreach (Student s in list)
            {
                Console.WriteLine($"{s.nm}\t{s.Class} ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Student Details After Sorted by Name");
            Console.WriteLine("Student\t Class");
            var v1 = list.OrderBy(q => q.nm).ToList();
            foreach (Student s in v1)
            {
                Console.WriteLine($"{s.nm}\t {s.Class}");
            }
            Console.WriteLine("**********************************************");
            Console.WriteLine("Searching through name");
            
            Console.WriteLine("Enter the name  to search from text file");
            string pr = Console.ReadLine();
            var v2 = list.Where(q => q.nm == pr).ToList();
            if (v2 != null)
            {
                foreach (Student s in v2)
                {
                        Console.Write($"the student {s.nm} is in Class {s.Class} \n");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
            Console.ReadKey();
        }
    }
    
}