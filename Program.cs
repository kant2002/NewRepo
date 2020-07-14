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
            var allGroupNumbers = from a in studens
                                  select a.GroupNumb;
            Console.WriteLine("\n Введите группу, по которой вы начнёте поиск: ");
            var addGroupNumb = Convert.ToInt32(Console.ReadLine());
            foreach (int i in allGroupNumbers.Distinct())
            {
                if (addGroupNumb == i)
                {
                    Console.WriteLine("Введите букву для определения поиска студента: ");
                    var addFirstStringOfName = Console.ReadLine();

                    foreach (Student s in studens)
                    {

                        var firstStringItem = s.Name.FirstOrDefault().ToString();
                        if (firstStringItem == addFirstStringOfName)
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
