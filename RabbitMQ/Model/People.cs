using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Model
{
    public abstract class People
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }


        public People()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }

        public override string ToString()
        {
            return $@"
                Id = {Id}, 
                Nome = {Nome},
                Data de Criação = {DataCriacao.ToLongDateString()}
            ";
        }
    }
}
