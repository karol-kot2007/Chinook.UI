using BookLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Data;
using FluentValidation.Validators;
using BookLibrary.Console.Validators;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Results;

namespace proj
{
    public class pr
    {
        



        //private static void InitializeEmployees(List<User> users)
        //{
        //    Users.Add(new User
        //    {
        //        Email = "tuba@gmail.com",
        //        FirstName = "Tuba",
        //        Age = 35,
        //        LastName = "ojciechowski"
        //    });

        //    Users.Add(new User
        //    {
        //        Email = "atul@gmail.com",
        //        FirstName = "Tul",
        //        Age = 24,
        //        LastName = "krol"
        //    });
        //    var querySyntax1 = from user in Users
        //                       where user.FirstName.StartsWith("T")
        //                       select user.FirstName;

        private static void validateMethod(User user)
        {
            //while (user.FirstName.Length < 3 || user.LastName.Length < 3 || user.Email.Length < 3 || user.Age < 10)
            //{
            //    Console.WriteLine("what's your name ? ");
            //    user.FirstName = Console.ReadLine();
            //    Console.WriteLine("what's your Last name ? ");
            //    user.LastName = Console.ReadLine();
            //    Console.WriteLine("what's your Email ? ");
            //    user.Email = Console.ReadLine();

            //}

        }

        public void Personvalidator()
        {

        }
        //    Console.WriteLine("Where in querySyntax------");
        //    foreach (var item in querySyntax1)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
        static void Main(string[] args)
        {
            User user = new User();
            Console.WriteLine("what's your age ? ");
            user.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("what's your name ? ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("what's your Last name ? ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("what's your Email ? ");
            user.Email = Console.ReadLine();
            //  validateMethod(user);
            UserValidator validator = new UserValidator();
            var result= validator.Validate(user); ;
            if (result.IsValid == false)
            {
                foreach (ValidationFailure failure in result.Errors)
                {
                    Console.WriteLine($"Bład" + (failure.PropertyName));
                }
            }
            else
            {
                Console.WriteLine("your first name is : " + user.FirstName + " ,your last name is : " + user.LastName + " ,your age is : " + user.Age + " ,your email is : " + user.Email);
            }

            //  InitializeEmployees(Users);
        }
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers().AddFluentValidation(opt =>
        //    {
        //        opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //    });

        //}

    }
}