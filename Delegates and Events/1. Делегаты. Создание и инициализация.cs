using System;
namespace Delegate
{
    class Program
    {
        private struct Person
        {
            public string FirstName;
            public string LastName;
            public DateTime BirthDay;

            public Person(string firstName, string lastName, DateTime birthDay)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.BirthDay = birthDay;
            }

            public override string ToString()
            {
                return string.Format("Имя: {0}; Фамилия: {1}; Дата рождения: {2:d}.", FirstName, LastName, BirthDay);
            }

            public static string GetTypeName() { return "Человек"; }
        }

        private delegate string GetAsString();///об'явили тип делегату

        static void Main(string[] args)
        {
            DateTime birthDay = new DateTime(1978, 2, 15);

            birthDay.ToLongDateString();

            Person person = new Person("Иван", "Петров", birthDay);

            //DateTime obj= new DateTime();
            // obj.ToLongDateString();

            GetAsString getStringMethod = new GetAsString(birthDay.ToLongDateString);/////створюємо об'єкт делегату і ініціалізуємо методом що має сігнатуру відповідну до делегату
            Console.WriteLine(getStringMethod.Invoke());

            getStringMethod = person.ToString;
            Console.WriteLine(getStringMethod());
            Console.WriteLine(getStringMethod.Invoke());


            getStringMethod = Person.GetTypeName;
            Console.WriteLine(getStringMethod());



        }
    }
}
