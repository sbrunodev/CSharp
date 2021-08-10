using RabbitMQ.Application;
using RabbitMQ.Model;
using System;
using System.Threading;

namespace RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            AppConsole.AddMessage("Escolha o Comportamento [P] - Publisher | [C] - Consumer");
            var operationType = AppConsole.ReadLine();
            operationType = operationType.ToUpper();
            if (operationType.Equals("P") || operationType.Equals("C"))
            {
                AppConsole.AddMessage("Informe o nome da Fila");
                var nameQueue = AppConsole.ReadLine();
                if (!string.IsNullOrWhiteSpace(nameQueue))
                {
                    switch (operationType)
                    {
                        case "P":
                            {
                                InitMessageQueue_Publisher(nameQueue);
                            }; break;


                        case "C":
                            {
                                InitMessageQueue_Consumer(nameQueue);
                            }; break;

                    }
                }
                else
                    AppConsole.AddMessage("Nome da fila é inválido.");
            }
            else
                AppConsole.AddMessage("Operação inválida.");



            AppConsole.ReadKey();

        }

        static void InitMessageQueue_Publisher(string nameQueue)
        {
            MessageQueue menssaQueueBetweenSystems = new MessageQueue(nameQueue);
            menssaQueueBetweenSystems.InitChannel();

            int count = 0;
            int seconds = 2500;

            while (true)
            {
                Thread.Sleep(seconds);
                count++;
                AppConsole.AddMessage(count.ToString());

                var dataTransfer = new DataTransfer("message", "[Publisher] Message: " + count.ToString());
                menssaQueueBetweenSystems.SendMessage(dataTransfer);
            }
        }

        static void InitMessageQueue_Consumer(string nameQueue)
        {
            var messageQueue = new MessageQueue(nameQueue);
            messageQueue.InitChannel();
            messageQueue.ConsumeMessage();

            AppConsole.ReadKey();
        }


    }
}
