using RimWorld;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Verse;

namespace Roos_Satyr_Xenotype
{
    public class RBSF_CompAbilityEffect_MelodicHealing : CompAbilityEffect
    {

        public new RBSF_CompProperties_AbilityMelodicHealing Props
        {
            get
            {
                return (RBSF_CompProperties_AbilityMelodicHealing)this.props;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Log.Message("Melodic Sonata Begun");

            Map map = this.parent.pawn.Map;
            var radius = Props.radius;
            var pawnPos = this.parent.pawn.Position;
            Hediff hediff = new Hediff();
            hediff.def = RBSF_DefOf.RBSF_HeardHealing;

            base.Apply(target, dest);

            Utilities.ApplyHediffInArea(map, pawnPos, radius, hediff);
            
        }

    }

    public class RBSF_CompProperties_AbilityMelodicHealing : CompProperties_AbilityEffect
    {
        public RBSF_CompProperties_AbilityMelodicHealing()
        {
            Log.Message("properties loaded.");
            this.compClass = typeof(RBSF_CompAbilityEffect_MelodicHealing);
        }
        public int radius = 6;
    }
}
