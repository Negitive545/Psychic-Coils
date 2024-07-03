using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using VREAndroids;
using HarmonyLib;
using UnityEngine;

namespace Psychic_Coiling_VRE_Addon
{
    [HarmonyPatch(typeof(Pawn_PsychicEntropyTracker), "PsychicEntropyTrackerTick")]
    public class EntropyTickPatch
    {
        public const float secsPerTick = 0.0166666675F;
        [HarmonyPrefix]
        public static bool EntropyToCoilStress(Pawn_PsychicEntropyTracker __instance, float ___currentEntropy, Pawn ___pawn)
        {
            if (!___pawn.IsAndroid())
            {
                return true;
            }
            if (___currentEntropy > float.Epsilon)
            {
                ___currentEntropy = Mathf.Max(___currentEntropy - secsPerTick * __instance.RecoveryRate, 0f);
            }
            if (___currentEntropy > float.Epsilon && !___pawn.health.hediffSet.HasHediff(VREAPC_InternalDefs.VREAPC_PsychicCoilStress))
            {
                ___pawn.health.AddHediff(VREAPC_InternalDefs.VREAPC_PsychicCoilStress);
            }
            return true;
        }
    }
}
