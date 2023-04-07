using RimWorld;
using Verse;

namespace Roos_Satyr_Xenotype
{
    public class RBSF_CompAbilityEffect_MelodicHealing : CompAbilityEffect
    {

        public new RBSF_CompProperties_AbilityMelodicHealing Props
        {
            get
            {
                return this.props as RBSF_CompProperties_AbilityMelodicHealing;
            }
        }

        public override void CompTick()
        {
            if (!this.parent.pawn.IsHashIntervalTick(100))
                return;

            Hediff hediff = new Hediff
            {
                def = RBSF_DefOf.RBSF_HeardHealing,
                Severity = 1
            };

            Utilities.ApplySong(this.parent.pawn, Props.radius, hediff);

            base.CompTick();
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

