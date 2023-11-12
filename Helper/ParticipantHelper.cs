using System.Collections.Generic;

namespace WichtelApp.Helper
{
    public static class ParticipantHelper
    {
        public static List<Wichtel> GetParticipants()
        {
            var kara = new Wichtel("Kara", "Schmich", "");
            var robin = new Wichtel("Robin", "Olde Meule", "");
            var lukas = new Wichtel("Lukas", "Wewel", "");
            var leon = new Wichtel("Leon", "Campos Ribeiro", "");
            var jannik = new Wichtel("Jannik", "Kolthof", "");
            var moritz = new Wichtel("Moritz Benjamin", "Jacobs", "");
            var jan = new Wichtel("Jan", "Steinkamp", "");
            var ingo = new Wichtel("Ingo", "Wilkosinski", "");

            #region LastPartner

            kara.LastReceiver = moritz;
            moritz.LastReceiver = kara;

            robin.LastReceiver = ingo;
            ingo.LastReceiver = robin;

            lukas.LastReceiver = leon;
            leon.LastReceiver = lukas;

            jannik.LastReceiver = jan;
            jan.LastReceiver = jannik;

            #endregion

            #region Stories

            kara.BackGroundStory = "";

            robin.BackGroundStory = "";

            lukas.BackGroundStory = "";

            leon.BackGroundStory = "";

            jannik.BackGroundStory = "";

            moritz.BackGroundStory = "";

            jan.BackGroundStory = "";

            ingo.BackGroundStory = "";

            #endregion

            return new List<Wichtel>()
            {
                kara,
                moritz,
                robin,
                ingo,
                lukas,
                leon,
                jannik,
                jan,
            };
        }
    }
}
