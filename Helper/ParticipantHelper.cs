﻿using System.Collections.Generic;

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
            var moritz = new Wichtel("Moritz Benjamin", "Jacobs", "h@test.de");
            var jan = new Wichtel("Jan", "Steinkamp", "h@test.de");
            var ingo = new Wichtel("Ingo", "Wilkosinski", "h@test.de");

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
