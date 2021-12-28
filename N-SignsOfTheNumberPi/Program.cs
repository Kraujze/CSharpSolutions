using System.Globalization;

namespace N_SignsOfTheNumberPi
{
    public static class Program
    {
        private static ushort n;
        private static int[,] a;
        /*
         * Используемый метод: "Метод краника"
         * a[x, 0] – основной числитель массива в позиции "x" || ЧИСЛИТЕЛЬ
         * a[x, 1] – постоянный знаменатель массива в позиции "x" || ЗНАМЕНАТЕЛЬ
         * a[x, 2] – остаток операций числителя в позиции "x" || ОСТАТОК
         */
        private static string Solution()
        {
            InitializeArray();
            string pi = "";
            for (int j = 1; j <= n; j++)
            {
                if (j == 2) pi += ',';
                if (j % 10 == 2 && j > 11) pi += ' ';
                int prev = 0;
                for (int i = a.GetLength(0) - 1; i >= 0; i--)
                {
                    a[i, 0] *= 10;
                    a[i, 0] += prev;
                    if (i == 0)
                    {
                        pi += a[i, 0] / a[i, 1];
                        a[i, 2] = a[i, 0] % a[i, 1];
                    }
                    else
                    {
                        a[i, 2] = a[i, 0] % a[i, 1];
                    }
                    prev =  a[i, 0] / a[i, 1] * i;
                    a[i, 0] = a[i, 2];
                }
            }
            return pi;
        }

        private static void InitializeArray()
        {
            a = new int[Convert.ToInt32((10 * n) % 3 == 0 ? 10 * n / 3.0 : Math.Floor(10 * n / 3.0) + 1), 3];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                a[i, 0] = 2;
                a[i, 1] = (i == 0) ? 10 : (i * 2 + 1);
            }
        }
        public static void Main()
        {
            
            try
            {
                Console.Write("Введите необходимое количество знаков: ");
                n = Convert.ToUInt16(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверные исходные данные");
                return;
            }
            
            var t1 = DateTime.Now;
            string pi = Solution();
                Console.WriteLine($"Полученные знаки числа Пи: {pi}");
            var t2 = DateTime.Now;
            Console.WriteLine($"Время старта: {t1.Hour}h:{t1.Minute}m:{t1.Second}s:{t1.Millisecond}ms");
            Console.WriteLine($"Время на конец: {t2.Hour}h:{t2.Minute}m:{t2.Second}s:{t2.Millisecond}ms");
        }
    }
}