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
            if(Rand.Chance(Props.chance) == true)
            {
                base.Apply(target, dest);
                return;
            }

            FireUtility.TryAttachFire(target.Thing, 5);
            FireUtility.TryAttachFire(dest.Thing, 5);
            target.Pawn.Destroy();
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
