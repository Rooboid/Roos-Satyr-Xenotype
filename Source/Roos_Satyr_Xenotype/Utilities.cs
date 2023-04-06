
using System.Collections.Generic;
using Verse;

namespace Roos_Satyr_Xenotype
{
    internal class Utilities
    {
        public static List<Pawn> ListPawnsInArea(Map map, IntVec3 startPosition, int maxDistance)
        {
            var pawnList = new List<Pawn>();
            foreach (Pawn pawn in map.mapPawns.AllPawnsSpawned)
            {
                if (pawn.Position.InHorDistOf(startPosition, maxDistance))
                {
                    pawnList.Add(pawn);
                    Log.Message("Pawn: " + pawn.Name + " Added.");
                }
            }
            return pawnList;
        }

        public static void ApplyHediffInArea(Map map, IntVec3 startPosition, int maxApplyDistance, Hediff hediff) 
        {
            var pawnlist = ListPawnsInArea(map, startPosition, maxApplyDistance);
            foreach (Pawn pawn in pawnlist)
            {
                pawn.health.AddHediff(hediff);
                Log.Message("Pawn: " + pawn.Name + " given hediff.");
            }
        }
    }
}
