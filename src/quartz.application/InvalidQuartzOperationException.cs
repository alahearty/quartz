using System;

namespace Quartz.Application
{
    public class InvalidQuartzOperationException : Exception
    {
        public InvalidQuartzOperationException(string message):base(message)
        {

        }
    }
}
