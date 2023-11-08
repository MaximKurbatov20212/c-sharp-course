using System;

namespace lab1
{
    public class InvalidDeckSizeException : Exception
    {
        public InvalidDeckSizeException(string msg) : base(msg) {}
    }
}