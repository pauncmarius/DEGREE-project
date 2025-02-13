using System;

namespace FCUnirea.Business.Exceptions
{
    public class NotAvailableException : ApplicationException
    {
        public NotAvailableException(string message) : base(message) { 
        
        }
    }
}
