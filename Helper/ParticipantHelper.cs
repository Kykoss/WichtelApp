using System.Collections.Generic;

namespace WichtelApp.Helper
{
    public static class ParticipantHelper
    {
        public static List<Wichtel> GetParticipants()
        {
            var kara = new Wichtel("Kara", "Schmich", string.Empty);
            var robin = new Wichtel("Robin", "Olde Meule", string.Empty);
            var lukas = new Wichtel("Lukas", "Wewel", string.Empty);
            var leon = new Wichtel("Leon", "Campos Ribeiro", string.Empty);
            var jannik = new Wichtel("Jannik", "Kolthof", string.Empty);
            var moritz = new Wichtel("Moritz", "Jacobs", string.Empty);
            var jan = new Wichtel("Jan", "Steinkamp", string.Empty);
            var ingo = new Wichtel("Ingo", "Wilkosinski", string.Empty);

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
