namespace WichtelApp
{
    public class Wichtel
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string BackGroundStory { get; set; }

        public Wichtel LastReceiver { get; set; }

        public Wichtel(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
