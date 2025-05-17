using System;
namespace Events
{
    delegate void MyDelegate();
    class SourceEvent
    {
        public event MyDelegate ev;
        public void GeneratorEvent()
        {
            Console.WriteLine("Произошло событие!");
            ev?.Invoke();
        }
    }

    class ObserverEventA
    {
        public void see()///  соответствует сигнатуре делегата  delegate void MyDelegate();
        {
            Console.WriteLine("ObserverEventA. Событие обработано!");
        }
    }

    class ObserverEventB
    {
        public void see()///  соответствует сигнатуре делегата  delegate void MyDelegate();
        {
            Console.WriteLine("ObserverEventB. Событие обработано!");
        }
    }

    class MainClass
    {
        static void Main()
        {
            SourceEvent s = new SourceEvent(); // объект класса-источника события

            ObserverEventA obj1 = new ObserverEventA(); // объект класса наблюдателя
            ObserverEventA obj2 = new ObserverEventA(); // объект класса наблюдателя
            ObserverEventB obj3 = new ObserverEventB(); // объект класса наблюдателя
            ObserverEventB obj4 = new ObserverEventB(); // объект класса наблюдателя

            // добавление обработчиков к событию
            s.ev += new MyDelegate(obj1.see);
            s.ev += new MyDelegate(obj2.see);
            s.ev += new MyDelegate(obj3.see);
            s.ev += new MyDelegate(obj4.see);
            ////Подписка на событие ev += Метод 
            /// Сгенерировать событие (собитие произошло)  ev?.Invoke() Все методы которые подписались будут вызванны


            s.GeneratorEvent(); // инициирование события

           // s.GeneratorEvent();



            //// Отписка
            s.ev -= obj3.see;
            s.ev -= obj4.see;

            s.GeneratorEvent(); // инициирование события  ev.Invoke()
        }
    }

}
