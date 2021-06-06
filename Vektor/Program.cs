using Vektor.Model;
using System;
using static System.Console;

namespace Vektor
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Program Wektor");
            var newVektor = new WektorCls(10, 1, 100);
            WriteLine(newVektor.Show());
            WriteLine("Suma "+ newVektor.SumOfVecktor());
            double[] addingNew = new double[4] {1.3,6,2.3,99.9 };
            newVektor.WektorMerge(addingNew);
            WriteLine(newVektor.Show());
            WriteLine("Suma "+newVektor.SumOfVecktor());

            var newVektor2 = new WektorCls(addingNew, "Separator ");
            WriteLine(newVektor2.Show());


            var newVektor3 = new WektorCls(addingNew);
            WriteLine(newVektor3.Show());

        }
    }
}
