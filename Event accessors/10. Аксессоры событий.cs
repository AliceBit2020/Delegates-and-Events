using System;
using System.Collections.Generic;
namespace Events
{
    delegate void MyDelegate();
    class SourceEvent
    {
        List<MyDelegate> list = new List<MyDelegate>();

        // ƒл€ управлени€ списком обработчиков событий служит 
        // расширенна€ форма оператора event, позвол€юща€ использовать аксессоры событий. 
        // Ёти аксессоры предоставл€ют средства дл€ управлени€ реализацией подобного списка. 
        // Ёлементы управлени€ WPF используют этот подход дл€ добавлени€ функциональности 
        // "пузырькового" и туннельного распространени€ событий.

        public event MyDelegate ev
        {
            // »спользуем аксессоры событий
            add
            {
                list.Add(value);
            }

            remove
            {
                list.Remove(value);
            }
        }
        public void GeneratorEvent()
        {
            Console.WriteLine("ѕроизошло событие!!!");
            if (list.Count != 0)
                foreach(MyDelegate i in list)
                {
                    i();
                   // i.Invoke();
                }
           ;
        }
    }

    class ObserverEventA
    {
        public void see()
        {
            Console.WriteLine("ObserverEventA. —обытие обработано! ");
        }
    }

    class ObserverEventB
    {
        public void see()
        {
            Console.WriteLine("ObserverEventB. —обытие обработано!");
        }
    }

    class MainClass
    {
        static void Main()
        {
            SourceEvent s = new SourceEvent(); // объект класса-источника событи€
            ObserverEventA obj1 = new ObserverEventA(); // объект класса наблюдател€
            ObserverEventA obj2 = new ObserverEventA(); // объект класса наблюдател€
            ObserverEventB obj3 = new ObserverEventB(); // объект класса наблюдател€
            ObserverEventB obj4 = new ObserverEventB(); // объект класса наблюдател€

            // добавление обработчиков к событию
            s.ev += new MyDelegate(obj1.see);
            s.ev += new MyDelegate(obj2.see);
            s.ev += new MyDelegate(obj3.see);
            s.ev += new MyDelegate(obj4.see);

            s.GeneratorEvent(); // инициирование событи€

            s.ev -= obj3.see;
            s.ev -= obj4.see;

            s.GeneratorEvent(); // инициирование событи€
        }
    }

}
