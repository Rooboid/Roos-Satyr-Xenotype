using HarmonyLib;
using Verse;

namespace Roos_Satyr_Xenotype
{
    [StaticConstructorOnStartup]
    public static class RBSF_Satyr
    {
        static RBSF_Satyr()
        {
            Harmony harmony = new Harmony("rimworld.mod.rooboid.satyr");
            harmony.PatchAll();
            Log.Message("SATYR MOD LOADED.");
        }
    }
}
