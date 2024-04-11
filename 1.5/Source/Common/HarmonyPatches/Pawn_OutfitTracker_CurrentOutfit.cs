// <copyright file="Pawn_OutfitTracker_CurrentApparelPolicy.cs" company="Zizhen Li">
// Copyright (c) 2019 - 2020 Zizhen Li. All rights reserved.
// Licensed under the LGPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AwesomeInventory.Loadout;
using HarmonyLib;
using RimWorld;
using Verse;

namespace AwesomeInventory.HarmonyPatches
{
    /// <summary>
    /// Patch into the setter of <see cref="Pawn_OutfitTracker.CurrentApparelPolicy"/>, so to synchronize with AILoadout.
    /// </summary>
    [StaticConstructorOnStartup]
    public static class Pawn_OutfitTracker_CurrentApparelPolicy
    {
        static Pawn_OutfitTracker_CurrentApparelPolicy()
        {
            MethodInfo original = AccessTools.Property(typeof(Pawn_OutfitTracker), "CurrentApparelPolicy").GetSetMethod();
            MethodInfo postfix = AccessTools.Method(typeof(Pawn_OutfitTracker_CurrentApparelPolicy), "Postfix");
            Utility.Harmony.Patch(original, null, new HarmonyMethod(postfix));
        }

        /// <summary>
        /// Patch into the setter of <see cref="Pawn_OutfitTracker.CurrentApparelPolicy"/>, so to synchronize with AILoadout.
        /// </summary>
        /// <param name="value"> New loadout. </param>
        /// <param name="__instance"> Instance of <see cref="Pawn_OutfitTracker"/>. </param>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Postfix patch")]
        public static void Postfix(ApparelPolicy value, Pawn_OutfitTracker __instance)
        {
            if (__instance?.pawn != null)
            {
                if (value is AwesomeInventoryLoadout loadout)
                    __instance.pawn.SetLoadout(loadout);
                else
                    __instance.pawn.GetComp<CompAwesomeInventoryLoadout>()?.RemoveLoadout();
            }
        }
    }
}
