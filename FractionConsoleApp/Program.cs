using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FractionLibrary;

namespace FractionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            int index;
            List<Fraction> fractions = new List<Fraction>();
            fractions.Add(new Fraction("asd---12,0/34,asd"));
            fractions.Add(new Fraction("3/5"));
            fractions.Add(new Fraction("3.4/5.6"));
            fractions.Add(new Fraction(13));
            fractions.Add(new Fraction("4,1/8.21"));
            fractions.Add(new Fraction(-7, -13));
            fractions.Add(new Fraction(16.37, 7));
            fractions.Add(new Fraction(-36, 4));
            fractions.Add(new Fraction("a/b"));

            fractions[0].SetNumerator(37);
            Console.WriteLine($"fractions[0]: Numerator = {fractions[0].GetNumerator()} Denominator = {fractions[0].GetDenominator()}   -->   {fractions[0]}\n");

            fractions[1].SetDenominator(12);
            Console.WriteLine($"fractions[1]: Numerator = {fractions[1].GetNumerator()} Denominator = {fractions[1].GetDenominator()}   -->   {fractions[1]}\n");

            fractions[2].SetNumerator("52/16");
            fractions[2].SetDenominator("52/16");
            Console.WriteLine($"fractions[2]: Numerator = {fractions[2].GetNumerator()} Denominator = {fractions[2].GetDenominator()}   -->   {fractions[2]}\n");

            Console.WriteLine("\t### До скорочення дробів ###");
            index = 0;
            foreach (Fraction fraction in fractions)
            {
                Console.WriteLine($"fractions[{index}] = {fraction}");
                index++;
            }

            foreach (Fraction fraction in fractions)
                fraction.FractionReduction(fraction.GetNumerator(), fraction.GetDenominator());

            Console.WriteLine("\n\t### Після скорочення дробів ###");
            index = 0;
            foreach (Fraction fraction in fractions)
            {
                Console.WriteLine($"fractions[{index}] = {fraction}");
                index++;
            }

            Console.WriteLine("\n\tУнарні: +, – (для типу Fraction):");
            fractions.Add(new Fraction());
            fractions[9] = -fractions[7];
            Console.WriteLine($"fractions[9] = -({fractions[7]}) = {fractions[9]}");

            fractions.Add(new Fraction());
            fractions[10] = +fractions[7];
            Console.WriteLine($"fractions[10] = +({fractions[7]}) = {fractions[10]}");

            fractions[10] = new Fraction(15, 30);
            Console.WriteLine($"fractions[10] = +({fractions[10]}) = {+fractions[10]}");

            fractions[10] = new Fraction("0/3");
            Console.WriteLine($"fractions[10] = -({fractions[10]}) = {-fractions[10]}");

            Console.WriteLine("\n\tБінарні +, –, *, / (для типу Fraction, Fraction):");
            fractions.Add(new Fraction());
            fractions[11] = fractions[1] + fractions[5];
            Console.WriteLine($"fractions[11] = {fractions[1]} + {fractions[5]} = {fractions[11]}");

            fractions.Add(new Fraction());
            fractions[12] = fractions[1] - fractions[5];
            Console.WriteLine($"fractions[12] = {fractions[1]} - {fractions[5]} = {fractions[12]}");

            fractions[1] = new Fraction("1/2");
            fractions[5] = new Fraction("1/2");
            fractions[12] = fractions[1] + fractions[5];
            Console.WriteLine($"fractions[12] = {fractions[1]} + {fractions[5]} = {fractions[12]}");

            fractions[12] = fractions[1] - fractions[5];
            Console.WriteLine($"fractions[12] = {fractions[1]} - {fractions[5]} = {fractions[12]}");

            fractions[1] = new Fraction(0, 3);
            fractions[5] = new Fraction(0, 8);
            fractions[12] = fractions[1] - fractions[5];
            Console.WriteLine($"fractions[12] = {fractions[1]} - {fractions[5]} = {fractions[12]}");

            fractions[1] = new Fraction(0, 8);
            fractions[5] = new Fraction(5, 3);
            fractions[12] = fractions[1] - fractions[5];
            Console.WriteLine($"fractions[12] = {fractions[1]} - {fractions[5]} = {fractions[12]}");

            Fraction frac = fractions[5] * fractions[6];
            Console.WriteLine($"frac = {fractions[5]} * {fractions[6]} = {frac}");

            frac = fractions[5] / fractions[6];
            Console.WriteLine($"frac = {fractions[5]} / {fractions[6]} = {frac}");

            Console.WriteLine("\n\tБінарні +, –, *, / (для типу Fraction, long):");
            Console.Write($"fractions[12] = {fractions[12]} + 10 = ");
            fractions[12] = fractions[12] + 10;
            Console.WriteLine($"{fractions[12]}");

            Console.Write($"fractions[12] = {fractions[12]} + -10 = ");
            fractions[12] = fractions[12] + -10;
            Console.WriteLine($"{fractions[12]}");

            Console.Write($"fractions[12] = {10} + {fractions[12]} = ");
            fractions[12] = 10 + fractions[12];
            Console.WriteLine($"{fractions[12]}");

            fractions[7].SetDenominator(3);
            Console.Write($"fractions[7] = {fractions[7]} - 10 = ");
            fractions[7] = fractions[7] - 10;
            Console.WriteLine($"{fractions[7]}");

            Console.Write($"fractions[7] = 10 - {fractions[7]} = ");
            fractions[7] = 10 - fractions[7];
            Console.WriteLine($"{fractions[7]}");

            frac = fractions[5] * 12;
            Console.WriteLine($"frac = {fractions[5]} * 12 = {frac}");

            frac = 5 * fractions[5];
            Console.WriteLine($"frac = 5 * {fractions[5]} = {frac}");

            frac = fractions[5] / 15;
            Console.WriteLine($"frac = {fractions[5]} / 15 = {frac}");

            frac = 4 / fractions[6];
            Console.WriteLine($"frac = 4 / {fractions[6]} = {frac}");

            Console.WriteLine("\n\tБінарні порівняння: >, >=, <, <=, ==, !=:");
            Console.WriteLine($"{fractions[0]} > {fractions[1]}   -->   {fractions[0] > fractions[1]}");
            Console.WriteLine($"{fractions[1]} < {fractions[2]}   -->   {fractions[1] < fractions[2]}");
            Console.WriteLine($"{fractions[2]} >= {fractions[3]}   -->   {fractions[2] >= fractions[3]}");
            Console.WriteLine($"{fractions[3]} <= {fractions[4]}   -->   {fractions[3] <= fractions[4]}");
            Console.WriteLine($"{fractions[4]} == {fractions[5]}   -->   {fractions[4] == fractions[5]}");
            Console.WriteLine($"{fractions[5]} != {fractions[6]}   -->   {fractions[5] != fractions[6]}");
            Console.WriteLine($"{fractions[6]} > 5   -->   {fractions[6] > 5}");
            Console.WriteLine($"2 < {fractions[6]}   -->   {2 < fractions[6]}");
            Console.WriteLine($"{fractions[6]} >= 7.74   -->   {fractions[6] >= 7.74}");
            Console.WriteLine($"8.26 <= {fractions[6]}   -->   {8.26 <= fractions[6]}");
            fractions[6] = new Fraction("1/2");
            Fraction fract = new Fraction("3/6");
            Console.WriteLine($"{fractions[6]} == 0.5   -->   {fractions[6] == 0.5}");
            Console.WriteLine($"{fractions[6]} == {fract}   -->   {fractions[6] == fract}");
            Console.WriteLine($"{fractions[6]} != 0.5   -->   {fractions[6] != 0.5}");
            Console.WriteLine($"0.5 != {fractions[6]}   -->   {0.5 != fractions[6]}");
            Console.WriteLine($"0.5 == {fractions[6]}   -->   {0.5 == fractions[6]}");
            
            fractions[6] = new Fraction(16, 7);
            Console.WriteLine("\n\tЯвне перетворення типу Fraction до double:");
            index = 0;
            foreach (Fraction fraction in fractions)
            {
                Console.WriteLine($"fractions[{index}] = {fraction} = (double)fractions[{index}] = {(double)fraction, 0:f4}");
                index++;
            }

            Console.WriteLine("\n\tБінарні +, –, *, / (для типу Fraction, double):");
            Console.WriteLine($"{frac} + 0.27 = {frac + 0.27}");
            Console.WriteLine($"31.5 + {frac} = {31.5 + frac}");
            Console.WriteLine($"{frac} + (-7.31) = {frac + -7.31}");
            double x = frac + -7.31;
            Console.WriteLine($"{frac} - {x} = {frac - x}");
            x = frac - x;
            Console.WriteLine($"13.55 * {frac} = {13.55 * frac}");
            Console.WriteLine($"{frac} / {x} = {frac / x}");

            Console.WriteLine("\n\tDoubleToFraction:");
            frac = frac.DoubleToFraction(-3.58);
            Console.WriteLine($"frac = -3.58 = {frac}");
            frac = frac.DoubleToFraction(0.23);
            Console.WriteLine($"frac = 0.23 = {frac}");
            frac = frac.DoubleToFraction(71.5834);
            Console.WriteLine($"frac = 71.5834 = {frac}");

            x = frac - 25.37;
            Console.WriteLine($"{frac} - 25.37 = {frac - 25.37} = {frac.DoubleToFraction(x)}\n\n");
        }
    }
}