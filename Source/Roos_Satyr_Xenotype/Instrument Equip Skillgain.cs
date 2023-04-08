﻿
using Verse;
using HarmonyLib;
using RimWorld;

namespace Roos_Satyr_Xenotype
{

    [HarmonyPatch(typeof(Pawn_EquipmentTracker))]
    [HarmonyPatch(nameof(Pawn_EquipmentTracker.EquipmentTrackerTick))]
    static class Pawn_EquipmentTracker_EquipmentTrackerTick_Patch
    {
        static void Postfix(Pawn ___pawn)
        {
            bool? defContainsClass = ___pawn.equipment?.Primary?.def?.weaponClasses?.Contains(RBSF_DefOf.RBSF_Instrument);
            if (defContainsClass == true)
            {
                if (___pawn.IsHashIntervalTick(250))
                {
                    ___pawn.skills.Learn(SkillDefOf.Artistic, 4);
                }
            }
        }
    }
}
