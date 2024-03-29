﻿// <copyright file="ThinkNode_AwesomeInventory_Core.cs" company="Zizhen Li">
// Copyright (c) 2019 - 2020 Zizhen Li. All rights reserved.
// Licensed under the LGPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using RimWorld;
using Verse;

namespace AwesomeInventory.Loadout
{
    /// <summary>
    /// Check if inventory needs to restock.
    /// </summary>
    public class ThinkNode_AwesomeInventory_Core : ThinkNode_ConditionalColonist
    {
        /// <summary>
        /// Check if conditions are met to take actions.
        /// </summary>
        /// <param name="pawn"> Pawn to check. </param>
        /// <returns> Returns true if <paramref name="pawn"/>'s inventory needs to restock. </returns>
        public override bool Satisfied(Pawn pawn)
        {
            ValidateArg.NotNull(pawn, nameof(pawn));

            bool needRestock = base.Satisfied(pawn)
                            && ((pawn.TryGetComp<CompAwesomeInventoryLoadout>()?.NeedRestock ?? false)
                                ||
                                (pawn.equipment.Primary == null && AwesomeInventoryMod.Settings.AutoEquipWeapon));
            return needRestock;
        }
    }
}
