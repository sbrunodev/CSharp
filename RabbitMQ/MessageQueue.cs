using RabbitMQ.Application;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RabbitMQ
{
    public class MessageQueue
    {
        private string _uriAcess = "amqp://guest:guest@localhost:5672";
        private string _nameQueue;

        private IConnection _connection;
        private IModel _channel;

        public MessageQueue(string nameQueue)
        {
            this._nameQueue = nameQueue;
        }

        public void InitChannel()
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(_uriAcess)
            };

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: _nameQueue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            AppConsole.AddMessage("Channel created successfully");
        }

        public void SendMessage(object messageTransfer)
        {
            string jsonString = JsonSerializer.Serialize(messageTransfer);
            var body = Encoding.UTF8.GetBytes(jsonString);

            _channel.BasicPublish(exchange: "",
                                 routingKey: _nameQueue,
                                 basicProperties: null,
                                 body: body);
        }

        public void ConsumeMessage()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                HandleIncomingMessage(eventArgs.Body.ToArray());
            };

            _channel.BasicConsume(queue: _nameQueue,
                 autoAck: true,
                 consumer: consumer);
        }


        /// <summary>
        /// Lidar com a mensagem recebida.
        /// </summary>
        /// <param name="body"></param>
        public void HandleIncomingMessage(byte[] body)
        {
            var message = Encoding.UTF8.GetString(body);
            var dataTransfer = JsonSerializer.Deserialize<DataTransfer>(message);
            AppConsole.AddMessage(dataTransfer.Payload.ToString());
        }
    }
}
