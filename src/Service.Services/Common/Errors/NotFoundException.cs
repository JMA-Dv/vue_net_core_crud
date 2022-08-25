using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Common.Errors
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
