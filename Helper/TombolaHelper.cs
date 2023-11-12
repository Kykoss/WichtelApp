using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace WichtelApp.Helper
{
    public static class TombolaHelper
    {
        public static Dictionary<Wichtel, Wichtel> GetWichtelDrawing(List<Wichtel> wichtelList)
        {
            Dictionary<Wichtel, Wichtel>? drawReusults = null;

            while (drawReusults == null)
            {
                drawReusults = TombolaHelper.TryDrawing(wichtelList);
            }

            return drawReusults;
        }

        private static Dictionary<Wichtel, Wichtel>? TryDrawing(List<Wichtel> wichtelList)
        {
            var openReceivers = new List<Wichtel>(wichtelList);
            var results = new Dictionary<Wichtel, Wichtel>();
            var rnd = new Random();

            TombolaHelper.ShuffleWichtelList(wichtelList);
            foreach (var wichtel in wichtelList)
            {
                var possibleRecievers = openReceivers.Where(x => x != wichtel && x.LastReceiver != wichtel).ToList();
                TombolaHelper.ShuffleWichtelList(possibleRecievers);

                // Possible if only the wichtel itself and/or it's last partnet is open.
                if (!possibleRecievers.Any()) 
                {
                    return null;
                }

                var receiver = possibleRecievers[rnd.Next(possibleRecievers.Count - 1)];

                results.Add(wichtel, receiver);
                openReceivers.Remove(receiver);
            }

            return results;
        }

        public static bool IsTombolaResultOk(List<Wichtel> wichtelList, Dictionary<Wichtel, Wichtel> results)
        {
            foreach (var wichtel in wichtelList)
            {
                // Every wichtel needs to gift exactly ones.
                if (results.Keys.SingleOrDefault(x => x == wichtel) == default)
                {
                    return false;
                }

                // Every wichtel needs to receive exactly ones.
                if (results.Values.SingleOrDefault(x => x == wichtel) == default)
                {
                    return false;
                }

                // Every wichtel is not allowed to gift the same person as last year.
                if (results[wichtel] == wichtel.LastReceiver)
                {
                    return false;
                }

                // Every wichtel is not allowed to gift themselfes.
                if (results[wichtel] == wichtel)
                {
                    return false;
                }
            }

            return true;
        }

        private static void ShuffleWichtelList(List<Wichtel> wichtelList)
        {
            var rnd = new Random();

            int n = wichtelList.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                var value = wichtelList[k];
                wichtelList[k] = wichtelList[n];
                wichtelList[n] = value;
            };
        }
    }
}
