using Domain.Enums;

namespace Domain.DomainObjects
{
    public class Administrator : User
    {
        public Profile Profile { get; } = Profile.AdminUser;

        public Administrator(string name, string emailAddress) : 
            base(name, emailAddress)
        { }
    }
}