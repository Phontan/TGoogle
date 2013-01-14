using System;

namespace TGoogle.Site.Models.Exceptions
{
    public class ModelException : Exception
    {
        public ModelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ModelException(string message) : base(message)
        {
        }
    }
}