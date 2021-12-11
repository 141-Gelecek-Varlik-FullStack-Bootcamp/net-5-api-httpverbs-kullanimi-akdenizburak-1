using System;

namespace MovieList.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] - "+message);
        }
    }
}
