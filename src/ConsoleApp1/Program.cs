using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PostBox postBox = new PostBox();


            int n;
            string StrN;
        Vodn:
            bool VodNChesla = false;

            Console.Write("Введите количество записей: ");
            string input = Console.ReadLine();

            if (!IsValidInt(input))
            {
                Console.WriteLine("Ошибка: введено неверное значение.");

                VodNChesla = true;
            }
            if (VodNChesla) goto Vodn;

            n = Convert.ToInt32(input);

            if (n <= 0)
            {
                Console.WriteLine("количество записей должно быть положительным числом");
                VodNChesla = true;
            }
            if (VodNChesla) goto Vodn;


            Console.Clear();

            string Nazvanie, Vladelec, ChisloStranicStr;
            int ChisloStranic;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"запись {i + 1}");
                Console.Write("Введите название газеты: ");
                Nazvanie = Console.ReadLine();


                Console.Write("Введите владельца газеты: ");
                Vladelec = Console.ReadLine();

            ChisloStanic:

                Console.Write("Введите число страниц газеты: ");
                ChisloStranicStr = Console.ReadLine();





                if (!IsValidInt(ChisloStranicStr))
                {
                    Console.WriteLine("Ошибка: введено неверное значение.");

                    goto ChisloStanic;


                }

                ChisloStranic = Convert.ToInt32(ChisloStranicStr);

                if (ChisloStranic <= 0)
                {
                    Console.WriteLine("число страниц должно быть положительным числом");

                    goto ChisloStanic;

                }




                postBox.AddBook(new Newspaper { Nazvanie = Nazvanie, Vladelec = Vladelec, ChisloStranic = ChisloStranic });



                Console.Write("\n");
            }



            postBox.SortNews();

            postBox.SaveToFile("news.txt");



        }

        static public bool IsValidInt(string value)
        {
            try
            {
                // Проверяем преобразование в Int32
                _ = Convert.ToInt32(value);
                return true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    }



}

public struct Newspaper
{
    public string Nazvanie { get; set; }
    public string Vladelec { get; set; }
    public int ChisloStranic { get; set; }
}
