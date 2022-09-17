using System;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Email
    {
        private const string EmailRegex = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
        
        public string Address { get; }

        public Email(string emailAddress)
        {
            Address = Validation(emailAddress);
        }
        
        private string Validation(string mailAddress)
        {
            var isValid = Regex.IsMatch(mailAddress, EmailRegex, RegexOptions.IgnoreCase);

            if (!isValid)
                throw new Exception();

            return mailAddress;
        }
    }
}