using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vektor.Helper;

namespace Vektor.Model
{
    public class WektorCls
    {
        private int pArrLenght;
        private double[] pDaneArr;

        [System.ComponentModel.DefaultValue("; ")]
        private string pSeparator { get; set; } = "; ";
        private byte pRounding { get; } = 2;

        public int ArrLenght { get => pArrLenght; set => pArrLenght = value; }
        public double[] DaneArr { get => pDaneArr; set => pDaneArr = value; }

        public WektorCls(double[] tempArr, [Optional] string howSeparate )
        {
            ArrLenght = tempArr.Length;
            DaneArr = new double[pArrLenght];
            DaneArr = tempArr;
            if (!string.IsNullOrEmpty(howSeparate)) pSeparator = howSeparate;
        }
        public WektorCls(int arrLen, double[] tempArr, [Optional] string howSeparate)
        {
            DaneArr = new double[arrLen];
            DaneArr = tempArr;
            if (!string.IsNullOrEmpty(howSeparate)) pSeparator = howSeparate;
        }
        public WektorCls(int arrLen, double min, double max)
        {
            Random rnd = new Random();
            ArrLenght = arrLen;

            double[] tempArr = new double[arrLen];

            double randomowyNumber;
            for (int i = 0; i < arrLen; i++)
            {
                do
                {
                    randomowyNumber =Math.Round(NextDouble(rnd,min,max), pRounding);
                } while (randomowyNumber<min && randomowyNumber>max);
                tempArr[i]= randomowyNumber;
            }
            //double[] test2 = Enumerable
            //    .Repeat(0, arrLen)
            //    .Select(i => rnd.Next(min, max))
            //    .ToArray();
            DaneArr = tempArr;
        }

        public string Show()=> string.Join(pSeparator, DaneArr);
 
        public double SumOfVecktor() => DaneArr.Sum();

        public double this[int index]
        {
            get => DaneArr[index];
            set => DaneArr[index] = value;
        }
        private double NextDouble(Random rand, double minValue, double maxValue)=> rand.NextDouble()* (maxValue - minValue) + minValue;
     
        public void WektorMerge(double[] newArr)
        {
            var newVec=  DaneArr.Concat(newArr).ToArray();
            DaneArr = newVec;
        }
        public double[] zbudujWektor()
        {
            double[] tempvek = new double[ArrLenght];
            for (int loopI  = 0; loopI < ArrLenght; loopI++)
            {
                tempvek[loopI] = GetFromUserDouble("Podaj jakomość liczbę rzeczywistą np 3.2");
            }
            return tempvek;
        }
        private double GetFromUserDouble(string inputMsg)
        {
            NumberFormatInfo provider = new NumberFormatInfo();/// Dla poprawnego ustpawienia formatu double
            provider.NumberDecimalSeparator = ".";

            Console.WriteLine(inputMsg);
            double tempdouble;
            do
            {
                if (double.TryParse(GeneralMethods.RemLetters(Console.ReadLine().Replace(",", ".")), NumberStyles.Float, provider, out tempdouble) != true)
                    Console.WriteLine(@"Nie poprawna wartość. Sprobój jeszcze raz");

            } while (tempdouble == 0);
            return tempdouble;
        }

    }

        
}
