using System.Collections.Generic;

namespace WichtelApp.Helper
{
    public static class ParticipantHelper
    {
        public static List<Wichtel> GetParticipants()
        {
            var kara = new Wichtel("Kara", "Schmich", "kara-schmich@outlook.de");
            var robin = new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com");
            var lukas = new Wichtel("Lukas", "Wewel", "lukaswewel@gmx.de");
            var leon = new Wichtel("Leon Campos", "Ribeiro", "raiva97@yahoo.de");
            var jannik = new Wichtel("Jannik", "Kolthof", "jannik.kolthof@hs-osnabrueck.de");
            var moritz = new Wichtel("Moritz Benjamin", "Jacobs", "moritzjacobs@protonmail.com");
            var jan = new Wichtel("Jan", "Steinkamp", "steinkampjan@gmail.com");
            var ingo = new Wichtel("Ingo", "Wilkosinski", "ingo.wilkosinski@gmx.de");

            kara.LastReciever = moritz;
            moritz.LastReciever = kara;

            robin.LastReciever = ingo;
            ingo.LastReciever = robin;

            lukas.LastReciever = leon;
            leon.LastReciever = lukas;

            jannik.LastReciever = jan;
            jan.LastReciever = jannik;

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
