using System;

namespace Imperial
{
    public class Error : Exception
    {
        public Error() : base() { }
        public Error(string message) : base(message) { }
    }
}
