using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Программа
    {
        static int хКоорд = 0;
        static int уКоорд = 0;
        static int[] звезды = new int[100];
        static void ПереместитьКурсорВниз()
        {
            Console.SetCursorPosition(хКоорд, ++уКоорд);
        }
        static void ПереместитьКурсорВверх()
        {
            Console.SetCursorPosition(хКоорд, --уКоорд);
        }
        static void ПереместитьКурсорВправо()
        {
            Console.SetCursorPosition(++хКоорд, уКоорд);
        }
        static void ПереместитьКурсорВлево()
        {
            Console.SetCursorPosition(--хКоорд, уКоорд);
        }
        static void ПереключитьЗвезду()
        {
            if (СоответствуетЛиЗвездаЛинии() && ОтображаетсяЛиЗвезда(хКоорд, уКоорд))
            {
                Console.Write("*");
                Console.SetCursorPosition(хКоорд, уКоорд);
                звезды[10 * хКоорд + уКоорд] = 1;
                return;
            }

            Console.Write(" ");
            Console.SetCursorPosition(хКоорд, уКоорд);
            звезды[10 * хКоорд + уКоорд] = 0;
        }
        static bool СоответствуетЛиЗвездаЛинии()
        {
            var star = 0;
            if (хКоорд <= 8 && уКоорд <= 8)
            {
                if (!ОтображаетсяЛиЗвезда(хКоорд + 1, уКоорд + 1))
                {
                    ++star;
                }
            }
            if (хКоорд > 0 && уКоорд <= 8)
            {
                if (!ОтображаетсяЛиЗвезда(хКоорд - 1, уКоорд + 1))
                {
                    ++star;
                }
            }
            if (хКоорд > 0 && уКоорд > 0)
            {
                if (!ОтображаетсяЛиЗвезда(хКоорд - 1, уКоорд - 1))
                {
                    ++star;
                }
            }
            if (хКоорд < 9 && уКоорд > 0)
            {
                if (!ОтображаетсяЛиЗвезда(хКоорд + 1, уКоорд - 1))
                {
                    ++star;
                }
            }
            if (star == 0)
            {
                return true;
            }
            return false;
        }
        static bool ОтображаетсяЛиЗвезда(int xCoord, int yCoord)
        {
            var currentStarCoord = звезды[10 * xCoord + yCoord];
            if (currentStarCoord == 0)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            for (int i = 0; i >= 0; i++)
            {
                var следуюющийСимв = Console.ReadKey(true);
                switch (следуюющийСимв.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (уКоорд > 0)
                        {
                            ПереместитьКурсорВверх();
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (хКоорд > 0)
                        {
                            ПереместитьКурсорВлево();
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (уКоорд <= 8)
                        {
                            ПереместитьКурсорВниз();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (хКоорд <= 8)
                        {
                            ПереместитьКурсорВправо();
                        }
                        break;

                    case ConsoleKey.Spacebar:
                        ПереключитьЗвезду();
                        break;
                }
            }
        }
    }
}
