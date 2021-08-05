using AutoMapper;
using Learn.AutoMapper.Model;
using System;

namespace Learn.AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Name = "Bruno",
                Email = "brunosilva.dev@outlook.com",
                Age = 26,
                Birth = new DateTime(1995, 2, 25)
            };

            AutoMapperManagement autoMapper = new AutoMapperManagement();

            var userViewModel = (UserViewModel) autoMapper.MappingClass<User, UserViewModel>(user);


            Product p = new Product()
            {
                NameProduct = "Produto A"
            };

            var productViewModel = autoMapper.MappingClassProduct(p);
        }
    }
}
