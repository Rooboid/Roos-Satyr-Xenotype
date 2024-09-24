using RimWorld;
using Verse;
using Verse.Sound;

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

            if (Rand.Chance(Props.chance))
            {
                //Log.Message("Success!");
                base.Apply(target, dest);
                RBSF_DefOf.RBSF_MelodicElegySucceed.PlayOneShot(new TargetInfo(this.parent.pawn.Position, this.parent.pawn.Map, false));
                Find.LetterStack.ReceiveLetter("Elegy Success", parent.pawn.Name.ToStringShort + "'s melodic elegy was breathtaking, beautiful and sincere. The golden fiddle evaporated into a shining light, and the corpse has been resurrected.\n\nIt will be a long time before " + parent.pawn.Name.ToStringShort + " can summon up the courage to play such a challenging melody again.", LetterDefOf.PositiveEvent);
                return;
            }

            //Log.Message("Failure...");
            float radius = 0.5f;
            GenExplosion.DoExplosion(target.Thing.Position, this.parent.pawn.MapHeld, radius, DamageDefOf.Flame, this.parent.pawn);
            GenExplosion.DoExplosion(this.parent.pawn.Position, this.parent.pawn.MapHeld, radius, DamageDefOf.Flame, this.parent.pawn);
            RBSF_DefOf.RBSF_MelodicElegyFail.PlayOneShot(new TargetInfo(this.parent.pawn.Position, this.parent.pawn.Map, false));
            Find.LetterStack.ReceiveLetter("Elegy Failed", parent.pawn.Name.ToStringShort + "'s melodic elegy failed to resurrect the corpse, setting it on fire.\n\nIt will be a long time before " + parent.pawn.Name.ToStringShort + " dares to play such a harrowing melody again...", LetterDefOf.NegativeEvent);
            return;
        }
    }

    public class RBSF_CompProperties_Deal_With_the_Devil : CompProperties_AbilityEffect
    {
        public RBSF_CompProperties_Deal_With_the_Devil()
        {
            this.compClass = typeof(RBSF_Deal_With_the_Devil);
        }
        public float chance = 0.65f;
    }
}
