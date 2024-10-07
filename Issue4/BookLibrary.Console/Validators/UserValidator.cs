using BookLibrary.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Console.Validators
{
    internal class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u => u.Age).InclusiveBetween(10,100);
            RuleFor(u => u.Email).MinimumLength(10);
        }
    }
}
