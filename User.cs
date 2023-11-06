namespace WichtelApp
{
    internal class User
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public User LastPartner { get; }

        public User(string firstName, string lastName, string email, User lastPartner)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            LastPartner = lastPartner;
        }
    }
}
