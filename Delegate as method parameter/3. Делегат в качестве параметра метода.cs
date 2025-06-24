using System;
namespace Delegate
{
    class Program
    {
        public delegate bool Comparer(object elem1, object elem2);/// Func( object, object, bool)

        static class BubbleSorter
        {
            static public void Sort(object[] array, Comparer comparer)
            {
                for (int i = 0; i < array.Length; i++)
                    for (int j = i + 1; j < array.Length; j++)
                        if (comparer(array[j], array[i]))
                        {
                            object buffer = array[i];
                            array[i] = array[j];
                            array[j] = buffer;
                        }
            }
        }

        public struct Person
        {
            public string FirstName;
            public string LastName;
            public DateTime Birthday;

            public Person(string firstName, string lastName, DateTime birthday)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Birthday = birthday;
            }

            public override string ToString()/////  System.Object
            {
                return string.Format(
                    "Имя: {0,-10} Фамилия: {1,-10} Дата рождения: {2:d}.",
                    FirstName, LastName, Birthday);
            }
        }

        static public bool PersonBirthdayComparer(object person1, object person2)
        {
            return ((Person)person1).Birthday < ((Person)person2).Birthday;
        }
        static public bool PersonNameComparer(object person1, object person2)
        {
            return (   (Person)person1).LastName.CompareTo(   ((Person)person2).LastName  )<0;
        }

        static void Main(string[] args)
        {
            Person p0 = new Person("Максим", "Орлов", new DateTime(1989, 5, 12));
            Person p1 = new Person("Иван", "Иванов", new DateTime(1985, 7, 21));
            Person p2 = new Person("Петр", "Петров", new DateTime(1991, 3, 1));
            Person p3 = new Person("Федор", "Федоров", new DateTime(1971, 11, 25));
            Person p4 = new Person("Павел", "Козлов", new DateTime(1966, 8, 6));

            object[] persons = { p0, p1, p2, p3, p4 };

            Console.WriteLine("\nНеупорядоченный список:");
            foreach (object person in persons) Console.WriteLine(person);

            Console.WriteLine("\nОтсортированный список за датою:");
            BubbleSorter.Sort(persons, PersonBirthdayComparer);
            foreach (object person in persons) 
                Console.WriteLine(person);

            Console.WriteLine("\nОтсортированный список за фамілією:");
            BubbleSorter.Sort(persons, PersonNameComparer);
            foreach (object person in persons)
                Console.WriteLine(person);

            Console.WriteLine("\n");
        }
    }
}
