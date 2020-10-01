using AutoMapper;
using System;

namespace ValueObjects
{
    class Program
    {
        private static void Main(string[] args)
        {
            // korzystając z AutoMappera możemy zamiast:
            //var entity = new UserEntity
            //{
            //    Name = "Przemek",
            //    Email = "frost22a@tlen.pl",
            //    Age = 39
            //};

            //var dto = new UserDto
            //{
            //    Name = entity.Name,
            //    Email = entity.Email,
            //    Age = entity.Age,
            //    IsUserAboveEighteen = entity.Age > 18,
            //};

            //zrobić

            var mapper = new UserMapper();

            var entity = new UserEntity
            {
                Name = "Przemek",
                Email = "frost22a@tlen.pl",
                Age = 39
            };

            var dto = mapper.Map(entity);

        }
    }
}
