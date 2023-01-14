// <copyright file="SimpleSidearmUtility.cs" company="Zizhen Li">
// Copyright (c) 2019 - 2020 Zizhen Li. All rights reserved.
// Licensed under the LGPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using HarmonyLib;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Verse;
namespace AwesomeInventory
{
    [StaticConstructorOnStartup]
    public static class SimpleSidearmUtility
    {
        private static readonly string _packageID = "PeteTimesSix.SimpleSidearms".ToLowerInvariant();
        private static readonly Type _compSidearmMemory;
        private static readonly PropertyInfo _pawnMemory;
        private static readonly MethodInfo _toThingDefStuffDefPair;
        private static readonly MethodInfo _forgetSidearmMemory;
        static SimpleSidearmUtility()
        {
            IsActive = LoadedModManager.RunningModsListForReading.Any(m => m.PackageId == _packageID);
            if (IsActive)
            {
                _compSidearmMemory = AccessTools.TypeByName("SimpleSidearms.rimworld.CompSidearmMemory");
                _pawnMemory = _compSidearmMemory.GetProperty("RememberedWeapons", BindingFlags.Public | BindingFlags.Instance);
                _toThingDefStuffDefPair = AccessTools.TypeByName("PeteTimesSix.SimpleSidearms.Extensions")
                    .GetMethod("toThingDefStuffDefPair", BindingFlags.Static | BindingFlags.Public);
                _forgetSidearmMemory = _compSidearmMemory.GetMethod("ForgetSidearmMemory", BindingFlags.Public | BindingFlags.Instance);
            }
        }

        /// <summary>
        /// Gets a value indicating whether simple sidearm is actived in this save.
        /// </summary>
        public static bool IsActive { get; private set; }

        /// <summary>
        /// Check if <paramref name="thing"/> is in Simple Sidearms's memory.
        /// </summary>
        /// <param name="pawn"> Pawn who has <paramref name="thing"/>. </param>
        /// <param name="thing"> Thing to check. </param>
        /// <returns> True, if <paramref name="thing"/> is in SS memory. </returns>
        public static bool InMemory(Pawn pawn, Thing thing)
        {
            ValidateArg.NotNull(pawn, nameof(pawn));

            ThingComp comp = pawn.AllComps.FirstOrDefault(t => t.GetType() == _compSidearmMemory);
            if (comp != null)
            {
                IList memory = (IList)_pawnMemory.GetValue(comp);
                return memory.Contains(_toThingDefStuffDefPair.Invoke(null, new[] { thing }));
            }

            return false;
        }

        /// <summary>
        /// Remove weaspon from sidearm memory.
        /// </summary>
        /// <param name="pawn"> Pawn who carries <paramref name="thing"/>. </param>
        /// <param name="thing"> Weapon to remove. </param>
        public static void RemoveWeaponFromMemory(Pawn pawn, Thing thing)
        {
            ValidateArg.NotNull(pawn, nameof(pawn));

            ThingComp comp = pawn.AllComps.FirstOrDefault(t => t.GetType() == _compSidearmMemory);
            if (comp != null)
            {
                _forgetSidearmMemory.Invoke(comp, new[] { _toThingDefStuffDefPair.Invoke(null, new[] { thing }) });
            }
        }
    }
}
