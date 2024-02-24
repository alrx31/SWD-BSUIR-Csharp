class Program
{
    public static void Main(String[] args)
    {




        Console.WriteLine("Enter a number of task 1/2/3");
        int choose = int.Parse(Console.ReadLine());

        if(choose == 1)
        {

            // part 1

            //5.	Билет на одну поездку в метро стоит
            //15 рублей, билет на 10 поездок стоит 125 рублей, билет на 60 поездок стоит 440 рублей. Пассажир планирует
            //совершить n поездок. Определите, сколько билетов каждого вида он должен приобрести, чтобы суммарное количество
            //оплаченных поездок было не меньше n, а общая стоимость приобретенных билетов – минимальна.


            int onePrice = 15;
            int priceTen = 125;
            int priceSixty = 440;

            int n = int.Parse(Console.ReadLine());


            int countSixty = n / 60;
            int countTen = (n - countSixty * 60) / 10;
            int countOne = n - countSixty * 60 - countTen * 10;
            int price = countSixty * priceSixty + countTen * priceTen + countOne * onePrice;

            Console.WriteLine("to 60 trips: " + countSixty + "\nto 10 trips: " + countTen + "\nto 1 trip: " + countOne + "\nprice:" + price); ;




        }
        else if (choose == 2)
        {
            // part 2

            //5.Пользователь вводит число от 1 до 12 (представляющее месяц), программа выводит
            //количество дней в этом месяце (високосный год не учитывается).

            Console.WriteLine("Enter a month number ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("number of days:\n");
            if (month < 0 || month > 12)
            {
                Console.WriteLine("Error");
            }
            else
            {
                switch (month)
                {
                    case 1:
                        Console.WriteLine("31");
                        break;
                    case 2:
                        Console.WriteLine("28");
                        break;
                    case 3:
                        Console.WriteLine("31");
                        break;
                    case 4:
                        Console.WriteLine("30");
                        break;
                    case 5:
                        Console.WriteLine("31");
                        break;
                    case 6:
                        Console.WriteLine("30");
                        break;
                    case 7:
                        Console.WriteLine("31");
                        break;
                    case 8:
                        Console.WriteLine("31");
                        break;
                    case 9:
                        Console.WriteLine("30");
                        break;
                    case 10:
                        Console.WriteLine("31");
                        break;
                    case 11:
                        Console.WriteLine("30");
                        break;
                    case 12:
                        Console.WriteLine("31");
                        break;
                }
            }

        }
        else if (choose == 3)
        {

            // part 3

            //5.Написать программу, подсчитывающую сумму и произведение
            //цифр числа. Число должно быть ограничено шестью разрядами.



            Console.WriteLine("enter a number");

            while (true)
            {
                int number = int.Parse(Console.ReadLine());


                if (number < 0 || number > 999999)
                {
                    Console.WriteLine("Error enter enother number ");
                }
                else
                {

                    int sum = 0;
                    int mult = 1;

                    while (number > 0)
                    {
                        sum += number % 10;
                        mult *= number % 10;
                        number /= 10;
                    }

                    Console.WriteLine("sum: " + sum + "\nmult: " + mult);
                    break;
                }
            }
        }







    }
}