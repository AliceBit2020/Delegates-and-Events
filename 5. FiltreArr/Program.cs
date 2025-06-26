namespace _5._FiltreArr
{
    internal class Program
    {
        //1. Метод, логіка відбору для масиву  чисел які кратні 3.

        //2.  Метод, логіка відбору для масиву від'ємних чисел  


        static int[] FiltrFunc(int[] x,Predicate<int> dg)
        {
            int[] y = [];

            foreach (int elem in x)
            {
                if (dg.Invoke(elem))
                {
                  y=y.Append(elem).ToArray();
                }
            }
            return y;



        }


        static void Main(string[] args)
        {
            
            int a
           

        }
    }
}
