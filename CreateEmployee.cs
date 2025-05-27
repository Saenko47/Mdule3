using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD3
{
    internal class CreateEmployee
    {
        static Random random = new Random();
        public static string[] names = new string[]
 {
    "Олександр",
    "Марія",
    "Іван",
    "Анастасія",
    "Дмитро",
    "Олена",
    "Андрій",
    "Наталія",
    "Сергій",
    "Ірина",
    "Максим",
    "Тетяна",
    "Юрій",
    "Катерина",
    "Богдан"
 };
        public static string[] surnames = new string[]
        {
    "Шевченко",
    "Ковальчук",
    "Мельник",
    "Бондаренко",
    "Кравченко",
    "Олійник",
    "Ткаченко",
    "Романенко",
    "Козак",
    "Лисенко",
    "Петренко",
    "Гриценко",
    "Іваненко",
    "Захарченко",
    "Савченко"
        };
        public static string[] hobbies = new string[]
{
    "Читання",
    "Подорожі",
    "Гра на гітарі",
    "Фотографія",
    "Програмування",
    "Малювання",
    "Кулінарія",
    "Йога",
    "Футбол",
    "Волонтерство",
    "Риболовля",
    "Шахи",
    "Біг",
    "Плавання",
    "Колекціонування марок",
    "Гра в настільні ігри",
    "Письмо",
    "Вишивання",
    "Велоспорт",
    "Танці"
};
        public static string[] addresses = new string[]
{
    "вул. Шевченка буд. 12 кв. 45 ",
    "вул. Франка буд. 8 кв. 102 ",
    "вул. Грушевського буд. 5 кв. 3 ",
    "вул. Сагайдачного буд. 20 кв. 88 ",
    "вул. Лесі Українки буд. 7 кв. 17 ",
    "вул. Тараса Шевченка буд. 33 кв. 120 ",
    "вул. Івана Франка буд. 16 кв. 66 ",
    "вул. Богдана Хмельницького буд. 9 кв. 5 ",
    "вул. Михайла Грушевського буд. 4 кв. 99 ",
    "вул. Симона Петлюри буд. 23 кв. 12 ",
    "вул. Василя Стуса буд. 10 кв. 45 ",
    "вул. Ольги Кобилянської буд. 6 кв. 81 ",
    "вул. Марії Заньковецької буд. 18 кв. 56 ",
    "вул. Пилипа Орлика буд. 3 кв. 7 ",
    "вул. Юрія Гагаріна буд. 2 кв. 19 ",
    "вул. Князя Володимира буд. 13 кв. 33 ",
    "вул. В'ячеслава Чорновола буд. 21 кв. 77 ",
    "вул. Андрея Шептицького буд. 15 кв. 38 ",
    "вул. Романа Шухевича буд. 11 кв. 108 ",
    "вул. Ліни Костенко буд. 14 кв. 64 "
};
        public static Employee[] CreateRandomEmployee(int i)
        {
            string fatheerName;
            string name;
            string surname;
            string adress;
            DateTime dateOfBirth;
            int workExperience;
            decimal desirebleSalary;
            string[] hobies;

            Employee[] employees = new Employee[i];
            for(int k = 0; k < i; ++k)
            {
name = names[random.Next(0,names.Length)];
                surname = surnames[random.Next(0,surnames.Length)];
                fatheerName = names[random.Next(0, names.Length)];
                adress = addresses[random.Next(0,addresses.Length)];
                int year = random.Next(1950, 2025);
                int month = random.Next(1, 13);
                int daysInMonth = DateTime.DaysInMonth(year, month);
                int day = random.Next(1, daysInMonth + 1);
                DateTime birthDate = new DateTime(year, month, day);
                for(int j = 0;j<5; ++j)
                {
                    hobbies[j] = hobbies[random.Next(0, hobbies.Length)];
                }
                workExperience = random.Next(0, 51);
                desirebleSalary = (decimal)(random.Next(1000, 10000) + random.NextDouble());
                employees[k] = new Employee(name, surname, fatheerName, birthDate, workExperience, desirebleSalary, adress, hobbies, new Father(fatheerName.Substring(0, fatheerName.Length), surname), new Mother(names[random.Next(0,names.Length)], surname));

            }
            return employees;
        }
    }
}
