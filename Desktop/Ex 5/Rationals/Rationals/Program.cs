using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        public struct Rational
        {
            private int _numerator;
            private int _denominator;
            public int Numerator
            {
                get
                {
                    return _numerator;
                }
            }
            public int Denominator
            {
                get
                {
                    return _denominator;
                }
            }
            public double Value
            {
                get
                {
                    return Math.Round((double)_numerator / (double)_denominator, 2);
                }
            }
            public Rational(int numerator, int denominator)
            {
                if (denominator == 0)
                {
                    throw new ArgumentOutOfRangeException("denominator", "The denominator cannot be 0.");
                }
                _numerator = numerator;
                _denominator = denominator;
            }
            public Rational(int numerator)
            {
                _numerator = numerator;
                _denominator = 1;
            }
            public Rational Add(Rational other)
            {
                if (Denominator == other.Denominator)
                {
                    return new Rational(Numerator + other.Numerator, Denominator);
                }
                return new Rational(Numerator * other.Denominator + Denominator * other.Numerator, Denominator * other.Denominator);
            }
            public Rational Red(Rational other)
            {
                if (Denominator == other.Denominator)
                {
                    return new Rational(Numerator - other.Numerator, Denominator);
                }
                return new Rational(Numerator * other.Denominator - Denominator * other.Numerator, Denominator * other.Denominator);
            }
            public Rational Mul(Rational other)
            {
                return new Rational(Numerator * other.Numerator, Denominator * other.Denominator);
            }
            public Rational Div(Rational other)
            {
                return new Rational(other.Denominator * Numerator, Denominator * other.Numerator);
            }
            public static Rational operator +(Rational r1, Rational r2)
            {
                return r1.Add(r2);
            }
            public static Rational operator -(Rational r1, Rational r2)
            {
                return r1.Red(r2);
            }
            public static Rational operator *(Rational r1, Rational r2)
            {
                return r1.Mul(r2);
            }
            public static Rational operator /(Rational r1, Rational r2)
            {
                return r1.Div(r2);
            }
            public void Reduce()
            {
                int mod = Gcd(Numerator, Denominator);
                _numerator /= mod;
                _denominator /= mod;
            }
            public override string ToString()
            {
                Reduce();
                if (Denominator == 1)
                {
                    return Numerator.ToString();
                }
                else
                {
                    return Numerator.ToString() + "/" + Denominator.ToString();
                }
            }
            public bool Equals(Rational other)
            {
                return Numerator == other.Numerator && Denominator == other.Denominator;
            }

            public override bool Equals(object other)
            {
                return other is Rational && Equals((Rational)other);
            }
            public static explicit operator double(Rational r)
            {
                return r.Value;
            }
            public static implicit operator Rational(int number)
            {
                return new Rational(number);
            }
        }
        public static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        static void Main(string[] args)
        {
            Rational ratio1 = new Rational(9, 12);
            Console.WriteLine(ratio1.ToString());
            ratio1 = new Rational(1, 1);
            Console.WriteLine(ratio1.ToString());
            ratio1 = new Rational(6);
            Console.WriteLine(ratio1.ToString());
            Rational ratio2 = new Rational(30, 7);
            Console.WriteLine(ratio2.ToString());
            Console.WriteLine("Are a and b equal? {0}", ratio1.Equals(ratio2));
            Rational ratio3 = new Rational(3, 4);
            Rational ratio4 = new Rational(2, 5);
            Console.WriteLine(ratio3.Mul(ratio4).ToString());
            Console.WriteLine(ratio3.Add(ratio4).ToString());

            try
            {
                Rational testZero = new Rational(5, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Rational ratio5 = new Rational(2, 4);
            Rational ratio6 = new Rational(1, 4);
            Rational result = ratio5 + ratio6;
            Console.WriteLine(result.ToString());
            Console.WriteLine((ratio5 + ratio5).ToString());
            Console.WriteLine((ratio5 * ratio6).ToString());
            Console.WriteLine((ratio5 / ratio5).ToString());
            Console.WriteLine((ratio5 - ratio5).ToString());
            Console.WriteLine((ratio6 - ratio5).ToString());
            Console.WriteLine((double)ratio5);
            Rational ratio7 = 5;
            Console.WriteLine(ratio7.ToString());
        }
            
    }
}