// <copyright file="JobGiver_TakeAndEquip_Patch.cs" company="Zizhen Li">
// Copyright (c) 2019 - 2020 Zizhen Li. All rights reserved.
// Licensed under the LGPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Reflection;
using AwesomeInventory.UI;
using CombatExtended;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace AwesomeInventory.HarmonyPatches
{
    [StaticConstructorOnStartup]
    public static class RPG_Inventory_CEPatch
    {
        static RPG_Inventory_CEPatch()
        {
            MethodInfo original = AccessTools.Method("Sandy_Detailed_RPG_GearTab:FillTab");
            if (original != null)
            {
                MethodInfo postfix = AccessTools.Method(typeof(RPG_Inventory_CEPatch), "Postfix");
                Utility.Harmony.Patch(original, null, new HarmonyMethod(postfix));
            }
        }

        public static Dictionary<Pawn, CEDrawGearTabWorker> workers = new Dictionary<Pawn, CEDrawGearTabWorker>();
        public static void Postfix(ITab_Pawn_Gear __instance)
        {
            if (!workers.TryGetValue(__instance.SelPawnForGear, out var worker))
            {
                workers[__instance.SelPawnForGear] = worker = new CEDrawGearTabWorker(__instance);
            }
            var rect = new Rect(0f, 20f, __instance.size.x, __instance.size.y - 20f).ContractedBy(10f);
            worker.DrawMini(__instance.SelPawnForGear, rect, true);
        }
    }
    /// <summary>
    /// Skip this job when pawn has a loadout.
    /// </summary>
    [StaticConstructorOnStartup]
    public static class JobGiver_TakeAndEquip_Patch
    {
        static JobGiver_TakeAndEquip_Patch()
        {
            MethodInfo original = typeof(JobGiver_TakeAndEquip).GetMethod("GetPriorityWork", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo prefix = typeof(JobGiver_TakeAndEquip_Patch).GetMethod("Prefix", BindingFlags.Static | BindingFlags.Public);
            Utility.Harmony.Patch(original, prefix: new HarmonyMethod(prefix));
        }

        /// <summary>
        /// If a pawn has a loadout, return priority 0.
        /// </summary>
        /// <param name="pawn"> Selected pawn. </param>
        /// <param name="__result"> Result returned by the original method. </param>
        /// <returns> If true, continue to execute. </returns>
        public static bool Prefix(Pawn pawn, ref object __result)
        {
            if (pawn.UseLoadout(out _))
            {
                __result = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    [StaticConstructorOnStartup]
    public static class JobGiver_UpdateLoadout_Patch
    {
        static JobGiver_UpdateLoadout_Patch()
        {
            MethodInfo original = typeof(JobGiver_UpdateLoadout).GetMethod("TryGiveJob", AccessTools.all);
            MethodInfo prefix = typeof(JobGiver_UpdateLoadout_Patch).GetMethod("Prefix", AccessTools.all);
            Utility.Harmony.Patch(original, prefix: new HarmonyMethod(prefix));
        }

        /// <summary>
        /// If a pawn has a loadout, return null job.
        /// </summary>
        /// <param name="pawn"> Selected pawn. </param>
        /// <param name="__result"> Result returned by the original method. </param>
        /// <returns> If true, continue to execute. </returns>
        public static bool Prefix(Pawn pawn, ref Job __result)
        {
            if (pawn.UseLoadout(out _))
            {
                __result = null;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
