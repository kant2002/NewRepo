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
            students.Add(new Student { Name = "Lilya", GroupNumb = 3 });
            students.Add(new Student { Name = "Lev", GroupNumb = 3 });
            var selectedList = from g in students
                               select g;
            foreach (Student s in selectedList)
                Console.WriteLine($"Студент : {s.Name}, Группа: {s.GroupNumb}");
            var selectedGroupNumb = from n in students
                                    select n.GroupNumb;
            Console.WriteLine($"Введите интересующую группу из существующих {selectedGroupNumb.Max()}");
            var addGroupNumb = Convert.ToInt32(Console.ReadLine());

            IEnumerable<string> GetNameFilter(string studentName1, string studentName2)
            {
                var filteredNameList = from l in students
                                       where l.Name == studentName1 | l.Name == studentName2
                                       select l.Name;
                return filteredNameList;
            }

            IEnumerable<int> GetNumbersFilter(int groupNumber)
            {
                var selectedGroupNumb = from n in students
                                         where n.GroupNumb == groupNumber
                                         select n.GroupNumb;
                return selectedGroupNumb;
            }

            if (addGroupNumb == 1)
            {
                Console.WriteLine($"Введите интересующую букву, с которой начинается имя ученика: ");
                var addButtonName = Console.ReadLine();
                if (addButtonName == "I")
                {
                    var getNameFilter = GetNameFilter("Ilya", null);
                    foreach (string l in getNameFilter)
                        Console.WriteLine($"Имя студента: {l}");
                    var getNumbFilter = GetNumbersFilter(1);
                    foreach (int s in getNumbFilter.Distinct())
                        Console.WriteLine($"Группа студента: {s}");
                }
                else if (addButtonName == "V")
                {
                    var getNameFilter = GetNameFilter("Vanya", null);
                    foreach (string l in getNameFilter)
                        Console.WriteLine($"Имя студента: {l}");
                    var getNumbFilter = GetNumbersFilter(1);
                    foreach (int s in getNumbFilter.Distinct())
                        Console.WriteLine($"Группа студента: {s}");
                }
            }
            else if (addGroupNumb == 2)
            {
                Console.WriteLine($"Введите интересующую букву, с которой начинается имя ученика: ");
                var addButtonName = Console.ReadLine();
                if (addButtonName == "M")
                {
                    var getNameFilter = GetNameFilter("Masha", "Marina");
                    foreach (string l in getNameFilter)
                        Console.WriteLine($"Студент: {l}");
                    var getNumbFilter = GetNumbersFilter(2);
                    foreach (int s in getNumbFilter.Distinct())
                        Console.WriteLine($"Группа студента: {s}");
                }
            }
            else if (addGroupNumb == 3)
            {
                Console.WriteLine($"Введите интересующую букву, с которой начинается имя ученика: ");
                var addButtonName = Console.ReadLine();
                if (addButtonName == "L")
                {
                    var getNameFilter = GetNameFilter("Lev", "Lilya");
                    foreach (string l in getNameFilter)
                        Console.WriteLine($"Студент: {l}");
                    var getNumbFilter = GetNumbersFilter(3);
                    foreach (int s in getNumbFilter.Distinct())
                        Console.WriteLine($"Группа студента: {s}");
                }
            }
        }
    }
}