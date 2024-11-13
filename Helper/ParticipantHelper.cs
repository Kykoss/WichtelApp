using System.Collections.Generic;

namespace WichtelApp.Helper
{
    public static class ParticipantHelper
    {
        public static List<Wichtel> GetParticipants()
        {
            var kara = new Wichtel("Kara", "Schmich", "h@test.de");
            var robin = new Wichtel("Robin", "Olde Meule", "h@test.de");
            var lukas = new Wichtel("Lukas", "Wewel", "h@test.de");
            var leon = new Wichtel("Leon", "Campos Ribeiro", "h@test.de");
            var jannik = new Wichtel("Jannik", "Kolthof", "h@test.de");
            var moritz = new Wichtel("Moritz", "Jacobs", "h@test.de");
            var jan = new Wichtel("Jan", "Steinkamp", "h@test.de");
            var ingo = new Wichtel("Ingo", "Wilkosinski", "h@test.de");

            #region LastPartner

            kara.LastReceiver = robin;
            moritz.LastReceiver = jan;

            robin.LastReceiver = lukas;
            ingo.LastReceiver = moritz;

            lukas.LastReceiver = kara;
            leon.LastReceiver = jannik;

            jannik.LastReceiver = ingo;
            jan.LastReceiver = leon;

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
