using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class MultiMessageRegisterServicesException : Exception
    {
        public MultiMessageRegisterServicesException(string message) : base(message)
        {
        }

        public const string Name = "Name Not Found";
        public const string Email = "Email Not Found";
        public const string Password = "The Password is incorrect";
        public const string UnSuccessful = "Registration failed";
        public const string Successful = "Register successfully";
    }

}
