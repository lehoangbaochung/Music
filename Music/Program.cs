using System;

namespace Music
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Nhap chuoi: ");
            var str = Console.ReadLine();
            int a = 0;
            while (a % 2 == 0 || a == 13 || a < 1 || a > 25)
            {
                Console.WriteLine("Nhap so a: ");
                a = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Nhap so b: ");
            var b = int.Parse(Console.ReadLine());
            var res = "";
            foreach (var c in str)
            {
                var m = CharToInt(c);
                m = (m * a + b) % 26;
                res += IntToChar(m);
            }
            Console.WriteLine("Chuoi ma hoa: " + res);
            Console.ReadKey();
        }

        static int CharToInt(char c)
            => char.ToUpper(c) - 'A';

        static char IntToChar(int n)
            => (char)('A' + n);

        static int UCLN(int n1, int n2)
        {
            int ucln = 0;
            var j = (n1 < n2) ? n1 : n2;
            for (int i = 1; i <= j; i++)
            {
                if (n1 % i == 0 && n2 % i == 0)
                {
                    ucln = i;
                }
            }
            return ucln;
        }

        static void Caesar()
        {
            Console.WriteLine("Nhap chuoi: ");
            var str = Console.ReadLine();
            Console.WriteLine("Nhap khoa K: ");
            var k = int.Parse(Console.ReadLine());
            var res = string.Empty;
            foreach (var c in str)
            {
                var m = CharToInt(c);
                m = (m + k) % 26;
                res += IntToChar(m);
            }
            Console.WriteLine("Chuoi ma hoa:\n" + res);
            Console.ReadKey();
        }

        static void Decode()
        {
            const string str = "AHFGTRETMANUT";
            string res;
            for (int i = 0; i < 26; i++)
            {
                res = "";
                foreach (var c in str)
                {
                    var m = CharToInt(c);
                    m = (m - i + 26) % 26;
                    res += IntToChar(m);
                }
                Console.WriteLine($"Chuoi giai ma voi khoa { i } la: { res }");
            }
            Console.ReadKey();
        }
    }
}
