using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Model
{
    public class DataTransfer
    {
        public string TypeTransfer { get; set; }
        public Guid IdTransfer { get; set; }
        public object Payload { get; set; }
        public DateTime DataCriacao { get; set; }

        public DataTransfer()
        {

        }
        public DataTransfer(string typeTransfer, object payload)
        {
            IdTransfer = Guid.NewGuid();

            this.TypeTransfer = typeTransfer;
            this.Payload = payload;
            this.DataCriacao = DateTime.Now;
        }

    }
}
