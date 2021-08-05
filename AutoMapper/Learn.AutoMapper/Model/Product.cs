using System;
using System.Collections.Generic;
using System.Text;

namespace Learn.AutoMapper.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string NameProduct { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}
