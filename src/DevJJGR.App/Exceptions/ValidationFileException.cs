using System;
namespace CarritoWebApi.Exceptions
{
    public class ValidationFileException : Exception
    {
        public ValidationFileException(string messagge) : base(messagge)
        {

        }
    }
}

