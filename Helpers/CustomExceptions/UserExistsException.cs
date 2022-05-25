using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WHApp_API.Helpers.CustomExceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException() : base("User already exists.")
        {
        }
    }
}