using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmongUs.Matchmaking;
using HarmonyLib;

namespace Reactor.Networking.Patches
{
    internal class ModRegistrationPatch
    {
        [HarmonyPatch(typeof(CurrentModRegistration), nameof(CurrentModRegistration.UpdateFilterSetWithModRegistrationSettings))]
        public static class CurrentModRegistrationPatch
        {
            public static void Prefix(GameFilterSet filterSet)
            {
                for (int i = filterSet.Filters.Count - 1; i >= 0; i--)
                {
                    if (filterSet.Filters[i].Key == "mod")
                    {
                        filterSet.Filters.RemoveAt(i);
                    }
                }
            }
        }
    }
}
