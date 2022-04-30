namespace Quartz.Domain.Users
{
    public class User : EntityBase
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }

        public virtual string UserName { get; set; }

    }
}
