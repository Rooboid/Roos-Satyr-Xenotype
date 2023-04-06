using RimWorld;
using Verse;

namespace Roos_Satyr_Xenotype
{
    public class RBSF_Deal_With_the_Devil : CompAbilityEffect_Resurrect
    {

        public new RBSF_CompProperties_Deal_With_the_Devil Props
        {
            get
            {
                return (RBSF_CompProperties_Deal_With_the_Devil)this.props;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Log.Message("Target was " + target.ToString());
            var random = Rand.Value;
            Log.Message("Random value was " + random.ToString());
            if (Rand.Value >= Props.chance)
            {
                base.Apply(target, dest);
                Log.Message("Success!");
                return;
            }
            
            target.Pawn.Corpse.Destroy();
            Log.Message("Failure...");
            return;
        }
    }

    public class RBSF_CompProperties_Deal_With_the_Devil : CompProperties_AbilityEffect
    {
        public RBSF_CompProperties_Deal_With_the_Devil()
        {
            this.compClass = typeof(RBSF_Deal_With_the_Devil);
        }
        public float chance = 0.5f;
    }
}
