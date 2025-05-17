using System;
using System.Threading;
namespace Delegate
{
    delegate void MyDelegate(int a, int b, int c);
    class Class1
    {
        public static void Max(int a, int b, int c)
        {
            Console.WriteLine("Максимум из трёх чисел:" + Math.Max(Math.Max(a, b), c));


        }
        public static void Min(int a, int b, int c)
        {
            Console.WriteLine("Минимум из трёх чисел:" + Math.Min(Math.Min(a, b), c));
            Thread.Sleep(2000);

        }
        public static void Sum(int a, int b, int c)
        {
            Console.WriteLine("Сумма трёх чисел:" + (a + b + c));
        }
        public static void Mult(int a, int b, int c)
        {
            Console.WriteLine("Произведение трёх чисел:" + a * b * c);
        }
        static void Main(string[] args)
        {
            MyDelegate dg = new MyDelegate(Max);
            dg += Min;
            dg += Sum;
            dg += Mult;
            Console.WriteLine("Введите три числа: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());


            dg(a, b, c);//// виклик методів



            foreach (MyDelegate item in dg.GetInvocationList())
            {
                Console.WriteLine("{0}", item.Method.Name);

                   

            }
            dg -= Max;
            dg -= Min;
            Console.WriteLine();
            dg(a, b, c);
            foreach (MyDelegate item in dg.GetInvocationList())
            {
                Console.WriteLine("{0}", item.Method.Name);
            }
            dg = Min;
            Console.WriteLine();
            dg(a, b, c);
            foreach (MyDelegate item in dg.GetInvocationList())
            {
                Console.WriteLine("{0}", item.Method.Name);
            }
        }
    }
}


//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using static Calculator;



//class Calculator
//{
//    public delegate Task<int> MathOperationAsync(int a, int b);

//    public static MathOperationAsync dg;
//    public static async Task<int> AddAsync(int x, int y)
//    {
//        Console.WriteLine("Add");
//        Thread.Sleep(1000); // Симуляція затримки обчислення
//        return x + y;
//    }

//    public static async Task<int> MultiplyAsync(int x, int y)
//    {
//        // await Task.Delay(100);
//        Console.WriteLine("Mult");
//        return x * y;
//    }

//    public static async Task<int> ComputeAsync(int a, int b, MathOperationAsync op)
//    {
//       // Thread.Sleep(1000);
//        return await op(a, b);
//    }
//}

//class Program
//{
//    static async Task Main()
//    {
//        Calculator.dg += Calculator.AddAsync;
//        Calculator.dg += Calculator.MultiplyAsync;

//        foreach(MathOperationAsync item in Calculator.dg.GetInvocationList())
//        {

//           Console.WriteLine(await item.EndInvoke(item.BeginInvoke(5,3,null,null)));
        
        
//        }


//        //int sum = await Calculator.ComputeAsync(5, 3, Calculator.AddAsync);
//        //Console.WriteLine($"Сума: {sum}");

//        //int product = await Calculator.ComputeAsync(5, 3, Calculator.MultiplyAsync);
//        //Console.WriteLine($"Добуток: {product}");
//    }
//}
