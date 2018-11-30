using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteBook
{
    class Program
    {
        public static int id;
        public static Dictionary<int, Human> dict = new Dictionary<int, Human>();
        static void Main(string[] args)
        {
            id = 1;
            while (true)
            {
                Console.Clear();
                Show_Menu();
                string answer = Console.ReadLine();
                if (answer == "2") // ДОБАВЛЕНИЕ ЗАПИСИ
                {
                    Add_Human(id);
                }
                else if (answer == "1") // ПРОСМОТР И ПОИСК ЗАПИСЕЙ
                {
                    Find_note();
                }
                else if (answer == "4") // УДАЛЕНИЕ ЗАПИСЕЙ
                {
                    Delete_note();
                }
                else if (answer == "5") // ВЫХОД
                {
                    Environment.Exit(0);
                }
                else if (answer == "3") //РЕДАКТИРОВАНИЕ ЗАПИСИ
                {
                    Edit_note();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка. Введите доступный пункт МЕНЮ:");
                }
            }
        }
        static void Show_Menu()
        {
            Console.WriteLine("1. Просмотр записей");
            Console.WriteLine("2. Добавление записи");
            Console.WriteLine("3. Редактирование записи");
            Console.WriteLine("4. Удаление записи");
            Console.WriteLine("5. ВЫХОД");
        }
        static void Add_Human(int id)
        {
            Console.Clear();
            Set_Information(id);
            Program.id++;
        }
        static void Find_note()
        {
            Console.Clear();
            Console.WriteLine("1. Просмотр всех записей");
            Console.WriteLine("2. Поиск по ID");
            string answer1 = Console.ReadLine();

            if (answer1 == "1") // ВСЕ ЗАПИСИ
            {
                Console.Clear();
                foreach (KeyValuePair<int, Human> box in dict)
                {
                    Console.WriteLine(box.Key + " - " + box.Value.Name + " " + box.Value.Surname + " " + box.Value.Phone_number);
                }
                Console.ReadKey();
            }
            else if (answer1 == "2") // ПОИСК ПО ID
            {
                Console.Clear();
                Console.WriteLine("Введите ID:");
                int ask = int.Parse(Console.ReadLine());
                foreach (KeyValuePair<int, Human> box in dict)
                {
                    Console.Clear();
                    if (dict.TryGetValue(ask, out Human value))
                    {
                        Console.WriteLine(value.Surname + " " + value.Name + " " + value.Name + " " + value.Thirdname + " " + value.Phone_number + " " + value.citizenship + " " + value.Birth_date.ToShortDateString() +  " " + value.Org + " " + value.Position + " " + value.Notes);
                    }
                    else
                        Console.WriteLine("Ничего не найдено");
                }
                Console.ReadKey();
            }
        }
        static void Delete_note()
        {
            Console.Clear();
            Console.WriteLine("Для удаления введите ID:");
            int ask = int.Parse(Console.ReadLine());
            if (dict.TryGetValue(ask, out Human value))
            {
                dict.Remove(ask);
            }
        }
        static void Edit_note()
        {
            Console.Clear();
            Console.WriteLine("Для редактирования введите ID:");
            int ask = int.Parse(Console.ReadLine());
            if (dict.TryGetValue(ask, out Human value))
            {
                Console.Clear();
                dict.Remove(ask);
                Set_Information(ask);
            }
        }
        static void Set_Information(int id)
        {
            Human person1 = new Human();
            Console.WriteLine("Введите имя:");
            person1.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            person1.Surname = Console.ReadLine();
            Console.WriteLine("Введите номер телефона:");
            while (true)
            {
                string s = Console.ReadLine();
                if (Int32.TryParse(s, out int result))
                {
                    if (s.Length >= 5)
                    {
                        person1.Phone_number = s;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Введено недостаточное количество символов! Введите еще раз:");
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Выберите страну:");
            Console.WriteLine("1.Россия\n2.Украина\n3.Беларусь\n4.Казахстан");
            switch (Console.ReadLine())
            {
                case "1":
                    person1.citizenship = Human.Country.Russia;
                    break;
                case "2":
                    person1.citizenship = Human.Country.Ukraine;
                    break;
                case "3":
                    person1.citizenship = Human.Country.Belarus;
                    break;
                case "4":
                    person1.citizenship = Human.Country.Kazakhstan;
                    break;
                default:
                    person1.citizenship = Human.Country.Other_Country;
                    break;
            }
            Console.Clear();
            Console.WriteLine("Добавить дополнительную информацию? (Y/N)");
            string key = Console.ReadLine();
            if (key.ToLower().Equals("y"))
            {
                Console.Clear();
                Console.WriteLine("Введите отчество:");
                person1.Thirdname = Console.ReadLine();
                Console.WriteLine("Введите дату рождения (дд/мм/гггг):");
                person1.Birth_date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Введите организацию:");
                person1.Org = Console.ReadLine();
                Console.WriteLine("Введите должность:");
                person1.Position = Console.ReadLine();
                Console.WriteLine("Введите дополнительную информацию:");
                person1.Notes = Console.ReadLine();
            }
            else if (key.ToLower().Equals("n"))
            {

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Некорректный ответ. При необходимости отредактируйте запись!");
                Console.ReadKey();
            }
            dict.Add(id, person1);
        }
    } 
}

