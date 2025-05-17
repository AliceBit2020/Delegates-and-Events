using System;
using System.Timers;

class Test
{
    static int count = 0;
    static void Main()
    {
        Timer t = new Timer();
        t.Interval = 1000;
        // public event ElapsedEventHandler Elapsed - это событие происходит по истечении интервала времени
        t.Elapsed += new ElapsedEventHandler(OnTimer);
        t.Start(); // Ќачинает вызывать событие Elapsed
        Console.Read();
    }

    private static void OnTimer(object sender, ElapsedEventArgs arg /* ѕредоставл€ет данные дл€ событи€ Elapsed */)
    {
        Timer t = (Timer)sender;
        count++;
        if (count == 10)
            t.Stop();

        Console.Title = String.Format("{0}", arg.SignalTime);
    }
}

