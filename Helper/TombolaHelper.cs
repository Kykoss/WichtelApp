using System;
using System.Collections.Generic;
using System.Linq;

namespace WichtelApp.Helper
{
    public static class TombolaHelper
    {
        public static Dictionary<Wichtel, Wichtel> GetWichtelDrawing(List<Wichtel> wichtelList)
        {
            var results = new Dictionary<Wichtel, Wichtel>();
            var rnd = new Random();

            foreach (var wichtel in wichtelList)
            {
                var possibleRecievers = wichtelList.Where(x => x != wichtel && x.LastReceiver != wichtel).ToList();
                                
                results.Add(wichtel, possibleRecievers[rnd.Next(possibleRecievers.Count - 1)]);
            }

            return results;
        }

    }
}
