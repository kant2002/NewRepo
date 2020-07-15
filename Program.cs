using System;
using System.Collections.Generic;
using System.Linq;

namespace Нахождение_студентов_из_групп_по_номеру_группы_и_фамилии
{
    public class Student
    {
        public string Name;
        public int GroupNumb;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var studens = GetStudents();
            foreach (Student s in studens)
            {
                Console.WriteLine($"Студент : {s.Name}, Группа: {s.GroupNumb}");
            }
            Console.WriteLine("\n Введите группу, по которой вы начнёте поиск: ");
            var addGroupNumb = Convert.ToInt32(Console.ReadLine());
            var filtredGroupNumber = from f in studens
                                     where addGroupNumb == f.GroupNumb
                                     select f.GroupNumb;
            foreach (int i in filtredGroupNumber)
            {
                if (addGroupNumb == i)
                {
                    Console.WriteLine("Введите букву для определения поиска студента: ");
                    var addStringOfName = Console.ReadLine().Trim().ToUpper();
                    foreach (Student s in studens)
                    {
                        var startStringItem = s.Name.ToUpper().StartsWith(addStringOfName);
                        var endStringItem = s.Name.ToUpper().EndsWith(addStringOfName);
                        if (startStringItem == true)
                        {
                            Console.WriteLine($"Имя - {s.Name} Группа - {s.GroupNumb}");
                        }
                        else if(endStringItem == true)
                        {
                            Console.WriteLine($"Имя - {s.Name} Группа - {s.GroupNumb}");
                        }
                    }
                }
                else if (addGroupNumb != i)
                {
                    Console.WriteLine("Такой группы не существует");
                    break;
                }
            }
        }
        static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { Name = "Ilya", GroupNumb = 1 });
            students.Add(new Student { Name = "Masha", GroupNumb = 2 });
            students.Add(new Student { Name = "Vanya", GroupNumb = 1 });
            students.Add(new Student { Name = "Marina", GroupNumb = 2 });
            students.Add(new Student { Name = "baibek", GroupNumb = 99 });
            students.Add(new Student { Name = "Lev", GroupNumb = 3 });

            return students;
        }
    }
}
