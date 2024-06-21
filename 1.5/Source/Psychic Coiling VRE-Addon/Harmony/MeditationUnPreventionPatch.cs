using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;
using VREAndroids;

namespace Psychic_Coiling_VRE_Addon
{
    [HarmonyPatch(typeof(MeditationFocusTypeAvailabilityCache), "PawnCanUseInt")]
    public static class MeditationTypeAvailabilityUnPreventionPatch
    {
        public static void Postfix(ref bool __result, Pawn p)
        {
            if (p.HasActiveGene(VREAndroids.VREA_DefOf.VREA_JoyDisabled) && !(p.HasActiveGene(InternalDefs.VREA_Addon_PsychicCoils)))
            {
                __result = false;
            }
        }
    }

    [HarmonyPatch(typeof(MeditationUtility), "CanMeditateNow")]
    public static class MeditationJobgiverUnPreventionPatch
    {
        public static void PostFix(ref bool __result, Pawn pawn)
        {
            if (pawn.HasActiveGene(VREAndroids.VREA_DefOf.VREA_JoyDisabled) && !(pawn.HasActiveGene(InternalDefs.VREA_Addon_PsychicCoils)))
            {
                __result = false;
            }
        }
    }
}
