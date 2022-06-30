using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.Write("1 - Работа с листом\n" +
                            "2 - Телефонная книга\n" +
                            "3 - Проверка повторов\n" +
                            "4 - Записная книжка\n" +
                            "0 - Выйти из программы\n" +
                            "Введите свой выббор: ");

                int menuNavigation;
                if(int.TryParse(Console.ReadLine(), out menuNavigation) && menuNavigation >=0 && menuNavigation <= 4)
                {
                    switch (menuNavigation)
                    {
                        case 0:
                            exit = true;
                            break;
                        case 1:
                            Part1();
                            break;
                        case 2:
                            Part2();
                            break;
                        case 3:
                            Part3();
                            break;
                        case 4:
                            Part4();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Нажмите Enter для повторного ввода");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Работа с листом
        /// </summary>
        static void Part1()
        {
            Console.Clear();
            Console.WriteLine("Заполняем лист числами, ожидайте...");

            List<int> myList;
            FillList(out myList);

            Console.WriteLine("Лист заполнен. Нажмите любую клавишу для вывода его на экран");
            Console.ReadKey();

            PrintList(myList);

            Console.WriteLine("\nДля удаления чисел больше 25 и меньше 50 и вывода отредактированного листа нажмите любую клавишу");
            Console.ReadKey();

            myList = DeleteNumbers(myList);
            PrintList(myList);

            Console.WriteLine("\nНажмите любую клавишу для выхода в меню");
            Console.ReadKey();
        }

        /// <summary>
        /// Телефонная книга
        /// </summary>
        static void Part2()
        {
            Console.Clear();
            Console.WriteLine("Для начала заполнения нажмите любую кнопку");
            Dictionary<int, string> myDictionary;
            FillDictionary(out myDictionary);
            FindUser(myDictionary);
            Console.Write("Для возврата в меню нажмите любую кнопку");
            Console.ReadKey();
        }

        /// <summary>
        /// Проверка повторов
        /// </summary>
        static void Part3()
        {
            Console.Clear();
            HashSet<int> myHashSet = new HashSet<int>();
            bool exit = false;
            while (!exit)
            {
                Console.Write("Для завершения редактирования нажмите Enter не вводя число.\nВведите число: ");
                string temp = Console.ReadLine();
                if(temp == "")
                {
                    exit = true;
                }
                else
                {
                    try
                    {
                        if (!myHashSet.Add(int.Parse(temp)))
                        {
                            Console.WriteLine("Число уже есть в коллекции!!!");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Неверный ввод!!!");
                    }
                }
            }
        }

        /// <summary>
        /// Записная книжка
        /// </summary>
        static void Part4()
        {
            string Name, Street, HouseNumber, FlatNumber, MobilePhone, FlatPhone;
            Console.Write("Введите имя:");
            Name = Console.ReadLine();
            Console.Write("Введите название улицы:");
            Street = Console.ReadLine();
            Console.Write("Введите номер дома:");
            HouseNumber = Console.ReadLine();
            Console.Write("Введите номер квартиры:");
            FlatNumber = Console.ReadLine();
            Console.Write("Введите номер домашнего телефона:");
            MobilePhone = Console.ReadLine();
            Console.Write("Введите номер мобильного телефона:");
            FlatPhone = Console.ReadLine();

            Serialize(Name, Street, HouseNumber, FlatNumber, MobilePhone, FlatPhone);
        }

        #region Методы для 1 задания

        /// <summary>
        /// Заполнение листа случайными числами
        /// </summary>
        static void FillList(out List<int> newList)
        {
            newList = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 101; i++)
            {
                newList.Add(rnd.Next(0, 100));
            }

        }

        /// <summary>
        /// Вывод листа на экран
        /// </summary>
        static void PrintList(List<int> newList)
        {
            foreach (int i in newList)
                Console.Write(i + ", ");
        }

        /// <summary>
        /// Удаление чисел меньше 25 и больше 50
        /// </summary>
        /// <param name="newList"></param>
        /// <returns>Отредактированый лист</returns>
        static List<int> DeleteNumbers(List<int> newList)
        {
            for (int i = 0; i < newList.Count; i++)
            {
                if (newList[i] < 50 && newList[i] > 25)
                {
                    newList.RemoveAt(i);
                    i--;
                }
            }
            return newList;
        }


        #endregion

        #region Методы для 2 задания
        /// <summary>
        /// Заполнение коллекции
        /// </summary>
        /// <param name="newDictionary"></param>
        static void FillDictionary(out Dictionary<int, string> newDictionary)
        {
            newDictionary = new Dictionary<int, string>();
            while (true)
            {
                string temp, value;
                int key;
                Console.WriteLine("Для завершения заполнения оставьте строку пустой и нажмите Enter\n\n");
                Console.Write("Введите ФИО пользователя: ");
                temp = Console.ReadLine();
                if (temp == "")
                    break;
                else
                    value = temp;

                Console.Write("Введите номер пользователя: ");
                temp = Console.ReadLine();
                if (temp == "")
                    break;

                if (!int.TryParse(temp, out key))
                {
                    Console.WriteLine("Неверный ввод! Повторите попытку!");
                    continue;
                }

                try
                {
                    newDictionary.Add(key, value);
                }
                catch
                {
                    Console.WriteLine("Неверный ввод! Возможно такой номер уже есть в списке. Для повтора ввода нажмите Enter");
                    Console.ReadLine();
                }

                temp = "";

            }
        }

        /// <summary>
        /// Поиск имени пользователя по номеру
        /// </summary>
        /// <param name="newDictionary"></param>
        static void FindUser(Dictionary<int, string> newDictionary)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите номер пользователя. Для выхода нажмите Enter не вводя значение");
                string temp = Console.ReadLine();
                string result;
                int tempNumber;

                if (temp == "")
                    break;

                if (!int.TryParse(temp, out tempNumber))
                {
                    Console.WriteLine("Повторите ввод! Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if(newDictionary.TryGetValue(tempNumber, out result))
                {
                    Console.WriteLine($"Владельцем номера {tempNumber} является {result}. Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Потльзователь с таким номером не обнаружен. Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                }

            }
        }

        #endregion

        #region Методы для 3 задания (пусто)

        #endregion

        #region Методы для 4 задания
        static void Serialize(string Name, string Street, string HouseNumber, string FlatNumber, string MobilePhone, string FlatPhone)
        {
            XElement Person = new XElement("Person");
            XElement Adress = new XElement("Adress");
            XElement Phones = new XElement("Phones");

            Person.Add(new XAttribute("Name", Name));
            Adress.Add(new XAttribute("Street", Street));
            Adress.Add(new XAttribute("HouseNumber", HouseNumber));
            Adress.Add(new XAttribute("FlatNumber", FlatNumber));
            Phones.Add(new XAttribute("MobilePhone", MobilePhone));
            Phones.Add(new XAttribute("FlatPhone", FlatPhone));
            Person.Add(Adress);
            Person.Add(Phones);
            Person.Save("test.xml");
        }
        #endregion
    }
}