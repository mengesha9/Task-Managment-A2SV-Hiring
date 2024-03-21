using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Application.Exceptions
{
    public class IdentityException : ApplicationException
    {
        public IdentityException(string message, List<IdentityError> errors) : base(message)
        {
            Errors = errors;
        }

        public List<IdentityError> Errors { get; }
    }
}