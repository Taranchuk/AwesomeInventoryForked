// <copyright file="AddPickupOption.cs" company="Zizhen Li">
// Copyright (c) 2019 - 2020 Zizhen Li. All rights reserved.
// Licensed under the LGPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Reflection;
using AwesomeInventory.UI;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace AwesomeInventory.HarmonyPatches
{
    [StaticConstructorOnStartup]
    public static class RPG_Inventory_Patch
    {
        static RPG_Inventory_Patch()
        {
            MethodInfo original = AccessTools.Method("Sandy_Detailed_RPG_GearTab:FillTab");
            if (original != null)
            {
                MethodInfo postfix = AccessTools.Method(typeof(RPG_Inventory_Patch), "Postfix");
                Utility.Harmony.Patch(original, null, new HarmonyMethod(postfix));
            }
        }

        public static Dictionary<Pawn, VanillaGearTabWorker> workers = new Dictionary<Pawn, VanillaGearTabWorker>();
        public static void Postfix(ITab_Pawn_Gear __instance)
        {
            if (!workers.TryGetValue(__instance.SelPawnForGear, out var worker))
            {
                workers[__instance.SelPawnForGear] = worker = new VanillaGearTabWorker(__instance);
            }
            var rect = new Rect(0f, 20f, __instance.size.x, __instance.size.y - 20f).ContractedBy(10f);
            worker.DrawMini(__instance.SelPawnForGear, rect, true);
        }
    }

    /// <summary>
    /// Add pick up option to context menu when right click things on the ground.
    /// </summary>
    [StaticConstructorOnStartup]
    public static class AddPickupOption
    {
        static AddPickupOption()
        {
            MethodInfo original = AccessTools.Method(typeof(FloatMenuMakerMap), "AddHumanlikeOrders");
            MethodInfo postfix = AccessTools.Method(typeof(AddPickupOption), "Postfix");
            Utility.Harmony.Patch(original, null, new HarmonyMethod(postfix));
        }

        /// <summary>
        /// Add pickup option to context menu when right-click on items on map.
        /// </summary>
        /// <param name="clickPos"> Position of the mouse when right-click. </param>
        /// <param name="pawn"> Currently focused pawn. </param>
        /// <param name="opts"> Options displayed in context menu. </param>
        public static void Postfix(Vector3 clickPos, Pawn pawn, List<FloatMenuOption> opts)
        {
            ValidateArg.NotNull(pawn, nameof(pawn));
            ValidateArg.NotNull(opts, nameof(opts));

            if (pawn.IsQuestLodger())
                return;

            IntVec3 position = IntVec3.FromVector3(clickPos);
            List<Thing> items = position.GetThingList(pawn.Map);
            if (!PickUpAndHaulUtility.IsActive)
            {
                foreach (Thing item in items)
                {
                    if (item.def.category == ThingCategory.Item)
                    {
                        int count = MassUtility.CountToPickUpUntilOverEncumbered(pawn, item);
                        if (count == 0)
                        {
                            continue;
                        }

                        count = Math.Min(count, item.stackCount);

                        string displayText = UIText.Pickup.Translate(item.LabelNoCount + " x" + count);
                        var option = FloatMenuUtility.DecoratePrioritizedTask(
                            new FloatMenuOption(
                                displayText
                                , () =>
                                {
                                    Job job = JobMaker.MakeJob(JobDefOf.TakeInventory, item);
                                    job.count = count;
                                    job.checkEncumbrance = true;
                                    pawn.jobs.TryTakeOrderedJob(job);
                                })
                            , pawn
                            , item);
                        opts.Add(option);
                    }
                }
            }
        }
    }
}
