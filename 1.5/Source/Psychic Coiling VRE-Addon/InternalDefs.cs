using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace Psychic_Coiling_VRE_Addon
{
    [DefOf]
    public static class InternalDefs
    {
        public static GeneDef VREA_Addon_PsychicCoils;
        public static HediffDef VREAPC_PsychicCoilStress;

        static InternalDefs()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefs));
        }
    }
}
