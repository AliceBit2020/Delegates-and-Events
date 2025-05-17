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
                return string.Format("���: {0}; �������: {1}; ���� ��������: {2:d}.", FirstName, LastName, BirthDay);
            }

            public static string GetTypeName() { return "�������"; }
        }

        private delegate string GetAsString();///��'����� ��� ��������

        static void Main(string[] args)
        {
            DateTime birthDay = new DateTime(1978, 2, 15);

            birthDay.ToLongDateString();

            Person person = new Person("����", "������", birthDay);

            //DateTime obj= new DateTime();
            // obj.ToLongDateString();

            GetAsString getStringMethod = new GetAsString(birthDay.ToLongDateString);/////��������� ��'��� �������� � ���������� ������� �� �� �������� �������� �� ��������
            Console.WriteLine(getStringMethod.Invoke());

            getStringMethod = person.ToString;
            Console.WriteLine(getStringMethod());
            Console.WriteLine(getStringMethod.Invoke());


            getStringMethod = Person.GetTypeName;
            Console.WriteLine(getStringMethod());



        }
    }
}
