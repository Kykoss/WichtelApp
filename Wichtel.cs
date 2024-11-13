using System.Windows.Controls;

namespace WichtelApp
{
    public class Wichtel
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string BackGroundStory => Resources.ResourceManager.GetString($"Story_{this.FirstName}");

        public Image Picture => (Image)Resources.ResourceManager.GetObject(this.FirstName);

        public Wichtel LastReceiver { get; set; }

        public Wichtel(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
