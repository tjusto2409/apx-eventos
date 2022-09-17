using System;
using Domain.ValueObjects;

namespace Domain.DomainObjects
{
    public abstract class User
    {
        protected User(string name, string emailAddress)
        {
            Key = Guid.NewGuid();
            Name = name;
            Email = new Email(emailAddress);
        }

        protected Guid Key { get; }
        protected string Name { get; }
        protected Email Email { get; }
    }
}