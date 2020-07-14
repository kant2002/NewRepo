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
            List<Student> students = new List<Student>();
            students.Add(new Student { Name = "Ilya", GroupNumb = 1 });
            students.Add(new Student { Name = "Masha", GroupNumb = 2 });
            students.Add(new Student { Name = "Vanya", GroupNumb = 1 });
            students.Add(new Student { Name = "Marina", GroupNumb = 2 });
            students.Add(new Student { Name = "baibek", GroupNumb = 99 });
            students.Add(new Student { Name = "Lev", GroupNumb = 3 });

            foreach (Student s in students)
                Console.WriteLine($"Студент : {s.Name}, Группа: {s.GroupNumb}");
            /// Функция для возвращения значений всех GroupNumb
            IEnumerable<int> GetAllGroupNumbers()
            {
                var allGroupNumbers = from a in students
                                      select a.GroupNumb;
                return allGroupNumbers;
            }
            var getAllGroupNumbers = GetAllGroupNumbers();
            Console.WriteLine("Список имеющихся групп:");
            foreach (int i in getAllGroupNumbers.Distinct())
                Console.Write($" {i}");

            Console.WriteLine("\n Введите группу, по которой вы начнёте поиск: ");
            var addGroupNumb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите букву для определения поиска студента: ");
            var addFirstStringOfName = Console.ReadLine();
            foreach (int i in getAllGroupNumbers.Distinct())
            {

                if (addGroupNumb == i)
                {

                    foreach (Student s in students)
                    {

                        var firstStringItem = s.Name.FirstOrDefault().ToString();
                        if (firstStringItem == addFirstStringOfName)
                        {
                            Console.WriteLine($"Имя - {s.Name} Группа - {s.GroupNumb}");
                        }
                    }
                }
            }
        }

    }
}
