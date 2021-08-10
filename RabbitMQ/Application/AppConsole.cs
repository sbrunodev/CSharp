using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Application
{
    public class AppConsole
    {
        public static void AddMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ReadKey()
        {
            Console.ReadKey();
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
