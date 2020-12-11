using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FractionLibrary
{
    public class Fraction
    {
        protected long Numerator;
        protected long Denominator;

        public Fraction()
        {
            Numerator = 1;
            Denominator = 1;
        }

        public Fraction(long numerator, long denominator = 1)
        {
            SetNumerator(numerator);
            SetDenominator(denominator);
        }

        public Fraction(double numerator, double denominator)
        {
            SetNumerator(numerator);
            SetDenominator(denominator);
        }

        public Fraction(double numerator, long denominator = 1)
        {
            SetNumerator(numerator);
            SetDenominator(denominator);
        }

        public Fraction(long numerator, double denominator)
        {
            SetNumerator(numerator);
            SetDenominator(denominator);
        }

        public Fraction(string fraction)
        {
            SetNumerator(fraction);
            SetDenominator(fraction);
        }

        public void SetNumerator(long numerator)
        {
            Numerator = numerator;
        }

        public void SetDenominator(long denominator)
        {
            if (Numerator >= 0 && denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = Math.Abs(denominator);
            }
            else if (Numerator < 0 && denominator < 0)
            {
                Denominator = Math.Abs(denominator);
                Numerator = Math.Abs(Numerator);
            }
            else if (denominator == 0)
                Denominator = 1;
            else
                Denominator = denominator;
        }

        public void SetNumerator(double numerator)
        {
            Numerator = (long)Math.Round(numerator);
        }

        public void SetDenominator(double denominator)
        {
            SetDenominator((long)Math.Round(denominator));
        }

        public void SetNumerator(string fraction)
        {
            Regex regex = new Regex(@"(\-?\d+([\.\,]\d+)?)\/(\-?\d+([\.\,]\d+)?)");
            Match match = regex.Match(fraction);
            string num = match.Groups[1].Value.Replace('.', ',');

            double numerator = 1;
            if (num.Length > 0)
                numerator = double.Parse(num.ToString());
            Numerator = (long)Math.Round(numerator);
        }

        public void SetDenominator(string fraction)
        {
            Regex regex = new Regex(@"(\-?\d+(\.\d+)?)\/(\-?\d+(\.\d+)?)");
            Match match = regex.Match(fraction);
            string den = match.Groups[3].Value.Replace('.', ',');

            double denominator = 1;
            if (den.Length > 0)
                denominator = double.Parse(den.ToString());

            SetDenominator((long)Math.Round(denominator));
        }

        public long GetNumerator()
        {
            return Numerator;
        }

        public long GetDenominator()
        {
            return Denominator;
        }

        public static Fraction operator +(Fraction fraction)
        {
            return fraction;
        }

        public static Fraction operator -(Fraction fraction)
        {
            if (fraction.GetNumerator() == 0)
                return new Fraction(fraction.GetNumerator(), fraction.GetDenominator());
            return new Fraction(-fraction.GetNumerator(), fraction.GetDenominator());
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            if (fraction1.GetNumerator() == 0 && fraction2.GetNumerator() == 0)
                return new Fraction(0, NSK(fraction1.GetDenominator(), fraction2.GetDenominator()));
            else if (fraction1.GetNumerator() == 0 && fraction2.GetNumerator() != 0)
                return new Fraction(fraction2.GetNumerator(), fraction2.GetDenominator());
            else if (fraction1.GetNumerator() != 0 && fraction2.GetNumerator() == 0)
                return new Fraction(fraction1.GetNumerator(), fraction1.GetDenominator());

            return new Fraction(ReductionNumerator(fraction1, fraction2) + ReductionNumerator(fraction2, fraction1), NSK(fraction1.GetDenominator(), fraction2.GetDenominator()));
        }

        public static Fraction operator +(Fraction fraction, long x)
        {
            return new Fraction(fraction.GetNumerator() + x * fraction.GetDenominator(), fraction.GetDenominator());
        }

        public static Fraction operator +(long x, Fraction fraction)
        {
            return fraction + x;
        }

        public static Fraction operator -(Fraction fraction, long x)
        {
            return fraction + -x;
        }

        public static Fraction operator -(long x, Fraction fraction)
        {
            return x + -fraction;
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            return fraction1 + -fraction2;
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.GetNumerator() * fraction2.GetNumerator(), fraction1.GetDenominator() * fraction2.GetDenominator());
        }

        public static Fraction operator *(Fraction fraction, long x)
        {
            return new Fraction(fraction.GetNumerator() * x, fraction.GetDenominator());
        }

        public static Fraction operator *(long x, Fraction fraction)
        {
            return fraction * x;
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.GetNumerator() * fraction2.GetDenominator(), fraction1.GetDenominator() * fraction2.GetNumerator());
        }

        public static Fraction operator /(Fraction fraction, long x)
        {
            return new Fraction(fraction.GetNumerator(), fraction.GetDenominator() * x);
        }

        public static Fraction operator /(long x, Fraction fraction)
        {
            return new Fraction(x * fraction.GetDenominator(), fraction.GetNumerator());
        }

        public static bool operator >(Fraction fraction1, Fraction fraction2)
        {
            return ReductionNumerator(fraction1, fraction2) > ReductionNumerator(fraction2, fraction1);
        }

        public static bool operator <(Fraction fraction1, Fraction fraction2)
        {
            return ReductionNumerator(fraction1, fraction2) < ReductionNumerator(fraction2, fraction1);
        }

        public static bool operator >=(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 < fraction2);
        }

        public static bool operator <=(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 > fraction2);
        }

        public static bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            return ReductionNumerator(fraction1, fraction2) == ReductionNumerator(fraction2, fraction1);
        }

        public static bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 == fraction2);
        }

        public static explicit operator double(Fraction fraction)
        {
            return (double)fraction.GetNumerator() / fraction.GetDenominator();
        }

        public static double operator +(double x, Fraction fraction)
        {
            return x + (double)fraction;
        }

        public static double operator +(Fraction fraction, double x)
        {
            return (double)fraction + x;
        }

        public static double operator -(double x, Fraction fraction)
        {
            return x - (double)fraction;
        }

        public static double operator -(Fraction fraction, double x)
        {
            return (double)fraction - x;
        }

        public static double operator *(double x, Fraction fraction)
        {
            return x * (double)fraction;
        }

        public static double operator *(Fraction fraction, double x)
        {
            return (double)fraction * x;
        }

        public static double operator /(double x, Fraction fraction)
        {
            return x / (double)fraction;
        }

        public static double operator /(Fraction fraction, double x)
        {
            return (double)fraction / x;
        }

        public static bool operator >(double x, Fraction fraction)
        {
            return x > (double)fraction;
        }

        public static bool operator >(Fraction fraction, double x)
        {
            return (double)fraction > x;
        }

        public static bool operator <(double x, Fraction fraction)
        {
            return x < (double)fraction;
        }

        public static bool operator <(Fraction fraction, double x)
        {
            return (double)fraction < x;
        }

        public static bool operator >=(double x, Fraction fraction)
        {
            return x >= (double)fraction;
        }

        public static bool operator >=(Fraction fraction, double x)
        {
            return (double)fraction >= x;
        }

        public static bool operator <=(double x, Fraction fraction)
        {
            return x <= (double)fraction;
        }

        public static bool operator <=(Fraction fraction, double x)
        {
            return (double)fraction <= x;
        }

        public static bool operator ==(double x, Fraction fraction)
        {
            return x == (double)fraction;
        }

        public static bool operator ==(Fraction fraction, double x)
        {
            return (double)fraction == x;
        }

        public static bool operator !=(double x, Fraction fraction)
        {
            return x != (double)fraction;
        }

        public static bool operator !=(Fraction fraction, double x)
        {
            return (double)fraction != x;
        }

        public void FractionReduction(long numerator, long denominator)
        {
            if (numerator != denominator)
            {
                SetNumerator(numerator / NSD(numerator, denominator));
                SetDenominator(denominator/ NSD(numerator, denominator));
            }
            else
            {
                SetNumerator(1);
                SetDenominator(1);
            }
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        private long NSD(long a, long b)
        {
            if (a == 0 || b == 0)
                return 1;
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b) return a;
            else if (a > b) return NSD(a - b, b);
            else return NSD(a, b - a);
        }

        private static long NSK(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            long nsk = Math.Max(a, b);
            while (nsk % a != 0 || nsk % b != 0)
                if (a > b)
                    nsk += a;
                else
                    nsk += b;
            return nsk;
        }

        private static long ReductionNumerator(Fraction fraction1, Fraction fraction2)
        {
            long a = NSK(fraction1.GetDenominator(), fraction2.GetDenominator());
            return (a / fraction1.GetDenominator()) * fraction1.GetNumerator();
        }

        public Fraction DoubleToFraction(double a)
        {
            Regex regex = new Regex(@"(\-?\d+)[\.\,](\d+)");
            Match match = regex.Match(a.ToString());
            
            string numer = match.Groups[1].Value.ToString();
            string denom = match.Groups[2].Value.ToString();

            long numerator = long.Parse(numer + denom);
            long denominator = (long)Math.Pow(10, denom.Length);

            return new Fraction(numerator, denominator);
        }
    }
}