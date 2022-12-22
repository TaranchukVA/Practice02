using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrier<OrdersList> orderCarrier = new OrdersListWriter(new XmlReader<OrdersList>());
            bool isRepeat;
            do
            {
                Console.WriteLine("Insert path to File");
                string path = Console.ReadLine();

                if (orderCarrier.TryTransfer(path))
                    Console.WriteLine("\nOrders added successful");
                else
                    Console.WriteLine("\nNot all orders added succesful.\nThere were some errors");

                Console.WriteLine("\n\nFor repeat press Y");
                isRepeat = Console.ReadKey().Key == ConsoleKey.Y;
                Console.WriteLine("\n\n");

            } while (isRepeat);
        }
    }
}
