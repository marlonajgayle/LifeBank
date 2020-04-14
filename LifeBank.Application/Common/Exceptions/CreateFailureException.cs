using System;

namespace LifeBank.Application.Common.Exceptions
{
    public class CreateFailureException : Exception
    {
        public CreateFailureException(string name, string message)
          : base($"Creation of entity \"{name}\" failed. {message}")
        {
        }
    }
}
