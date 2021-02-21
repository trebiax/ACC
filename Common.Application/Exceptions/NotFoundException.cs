using System;

namespace Common.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg = "") : base(msg)
        {

        }
    }
}
