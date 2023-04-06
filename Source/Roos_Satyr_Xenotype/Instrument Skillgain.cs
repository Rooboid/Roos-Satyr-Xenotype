
using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace Roos_Satyr_Xenotype
{
    public class RBSF_Comp_SkillGainWhenEquipped : CompEquippable
    {

        public RBSF_CompProperties_SkillGainWhenEquipped Props
        {
            get
            {
                return (RBSF_CompProperties_SkillGainWhenEquipped)this.props;
            }
        }


        public override void CompTick()
        {
            Log.Message("We are tickin");
            base.CompTick();
            this.GainSkill();
        }
        
        public void GainSkill()
        {
            ThingWithComps parent = this.parent;

            Pawn_EquipmentTracker pawn_EquipmentTracker = parent.ParentHolder as Pawn_EquipmentTracker;
            if (pawn_EquipmentTracker.pawn == null)
            {
                return;
            }

            var pawn = pawn_EquipmentTracker.pawn;

            if (pawn != null && pawn.IsFreeColonist)
            {
                pawn.skills.Learn(SkillDefOf.Artistic, 100);
                Log.Message("We are learning!");
            }
            return;
        }
    }

    public class RBSF_CompProperties_SkillGainWhenEquipped : CompProperties
    {
        public RBSF_CompProperties_SkillGainWhenEquipped()
        {
            this.compClass = typeof(RBSF_Comp_SkillGainWhenEquipped);
            Log.Message("Loaded musical comp properties");
        }
        
    }

}
