using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

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
            for (int s = 0; s < studens.Count; s++)
            {
                Console.WriteLine($"Студент : {studens[s].Name}, Группа: {studens[s].GroupNumb}");
            }
            Console.WriteLine("\n Введите группу, по которой вы начнёте поиск: ");
            var addGroupNumb = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < studens.Count; i++)
            {
                var findSameNumb = addGroupNumb == studens[i].GroupNumb;
                var dontContainNumber = addGroupNumb != studens[i].GroupNumb;
                if (findSameNumb || !dontContainNumber)
                {
                    Console.WriteLine("Введите значение для поиска студента: ");
                    var addStringOfName = Console.ReadLine().Trim().ToUpper();
                    var filter = studens[i].Name.ToUpper().Contains(addStringOfName);
                    if(filter == true)
                    {
                        Console.WriteLine($"Имя - {studens[i].Name} Группа - {studens[i].GroupNumb}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Сочитаение символов не соответствует не одному студентом");
                        break;
                    }
                }
                if(!findSameNumb || dontContainNumber)
                {
                    Console.WriteLine("Такой группы нет");
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
